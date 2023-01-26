using ColossalFramework.UI;
using RenderIt.Managers;
using System;
using UnityEngine;

namespace RenderIt.Panels
{
    public class BloomPanel : UIPanel
    {
        private bool _initialized;

        private MainPanel _mainPanel;

        private UITextureAtlas _ingameAtlas;
        private UILabel _title;
        private UIButton _close;
        private UIDragHandle _dragHandle;
        private UIPanel _panel;

        private UILabel _intensitySliderLabel;
        private UILabel _intensitySliderNumeral;
        private UISlider _intensitySlider;
        private UILabel _thresholdSliderLabel;
        private UILabel _thresholdSliderNumeral;
        private UISlider _thresholdSlider;
        private UILabel _softKneeSliderLabel;
        private UILabel _softKneeSliderNumeral;
        private UISlider _softKneeSlider;
        private UILabel _radiusSliderLabel;
        private UILabel _radiusSliderNumeral;
        private UISlider _radiusSlider;
        private UICheckBox _antiFlickerCheckBox;

        public override void Awake()
        {
            base.Awake();

            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] BloomPanel:Awake -> Exception: " + e.Message);
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
                Debug.Log("[Render It!] BloomPanel:Start -> Exception: " + e.Message);
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
                Debug.Log("[Render It!] BloomPanel:Update -> Exception: " + e.Message);
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
                DestroyGameObject(_intensitySliderLabel);
                DestroyGameObject(_intensitySliderNumeral);
                DestroyGameObject(_intensitySlider);
                DestroyGameObject(_thresholdSliderLabel);
                DestroyGameObject(_thresholdSliderNumeral);
                DestroyGameObject(_thresholdSlider);
                DestroyGameObject(_softKneeSliderLabel);
                DestroyGameObject(_softKneeSliderNumeral);
                DestroyGameObject(_softKneeSlider);
                DestroyGameObject(_radiusSliderLabel);
                DestroyGameObject(_radiusSliderNumeral);
                DestroyGameObject(_radiusSlider);
                DestroyGameObject(_antiFlickerCheckBox);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] BloomPanel:OnDestroy -> Exception: " + e.Message);
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
                    _intensitySlider.value = profile.BloomIntensity;
                    _thresholdSlider.value = profile.BloomThreshold;
                    _softKneeSlider.value = profile.BloomSoftKnee;
                    _radiusSlider.value = profile.BloomRadius;
                    _antiFlickerCheckBox.isChecked = profile.BloomAntiFlicker;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] BloomPanel:ApplyProfile -> Exception: " + e.Message);
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

                _title = UIUtils.CreateMenuPanelTitle(this, _ingameAtlas, "Render It! - Bloom");
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

                _panel = UIUtils.CreatePanel(this, "BloomPanel");
                _panel.width = width - 40f;
                _panel.height = height - 60f;
                _panel.relativePosition = new Vector3(20f, 50f);
                _panel.autoLayout = true;
                _panel.autoLayoutStart = LayoutStart.TopLeft;
                _panel.autoLayoutDirection = LayoutDirection.Vertical;
                _panel.autoLayoutPadding.left = 5;
                _panel.autoLayoutPadding.right = 0;
                _panel.autoLayoutPadding.top = 0;
                _panel.autoLayoutPadding.bottom = 10;

                _intensitySliderLabel = UIUtils.CreateLabel(_panel, "IntensitySliderLabel", "Intensity");
                _intensitySliderLabel.tooltip = "Degree of bloom produced";

                _intensitySliderNumeral = UIUtils.CreateLabel(_intensitySliderLabel, "IntensitySliderNumeral", ProfileManager.Instance.ActiveProfile.BloomIntensity.ToString());
                _intensitySliderNumeral.width = 100f;
                _intensitySliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _intensitySliderNumeral.relativePosition = new Vector3(_panel.width - _intensitySliderNumeral.width - 10f, 0f);

                _intensitySlider = UIUtils.CreateSlider(_panel, "IntensitySlider", _ingameAtlas, 0f, 1f, 0.01f, 0.01f, ProfileManager.Instance.ActiveProfile.BloomIntensity);
                _intensitySlider.eventValueChanged += (component, value) =>
                {
                    _intensitySliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.BloomIntensity = value;
                    ProfileManager.Instance.Apply();
                };
                _intensitySlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _intensitySlider.value = 0.5f;
                    }
                };

                _thresholdSliderLabel = UIUtils.CreateLabel(_panel, "ThresholdSliderLabel", "Threshold");
                _thresholdSliderLabel.tooltip = "Filters out pixels under this level of brightness";

                _thresholdSliderNumeral = UIUtils.CreateLabel(_thresholdSliderLabel, "ThresholdSliderNumeral", ProfileManager.Instance.ActiveProfile.BloomThreshold.ToString());
                _thresholdSliderNumeral.width = 100f;
                _thresholdSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _thresholdSliderNumeral.relativePosition = new Vector3(_panel.width - _thresholdSliderNumeral.width - 10f, 0f);

                _thresholdSlider = UIUtils.CreateSlider(_panel, "ThresholdSlider", _ingameAtlas, 0f, 10f, 0.1f, 0.1f, ProfileManager.Instance.ActiveProfile.BloomThreshold);
                _thresholdSlider.eventValueChanged += (component, value) =>
                {
                    _thresholdSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.BloomThreshold = value;
                    ProfileManager.Instance.Apply();
                };
                _thresholdSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _thresholdSlider.value = 1.1f;
                    }
                };

                _softKneeSliderLabel = UIUtils.CreateLabel(_panel, "SoftKneeSliderLabel", "Soft Knee");
                _softKneeSliderLabel.tooltip = "Makes transition between under/over-threshold gradual";

                _softKneeSliderNumeral = UIUtils.CreateLabel(_softKneeSliderLabel, "SoftKneeSliderNumeral", ProfileManager.Instance.ActiveProfile.BloomSoftKnee.ToString());
                _softKneeSliderNumeral.width = 100f;
                _softKneeSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _softKneeSliderNumeral.relativePosition = new Vector3(_panel.width - _softKneeSliderNumeral.width - 10f, 0f);

                _softKneeSlider = UIUtils.CreateSlider(_panel, "SoftKneeSlider", _ingameAtlas, 0f, 1f, 0.01f, 0.01f, ProfileManager.Instance.ActiveProfile.BloomSoftKnee);
                _softKneeSlider.eventValueChanged += (component, value) =>
                {
                    _softKneeSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.BloomSoftKnee = value;
                    ProfileManager.Instance.Apply();
                };
                _softKneeSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _softKneeSlider.value = 0.5f;
                    }
                };

                _radiusSliderLabel = UIUtils.CreateLabel(_panel, "RadiusSliderLabel", "Radius");
                _radiusSliderLabel.tooltip = "Changes extent of veiling in a screen resolution-independent fashion";

                _radiusSliderNumeral = UIUtils.CreateLabel(_radiusSliderLabel, "RadiusSliderNumeral", ProfileManager.Instance.ActiveProfile.BloomRadius.ToString());
                _radiusSliderNumeral.width = 100f;
                _radiusSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _radiusSliderNumeral.relativePosition = new Vector3(_panel.width - _radiusSliderNumeral.width - 10f, 0f);

                _radiusSlider = UIUtils.CreateSlider(_panel, "RadiusSlider", _ingameAtlas, 1f, 7f, 0.05f, 0.05f, ProfileManager.Instance.ActiveProfile.BloomRadius);
                _radiusSlider.eventValueChanged += (component, value) =>
                {
                    _radiusSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.BloomRadius = value;
                    ProfileManager.Instance.Apply();
                };
                _radiusSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _radiusSlider.value = 4f;
                    }
                };

                _antiFlickerCheckBox = UIUtils.CreateCheckBox(_panel, "AntiFlickerCheckBox", _ingameAtlas, "Anti Flicker", ProfileManager.Instance.ActiveProfile.BloomAntiFlicker);
                _antiFlickerCheckBox.tooltip = "Reduces flashing noise with an additional filter";
                _antiFlickerCheckBox.eventCheckChanged += (component, value) =>
                {
                    ProfileManager.Instance.ActiveProfile.BloomAntiFlicker = value;
                    ProfileManager.Instance.Apply();
                };
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] BloomPanel:CreateUI -> Exception: " + e.Message);
            }
        }

        private void UpdateUI()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] BloomPanel:UpdateUI -> Exception: " + e.Message);
            }
        }
    }
}
