using ColossalFramework.UI;
using UnityEngine;

namespace RenderIt
{
    public class UIUtils
    {
        public static UIButton CreateButton(string name, UITextureAtlas atlas, string spriteName, string toolTip)
        {
            UIButton button = UIView.GetAView().AddUIComponent(typeof(UIButton)) as UIButton;
            button.name = name;
            button.atlas = atlas;
            button.tooltip = toolTip;

            button.normalBgSprite = null;
            button.hoveredBgSprite = "OptionBaseHovered";
            button.pressedBgSprite = "OptionBasePressed";
            button.disabledBgSprite = "OptionBaseDisabled";

            button.foregroundSpriteMode = UIForegroundSpriteMode.Stretch;
            button.normalFgSprite = spriteName;
            button.hoveredFgSprite = spriteName;
            button.pressedFgSprite = spriteName;
            button.disabledFgSprite = spriteName;

            return button;
        }
    }
}
