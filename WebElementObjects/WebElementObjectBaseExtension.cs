using System;
using System.Text;
using System.Threading.Tasks;
using Automation.Capsule.UI.WebElementObjects;
using OpenQA.Selenium;
using Xero.Automation.UI.Attributes;

namespace CapsuleCRMUI.WebElementObjects
{
    public static class WebElementObjectBaseExtension
    {
        public static void InitialiseWebElements(this WebElementObjectBase webElementObject, IWebElement rootElement)
        {
            var fields = webElementObject.GetType().GetFields();

            foreach (var field in fields)
            {
                var webElementLocatorAttribute = FieldAttributeHelper<WebElementLocatorAttributes>.ReturnAttribute(
                    field);

                var dataBindingAttribute = FieldAttributeHelper<DataBindingAttribute>.ReturnAttribute(field);

                var viewModelBindingAttribute = FieldAttributeHelper<ViewModelBindingAttribute>.ReturnAttribute(field);

                //Skip setup as no locator attributes found
                if (webElementLocatorAttribute.Count <= 0) continue;

                var constructor = field.FieldType.GetConstructor(new Type[] { });

                if (constructor == null) continue;
                var instance = constructor.Invoke(new object[] { });

                if (instance is WebElementObjectBase)
                {
                    var controlBase = instance as WebElementObjectBase;

                    controlBase.ByLocator = webElementLocatorAttribute[0].ByLocator;

                    controlBase.Locator = webElementLocatorAttribute[0].Locator;

                    controlBase.Driver = webElementObject.Driver;

                    controlBase.RootElement = rootElement;

                    controlBase.BindedDataAttribute = dataBindingAttribute.Count <= 0
                        ? null
                        : dataBindingAttribute[0].Value;

                    controlBase.ViewModelBinding = viewModelBindingAttribute.Count <= 0
                        ? null
                        : viewModelBindingAttribute[0].Value;

                    controlBase.InitialiseWebElements(rootElement);
                }

                field.SetValue(webElementObject, instance);
            }
        }
    }
}
