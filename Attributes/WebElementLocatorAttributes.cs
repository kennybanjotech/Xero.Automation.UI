using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Automation.Capsule.UI.WebElementObjects
{
    public enum LocatorTypeEnum
    {
        Id,
        Xpath,
        Css,
        PartialLinkText,
        Name,
        ClassName

    }
    [AttributeUsage(AttributeTargets.Field)]
    class WebElementLocatorAttributes : Attribute
    {
        public By ByLocator { get; set; }
        public string Locator { get; set; }

        public WebElementLocatorAttributes(LocatorTypeEnum locatorType, string locator)
        {
            this.ParseByDetail(locatorType, locator);
        }
        public void ParseByDetail(LocatorTypeEnum locatorType, string locator)
        {
            By parseBy = null;
            switch (locatorType)
            {
                case LocatorTypeEnum.Id:
                    parseBy = By.Id(locator);
                    break;
                case LocatorTypeEnum.ClassName:
                    parseBy = By.ClassName(locator);
                    break;
                case LocatorTypeEnum.Name:
                    parseBy = By.Name(locator);
                    break;
                case LocatorTypeEnum.Css:
                    parseBy = By.CssSelector(locator);
                    break;
                case LocatorTypeEnum.PartialLinkText:
                    parseBy= By.PartialLinkText(locator);
                    break;
                case LocatorTypeEnum.Xpath:
                    parseBy = By.XPath(locator);
                    break;
                default:
                    throw new InvalidOperationException("Invalid LocatorTypeEnum parsed in to ");
            }

            this.ByLocator = parseBy;
        }
    }
}
