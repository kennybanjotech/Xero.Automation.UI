using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Capsule.UI.WebElementObjects.Interfaces
{
    public interface ITypable
    {
        void EnterText(string text);
        string GetText();
    }
}
