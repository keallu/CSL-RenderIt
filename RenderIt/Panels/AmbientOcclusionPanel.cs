using ColossalFramework.UI;
using RenderIt.Managers;
using System;
using UnityEngine;

namespace RenderIt.Panels
{
    public class AmbientOcclusionPanel : UIPanel
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
        private UILabel _radiusSliderLabel;
        private UILabel _radiusSliderNumeral;
        private UISlider _radiusSlider;
        private UILabel _sampleCountDropDownLabel;
        private UIDropDown _sampleCountDropDown;
        private UICheckBox _downsamplingCheckBox;
        private UICheckBox _forceForwardCompatibilityCheckBox;
        private UICheckBox _ambientOnlyCheckBox;
        private UICheckBox _highPrecisionCheckBox;

        public override void Awake()
        {
            base.Awake();

            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] AmbientOcclusionPanel:Awake -> Exception: " + e.Message);
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
                Debug.Log("[Render It!] AmbientOcclusionPanel:Start -> Exception: " + e.Message);
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
                Debug.Log("[Render It!] AmbientOcclusionPanel:Update -> Exception: " + e.Message);
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
                DestroyGameObject(_title);
                DestroyGameObject(_intensitySliderLabel);
                DestroyGameObject(_intensitySliderNumeral);
                DestroyGameObject(_intensitySlider);
                DestroyGameObject(_radiusSliderLabel);
                DestroyGameObject(_radiusSliderNumeral);
                DestroyGameObject(_radiusSlider);
                DestroyGameObject(_sampleCountDropDownLabel);
                DestroyGameObject(_sampleCountDropDown);
                DestroyGameObject(_downsamplingCheckBox);
                DestroyGameObject(_forceForwardCompatibilityCheckBox);
                DestroyGameObject(_ambientOnlyCheckBox);
                DestroyGameObject(_highPrecisionCheckBox);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] AmbientOcclusionPanel:OnDestroy -> Exception: " + e.Message);
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
                    _intensitySlider.value = profile.AOIntensity;
                    _radiusSlider.value = profile.AORadius;
                    _sampleCountDropDown.selectedIndex = profile.AOSampleCount;
                    _downsamplingCheckBox.isChecked = profile.AODownsampling;
                    _forceForwardCompatibilityCheckBox.isChecked = profile.AOForceForwardCompatibility;
                    _ambientOnlyCheckBox.isChecked = profile.AOAmbientOnly;
                    _highPrecisionCheckBox.isChecked = profile.AOHighPrecision;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] AmbientOcclusionPanel:ApplyProfile -> Exception: " + e.Message);
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
                height = 350f;
                relativePosition = new Vector3(Mathf.Floor((GetUIView().fixedWidth - width) / 2f), Mathf.Floor((GetUIView().fixedHeight - height) / 2f));

                _title = UIUtils.CreateMenuPanelTitle(this, _ingameAtlas, "Render It! - Ambient Occlusion");
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

                _panel = UIUtils.CreatePanel(this, "AmbientOcclusionPanel");
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
                _intensitySliderLabel.tooltip = "Degree of darkness produced";

                _intensitySliderNumeral = UIUtils.CreateLabel(_intensitySliderLabel, "IntensitySliderNumeral", ProfileManager.Instance.ActiveProfile.AOIntensity.ToString());
                _intensitySliderNumeral.width = 100f;
                _intensitySliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _intensitySliderNumeral.relativePosition = new Vector3(_panel.width - _intensitySliderNumeral.width - 10f, 0f);

                _intensitySlider = UIUtils.CreateSlider(_panel, "IntensitySlider", _ingameAtlas, 0f, 4f, 0.05f, 0.05f, ProfileManager.Instance.ActiveProfile.AOIntensity);
                _intensitySlider.eventValueChanged += (component, value) =>
                {
                    _intensitySliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.AOIntensity = value;
                    ProfileManager.Instance.Apply();
                };
                _intensitySlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _intensitySlider.value = 1f;
                    }
                };

                _radiusSliderLabel = UIUtils.CreateLabel(_panel, "RadiusSliderLabel", "Radius");
                _radiusSliderLabel.tooltip = "Radius of sample points, which affects extent of darkened areas";

                _radiusSliderNumeral = UIUtils.CreateLabel(_radiusSliderLabel, "RadiusSliderNumeral", ProfileManager.Instance.ActiveProfile.AORadius.ToString());
                _radiusSliderNumeral.width = 100f;
                _radiusSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _radiusSliderNumeral.relativePosition = new Vector3(_panel.width - _radiusSliderNumeral.width - 10f, 0f);

                _radiusSlider = UIUtils.CreateSlider(_panel, "RadiusSlider", _ingameAtlas, 0f, 4f, 0.05f, 0.05f, ProfileManager.Instance.ActiveProfile.AORadius);
                _radiusSlider.eventValueChanged += (component, value) =>
                {
                    _radiusSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.AORadius = value;
                    ProfileManager.Instance.Apply();
                };
                _radiusSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _radiusSlider.value = 0.3f;
                    }
                };

                _sampleCountDropDownLabel = UIUtils.CreateLabel(_panel, "SampleCountDropDownLabel", "Sample Count");
                _sampleCountDropDownLabel.tooltip = "Number of sample points, which affects quality and performance";

                _sampleCountDropDown = UIUtils.CreateDropDown(_panel, "SampleCountDropDown", _ingameAtlas);
                _sampleCountDropDown.items = ModInvariables.AOSampleCount;
                _sampleCountDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.AOSampleCount;
                _sampleCountDropDown.eventSelectedIndexChanged += (component, value) =>
                {
                    if (value != -1)
                    {
                        ProfileManager.Instance.ActiveProfile.AOSampleCount = ConvertAmbientOcclusionSampleCount(value);
                        ProfileManager.Instance.Apply();
                    }
                };

                _downsamplingCheckBox = UIUtils.CreateCheckBox(_panel, "DownsamplingCheckBox", _ingameAtlas, "Downsampling", ProfileManager.Instance.ActiveProfile.AODownsampling);
                _downsamplingCheckBox.tooltip = "Halves the resolution of the effect to increase performance at the cost of visual quality";
                _downsamplingCheckBox.eventCheckChanged += (component, value) =>
                {
                    ProfileManager.Instance.ActiveProfile.AODownsampling = value;
                    ProfileManager.Instance.Apply();
                };

                _forceForwardCompatibilityCheckBox = UIUtils.CreateCheckBox(_panel, "ForceForwardCompatibilityCheckBox", _ingameAtlas, "Force Forward Compatibility", ProfileManager.Instance.ActiveProfile.AOForceForwardCompatibility);
                _forceForwardCompatibilityCheckBox.tooltip = "Forces compatibility with forward rendered objects when working with the deferred rendering path";
                _forceForwardCompatibilityCheckBox.eventCheckChanged += (component, value) =>
                {
                    ProfileManager.Instance.ActiveProfile.AOForceForwardCompatibility = value;
                    ProfileManager.Instance.Apply();
                };

                _highPrecisionCheckBox = UIUtils.CreateCheckBox(_panel, "HighPrecisionCheckBox", _ingameAtlas, "High Precision", ProfileManager.Instance.ActiveProfile.AOHighPrecision);
                _highPrecisionCheckBox.tooltip = "Uses higher precision depth texture with the forward rendering path which may impact performances";
                _highPrecisionCheckBox.eventCheckChanged += (component, value) =>
                {
                    ProfileManager.Instance.ActiveProfile.AOHighPrecision = value;
                    ProfileManager.Instance.Apply();
                };

                _ambientOnlyCheckBox = UIUtils.CreateCheckBox(_panel, "AmbientOnlyCheckBox", _ingameAtlas, "Ambient Only", ProfileManager.Instance.ActiveProfile.AOAmbientOnly);
                _ambientOnlyCheckBox.tooltip = "Enables the ambient-only mode in that ambient occlusion only affects ambient lighting";
                _ambientOnlyCheckBox.eventCheckChanged += (component, value) =>
                {
                    ProfileManager.Instance.ActiveProfile.AOAmbientOnly = value;
                    ProfileManager.Instance.Apply();
                };
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] AmbientOcclusionPanel:CreateUI -> Exception: " + e.Message);
            }
        }

        private void UpdateUI()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] AmbientOcclusionPanel:UpdateUI -> Exception: " + e.Message);
            }
        }

        private int ConvertAmbientOcclusionSampleCount(int index)
        {
            switch (index)
            {
                case 0:
                    return 3;
                case 1:
                    return 6;
                case 2:
                    return 10;
                case 3:
                    return 16;
                default:
                    return 10;
            }
        }
    }
}
