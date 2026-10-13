namespace TemplatePlugin
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TemplatePluginAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public TemplatePluginAttribute(string name, string desc)
        {
            Name = name;
            Description = desc;
        }
    }
}
