using ColossalFramework.UI;
using RenderIt.Managers;
using System;
using UnityEngine;

namespace RenderIt.Panels
{
    public class ColorGradingPanel : UIPanel
    {
        private bool _initialized;

        private MainPanel _mainPanel;

        private UITextureAtlas _ingameAtlas;
        private UILabel _title;
        private UIButton _close;
        private UIDragHandle _dragHandle;
        private UIPanel _panel;

        private UIScrollablePanel _scrollablePanel;
        private UIScrollbar _scrollbar;
        private UISlicedSprite _scrollbarTrack;
        private UISlicedSprite _scrollbarThumb;
        private UILabel _postExposureSliderLabel;
        private UILabel _postExposureSliderNumeral;
        private UISlider _postExposureSlider;
        private UILabel _temperatureSliderLabel;
        private UILabel _temperatureSliderNumeral;
        private UISlider _temperatureSlider;
        private UILabel _tintSliderLabel;
        private UILabel _tintSliderNumeral;
        private UISlider _tintSlider;
        private UILabel _hueShiftSliderLabel;
        private UILabel _hueShiftSliderNumeral;
        private UISlider _hueShiftSlider;
        private UILabel _saturationSliderLabel;
        private UILabel _saturationSliderNumeral;
        private UISlider _saturationSlider;
        private UILabel _contrastSliderLabel;
        private UILabel _contrastSliderNumeral;
        private UISlider _contrastSlider;
        private UILabel _tonemapperDropDownLabel;
        private UIDropDown _tonemapperDropDown;
        private UILabel _neutralBlackInSliderLabel;
        private UILabel _neutralBlackInSliderNumeral;
        private UISlider _neutralBlackInSlider;
        private UILabel _neutralWhiteInSliderLabel;
        private UILabel _neutralWhiteInSliderNumeral;
        private UISlider _neutralWhiteInSlider;
        private UILabel _neutralBlackOutSliderLabel;
        private UILabel _neutralBlackOutSliderNumeral;
        private UISlider _neutralBlackOutSlider;
        private UILabel _neutralWhiteOutSliderLabel;
        private UILabel _neutralWhiteOutSliderNumeral;
        private UISlider _neutralWhiteOutSlider;
        private UILabel _neutralWhiteLevelSliderLabel;
        private UILabel _neutralWhiteLevelSliderNumeral;
        private UISlider _neutralWhiteLevelSlider;
        private UILabel _neutralWhiteClipSliderLabel;
        private UILabel _neutralWhiteClipSliderNumeral;
        private UISlider _neutralWhiteClipSlider;
        private UILabel _channelDropDownLabel;
        private UIDropDown _channelDropDown;
        private UILabel _channelRedSliderLabel;
        private UILabel _channelRedSliderNumeral;
        private UISlider _channelRedSlider;
        private UILabel _channelGreenSliderLabel;
        private UILabel _channelGreenSliderNumeral;
        private UISlider _channelGreenSlider;
        private UILabel _channelBlueSliderLabel;
        private UILabel _channelBlueSliderNumeral;
        private UISlider _channelBlueSlider;

