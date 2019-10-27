using ColossalFramework.UI;
using UnityEngine;

namespace RenderIt
{
    public class UIUtils
    {
        public static UIFont GetUIFont(string name)
        {
            UIFont[] fonts = Resources.FindObjectsOfTypeAll<UIFont>();

            foreach (UIFont font in fonts)
            {
                if (font.name.CompareTo(name) == 0)
                {
                    return font;
                }
            }

            return null;
        }
        
        public static UIPanel CreatePanel(string name)
        {
            UIPanel panel = UIView.GetAView().AddUIComponent(typeof(UIPanel)) as UIPanel;
            panel.name = name;

            return panel;
        }

        public static UIPanel CreatePanel(UIComponent parent, string name)
        {
            UIPanel panel = parent.AddUIComponent<UIPanel>();
            panel.name = name;

            return panel;
        }

        public static UIScrollablePanel CreateScrollablePanel(UIComponent parent, string name)
        {
            UIScrollablePanel scrollablePanel = parent.AddUIComponent<UIScrollablePanel>();
            scrollablePanel.name = name;

            return scrollablePanel;
        }

        public static UIScrollbar CreateScrollbar(UIComponent parent, string name)
        {
            UIScrollbar scrollbar = parent.AddUIComponent<UIScrollbar>();
            scrollbar.name = name;

            return scrollbar;
        }

        public static UISlicedSprite CreateSlicedSprite(UIComponent parent, string name)
        {
            UISlicedSprite slicedSprite = parent.AddUIComponent<UISlicedSprite>();
            slicedSprite.name = name;

            return slicedSprite;
        }

        public static UILabel CreateTitle(UIComponent parent, string name, string text)
        {
            UILabel label = parent.AddUIComponent<UILabel>();
            label.name = name;
            label.text = text;
            label.font = GetUIFont("OpenSans-Bold");
            label.autoSize = false;
            label.height = 20f;
            label.verticalAlignment = UIVerticalAlignment.Top;
            label.relativePosition = new Vector3(0f, 0f);

            return label;
        }

        public static UILabel CreateLabel(UIComponent parent, string name, string text)
        {
            UILabel label = parent.AddUIComponent<UILabel>();
            label.name = name;
            label.text = text;
            label.font = GetUIFont("OpenSans-Regular");
            label.autoSize = false;
            label.height = 20f;
            label.verticalAlignment = UIVerticalAlignment.Top;
            label.relativePosition = new Vector3(0f, 0f);

            return label;
        }

        public static UISprite CreateDivider(UIComponent parent, string name)
        {
            UISprite sprite = parent.AddUIComponent<UISprite>();
            sprite.name = name;
            sprite.spriteName = "ContentManagerItemBackground";
            sprite.height = 15f;
            sprite.width = parent.width;
            sprite.relativePosition = new Vector3(0f, 0f);

            return sprite;
        }

        public static UIDropDown CreateDropDown(UIComponent parent, string name)
        {
            UIDropDown dropDown = parent.AddUIComponent<UIDropDown>();
            dropDown.name = name;

            dropDown.height = 32f;
            dropDown.width = parent.width - 10f;
            dropDown.relativePosition = new Vector3(0f, 0f);
            dropDown.listBackground = "OptionsDropboxListbox";
            dropDown.listHeight = 200;
            dropDown.itemHeight = 24;
            dropDown.itemHover = "ListItemHover";
            dropDown.itemHighlight = "ListItemHighlight";
            dropDown.normalBgSprite = "OptionsDropbox";
            dropDown.hoveredBgSprite = "OptionsDropboxHovered";
            dropDown.focusedBgSprite = "OptionsDropboxFocused";
            dropDown.disabledBgSprite = "OptionsDropboxDisabled";
            dropDown.foregroundSpriteMode = UIForegroundSpriteMode.Stretch;
            dropDown.horizontalAlignment = UIHorizontalAlignment.Left;
            dropDown.verticalAlignment = UIVerticalAlignment.Middle;
            dropDown.textFieldPadding = new RectOffset(14, 0, 8, 0);
            dropDown.itemPadding = new RectOffset(14, 0, 4, 0);
            dropDown.popupColor = new Color32(170, 170, 170, 255);

            UIButton button = dropDown.AddUIComponent<UIButton>();
            button.height = dropDown.height;
            button.width = dropDown.width;
            button.relativePosition = new Vector3(0f, 0f);
            button.textHorizontalAlignment = UIHorizontalAlignment.Center;
            button.textVerticalAlignment = UIVerticalAlignment.Middle;
            button.horizontalAlignment = UIHorizontalAlignment.Right;
            button.verticalAlignment = UIVerticalAlignment.Middle;

            dropDown.triggerButton = button;

            dropDown.eventSizeChanged += (component, value) =>
            {
                dropDown.listWidth = (int)value.x;
                button.size = value;
            };

            return dropDown;
        }

        public static UICheckBox CreateCheckBox(UIComponent parent, string name, string text, bool state)
        {
            UICheckBox checkBox = parent.AddUIComponent<UICheckBox>();
            checkBox.name = name;

            checkBox.height = 16f;
            checkBox.width = parent.width - 10f;

            UISprite uncheckedSprite = checkBox.AddUIComponent<UISprite>();
            uncheckedSprite.spriteName = "check-unchecked";
            uncheckedSprite.size = new Vector2(16f, 16f);
            uncheckedSprite.relativePosition = Vector3.zero;

            UISprite checkedSprite = checkBox.AddUIComponent<UISprite>();
            checkedSprite.spriteName = "check-checked";
            checkedSprite.size = new Vector2(16f, 16f);
            checkedSprite.relativePosition = Vector3.zero;
            checkBox.checkedBoxObject = checkedSprite;

            checkBox.label = checkBox.AddUIComponent<UILabel>();
            checkBox.label.text = text;
            checkBox.label.font = GetUIFont("OpenSans-Regular");
            checkBox.label.autoSize = false;
            checkBox.label.height = 20f;
            checkBox.label.verticalAlignment = UIVerticalAlignment.Middle;
            checkBox.label.relativePosition = new Vector3(20f, 0f);

            checkBox.isChecked = state;

            return checkBox;
        }

