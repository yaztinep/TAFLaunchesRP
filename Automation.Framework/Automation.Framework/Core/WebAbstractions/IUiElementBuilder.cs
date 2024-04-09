using Automation.Framework.Business.UiObject;

namespace Automation.Framework.Core.WebAbstractions
{
    public interface IUiElementBuilder
    {
        UiElementBuilder BuildFromNames(params string[] locators);
        IUiElement Build();
    }
}
