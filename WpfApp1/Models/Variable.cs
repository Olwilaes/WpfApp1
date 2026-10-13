using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Models
{
    public class Variable
    {
        public bool IsSelected { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public object Value { get; set; }

        public Variable(string name, Type type, object value)
        {
            Name = name;
            Type = type;
            IsSelected = false;
            Value = value;
        }
    }
}