        public override void Awake()
        {
            base.Awake();

            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ColorGradingPanel:Awake -> Exception: " + e.Message);
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
                Debug.Log("[Render It!] ColorGradingPanel:Start -> Exception: " + e.Message);
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
                Debug.Log("[Render It!] ColorGradingPanel:Update -> Exception: " + e.Message);
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
                DestroyGameObject(_scrollablePanel);
                DestroyGameObject(_scrollbar);
                DestroyGameObject(_scrollbarTrack);
                DestroyGameObject(_scrollbarThumb);
                DestroyGameObject(_postExposureSliderLabel);
                DestroyGameObject(_postExposureSliderNumeral);
                DestroyGameObject(_postExposureSlider);
                DestroyGameObject(_temperatureSliderLabel);
                DestroyGameObject(_temperatureSliderNumeral);
                DestroyGameObject(_temperatureSlider);
                DestroyGameObject(_tintSliderLabel);
                DestroyGameObject(_tintSliderNumeral);
                DestroyGameObject(_tintSlider);
                DestroyGameObject(_hueShiftSliderLabel);
                DestroyGameObject(_hueShiftSliderNumeral);
                DestroyGameObject(_hueShiftSlider);
                DestroyGameObject(_saturationSliderLabel);
                DestroyGameObject(_saturationSliderNumeral);
                DestroyGameObject(_saturationSlider);
                DestroyGameObject(_contrastSliderLabel);
                DestroyGameObject(_contrastSliderNumeral);
                DestroyGameObject(_contrastSlider);
                DestroyGameObject(_tonemapperDropDownLabel);
                DestroyGameObject(_tonemapperDropDown);
                DestroyGameObject(_neutralBlackInSliderLabel);
                DestroyGameObject(_neutralBlackInSliderNumeral);
                DestroyGameObject(_neutralBlackInSlider);
                DestroyGameObject(_neutralWhiteInSliderLabel);
                DestroyGameObject(_neutralWhiteInSliderNumeral);
                DestroyGameObject(_neutralWhiteInSlider);
                DestroyGameObject(_neutralBlackOutSliderLabel);
                DestroyGameObject(_neutralBlackOutSliderNumeral);
                DestroyGameObject(_neutralBlackOutSlider);
                DestroyGameObject(_neutralWhiteOutSliderLabel);
                DestroyGameObject(_neutralWhiteOutSliderNumeral);
                DestroyGameObject(_neutralWhiteOutSlider);
                DestroyGameObject(_neutralWhiteLevelSliderLabel);
                DestroyGameObject(_neutralWhiteLevelSliderNumeral);
                DestroyGameObject(_neutralWhiteLevelSlider);
                DestroyGameObject(_neutralWhiteClipSliderLabel);
                DestroyGameObject(_neutralWhiteClipSliderNumeral);
                DestroyGameObject(_neutralWhiteClipSlider);
                DestroyGameObject(_channelDropDownLabel);
                DestroyGameObject(_channelDropDown);
                DestroyGameObject(_channelRedSliderLabel);
                DestroyGameObject(_channelRedSliderNumeral);
                DestroyGameObject(_channelRedSlider);
                DestroyGameObject(_channelGreenSliderLabel);
                DestroyGameObject(_channelGreenSliderNumeral);
                DestroyGameObject(_channelGreenSlider);
                DestroyGameObject(_channelBlueSliderLabel);
                DestroyGameObject(_channelBlueSliderNumeral);
                DestroyGameObject(_channelBlueSlider);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ColorGradingPanel:OnDestroy -> Exception: " + e.Message);
            }
        }

        private void DestroyGameObject(UIComponent component)
        {
            if (component != null)
            {
                Destroy(component.gameObject);
            }
        }

