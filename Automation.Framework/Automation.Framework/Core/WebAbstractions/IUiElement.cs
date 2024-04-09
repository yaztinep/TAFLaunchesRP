using System.Collections.Generic;

namespace Automation.Framework.Core.WebAbstractions
{
    public interface IUiElement
    {
        void BuildFromElements(IList<string> locators);
    }
}
