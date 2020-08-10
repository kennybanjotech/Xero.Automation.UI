using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Capsule.UI.WebElementObjects;
using OpenQA.Selenium;
using Xero.Automation.UI.Attributes;

//using Xero.Automation.UI.Attributes;

namespace Automation.Capsule.UI.WebElementObjects.WebElements
{
    public class PageObjectBase
    {
        public PageObjectBase(IWebDriver driver, bool useWaitForAjax = true)
        {
            this.Driver = driver;

            this.InitialiseFields();

            this.WaitForAjax = useWaitForAjax;
        }

        public string BaseUrl;

        public IWebDriver Driver { get; private set; }

        protected string PageUrl { get; set; }

        public virtual string GetPageUrlSuffix()
        {
            return string.Empty;
        }

        public virtual string GetPageRoute()
        {
            return this.GetPageUrlSuffix();
        }

        public bool WaitForAjax { get; private set; }

        public void Refresh()
        {
            this.Driver.Navigate().Refresh();
        }

        private void InitialiseFields()
        {
            var fields = this.GetType().GetFields();

            foreach (var field in fields)
            {
                var webElementLocatorAttribute = FieldAttributeHelper<WebElementLocatorAttributes>.ReturnAttribute(field);

                var dataBindingAttribute = FieldAttributeHelper<DataBindingAttribute>.ReturnAttribute(field);

                var viewModelBindingAttribute = FieldAttributeHelper<ViewModelBindingAttribute>.ReturnAttribute(field);

                //Skip setup as no locator attributes found
                if (webElementLocatorAttribute.Count <= 0) continue;

                var constructor = field.FieldType.GetConstructor(new Type[] { });

                var instance = constructor?.Invoke(new object[] { });

                if (instance is WebElementObjectBase)
                {
                    var controlBase = instance as WebElementObjectBase;

                    controlBase.ByLocator = webElementLocatorAttribute[0].ByLocator;

                    controlBase.Locator = webElementLocatorAttribute[0].Locator;

                    controlBase.Driver = this.Driver;

                    controlBase.UseWaitForAjax = this.WaitForAjax;

                    controlBase.Url = this.BaseUrl + this.PageUrl;

                    controlBase.BindedDataAttribute = dataBindingAttribute.Count <= 0 ? null : dataBindingAttribute[0].Value;

                    controlBase.ViewModelBinding = viewModelBindingAttribute.Count <= 0 ? null : viewModelBindingAttribute[0].Value;
                }

                field.SetValue(this, instance);
            }
        }
    }
}
