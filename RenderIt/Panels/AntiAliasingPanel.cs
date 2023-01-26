using ColossalFramework.UI;
using RenderIt.Managers;
using System;
using UnityEngine;

namespace RenderIt.Panels
{
    public class AntiAliasingPanel : UIPanel
    {
        private bool _initialized;

        private MainPanel _mainPanel;

        private UITextureAtlas _ingameAtlas;
        private UILabel _title;
        private UIButton _close;
        private UIDragHandle _dragHandle;
        private UIPanel _panel;

        private UILabel _fxaaTitle;
        private UILabel _fxaaQualityDropDownLabel;
        private UIDropDown _fxaaQualityDropDown;
        private UISprite _fxaaDivider;
        private UILabel _taaTitle;
        private UILabel _taaJitterSpreadSliderLabel;
        private UILabel _taaJitterSpreadSliderNumeral;
        private UISlider _taaJitterSpreadSlider;
        private UILabel _taaStationaryBlendingSliderLabel;
        private UILabel _taaStationaryBlendingSliderNumeral;
        private UISlider _taaStationaryBlendingSlider;
        private UILabel _taaMotionBlendingSliderLabel;
        private UILabel _taaMotionBlendingSliderNumeral;
        private UISlider _taaMotionBlendingSlider;
        private UILabel _taaSharpenSliderLabel;
        private UILabel _taaSharpenSliderNumeral;
        private UISlider _taaSharpenSlider;

        public override void Awake()
        {
            base.Awake();

            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] AntiAliasingPanel:Awake -> Exception: " + e.Message);
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
                Debug.Log("[Render It!] AntiAliasingPanel:Start -> Exception: " + e.Message);
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
                Debug.Log("[Render It!] AntiAliasingPanel:Update -> Exception: " + e.Message);
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
                DestroyGameObject(_fxaaTitle);
                DestroyGameObject(_fxaaQualityDropDownLabel);
                DestroyGameObject(_fxaaQualityDropDown);
                DestroyGameObject(_fxaaDivider);
                DestroyGameObject(_taaTitle);
                DestroyGameObject(_taaJitterSpreadSliderLabel);
                DestroyGameObject(_taaJitterSpreadSliderNumeral);
                DestroyGameObject(_taaJitterSpreadSlider);
                DestroyGameObject(_taaStationaryBlendingSliderLabel);
                DestroyGameObject(_taaStationaryBlendingSliderNumeral);
                DestroyGameObject(_taaStationaryBlendingSlider);
                DestroyGameObject(_taaMotionBlendingSliderLabel);
                DestroyGameObject(_taaMotionBlendingSliderNumeral);
                DestroyGameObject(_taaMotionBlendingSlider);
                DestroyGameObject(_taaSharpenSliderLabel);
                DestroyGameObject(_taaSharpenSliderNumeral);
                DestroyGameObject(_taaSharpenSlider);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] AntiAliasingPanel:OnDestroy -> Exception: " + e.Message);
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
                    _fxaaQualityDropDown.selectedIndex = profile.FXAAQuality;

