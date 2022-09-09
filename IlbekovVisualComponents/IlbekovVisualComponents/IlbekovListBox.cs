using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IlbekovVisualComponents
{
    public partial class IlbekovListBox : UserControl
    {
        private string templateString = "";
        private char symbolStart = '{';
        private char symbolEnd = '}';
        private object? data;
        public IlbekovListBox()
        {
            InitializeComponent();
        }

        public int SelectedIndexData
        {
            set
            {
                if (value >= 0 && value < listBox.Items.Count)
                    listBox.SelectedIndex = value;
            }
            get
            {
                return listBox.SelectedIndex;
            }
        }

        public void SetTemplate(string templateString, char symbolStart, char symbolEnd)
        {
            this.templateString = templateString;
            this.symbolStart = symbolStart;
            this.symbolEnd = symbolEnd;
        }

        public void Add<T>(T someObject)
        {
            if (data == null)
            {
                data = new List<T>();
            }
            List<T>? listData = data as List<T>;
            if (listData != null && someObject != null)
            {
                var type = typeof(T);
                string result = string.Empty;
                for (int index = 0; index < templateString.Length; index++)
                {
                    if (templateString[index] == symbolStart)
                    {
                        for (int indexEnd = index + 1; indexEnd < templateString.Length; indexEnd++)
                        {
                            if (templateString[indexEnd] == symbolEnd)
                            {
                                string name = templateString.Substring(index + 1, indexEnd - index - 1);
                                var propInfo = type.GetProperty(name);
                                if (propInfo != null)
                                {
                                    result += propInfo.GetValue(someObject);
                                }
                                index += indexEnd - index;
                                break;
                            }
                        }
                    }
                    else
                    {
                        result += templateString[index];
                    }
                }
                listData.Add(someObject);
                listBox.Items.Add(result);
            }           
        }
        
        public T? GetSI<T>()
        {
            string selectedString = listBox.SelectedItem.ToString();
            if (string.IsNullOrEmpty(selectedString))
                return default(T);

            string separator = "{:}";
            int start = 0;
            int end = 0;
            List<string> propetryNames = new List<string>();
            for (int index = 0; index < templateString.Length; index++)
            {
                if (templateString[index] == symbolStart)
                {
                    end = index;
                    if (start != end)
                        selectedString = selectedString.Replace(templateString.Substring(start, end - start), separator);
                    for (int index2 = index; index2 < templateString.Length; index2++)
                    {
                        if (templateString[index2] == symbolEnd)
                        {
                            propetryNames.Add(templateString.Substring(index + 1, index2 - index - 1));
                            index += index2 - index;
                            start = index + 1;
                            break;
                        }
                    }
                }
            }
            List<string> propertyValues = selectedString.Split(separator).ToList();
            propertyValues.RemoveAll(IsEmptyString);
            if (propertyValues.Count == propetryNames.Count)
            {
                var type = typeof(T);
                T resultObject = (T)Activator.CreateInstance(typeof(T));
                for (int index = 0; index < propetryNames.Count; index++)
                {
                    var propInfo = type.GetProperty(propetryNames[index]);
                    if (propInfo == null)
                    {
                        throw new Exception("Invalid type");
                    }
                    propInfo.SetValue(resultObject, propertyValues[index]);
                }
                return resultObject;
            }
            else
            {
                throw new Exception("Invalid type");
            }

        }

        public T? GetSelectedItem<T>()
        {
            if (data == null)
            {
                return default(T);
            }
            var listData = data as List<T>;
            if (listData == null)
                throw new Exception("Incorrect type");

            if (listBox.SelectedItem == null)
            {
                return default(T);
            }
            else
            {
                return listData[listBox.SelectedIndex];
            }
        }

        private static bool IsEmptyString(string str)
        {
            return str == "";
        }
    }
}
