using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestComponents
{
    class Person
    {
        public Person(string name, int age, string des1, int des2, string des3, string des4)
        {
            Name = name;
            Age = age;
            Des1 = des1;
            Des2 = des2;
            Des3 = des3;
            Des4 = des4;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Des1 { get; set; }
        public int Des2 { get; set; }
        public string Des3 { get; set; }
        public string Des4 { get; set; }
    }
}