        public void ApplyProfile(Profile profile)
        {
            try
            {
                if (profile != null)
                {
                    _postExposureSlider.value = profile.CGPostExposure;
                    _temperatureSlider.value = profile.CGTemperature;
                    _tintSlider.value = profile.CGTint;
                    _hueShiftSlider.value = profile.CGHueShift;
                    _saturationSlider.value = profile.CGSaturation;
                    _contrastSlider.value = profile.CGContrast;
                    _tonemapperDropDown.selectedIndex = profile.CGTonemapper;
                    _neutralBlackInSlider.value = profile.CGNeutralBlackIn;
                    _neutralWhiteInSlider.value = profile.CGNeutralWhiteIn;
                    _neutralBlackOutSlider.value = profile.CGNeutralBlackOut;
                    _neutralWhiteOutSlider.value = profile.CGNeutralWhiteOut;
                    _neutralWhiteLevelSlider.value = profile.CGNeutralWhiteLevel;
                    _neutralWhiteClipSlider.value = profile.CGNeutralWhiteClip;

                    _channelDropDown.selectedIndex = -1;
                    _channelDropDown.selectedIndex = 0;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ColorGradingPanel:ApplyProfile -> Exception: " + e.Message);
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
                height = 450f;
                relativePosition = new Vector3(Mathf.Floor((GetUIView().fixedWidth - width) / 2f), Mathf.Floor((GetUIView().fixedHeight - height) / 2f));

                _title = UIUtils.CreateMenuPanelTitle(this, _ingameAtlas, "Render It! - Color Grading");
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

                _panel = UIUtils.CreatePanel(this, "ColorGradingPanel");
                _panel.width = width - 40f;
                _panel.height = height - 60f;
                _panel.relativePosition = new Vector3(20f, 50f);

                _scrollablePanel = UIUtils.CreateScrollablePanel(_panel, "ScrollablePanel");
                _scrollablePanel.width = _panel.width - 25f;
                _scrollablePanel.height = _panel.height;
                _scrollablePanel.relativePosition = new Vector3(0f, 0f);

                _scrollablePanel.autoLayout = true;
                _scrollablePanel.autoLayoutStart = LayoutStart.TopLeft;
                _scrollablePanel.autoLayoutDirection = LayoutDirection.Vertical;
                _scrollablePanel.autoLayoutPadding.left = 5;
                _scrollablePanel.autoLayoutPadding.right = 0;
                _scrollablePanel.autoLayoutPadding.top = 0;
                _scrollablePanel.autoLayoutPadding.bottom = 10;
                _scrollablePanel.scrollWheelDirection = UIOrientation.Vertical;
                _scrollablePanel.builtinKeyNavigation = true;
                _scrollablePanel.clipChildren = true;

                _scrollbar = UIUtils.CreateScrollbar(_panel, "Scrollbar");
                _scrollbar.width = 20f;
                _scrollbar.height = _scrollablePanel.height;
                _scrollbar.relativePosition = new Vector3(_panel.width - 20f, 0f);
                _scrollbar.orientation = UIOrientation.Vertical;
                _scrollbar.incrementAmount = 38f;

                _scrollbarTrack = UIUtils.CreateSlicedSprite(_scrollbar, "ScrollbarTrack");
                _scrollbarTrack.width = _scrollbar.width;
                _scrollbarTrack.height = _scrollbar.height;
                _scrollbarTrack.relativePosition = new Vector3(0f, 0f);
                _scrollbarTrack.spriteName = "ScrollbarTrack";
                _scrollbarTrack.fillDirection = UIFillDirection.Vertical;

                _scrollbarThumb = UIUtils.CreateSlicedSprite(_scrollbar, "ScrollbarThumb");
                _scrollbarThumb.width = _scrollbar.width - 6f;
                _scrollbarThumb.relativePosition = new Vector3(3f, 0f);
                _scrollbarThumb.spriteName = "ScrollbarThumb";
                _scrollbarThumb.fillDirection = UIFillDirection.Vertical;

                _scrollablePanel.verticalScrollbar = _scrollbar;
                _scrollbar.trackObject = _scrollbarTrack;
                _scrollbar.thumbObject = _scrollbarThumb;

                _postExposureSliderLabel = UIUtils.CreateLabel(_scrollablePanel, "PostExposureSliderLabel", "Post Exposure");
                _postExposureSliderLabel.tooltip = "Adjusts the overall exposure of the scene";

                _postExposureSliderNumeral = UIUtils.CreateLabel(_postExposureSliderLabel, "PostExposureSliderNumeral", ProfileManager.Instance.ActiveProfile.CGPostExposure.ToString());
                _postExposureSliderNumeral.width = 100f;
                _postExposureSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _postExposureSliderNumeral.relativePosition = new Vector3(_scrollablePanel.width - _postExposureSliderNumeral.width - 10f, 0f);

                _postExposureSlider = UIUtils.CreateSlider(_scrollablePanel, "PostExposureSlider", _ingameAtlas, -2f, 2f, 0.05f, 0.05f, ProfileManager.Instance.ActiveProfile.CGPostExposure);
                _postExposureSlider.eventValueChanged += (component, value) =>
                {
                    _postExposureSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.CGPostExposure = value;
                    ProfileManager.Instance.Apply();
                };
                _postExposureSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _postExposureSlider.value = 0f;
                    }
                };

                _temperatureSliderLabel = UIUtils.CreateLabel(_scrollablePanel, "TemperatureSliderLabel", "Temperature");
                _temperatureSliderLabel.tooltip = "Sets the white balance to a custom color temperature";

                _temperatureSliderNumeral = UIUtils.CreateLabel(_temperatureSliderLabel, "TemperatureSliderNumeral", ProfileManager.Instance.ActiveProfile.CGTemperature.ToString());
                _temperatureSliderNumeral.width = 100f;
                _temperatureSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _temperatureSliderNumeral.relativePosition = new Vector3(_scrollablePanel.width - _temperatureSliderNumeral.width - 10f, 0f);

                _temperatureSlider = UIUtils.CreateSlider(_scrollablePanel, "TemperatureSlider", _ingameAtlas, -100f, 100f, 2f, 2f, ProfileManager.Instance.ActiveProfile.CGTemperature);
                _temperatureSlider.eventValueChanged += (component, value) =>
                {
                    _temperatureSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.CGTemperature = value;
                    ProfileManager.Instance.Apply();
                };
                _temperatureSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _temperatureSlider.value = 0f;
                    }
                };

                _tintSliderLabel = UIUtils.CreateLabel(_scrollablePanel, "TintSliderLabel", "Tint");
                _tintSliderLabel.tooltip = "Sets the white balance to compensate for a green or magenta tint";

                _tintSliderNumeral = UIUtils.CreateLabel(_tintSliderLabel, "TintSliderNumeral", ProfileManager.Instance.ActiveProfile.CGTint.ToString());
                _tintSliderNumeral.width = 100f;
                _tintSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _tintSliderNumeral.relativePosition = new Vector3(_scrollablePanel.width - _tintSliderNumeral.width - 10f, 0f);

                _tintSlider = UIUtils.CreateSlider(_scrollablePanel, "TintSlider", _ingameAtlas, -100f, 100f, 2f, 2f, ProfileManager.Instance.ActiveProfile.CGTint);
                _tintSlider.eventValueChanged += (component, value) =>
                {
                    _tintSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.CGTint = value;
                    ProfileManager.Instance.Apply();
                };
                _tintSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _tintSlider.value = 0f;
                    }
                };

                _hueShiftSliderLabel = UIUtils.CreateLabel(_scrollablePanel, "HueShiftSliderLabel", "Hue Shift");
                _hueShiftSliderLabel.tooltip = "Shift the hue of all colors";

                _hueShiftSliderNumeral = UIUtils.CreateLabel(_hueShiftSliderLabel, "HueShiftSliderNumeral", ProfileManager.Instance.ActiveProfile.CGHueShift.ToString());
                _hueShiftSliderNumeral.width = 100f;
                _hueShiftSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _hueShiftSliderNumeral.relativePosition = new Vector3(_scrollablePanel.width - _hueShiftSliderNumeral.width - 10f, 0f);

                _hueShiftSlider = UIUtils.CreateSlider(_scrollablePanel, "HueShiftSlider", _ingameAtlas, -180f, 180f, 3f, 3f, ProfileManager.Instance.ActiveProfile.CGHueShift);
                _hueShiftSlider.eventValueChanged += (component, value) =>
                {
                    _hueShiftSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.CGHueShift = value;
                    ProfileManager.Instance.Apply();
                };
                _hueShiftSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _hueShiftSlider.value = 0f;
                    }
                };

                _saturationSliderLabel = UIUtils.CreateLabel(_scrollablePanel, "SaturationSliderLabel", "Saturation");
                _saturationSliderLabel.tooltip = "Pushes the intensity of all colors";

                _saturationSliderNumeral = UIUtils.CreateLabel(_saturationSliderLabel, "SaturationSliderNumeral", ProfileManager.Instance.ActiveProfile.CGSaturation.ToString());
                _saturationSliderNumeral.width = 100f;
                _saturationSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _saturationSliderNumeral.relativePosition = new Vector3(_scrollablePanel.width - _saturationSliderNumeral.width - 10f, 0f);

                _saturationSlider = UIUtils.CreateSlider(_scrollablePanel, "SaturationSlider", _ingameAtlas, 0f, 2f, 0.02f, 0.02f, ProfileManager.Instance.ActiveProfile.CGSaturation);
                _saturationSlider.eventValueChanged += (component, value) =>
                {
                    _saturationSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.CGSaturation = value;
                    ProfileManager.Instance.Apply();
                };
                _saturationSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _saturationSlider.value = 1f;
                    }
                };

                _contrastSliderLabel = UIUtils.CreateLabel(_scrollablePanel, "ContrastSliderLabel", "Contrast");
                _contrastSliderLabel.tooltip = "Expands or shrinks the overall range of tonal values";

                _contrastSliderNumeral = UIUtils.CreateLabel(_contrastSliderLabel, "ContrastSliderNumeral", ProfileManager.Instance.ActiveProfile.CGContrast.ToString());
                _contrastSliderNumeral.width = 100f;
                _contrastSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _contrastSliderNumeral.relativePosition = new Vector3(_scrollablePanel.width - _contrastSliderNumeral.width - 10f, 0f);

                _contrastSlider = UIUtils.CreateSlider(_scrollablePanel, "ContrastSlider", _ingameAtlas, 0f, 2f, 0.02f, 0.02f, ProfileManager.Instance.ActiveProfile.CGContrast);
                _contrastSlider.eventValueChanged += (component, value) =>
                {
                    _contrastSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.CGContrast = value;
                    ProfileManager.Instance.Apply();
                };
                _contrastSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _contrastSlider.value = 1f;
                    }
                };

                _tonemapperDropDownLabel = UIUtils.CreateLabel(_scrollablePanel, "TonemapperDropDownLabel", "Tonemapper");
                _tonemapperDropDownLabel.tooltip = "Tonemapping is the process of remapping HDR values of an image into a range suitable to be displayed on screen.\n\nThe Neutral tonemapper only does range-remapping with minimal impact on color hue & saturation.\nThe Filmic (ACES) tonemapper uses a close approximation of the reference ACES tonemapper for a more filmic look";

                _tonemapperDropDown = UIUtils.CreateDropDown(_scrollablePanel, "TonemapperDropDown", _ingameAtlas);
                _tonemapperDropDown.items = ModInvariables.CGTonemapper;


                _neutralBlackInSliderLabel = UIUtils.CreateLabel(_scrollablePanel, "NeutralBlackInSliderLabel", "Neutral Black In");
                _neutralBlackInSliderLabel.tooltip = "Inner control point for the black point when using neutral tonemapper";

                _neutralBlackInSliderNumeral = UIUtils.CreateLabel(_neutralBlackInSliderLabel, "NeutralBlackInSliderNumeral", ProfileManager.Instance.ActiveProfile.CGNeutralBlackIn.ToString());
                _neutralBlackInSliderNumeral.width = 100f;
                _neutralBlackInSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _neutralBlackInSliderNumeral.relativePosition = new Vector3(_scrollablePanel.width - _neutralBlackInSliderNumeral.width - 10f, 0f);

                _neutralBlackInSlider = UIUtils.CreateSlider(_scrollablePanel, "NeutralBlackInSlider", _ingameAtlas, -0.1f, 0.1f, 0.002f, 0.002f, ProfileManager.Instance.ActiveProfile.CGNeutralBlackIn);
                _neutralBlackInSlider.eventValueChanged += (component, value) =>
                {
                    _neutralBlackInSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.CGNeutralBlackIn = value;
                    ProfileManager.Instance.Apply();
                };
                _neutralBlackInSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _neutralBlackInSlider.value = 0.02f;
                    }
                };

                _neutralWhiteInSliderLabel = UIUtils.CreateLabel(_scrollablePanel, "NeutralWhiteInSliderLabel", "Neutral White In");
                _neutralWhiteInSliderLabel.tooltip = "Inner control point for the white point when using neutral tonemapper";

                _neutralWhiteInSliderNumeral = UIUtils.CreateLabel(_neutralWhiteInSliderLabel, "NeutralWhiteInSliderNumeral", ProfileManager.Instance.ActiveProfile.CGNeutralWhiteIn.ToString());
                _neutralWhiteInSliderNumeral.width = 100f;
                _neutralWhiteInSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _neutralWhiteInSliderNumeral.relativePosition = new Vector3(_scrollablePanel.width - _neutralWhiteInSliderNumeral.width - 10f, 0f);

                _neutralWhiteInSlider = UIUtils.CreateSlider(_scrollablePanel, "NeutralWhiteInSlider", _ingameAtlas, 1f, 20f, 0.2f, 0.2f, ProfileManager.Instance.ActiveProfile.CGNeutralWhiteIn);
                _neutralWhiteInSlider.eventValueChanged += (component, value) =>
                {
                    _neutralWhiteInSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.CGNeutralWhiteIn = value;
                    ProfileManager.Instance.Apply();
                };
                _neutralWhiteInSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _neutralWhiteInSlider.value = 10f;
                    }
                };

                _neutralBlackOutSliderLabel = UIUtils.CreateLabel(_scrollablePanel, "NeutralBlackOutSliderLabel", "Neutral Black Out");
                _neutralBlackOutSliderLabel.tooltip = "Outer control point for the black point when using neutral tonemapper";

                _neutralBlackOutSliderNumeral = UIUtils.CreateLabel(_neutralBlackOutSliderLabel, "NeutralBlackOutSliderNumeral", ProfileManager.Instance.ActiveProfile.CGNeutralBlackOut.ToString());
                _neutralBlackOutSliderNumeral.width = 100f;
                _neutralBlackOutSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _neutralBlackOutSliderNumeral.relativePosition = new Vector3(_scrollablePanel.width - _neutralBlackOutSliderNumeral.width - 10f, 0f);

                _neutralBlackOutSlider = UIUtils.CreateSlider(_scrollablePanel, "NeutralBlackOutSlider", _ingameAtlas, -0.09f, 0.1f, 0.002f, 0.002f, ProfileManager.Instance.ActiveProfile.CGNeutralBlackOut);
                _neutralBlackOutSlider.eventValueChanged += (component, value) =>
                {
                    _neutralBlackOutSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.CGNeutralBlackOut = value;
                    ProfileManager.Instance.Apply();
                };
                _neutralBlackOutSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _neutralBlackOutSlider.value = 0f;
                    }
                };

                _neutralWhiteOutSliderLabel = UIUtils.CreateLabel(_scrollablePanel, "NeutralWhiteOutSliderLabel", "Neutral White Out");
                _neutralWhiteOutSliderLabel.tooltip = "Outer control point for the white point when using neutral tonemapper";

                _neutralWhiteOutSliderNumeral = UIUtils.CreateLabel(_neutralWhiteOutSliderLabel, "NeutralWhiteOutSliderNumeral", ProfileManager.Instance.ActiveProfile.CGNeutralWhiteOut.ToString());
                _neutralWhiteOutSliderNumeral.width = 100f;
                _neutralWhiteOutSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _neutralWhiteOutSliderNumeral.relativePosition = new Vector3(_scrollablePanel.width - _neutralWhiteOutSliderNumeral.width - 10f, 0f);

                _neutralWhiteOutSlider = UIUtils.CreateSlider(_scrollablePanel, "NeutralWhiteOutSlider", _ingameAtlas, 1f, 19f, 0.2f, 0.2f, ProfileManager.Instance.ActiveProfile.CGNeutralWhiteOut);
                _neutralWhiteOutSlider.eventValueChanged += (component, value) =>
                {
                    _neutralWhiteOutSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.CGNeutralWhiteOut = value;
                    ProfileManager.Instance.Apply();
                };
                _neutralWhiteOutSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _neutralWhiteOutSlider.value = 10f;
                    }
                };

                _neutralWhiteLevelSliderLabel = UIUtils.CreateLabel(_scrollablePanel, "NeutralWhiteLevelSliderLabel", "Neutral White Level");
                _neutralWhiteLevelSliderLabel.tooltip = "Pre-curve white point adjustment when using neutral tonemapper";

                _neutralWhiteLevelSliderNumeral = UIUtils.CreateLabel(_neutralWhiteLevelSliderLabel, "NeutralWhiteLevelSliderNumeral", ProfileManager.Instance.ActiveProfile.CGNeutralWhiteLevel.ToString());
                _neutralWhiteLevelSliderNumeral.width = 100f;
                _neutralWhiteLevelSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _neutralWhiteLevelSliderNumeral.relativePosition = new Vector3(_scrollablePanel.width - _neutralWhiteLevelSliderNumeral.width - 10f, 0f);

                _neutralWhiteLevelSlider = UIUtils.CreateSlider(_scrollablePanel, "NeutralWhiteLevelSlider", _ingameAtlas, 0.1f, 20f, 0.1f, 0.1f, ProfileManager.Instance.ActiveProfile.CGNeutralWhiteLevel);
                _neutralWhiteLevelSlider.eventValueChanged += (component, value) =>
                {
                    _neutralWhiteLevelSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.CGNeutralWhiteLevel = value;
                    ProfileManager.Instance.Apply();
                };
                _neutralWhiteLevelSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _neutralWhiteLevelSlider.value = 5.3f;
                    }
                };

                _neutralWhiteClipSliderLabel = UIUtils.CreateLabel(_scrollablePanel, "NeutralWhiteClipSliderLabel", "Neutral White Clip");
                _neutralWhiteClipSliderLabel.tooltip = "Post-curve white point adjustment using neutral tonemapper";

                _neutralWhiteClipSliderNumeral = UIUtils.CreateLabel(_neutralWhiteClipSliderLabel, "NeutralWhiteClipSliderNumeral", ProfileManager.Instance.ActiveProfile.CGNeutralWhiteClip.ToString());
                _neutralWhiteClipSliderNumeral.width = 100f;
                _neutralWhiteClipSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _neutralWhiteClipSliderNumeral.relativePosition = new Vector3(_scrollablePanel.width - _neutralWhiteClipSliderNumeral.width - 10f, 0f);

                _neutralWhiteClipSlider = UIUtils.CreateSlider(_scrollablePanel, "NeutralWhiteClipSlider", _ingameAtlas, 1f, 10f, 0.1f, 0.1f, ProfileManager.Instance.ActiveProfile.CGNeutralWhiteClip);
                _neutralWhiteClipSlider.eventValueChanged += (component, value) =>
                {
                    _neutralWhiteClipSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.CGNeutralWhiteClip = value;
                    ProfileManager.Instance.Apply();
                };
                _neutralWhiteClipSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _neutralWhiteClipSlider.value = 10f;
                    }
                };

                _channelDropDownLabel = UIUtils.CreateLabel(_scrollablePanel, "ChannelDropDownLabel", "Channel");
                _channelDropDownLabel.tooltip = "The Channel Mixer is used to modify the influence of each input color channel (RGB) on the overall mix of the output channel";

                _channelDropDown = UIUtils.CreateDropDown(_scrollablePanel, "ChannelDropDown", _ingameAtlas);
                _channelDropDown.items = ModInvariables.CGChannel;

                _channelRedSliderLabel = UIUtils.CreateLabel(_scrollablePanel, "ChannelRedSliderLabel", "Red");

                _channelRedSliderNumeral = UIUtils.CreateLabel(_channelRedSliderLabel, "ChannelRedSliderNumeral", "");
                _channelRedSliderNumeral.width = 100f;
                _channelRedSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _channelRedSliderNumeral.relativePosition = new Vector3(_scrollablePanel.width - _channelRedSliderNumeral.width - 10f, 0f);

                _channelRedSlider = UIUtils.CreateSlider(_scrollablePanel, "ChannelRedSlider", _ingameAtlas, 0f, 1f, 0.01f, 0.01f, 0f);
                _channelRedSlider.eventValueChanged += (component, value) =>
                {
                    _channelRedSliderNumeral.text = value.ToString();

                    switch (_channelDropDown.selectedIndex)
                    {
                        case 0:
                            ProfileManager.Instance.ActiveProfile.CGChannelMixerRedRed = value;
                            break;
                        case 1:
                            ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenRed = value;
                            break;
                        case 2:
                            ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueRed = value;
                            break;
                    }

                    ProfileManager.Instance.Apply();
                };
                _channelRedSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        switch (_channelDropDown.selectedIndex)
                        {
                            case 0:
                                _channelRedSlider.value = 1f;
                                break;
                            case 1:
                                _channelRedSlider.value = 0f;
                                break;
                            case 2:
                                _channelRedSlider.value = 0f;
                                break;
                        }

                        ProfileManager.Instance.Apply();
                    }
                };

                _channelGreenSliderLabel = UIUtils.CreateLabel(_scrollablePanel, "ChannelGreenSliderLabel", "Green");

                _channelGreenSliderNumeral = UIUtils.CreateLabel(_channelGreenSliderLabel, "ChannelGreenSliderNumeral", "");
                _channelGreenSliderNumeral.width = 100f;
                _channelGreenSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _channelGreenSliderNumeral.relativePosition = new Vector3(_scrollablePanel.width - _channelGreenSliderNumeral.width - 10f, 0f);

                _channelGreenSlider = UIUtils.CreateSlider(_scrollablePanel, "ChannelGreenSlider", _ingameAtlas, 0f, 1f, 0.01f, 0.01f, 0f);
                _channelGreenSlider.eventValueChanged += (component, value) =>
                {
                    _channelGreenSliderNumeral.text = value.ToString();

                    switch (_channelDropDown.selectedIndex)
                    {
                        case 0:
                            ProfileManager.Instance.ActiveProfile.CGChannelMixerRedGreen = value;
                            break;
                        case 1:
                            ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenGreen = value;
                            break;
                        case 2:
                            ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueGreen = value;
                            break;
                    }

                    ProfileManager.Instance.Apply();
                };
                _channelGreenSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        switch (_channelDropDown.selectedIndex)
                        {
                            case 0:
                                _channelGreenSlider.value = 0f;
                                break;
                            case 1:
                                _channelGreenSlider.value = 1f;
                                break;
                            case 2:
                                _channelGreenSlider.value = 0f;
                                break;
                        }

                        ProfileManager.Instance.Apply();
                    }
                };

                _channelBlueSliderLabel = UIUtils.CreateLabel(_scrollablePanel, "ChannelBlueSliderLabel", "Blue");

                _channelBlueSliderNumeral = UIUtils.CreateLabel(_channelBlueSliderLabel, "ChannelBlueSliderNumeral", "");
                _channelBlueSliderNumeral.width = 100f;
                _channelBlueSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _channelBlueSliderNumeral.relativePosition = new Vector3(_scrollablePanel.width - _channelBlueSliderNumeral.width - 10f, 0f);

                _channelBlueSlider = UIUtils.CreateSlider(_scrollablePanel, "ChannelBlueSlider", _ingameAtlas, 0f, 1f, 0.01f, 0.01f, 0f);
                _channelBlueSlider.eventValueChanged += (component, value) =>
                {
                    _channelBlueSliderNumeral.text = value.ToString();

                    switch (_channelDropDown.selectedIndex)
                    {
                        case 0:
                            ProfileManager.Instance.ActiveProfile.CGChannelMixerRedBlue = value;
                            break;
                        case 1:
                            ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenBlue = value;
                            break;
                        case 2:
                            ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueBlue = value;
                            break;
                    }

                    ProfileManager.Instance.Apply();
                };
                _channelBlueSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        switch (_channelDropDown.selectedIndex)
                        {
                            case 0:
                                _channelBlueSlider.value = 0f;
                                break;
                            case 1:
                                _channelBlueSlider.value = 0f;
                                break;
                            case 2:
                                _channelBlueSlider.value = 1f;
                                break;
                        }

                        ProfileManager.Instance.Apply();
                    }
                };

                _tonemapperDropDown.eventSelectedIndexChanged += (component, value) =>
                {
                    if (value != -1)
                    {
                        ProfileManager.Instance.ActiveProfile.CGTonemapper = value;
                        ProfileManager.Instance.Apply();

                        if (value == 2)
                        {
                            _neutralBlackInSliderLabel.isVisible = true;
                            _neutralBlackInSliderNumeral.isVisible = true;
                            _neutralBlackInSlider.isVisible = true;
                            _neutralWhiteInSliderLabel.isVisible = true;
                            _neutralWhiteInSliderNumeral.isVisible = true;
                            _neutralWhiteInSlider.isVisible = true;
                            _neutralBlackOutSliderLabel.isVisible = true;
                            _neutralBlackOutSliderNumeral.isVisible = true;
                            _neutralBlackOutSlider.isVisible = true;
                            _neutralWhiteOutSliderLabel.isVisible = true;
                            _neutralWhiteOutSliderNumeral.isVisible = true;
                            _neutralWhiteOutSlider.isVisible = true;
                            _neutralWhiteLevelSliderLabel.isVisible = true;
                            _neutralWhiteLevelSliderNumeral.isVisible = true;
                            _neutralWhiteLevelSlider.isVisible = true;
                            _neutralWhiteClipSliderLabel.isVisible = true;
                            _neutralWhiteClipSliderNumeral.isVisible = true;
                            _neutralWhiteClipSlider.isVisible = true;
                        }
                        else
                        {
                            _neutralBlackInSliderLabel.isVisible = false;
                            _neutralBlackInSliderNumeral.isVisible = false;
                            _neutralBlackInSlider.isVisible = false;
                            _neutralWhiteInSliderLabel.isVisible = false;
                            _neutralWhiteInSliderNumeral.isVisible = false;
                            _neutralWhiteInSlider.isVisible = false;
                            _neutralBlackOutSliderLabel.isVisible = false;
                            _neutralBlackOutSliderNumeral.isVisible = false;
                            _neutralBlackOutSlider.isVisible = false;
                            _neutralWhiteOutSliderLabel.isVisible = false;
                            _neutralWhiteOutSliderNumeral.isVisible = false;
                            _neutralWhiteOutSlider.isVisible = false;
                            _neutralWhiteLevelSliderLabel.isVisible = false;
                            _neutralWhiteLevelSliderNumeral.isVisible = false;
                            _neutralWhiteLevelSlider.isVisible = false;
                            _neutralWhiteClipSliderLabel.isVisible = false;
                            _neutralWhiteClipSliderNumeral.isVisible = false;
                            _neutralWhiteClipSlider.isVisible = false;
                        }
                    }
                };
                _tonemapperDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.CGTonemapper;

                _channelDropDown.eventSelectedIndexChanged += (component, value) =>
                {
                    if (value != -1)
                    {
                        switch (value)
                        {
                            case 0:
                                _channelRedSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerRedRed.ToString();
                                _channelGreenSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerRedGreen.ToString();
                                _channelBlueSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerRedBlue.ToString();
                                _channelRedSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerRedRed;
                                _channelGreenSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerRedGreen;
                                _channelBlueSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerRedBlue;
                                break;
                            case 1:
                                _channelRedSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenRed.ToString();
                                _channelGreenSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenGreen.ToString();
                                _channelBlueSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenBlue.ToString();
                                _channelRedSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenRed;
                                _channelGreenSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenGreen;
                                _channelBlueSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenBlue;
                                break;
                            case 2:
                                _channelRedSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueRed.ToString();
                                _channelGreenSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueGreen.ToString();
                                _channelBlueSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueBlue.ToString();
                                _channelRedSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueRed;
                                _channelGreenSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueGreen;
                                _channelBlueSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueBlue;
                                break;
                        }
                    }
                };

                _channelDropDown.selectedIndex = 0;
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ColorGradingPanel:CreateUI -> Exception: " + e.Message);
            }
        }

        private void UpdateUI()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ColorGradingPanel:UpdateUI -> Exception: " + e.Message);
            }
        }
    }
}
