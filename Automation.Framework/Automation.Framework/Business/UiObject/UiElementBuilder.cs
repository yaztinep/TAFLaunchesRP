using Automation.Framework.Core.WebAbstractions;
using System.Collections.Generic;

namespace Automation.Framework.Business.UiObject
{
    public class UiElementBuilder : IUiElementBuilder
    {
        IUiElement _iuiElement;
        IList<string> objectMaps;
        public UiElementBuilder(IUiElement iuiElement)
        {
            _iuiElement = iuiElement;
        }

        public UiElementBuilder BuildFromNames(params string[] locators)
        {
            objectMaps = new List<string>();
            foreach (string locator in locators)
            {
                objectMaps.Add(locator);
            }

            _iuiElement.BuildFromElements(objectMaps);
            return this;
        }

        public IUiElement Build()
        {
            return _iuiElement;
        }

    }
}
