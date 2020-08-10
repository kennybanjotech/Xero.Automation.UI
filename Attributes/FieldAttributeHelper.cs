using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Automation.Capsule.UI.WebElementObjects
{
    public class FieldAttributeHelper<TAttributeType>
    {
        public static List<TAttributeType> ReturnAttribute(FieldInfo field)
        {
            return field
                .GetCustomAttributes(typeof(TAttributeType), true)
                .Cast<TAttributeType>()
                .ToList();

        }
    }
}