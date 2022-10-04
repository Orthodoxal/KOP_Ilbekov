using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestComponents
{
    [Serializable]
    public class Pet
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Description { get; set; }
        public override string ToString()
        {
            return string.Format("Age: {0}, Name: {1}", Age, Name);
        }
    }
}
