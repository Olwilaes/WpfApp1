using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WpfApp1.Models
{
    public class Method(string name, Type type, MethodInfo methodInfo)
    {
        public string Name { get; set; } = name;
        public Type Type { get; set; } = type;
        public bool IsSelected { get; set; } = false;
        public MethodInfo MethodInfo { get; set; } = methodInfo;
    }
}
