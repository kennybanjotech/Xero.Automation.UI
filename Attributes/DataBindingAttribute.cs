using System;

namespace Xero.Automation.UI.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DataBindingAttribute : Attribute
    {
        public string Value { get; set; }

        public DataBindingAttribute(string dataBindingAttribute)
        {
            this.Value = dataBindingAttribute;
        }
    }
}