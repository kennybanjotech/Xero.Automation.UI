using System;

namespace Automation.Capsule.UI.WebElementObjects
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ViewModelBindingAttribute : Attribute
    {
        public string Value { get; set; }

        public ViewModelBindingAttribute(string viewModelBindingAttribute)
        {
            this.Value = viewModelBindingAttribute;
        }
    }
}