        public static UISlider CreateSlider(UIComponent parent, string name, float min, float max, float step, float defaultValue)
        {
            UISlider slider = parent.AddUIComponent<UISlider>();
            slider.name = name;

            slider.height = 12f;
            slider.width = parent.width - 10f;
            slider.relativePosition = new Vector3(0f, 30f);

            slider.maxValue = max;
            slider.minValue = min;
            slider.stepSize = step;

            UISlicedSprite slicedSprite = slider.AddUIComponent<UISlicedSprite>();
            slicedSprite.spriteName = "ScrollbarTrack";
            slicedSprite.height = slider.height;
            slicedSprite.width = slider.width;
            slicedSprite.relativePosition = new Vector3(0f, 0f);

            UISprite thumbSprite = slider.AddUIComponent<UISprite>();
            thumbSprite.spriteName = "ScrollbarThumb";
            thumbSprite.height = 20f;
            thumbSprite.width = 10f;
            thumbSprite.relativePosition = new Vector3(0f, -4f);
            slider.thumbObject = thumbSprite;

            slider.value = defaultValue;

            slider.eventSizeChanged += (component, value) =>
            {
                slicedSprite.width = slicedSprite.parent.width;
            };

            return slider;
        }

        public static UIButton CreatePanelButton(UIComponent parent, string name, string text)
        {
            UIButton button = parent.AddUIComponent<UIButton>();
            button.name = name;

            button.text = text;
            button.textScale = 0.875f;
            button.size = new Vector2(80f, 32f);

            button.normalBgSprite = "ButtonMenu";

            button.hoveredTextColor = new Color32(7, 132, 255, 255);
            button.pressedTextColor = new Color32(30, 30, 44, 255);

            return button;
        }

        public static UIButton CreateButton(UIComponent parent, string name, UITextureAtlas atlas, string spriteName)
        {
            UIButton button = parent.AddUIComponent<UIButton>();
            button.name = name;
            button.atlas = atlas;

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

        public static UILabel CreateMenuPanelTitle(UIComponent parent, string title)
        {
            UILabel label = parent.AddUIComponent<UILabel>();
            label.name = "Title";
            label.zOrder = 1;
            label.text = title;
            label.textAlignment = UIHorizontalAlignment.Center;

            return label;
        }

        public static UIButton CreateMenuPanelLocationButton(UIComponent parent)
        {
            UIButton button = parent.AddUIComponent<UIButton>();
            button.name = "LocationButton";
            button.zOrder = 1;

            button.normalBgSprite = "LocationMarkerActiveNormal";
            button.hoveredBgSprite = "LocationMarkerActiveHovered";
            button.pressedBgSprite = "LocationMarkerActivePressed";

            return button;
        }

        public static UIButton CreateMenuPanelCloseButton(UIComponent parent)
        {
            UIButton button = parent.AddUIComponent<UIButton>();
            button.name = "CloseButton";
            button.zOrder = 1;

            button.normalBgSprite = "buttonclose";
            button.hoveredBgSprite = "buttonclosehover";
            button.pressedBgSprite = "buttonclosepressed";

            button.eventClick += (component, eventParam) =>
            {
                if (!eventParam.used)
                {
                    parent.Hide();

                    eventParam.Use();
                }
            };

            return button;
        }

        public static UIDragHandle CreateMenuPanelDragHandle(UIComponent parent)
        {
            UIDragHandle dragHandle = parent.AddUIComponent<UIDragHandle>();
            dragHandle.name = "DragHandle";
            dragHandle.zOrder = 2;

            dragHandle.target = parent;

            return dragHandle;
        }

        public static UITabstrip CreateTabStrip(UIComponent parent)
        {
            UITabstrip tabstrip = parent.AddUIComponent<UITabstrip>();
            tabstrip.name = "TabStrip";
            tabstrip.clipChildren = true;

            return tabstrip;
        }

        public static UITabContainer CreateTabContainer(UIComponent parent)
        {
            UITabContainer tabContainer = parent.AddUIComponent<UITabContainer>();
            tabContainer.name = "TabContainer";

            return tabContainer;
        }

        public static UIButton CreateTabButton(UIComponent parent)
        {
            UIButton button = parent.AddUIComponent<UIButton>();
            button.name = "TabButton";

            button.height = 26f;
            button.width = 120f;

            button.textHorizontalAlignment = UIHorizontalAlignment.Center;
            button.textVerticalAlignment = UIVerticalAlignment.Middle;

            button.normalBgSprite = "GenericTab";
            button.disabledBgSprite = "GenericTabDisabled";
            button.focusedBgSprite = "GenericTabFocused";
            button.hoveredBgSprite = "GenericTabHovered";
            button.pressedBgSprite = "GenericTabPressed";

            button.textColor = new Color32(255, 255, 255, 255);
            button.disabledTextColor = new Color32(111, 111, 111, 255);
            button.focusedTextColor = new Color32(16, 16, 16, 255);
            button.hoveredTextColor = new Color32(255, 255, 255, 255);
            button.pressedTextColor = new Color32(255, 255, 255, 255);

            return button;
        }
    }
}
