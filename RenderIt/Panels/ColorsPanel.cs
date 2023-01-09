using ColossalFramework;
using ColossalFramework.UI;
using RenderIt.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RenderIt.Panels
{
    public class ColorsPanel : UIPanel
    {
        private bool _initialized;

        private MainPanel _mainPanel;

        private UITextureAtlas _ingameAtlas;
        private UILabel _title;
        private UIButton _close;
        private UIDragHandle _dragHandle;
        private UIPanel _panel;
        private UILabel _dropDownLabel;
        private UIDropDown _dropDown;
        private UILabel _redSliderLabel;
        private UILabel _redSliderNumeral;
        private UISlider _redSlider;
        private UILabel _greenSliderLabel;
        private UILabel _greenSliderNumeral;
        private UISlider _greenSlider;
        private UILabel _blueSliderLabel;
        private UILabel _blueSliderNumeral;
        private UISlider _blueSlider;

        private List<Profile.TimedColor> _timedColors;

        public override void Awake()
        {
            base.Awake();

            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ColorsPanel:Awake -> Exception: " + e.Message);
            }
        }

        public override void Start()
        {
            base.Start();

            try
            {
                if (_mainPanel == null)
                {
                    _mainPanel = GameObject.Find("RenderItMainPanel")?.GetComponent<MainPanel>();
                }

                _ingameAtlas = ResourceLoader.GetAtlas("Ingame");

                CreateUI();
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ColorsPanel:Start -> Exception: " + e.Message);
            }
        }

        public override void Update()
        {
            base.Update();

            try
            {
                if (!_initialized)
                {
                    UpdateUI();

                    _initialized = true;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ColorsPanel:Update -> Exception: " + e.Message);
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            try
            {
                DestroyGameObject(_title);
                DestroyGameObject(_close);
                DestroyGameObject(_dragHandle);
                DestroyGameObject(_panel);
                DestroyGameObject(_dropDownLabel);
                DestroyGameObject(_dropDown);
                DestroyGameObject(_redSliderLabel);
                DestroyGameObject(_redSliderNumeral);
                DestroyGameObject(_redSlider);
                DestroyGameObject(_greenSliderLabel);
                DestroyGameObject(_greenSliderNumeral);
                DestroyGameObject(_greenSlider);
                DestroyGameObject(_blueSliderLabel);
                DestroyGameObject(_blueSliderNumeral);
                DestroyGameObject(_blueSlider);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ColorsPanel:OnDestroy -> Exception: " + e.Message);
            }
        }

        private void DestroyGameObject(UIComponent component)
        {
            if (component != null)
            {
                Destroy(component.gameObject);
            }
        }

        private void CreateUI()
        {
            try
            {
                backgroundSprite = "MenuPanel2";
                isVisible = false;
                canFocus = true;
                isInteractive = true;
                width = 400f;
                height = 300f;
                relativePosition = new Vector3(Mathf.Floor((GetUIView().fixedWidth - width) / 2f), Mathf.Floor((GetUIView().fixedHeight - height) / 2f));

                _title = UIUtils.CreateMenuPanelTitle(this, _ingameAtlas, "Render It! - Colors");
                _title.relativePosition = new Vector3(width / 2f - _title.width / 2f, 15f);

                _close = UIUtils.CreateMenuPanelCloseButton(this, _ingameAtlas);
                _close.relativePosition = new Vector3(width - 37f, 3f);
                _close.eventClick += (component, eventParam) =>
                {
                    if (!eventParam.used)
                    {
                        _close.parent.Hide();

                        eventParam.Use();
                    }
                };

                _dragHandle = UIUtils.CreateMenuPanelDragHandle(this);
                _dragHandle.width = width - 40f;
                _dragHandle.height = 40f;
                _dragHandle.relativePosition = Vector3.zero;

                _panel = UIUtils.CreatePanel(this, "ColorsPanel");
                _panel.width = width - 40f;
                _panel.height = height - 40f;
                _panel.relativePosition = new Vector3(20f, 50f);
                _panel.autoLayout = true;
                _panel.autoLayoutStart = LayoutStart.TopLeft;
                _panel.autoLayoutDirection = LayoutDirection.Vertical;
                _panel.autoLayoutPadding.left = 5;
                _panel.autoLayoutPadding.right = 0;
                _panel.autoLayoutPadding.top = 0;
                _panel.autoLayoutPadding.bottom = 10;

                _dropDownLabel = UIUtils.CreateLabel(_panel, "TimeLabel", "Time");
                _dropDownLabel.tooltip = "Select the time for adjusting the red, green and blue primary color of light";

                _dropDown = UIUtils.CreateDropDown(_panel, "TimeDropDown", _ingameAtlas);
                _dropDown.width = _panel.width / 2f;
                _dropDown.eventSelectedIndexChanged += (component, value) =>
                {
                    if (value != -1)
                    {
                        _redSlider.value = _timedColors[value].Red;
                        _greenSlider.value = _timedColors[value].Green;
                        _blueSlider.value = _timedColors[value].Blue;
                    }
                };

                _redSliderLabel = UIUtils.CreateLabel(_panel, "RedSliderLabel", "Red");
                _redSliderLabel.tooltip = "Set the red primary color of light";

                _redSliderNumeral = UIUtils.CreateLabel(_redSliderLabel, "RedSliderNumeral", "0");
                _redSliderNumeral.width = 100f;
                _redSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _redSliderNumeral.relativePosition = new Vector3(_panel.width - _redSliderNumeral.width - 10f, 0f);

                _redSlider = UIUtils.CreateSlider(_panel, "RedSlider", _ingameAtlas, 0f, 255f, 1f, 1f, 0f);
                _redSlider.eventValueChanged += (component, value) =>
                {
                    _redSliderNumeral.text = value.ToString();
                    _timedColors[_dropDown.selectedIndex].Red = (byte)value;
                    ProfileManager.Instance.Apply();
                };
                _redSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {

                    }
                };

                _greenSliderLabel = UIUtils.CreateLabel(_panel, "GreenSliderLabel", "Green");
                _greenSliderLabel.tooltip = "Set the green primary color of light";

                _greenSliderNumeral = UIUtils.CreateLabel(_greenSliderLabel, "GreenSliderNumeral", "0");
                _greenSliderNumeral.width = 100f;
                _greenSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _greenSliderNumeral.relativePosition = new Vector3(_panel.width - _greenSliderNumeral.width - 10f, 0f);

                _greenSlider = UIUtils.CreateSlider(_panel, "GreenSlider", _ingameAtlas, 0f, 255f, 1f, 1f, 0f);
                _greenSlider.eventValueChanged += (component, value) =>
                {
                    _greenSliderNumeral.text = value.ToString();
                    _timedColors[_dropDown.selectedIndex].Green = (byte)value;
                    ProfileManager.Instance.Apply();
                };
                _greenSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {

                    }
                };

                _blueSliderLabel = UIUtils.CreateLabel(_panel, "BlueSliderLabel", "Blue");
                _blueSliderLabel.tooltip = "Set the blue primary color of light";

                _blueSliderNumeral = UIUtils.CreateLabel(_blueSliderLabel, "BlueSliderNumeral", "0");
                _blueSliderNumeral.width = 100f;
                _blueSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _blueSliderNumeral.relativePosition = new Vector3(_panel.width - _blueSliderNumeral.width - 10f, 0f);

                _blueSlider = UIUtils.CreateSlider(_panel, "BlueSlider", _ingameAtlas, 0f, 255f, 1f, 1f, 0f);
                _blueSlider.eventValueChanged += (component, value) =>
                {
                    _blueSliderNumeral.text = value.ToString();
                    _timedColors[_dropDown.selectedIndex].Blue = (byte)value;
                    ProfileManager.Instance.Apply();
                };
                _blueSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {

                    }
                };
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ColorsPanel:CreateUI -> Exception: " + e.Message);
            }
        }

        private void UpdateUI()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ColorsPanel:UpdateUI -> Exception: " + e.Message);
            }
        }

        public void SetColors(int colors)
        {
            try
            {
                switch (colors)
                {
                    case 1:
                        _timedColors = ProfileManager.Instance.ActiveProfile.LightColors;
                        _title.text = "Render It! - Sun & Moon Colors";
                        _title.relativePosition = new Vector3(width / 2f - _title.width / 2f, 15f);
                        break;
                    case 2:
                        _timedColors = ProfileManager.Instance.ActiveProfile.SkyColors;
                        _title.text = "Render It! - Sky Colors";
                        _title.relativePosition = new Vector3(width / 2f - _title.width / 2f, 15f);
                        break;
                    case 3:
                        _timedColors = ProfileManager.Instance.ActiveProfile.EquatorColors;
                        _title.text = "Render It! - Equator Colors";
                        _title.relativePosition = new Vector3(width / 2f - _title.width / 2f, 15f);
                        break;
                    case 4:
                        _timedColors = ProfileManager.Instance.ActiveProfile.GroundColors;
                        _title.text = "Render It! - Ground Colors";
                        _title.relativePosition = new Vector3(width / 2f - _title.width / 2f, 15f);
                        break;
                    default:
                        _timedColors = ProfileManager.Instance.ActiveProfile.LightColors;
                        _title.text = "Render It! - Sun & Moon Colors";
                        _title.relativePosition = new Vector3(width / 2f - _title.width / 2f, 15f);
                        break;
                }

                _dropDown.items = _timedColors.Select(x => TimeOfDay(x.Time)).ToArray();
                _dropDown.selectedValue = TimeOfDay(_timedColors.FirstOrDefault().Time);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ColorsPanel:SetMode -> Exception: " + e.Message);
            }
        }

        private string TimeOfDay(float value)
        {
            string name = string.Empty;

            if (value < 0.25f)
            {
                name = "Night/Dawn";
            }
            else if (value >= 0.25f && value < 0.275f)
            {
                name = "Sunrise";
            }
            else if (value >= 0.275f && value < 0.325f)
            {
                name = "Morning";
            }
            else if (value >= 0.325f && value < 0.68f)
            {
                name = "Noon";
            }
            else if (value >= 0.68f && value < 0.73f)
            {
                name = "Evening";
            }
            else if (value >= 0.73f && value < 0.76f)
            {
                name = "Sunset";
            }
            else if (value >= 0.76f)
            {
                name = "Dusk/Night";
            }

            float timeOfDay = value * 24f;

            int hour = (int)Mathf.Floor(timeOfDay);
            int minute = (int)Mathf.Floor((timeOfDay - hour) * 60.0f);

            DateTime dateTime = DateTime.Parse(string.Format("{0,2:00}:{1,2:00}", hour, minute));

            return name + " (~" + dateTime.ToString("HH:mm") + ")";
        }
    }
}