                    _taaJitterSpreadSlider.value = profile.TAAJitterSpread;
                    _taaStationaryBlendingSlider.value = profile.TAAStationaryBlending;
                    _taaMotionBlendingSlider.value = profile.TAAMotionBlending;
                    _taaSharpenSlider.value = profile.TAASharpen;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] AntiAliasingPanel:ApplyProfile -> Exception: " + e.Message);
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

                _title = UIUtils.CreateMenuPanelTitle(this, _ingameAtlas, "Render It! - Anti-aliasing");
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

                _panel = UIUtils.CreatePanel(this, "AntiAliasingPanel");
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

                _fxaaTitle = UIUtils.CreateTitle(_panel, "FXAATitle", "Fast Approximate Anti-aliasing (FXAA)");
                _fxaaTitle.tooltip = "A fast technique for platforms that don’t support motion vectors. It contains multiple quality presets\nand as such is also suitable as a fallback solution for slower desktop hardware";

                _fxaaQualityDropDownLabel = UIUtils.CreateLabel(_panel, "FXAAQualityDropDownLabel", "Quality");
                _fxaaQualityDropDownLabel.tooltip = "Set the quality to be used which provides a trade-off between performance and edge quality";

                _fxaaQualityDropDown = UIUtils.CreateDropDown(_panel, "FXAAQualityDropDown", _ingameAtlas);
                _fxaaQualityDropDown.items = ModInvariables.FXAAQuality;
                _fxaaQualityDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.FXAAQuality;
                _fxaaQualityDropDown.eventSelectedIndexChanged += (component, value) =>
                {
                    if (value != -1)
                    {
                        ProfileManager.Instance.ActiveProfile.FXAAQuality = value;
                        ProfileManager.Instance.Apply();
                    }
                };

                _fxaaDivider = UIUtils.CreateDivider(_panel, "FXAADivider", _ingameAtlas);

                _taaTitle = UIUtils.CreateTitle(_panel, "TAATitle", "Temporal Anti-aliasing (TAA)");
                _taaTitle.tooltip = "An advanced technique where frames are accumulated over time in a history buffer to be used to smooth edges more effectively.\nIt is substantially better at smoothing edges in motion but requires motion vectors and is more expensive than FXAA.\nIdeal for faster desktop hardware";

                _taaJitterSpreadSliderLabel = UIUtils.CreateLabel(_panel, "TAAJitterSpreadSliderLabel", "Jitter Spread");
                _taaJitterSpreadSliderLabel.tooltip = "Set the diameter (in texels) inside which jitter samples are spread. Smaller values result in crisper\nbut a more aliased output. Larger values result in more stable but blurrier output";

                _taaJitterSpreadSliderNumeral = UIUtils.CreateLabel(_taaJitterSpreadSliderLabel, "TAAJitterSpreadSliderNumeral", ProfileManager.Instance.ActiveProfile.TAAJitterSpread.ToString());
                _taaJitterSpreadSliderNumeral.width = 100f;
                _taaJitterSpreadSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _taaJitterSpreadSliderNumeral.relativePosition = new Vector3(_panel.width - _taaJitterSpreadSliderNumeral.width - 10f, 0f);

                _taaJitterSpreadSlider = UIUtils.CreateSlider(_panel, "TAAJitterSpreadSlider", _ingameAtlas, 0.1f, 1f, 0.01f, 0.01f, ProfileManager.Instance.ActiveProfile.TAAJitterSpread);
                _taaJitterSpreadSlider.eventValueChanged += (component, value) =>
                {
                    _taaJitterSpreadSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.TAAJitterSpread = value;
                    ProfileManager.Instance.Apply();
                };
                _taaJitterSpreadSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _taaJitterSpreadSlider.value = 0.75f;
                    }
                };

                _taaStationaryBlendingSliderLabel = UIUtils.CreateLabel(_panel, "TAAStationaryBlendingSliderLabel", "Stationary Blending");
                _taaStationaryBlendingSliderLabel.tooltip = "Set the blend coefficient for stationary fragments. This setting controls the percentage of history sample\nblended into final color for fragments with minimal active motion";

                _taaStationaryBlendingSliderNumeral = UIUtils.CreateLabel(_taaStationaryBlendingSliderLabel, "TAAStationaryBlendingSliderNumeral", ProfileManager.Instance.ActiveProfile.TAAStationaryBlending.ToString());
                _taaStationaryBlendingSliderNumeral.width = 100f;
                _taaStationaryBlendingSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _taaStationaryBlendingSliderNumeral.relativePosition = new Vector3(_panel.width - _taaStationaryBlendingSliderNumeral.width - 10f, 0f);

                _taaStationaryBlendingSlider = UIUtils.CreateSlider(_panel, "TAAStationaryBlendingSlider", _ingameAtlas, 0f, 0.99f, 0.01f, 0.01f, ProfileManager.Instance.ActiveProfile.TAAStationaryBlending);
                _taaStationaryBlendingSlider.eventValueChanged += (component, value) =>
                {
                    _taaStationaryBlendingSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.TAAStationaryBlending = value;
                    ProfileManager.Instance.Apply();
                };
                _taaStationaryBlendingSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _taaStationaryBlendingSlider.value = 0.95f;
                    }
                };

                _taaMotionBlendingSliderLabel = UIUtils.CreateLabel(_panel, "TAAMotionBlendingSliderLabel", "Motion Blending");
                _taaMotionBlendingSliderLabel.tooltip = "Set the blending coefficient for moving fragments. This setting controls the percentage of history sample\nblended into the final color for fragments with significant active motion";

                _taaMotionBlendingSliderNumeral = UIUtils.CreateLabel(_taaMotionBlendingSliderLabel, "TAAMotionBlendingSliderNumeral", ProfileManager.Instance.ActiveProfile.TAAMotionBlending.ToString());
                _taaMotionBlendingSliderNumeral.width = 100f;
                _taaMotionBlendingSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _taaMotionBlendingSliderNumeral.relativePosition = new Vector3(_panel.width - _taaMotionBlendingSliderNumeral.width - 10f, 0f);

                _taaMotionBlendingSlider = UIUtils.CreateSlider(_panel, "TAAMotionBlendingSlider", _ingameAtlas, 0f, 0.99f, 0.01f, 0.01f, ProfileManager.Instance.ActiveProfile.TAAMotionBlending);
                _taaMotionBlendingSlider.eventValueChanged += (component, value) =>
                {
                    _taaMotionBlendingSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.TAAMotionBlending = value;
                    ProfileManager.Instance.Apply();
                };
                _taaMotionBlendingSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _taaMotionBlendingSlider.value = 0.85f;
                    }
                };

                _taaSharpenSliderLabel = UIUtils.CreateLabel(_panel, "TAASharpenSliderLabel", "Sharpen");
                _taaSharpenSliderLabel.tooltip = "Set the sharpness to alleviate the slight loss of details in high frequency regions";

                _taaSharpenSliderNumeral = UIUtils.CreateLabel(_taaSharpenSliderLabel, "TAASharpenSliderNumeral", ProfileManager.Instance.ActiveProfile.TAASharpen.ToString());
                _taaSharpenSliderNumeral.width = 100f;
                _taaSharpenSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                _taaSharpenSliderNumeral.relativePosition = new Vector3(_panel.width - _taaSharpenSliderNumeral.width - 10f, 0f);

                _taaSharpenSlider = UIUtils.CreateSlider(_panel, "TAASharpenSlider", _ingameAtlas, 0f, 3f, 0.03f, 0.03f, ProfileManager.Instance.ActiveProfile.TAASharpen);
                _taaSharpenSlider.eventValueChanged += (component, value) =>
                {
                    _taaSharpenSliderNumeral.text = value.ToString();
                    ProfileManager.Instance.ActiveProfile.TAASharpen = value;
                    ProfileManager.Instance.Apply();
                };
                _taaSharpenSlider.eventMouseUp += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        _taaSharpenSlider.value = 0.3f;
                    }
                };
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] AntiAliasingPanel:CreateUI -> Exception: " + e.Message);
            }
        }

        private void UpdateUI()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] AntiAliasingPanel:UpdateUI -> Exception: " + e.Message);
            }
        }
    }
}
