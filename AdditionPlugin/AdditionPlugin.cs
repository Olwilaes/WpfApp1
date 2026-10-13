using TemplatePlugin;

namespace AdditionPlugin
{
    [TemplatePluginAttribute("AdditionPlugin", "Allows you to add two numbers.")]
    public class AdditionPlugin
    {
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }
    }
}
