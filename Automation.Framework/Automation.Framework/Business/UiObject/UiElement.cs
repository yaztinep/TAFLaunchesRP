using Automation.Framework.Core.WebAbstractions;
using System.Collections.Generic;

namespace Automation.Framework.Business.UiObject
{
    public class UiElement : IUiElement
    {
        IList<string> _locators;
        IGlobalProperties _iglobalProperties;
        public UiElement(IGlobalProperties iglobalProperties)
        {
            _iglobalProperties = iglobalProperties;
        }

        public void BuildFromElements(IList<string> locators)
        {
            _locators = locators;
        }
    }
}
