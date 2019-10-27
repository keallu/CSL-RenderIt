using ColossalFramework.UI;
using System;
using System.Linq;
using UnityEngine;

namespace RenderIt
{
    public class MainPanel : UIPanel
    {
        private bool _initialized;

        private UILabel _title;
        private UIButton _close;
        private UIDragHandle _dragHandle;

        private UITabstrip _tabstrip;
        private UITabContainer _tabContainer;
        private UIButton _templateButton;

        private UILabel _profilesActiveDropDownLabel;
        private UIDropDown _profilesActiveDropDown;
        private UIPanel _profilesButtonsPanel;
        private UIButton _profilesAddButton;
        private UIButton _profilesRemoveButton;
        private UIButton _profilesRenameButton;
        private UIButton _profilesSaveButton;

        private UILabel _optionsAntiAliasingDropDownLabel;
        private UIDropDown _optionsAntiAliasingDropDown;
        private UICheckBox _optionsAmbientOcclusionCheckBox;
        private UICheckBox _optionsBloomCheckBox;
        private UICheckBox _optionsColorGradingCheckBox;

        private UILabel _advancedFXAATitle;
        private UILabel _advancedFXAAQualityDropDownLabel;
        private UIDropDown _advancedFXAAQualityDropDown;
        private UISprite _advancedFXAADivider;

        private UIScrollablePanel _advancedScrollablePanel;
        private UIScrollbar _advancedScrollbar;
        private UISlicedSprite _advancedScrollbarTrack;
        private UISlicedSprite _advancedScrollbarThumb;
        private UILabel _advancedTAATitle;
        private UILabel _advancedTAAJitterSpreadSliderLabel;
        private UISlider _advancedTAAJitterSpreadSlider;
        private UILabel _advancedTAASharpenSliderLabel;
        private UISlider _advancedTAASharpenSlider;
        private UILabel _advancedTAAStationaryBlendingSliderLabel;
        private UISlider _advancedTAAStationaryBlendingSlider;
        private UILabel _advancedTAAMotionBlendingSliderLabel;
        private UISlider _advancedTAAMotionBlendingSlider;
        private UISprite _advancedTAADivider;
        private UILabel _advancedAOTitle;
        private UILabel _advancedAOIntensitySliderLabel;
        private UISlider _advancedAOIntensitySlider;
        private UILabel _advancedAORadiusSliderLabel;
        private UISlider _advancedAORadiusSlider;
        private UILabel _advancedAOSampleCountDropDownLabel;
        private UIDropDown _advancedAOSampleCountDropDown;
        private UICheckBox _advancedAODownsamplingCheckBox;
        private UICheckBox _advancedAOForceForwardCompatibilityCheckBox;
        private UICheckBox _advancedAOAmbientOnlyCheckBox;
        private UICheckBox _advancedAOHighPrecisionCheckBox;
        private UISprite _advancedAODivider;
        private UILabel _advancedBloomTitle;
        private UICheckBox _advancedBloomVanillaBloomCheckBox;
        private UILabel _advancedBloomIntensitySliderLabel;
        private UISlider _advancedBloomIntensitySlider;
        private UILabel _advancedBloomThresholdSliderLabel;
        private UISlider _advancedBloomThresholdSlider;
        private UILabel _advancedBloomSoftKneeSliderLabel;
        private UISlider _advancedBloomSoftKneeSlider;
        private UILabel _advancedBloomRadiusSliderLabel;
        private UISlider _advancedBloomRadiusSlider;
        private UICheckBox _advancedBloomAntiFlickerCheckBox;
        private UISprite _advancedBloomDivider;
        private UILabel _advancedCGTitle;
        private UICheckBox _advancedCGVanillaTonemappingCheckBox;
        private UICheckBox _advancedCGVanillaColorCorrectionLUTCheckBox;
        private UILabel _advancedCGPostExposureSliderLabel;
        private UISlider _advancedCGPostExposureSlider;
        private UILabel _advancedCGTemperatureSliderLabel;
        private UISlider _advancedCGTemperatureSlider;
        private UILabel _advancedCGTintSliderLabel;
        private UISlider _advancedCGTintSlider;
        private UILabel _advancedCGHueShiftSliderLabel;
        private UISlider _advancedCGHueShiftSlider;
        private UILabel _advancedCGSaturationSliderLabel;
        private UISlider _advancedCGSaturationSlider;
        private UILabel _advancedCGContrastSliderLabel;
        private UISlider _advancedCGContrastSlider;
        private UILabel _advancedCGTonemapperDropDownLabel;
        private UIDropDown _advancedCGTonemapperDropDown;
        private UILabel _advancedCGNeutralBlackInSliderLabel;
        private UISlider _advancedCGNeutralBlackInSlider;
        private UILabel _advancedCGNeutralWhiteInSliderLabel;
        private UISlider _advancedCGNeutralWhiteInSlider;
        private UILabel _advancedCGNeutralBlackOutSliderLabel;
        private UISlider _advancedCGNeutralBlackOutSlider;
        private UILabel _advancedCGNeutralWhiteOutSliderLabel;
        private UISlider _advancedCGNeutralWhiteOutSlider;
        private UILabel _advancedCGNeutralWhiteLevelSliderLabel;
        private UISlider _advancedCGNeutralWhiteLevelSlider;
        private UILabel _advancedCGNeutralWhiteClipSliderLabel;
        private UISlider _advancedCGNeutralWhiteClipSlider;
        private UISprite _advancedCGDivider;

        public override void Awake()
        {
            base.Awake();

            try
            {
                if (ModConfig.Instance.PanelPositionX == 0.0f)
                {
                    ModConfig.Instance.PanelPositionX = Mathf.Floor((GetUIView().fixedWidth - width) / 2f);
                }

                if (ModConfig.Instance.PanelPositionY == 0.0f)
                {
                    ModConfig.Instance.PanelPositionY = Mathf.Floor((GetUIView().fixedHeight - height) / 2f);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] MainPanel:Awake -> Exception: " + e.Message);
            }
        }

        public override void Start()
        {
            base.Start();

            CreateUI();
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
                Debug.Log("[Render It!] MainPanel:Update -> Exception: " + e.Message);
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            if (_title != null)
            {
                Destroy(_title);
            }
            if (_close != null)
            {
                Destroy(_close);
            }
            if (_dragHandle != null)
            {
                Destroy(_dragHandle);
            }
            if (_tabstrip != null)
            {
                Destroy(_tabstrip);
            }
            if (_tabContainer != null)
            {
                Destroy(_tabContainer);
            }
            if (_templateButton != null)
            {
                Destroy(_templateButton);
            }
            if (_profilesActiveDropDownLabel != null)
            {
                Destroy(_profilesActiveDropDownLabel);
            }
            if (_profilesActiveDropDown != null)
            {
                Destroy(_profilesActiveDropDown);
            }
            if (_profilesButtonsPanel != null)
            {
                Destroy(_profilesButtonsPanel);
            }
            if (_profilesAddButton != null)
            {
                Destroy(_profilesAddButton);
            }
            if (_profilesRemoveButton != null)
            {
                Destroy(_profilesRemoveButton);
            }
            if (_profilesRenameButton != null)
            {
                Destroy(_profilesRenameButton);
            }
            if (_profilesSaveButton != null)
            {
                Destroy(_profilesSaveButton);
            }
            if (_optionsAntiAliasingDropDownLabel != null)
            {
                Destroy(_optionsAntiAliasingDropDownLabel);
            }
            if (_optionsAntiAliasingDropDown != null)
            {
                Destroy(_optionsAntiAliasingDropDown);
            }
            if (_optionsAmbientOcclusionCheckBox != null)
            {
                Destroy(_optionsAmbientOcclusionCheckBox);
            }
            if (_optionsBloomCheckBox != null)
            {
                Destroy(_optionsBloomCheckBox);
            }
            if (_optionsColorGradingCheckBox != null)
            {
                Destroy(_optionsColorGradingCheckBox);
            }
            if (_advancedScrollablePanel != null)
            {
                Destroy(_advancedScrollablePanel);
            }
            if (_advancedScrollbar != null)
            {
                Destroy(_advancedScrollbar);
            }
            if (_advancedScrollbarTrack != null)
            {
                Destroy(_advancedScrollbarTrack);
            }
            if (_advancedScrollbarThumb != null)
            {
                Destroy(_advancedScrollbarThumb);
            }
            if (_advancedFXAATitle != null)
            {
                Destroy(_advancedFXAATitle);
            }
            if (_advancedFXAAQualityDropDownLabel != null)
            {
                Destroy(_advancedFXAAQualityDropDownLabel);
            }
            if (_advancedFXAAQualityDropDown != null)
            {
                Destroy(_advancedFXAAQualityDropDown);
            }
            if (_advancedFXAADivider != null)
            {
                Destroy(_advancedFXAADivider);
            }
            if (_advancedTAATitle != null)
            {
                Destroy(_advancedTAATitle);
            }
            if (_advancedTAAJitterSpreadSliderLabel != null)
            {
                Destroy(_advancedTAAJitterSpreadSliderLabel);
            }
            if (_advancedTAAJitterSpreadSlider != null)
            {
                Destroy(_advancedTAAJitterSpreadSlider);
            }
            if (_advancedTAASharpenSliderLabel != null)
            {
                Destroy(_advancedTAASharpenSliderLabel);
            }
            if (_advancedTAASharpenSlider != null)
            {
                Destroy(_advancedTAASharpenSlider);
            }
            if (_advancedTAAStationaryBlendingSliderLabel != null)
            {
                Destroy(_advancedTAAStationaryBlendingSliderLabel);
            }
            if (_advancedTAAStationaryBlendingSlider != null)
            {
                Destroy(_advancedTAAStationaryBlendingSlider);
            }
            if (_advancedTAAMotionBlendingSliderLabel != null)
            {
                Destroy(_advancedTAAMotionBlendingSliderLabel);
            }
            if (_advancedTAAMotionBlendingSlider != null)
            {
                Destroy(_advancedTAAMotionBlendingSlider);
            }
            if (_advancedTAADivider != null)
            {
                Destroy(_advancedTAADivider);
            }
            if (_advancedAOTitle != null)
            {
                Destroy(_advancedAOTitle);
            }
            if (_advancedAOIntensitySliderLabel != null)
            {
                Destroy(_advancedAOIntensitySliderLabel);
            }
            if (_advancedAOIntensitySlider != null)
            {
                Destroy(_advancedAOIntensitySlider);
            }
            if (_advancedAORadiusSliderLabel != null)
            {
                Destroy(_advancedAORadiusSliderLabel);
            }
            if (_advancedAORadiusSlider != null)
            {
                Destroy(_advancedAORadiusSlider);
            }
            if (_advancedAOSampleCountDropDownLabel != null)
            {
                Destroy(_advancedAOSampleCountDropDownLabel);
            }
            if (_advancedAOSampleCountDropDown != null)
            {
                Destroy(_advancedAOSampleCountDropDown);
            }
            if (_advancedAODownsamplingCheckBox != null)
            {
                Destroy(_advancedAODownsamplingCheckBox);
            }
            if (_advancedAOForceForwardCompatibilityCheckBox != null)
            {
                Destroy(_advancedAOForceForwardCompatibilityCheckBox);
            }
            if (_advancedAOAmbientOnlyCheckBox != null)
            {
                Destroy(_advancedAOAmbientOnlyCheckBox);
            }
            if (_advancedAOHighPrecisionCheckBox != null)
            {
                Destroy(_advancedAOHighPrecisionCheckBox);
            }
            if (_advancedAODivider != null)
            {
                Destroy(_advancedAODivider);
            }
            if (_advancedBloomTitle != null)
            {
                Destroy(_advancedBloomTitle);
            }
            if (_advancedBloomVanillaBloomCheckBox != null)
            {
                Destroy(_advancedBloomVanillaBloomCheckBox);
            }
            if (_advancedBloomIntensitySliderLabel != null)
            {
                Destroy(_advancedBloomIntensitySliderLabel);
            }
            if (_advancedBloomIntensitySlider != null)
            {
                Destroy(_advancedBloomIntensitySlider);
            }
            if (_advancedBloomThresholdSliderLabel != null)
            {
                Destroy(_advancedBloomThresholdSliderLabel);
            }
            if (_advancedBloomThresholdSlider != null)
            {
                Destroy(_advancedBloomThresholdSlider);
            }
            if (_advancedBloomSoftKneeSliderLabel != null)
            {
                Destroy(_advancedBloomSoftKneeSliderLabel);
            }
            if (_advancedBloomSoftKneeSlider != null)
            {
                Destroy(_advancedBloomSoftKneeSlider);
            }
            if (_advancedBloomRadiusSliderLabel != null)
            {
                Destroy(_advancedBloomRadiusSliderLabel);
            }
            if (_advancedBloomRadiusSlider != null)
            {
                Destroy(_advancedBloomRadiusSlider);
            }
            if (_advancedBloomAntiFlickerCheckBox != null)
            {
                Destroy(_advancedBloomAntiFlickerCheckBox);
            }
            if (_advancedBloomDivider != null)
            {
                Destroy(_advancedBloomDivider);
            }
            if (_advancedCGTitle != null)
            {
                Destroy(_advancedCGTitle);
            }
            if (_advancedCGVanillaTonemappingCheckBox != null)
            {
                Destroy(_advancedCGVanillaTonemappingCheckBox);
            }
            if (_advancedCGVanillaColorCorrectionLUTCheckBox != null)
            {
                Destroy(_advancedCGVanillaColorCorrectionLUTCheckBox);
            }
            if (_advancedCGPostExposureSliderLabel != null)
            {
                Destroy(_advancedCGPostExposureSliderLabel);
            }
            if (_advancedCGPostExposureSlider != null)
            {
                Destroy(_advancedCGPostExposureSlider);
            }
            if (_advancedCGTemperatureSliderLabel != null)
            {
                Destroy(_advancedCGTemperatureSliderLabel);
            }
            if (_advancedCGTemperatureSlider != null)
            {
                Destroy(_advancedCGTemperatureSlider);
            }
            if (_advancedCGTintSliderLabel != null)
            {
                Destroy(_advancedCGTintSliderLabel);
            }
            if (_advancedCGTintSlider != null)
            {
                Destroy(_advancedCGTintSlider);
            }
            if (_advancedCGHueShiftSliderLabel != null)
            {
                Destroy(_advancedCGHueShiftSliderLabel);
            }
            if (_advancedCGHueShiftSlider != null)
            {
                Destroy(_advancedCGHueShiftSlider);
            }
            if (_advancedCGSaturationSliderLabel != null)
            {
                Destroy(_advancedCGSaturationSliderLabel);
            }
            if (_advancedCGSaturationSlider != null)
            {
                Destroy(_advancedCGSaturationSlider);
            }
            if (_advancedCGContrastSliderLabel != null)
            {
                Destroy(_advancedCGContrastSliderLabel);
            }
            if (_advancedCGContrastSlider != null)
            {
                Destroy(_advancedCGContrastSlider);
            }
            if (_advancedCGTonemapperDropDownLabel != null)
            {
                Destroy(_advancedCGTonemapperDropDownLabel);
            }
            if (_advancedCGTonemapperDropDown != null)
            {
                Destroy(_advancedCGTonemapperDropDown);
            }
            if (_advancedCGNeutralBlackInSliderLabel != null)
            {
                Destroy(_advancedCGNeutralBlackInSliderLabel);
            }
            if (_advancedCGNeutralBlackInSlider != null)
            {
                Destroy(_advancedCGNeutralBlackInSlider);
            }
            if (_advancedCGNeutralWhiteInSliderLabel != null)
            {
                Destroy(_advancedCGNeutralWhiteInSliderLabel);
            }
            if (_advancedCGNeutralWhiteInSlider != null)
            {
                Destroy(_advancedCGNeutralWhiteInSlider);
            }
            if (_advancedCGNeutralBlackOutSliderLabel != null)
            {
                Destroy(_advancedCGNeutralBlackOutSliderLabel);
            }
            if (_advancedCGNeutralBlackOutSlider != null)
            {
                Destroy(_advancedCGNeutralBlackOutSlider);
            }
            if (_advancedCGNeutralWhiteOutSliderLabel != null)
            {
                Destroy(_advancedCGNeutralWhiteOutSliderLabel);
            }
            if (_advancedCGNeutralWhiteOutSlider != null)
            {
                Destroy(_advancedCGNeutralWhiteOutSlider);
            }
            if (_advancedCGNeutralWhiteLevelSliderLabel != null)
            {
                Destroy(_advancedCGNeutralWhiteLevelSliderLabel);
            }
            if (_advancedCGNeutralWhiteLevelSlider != null)
            {
                Destroy(_advancedCGNeutralWhiteLevelSlider);
            }
            if (_advancedCGNeutralWhiteClipSliderLabel != null)
            {
                Destroy(_advancedCGNeutralWhiteClipSliderLabel);
            }
            if (_advancedCGNeutralWhiteClipSlider != null)
            {
                Destroy(_advancedCGNeutralWhiteClipSlider);
            }
            if (_advancedCGDivider != null)
            {
                Destroy(_advancedCGDivider);
            }
        }

        private void CreateUI()
        {
            try
            {
                name = "RenderItMainPanel";
                backgroundSprite = "MenuPanel2";
                clipChildren = true;
                isVisible = false;
                width = 400f;
                height = 800f;

                _title = UIUtils.CreateMenuPanelTitle(this, "Render It!");
                _title.relativePosition = new Vector3(width / 2f - _title.width / 2f, 15f);

                _close = UIUtils.CreateMenuPanelCloseButton(this);
                _close.relativePosition = new Vector3(width - 37f, 3f);

                _dragHandle = UIUtils.CreateMenuPanelDragHandle(this);
                _dragHandle.width = width - 40f;
                _dragHandle.height = 40f;
                _dragHandle.relativePosition = Vector3.zero;
                _dragHandle.eventMouseUp += (component, eventParam) =>
                {
                    ModConfig.Instance.PanelPositionX = absolutePosition.x;
                    ModConfig.Instance.PanelPositionY = absolutePosition.y;
                    ModConfig.Instance.Save();
                };

                _tabstrip = UIUtils.CreateTabStrip(this);
                _tabstrip.width = width - 40f;
                _tabstrip.relativePosition = new Vector3(20f, 50f);

                _tabContainer = UIUtils.CreateTabContainer(this);
                _tabContainer.width = width - 40f;
                _tabContainer.height = height - 120f;
                _tabContainer.relativePosition = new Vector3(20f, 100f);

                _templateButton = UIUtils.CreateTabButton(this);

                _tabstrip.tabPages = _tabContainer;

                UIPanel panel = null;

                _tabstrip.AddTab("Profiles", _templateButton, true);
                _tabstrip.selectedIndex = 0;
                panel = _tabstrip.tabContainer.components[0] as UIPanel;
                if (panel != null)
                {
                    panel.autoLayout = true;
                    panel.autoLayoutStart = LayoutStart.TopLeft;
                    panel.autoLayoutDirection = LayoutDirection.Vertical;
                    panel.autoLayoutPadding.left = 5;
                    panel.autoLayoutPadding.right = 0;
                    panel.autoLayoutPadding.top = 0;
                    panel.autoLayoutPadding.bottom = 10;

                    _profilesActiveDropDownLabel = UIUtils.CreateLabel(panel, "ProfilesActiveDropDownLabel", "Active");

                    _profilesActiveDropDown = UIUtils.CreateDropDown(panel, "ProfilesActiveDropDown");
                    foreach (Profile profile in ModConfig.Instance.Profiles)
                    {
                        _profilesActiveDropDown.AddItem(profile.Name);
                    }
                    _profilesActiveDropDown.selectedValue = ModConfig.Instance.Profiles.Find(x => x.Active == true).Name;
                    _profilesActiveDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        if (value != -1)
                        {
                            foreach (Profile profile in ModConfig.Instance.Profiles)
                            {
                                profile.Active = false;
                            }

                            ModProperties.Instance.ActiveProfile = ModConfig.Instance.Profiles[value];
                            ModConfig.Instance.Profiles[value].Active = true;

                            ApplyActiveProfile();
                        }
                    };

                    _profilesButtonsPanel = UIUtils.CreatePanel(panel, "ProfilesButtonsPanel");
                    _profilesButtonsPanel.width = panel.width - 10f;
                    _profilesButtonsPanel.height = 40f;

                    _profilesAddButton = UIUtils.CreatePanelButton(_profilesButtonsPanel, "ProfilesAddButton", "Add");
                    _profilesAddButton.tooltip = "Click to add new active profile with default values";
                    _profilesAddButton.relativePosition = new Vector3(0f, 0f);
                    _profilesAddButton.eventClick += (component, eventParam) =>
                    {
                        if (!eventParam.used)
                        {
                            Profile profile = new Profile
                            {
                                Name = DateTime.Now.ToString("MM/dd/yy HH:mm:ss"),
                                Active = true
                            };
                            ModConfig.Instance.Profiles.Add(profile);
                            ModProperties.Instance.ActiveProfile = profile;

                            _profilesActiveDropDown.AddItem(profile.Name);
                            _profilesActiveDropDown.selectedValue = profile.Name;

                            eventParam.Use();
                        }
                    };

                    _profilesRemoveButton = UIUtils.CreatePanelButton(_profilesButtonsPanel, "ProfilesRemoveButton", "Remove");
                    _profilesRemoveButton.tooltip = "Click to remove current active profile";
                    _profilesRemoveButton.relativePosition = new Vector3(85f, 0f);
                    _profilesRemoveButton.eventClick += (component, eventParam) =>
                    {
                        if (!eventParam.used)
                        {
                            if (ModConfig.Instance.Profiles.Count > 1)
                            {
                                ModConfig.Instance.Profiles.Remove(ModConfig.Instance.Profiles[_profilesActiveDropDown.selectedIndex]);
                                ModProperties.Instance.ActiveProfile = ModConfig.Instance.Profiles[0];

                                _profilesActiveDropDown.items = _profilesActiveDropDown.items.Where((w, i) => i != _profilesActiveDropDown.selectedIndex).ToArray();
                                _profilesActiveDropDown.selectedValue = ModConfig.Instance.Profiles[0].Name;
                            }

                            eventParam.Use();
                        }
                    };

                    //_profilesRenameButton = UIUtils.CreatePanelButton(_profilesButtonsPanel, "ProfilesRenameButton", "Rename");
                    //_profilesRenameButton.tooltip = "Click to rename current active profile";
                    //_profilesRenameButton.relativePosition = new Vector3(185f, 0f);
                    //_profilesRenameButton.eventClick += (component, eventParam) =>
                    //{
                    //    if (!eventParam.used)
                    //    {
                            

                    //        eventParam.Use();
                    //    }
                    //};

                    _profilesSaveButton = UIUtils.CreatePanelButton(_profilesButtonsPanel, "ProfilesSaveButton", "Save");
                    _profilesSaveButton.tooltip = "Click to save all profiles and their specific values";
                    _profilesSaveButton.relativePosition = new Vector3(270f, 0f);
                    _profilesSaveButton.eventClick += (component, eventParam) =>
                    {
                        if (!eventParam.used)
                        {
                            ModConfig.Instance.Save();

                            eventParam.Use();
                        }
                    };
                }

                _tabstrip.AddTab("Options", _templateButton, true);
                _tabstrip.selectedIndex = 1;
                panel = _tabstrip.tabContainer.components[1] as UIPanel;
                if (panel != null)
                {
                    panel.autoLayout = true;
                    panel.autoLayoutStart = LayoutStart.TopLeft;
                    panel.autoLayoutDirection = LayoutDirection.Vertical;
                    panel.autoLayoutPadding.left = 5;
                    panel.autoLayoutPadding.right = 0;
                    panel.autoLayoutPadding.top = 0;
                    panel.autoLayoutPadding.bottom = 10;

                    _optionsAntiAliasingDropDownLabel = UIUtils.CreateLabel(panel, "OptionsAntiAliasingDropDownLabel", "Anti-aliasing Technique");

                    _optionsAntiAliasingDropDown = UIUtils.CreateDropDown(panel, "OptionsAntiAliasingDropDown");
                    _optionsAntiAliasingDropDown.items = ModInvariables.AntialiasingTechnique;
                    _optionsAntiAliasingDropDown.selectedIndex = ModProperties.Instance.ActiveProfile.AntialiasingTechnique;
                    _optionsAntiAliasingDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.AntialiasingTechnique = value;
                        ModUtils.UpdateOptionsGraphicsPanel();
                        ModConfig.Instance.Apply();
                    };

                    _optionsAmbientOcclusionCheckBox = UIUtils.CreateCheckBox(panel, "OptionsAmbientOcclusionCheckBox", "Ambient Occlusion Enabled", ModProperties.Instance.ActiveProfile.AmbientOcclusionEnabled);
                    _optionsAmbientOcclusionCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.AmbientOcclusionEnabled = value;
                        ModConfig.Instance.Apply();
                    };
                    _optionsBloomCheckBox = UIUtils.CreateCheckBox(panel, "OptionsBloomCheckBox", "Bloom Enabled", ModProperties.Instance.ActiveProfile.BloomEnabled);
                    _optionsBloomCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.BloomEnabled = value;
                        ModConfig.Instance.Apply();
                    };
                    _optionsColorGradingCheckBox = UIUtils.CreateCheckBox(panel, "OptionsColorGradingCheckBox", "Color Grading Enabled", ModProperties.Instance.ActiveProfile.ColorGradingEnabled);
                    _optionsColorGradingCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.ColorGradingEnabled = value;
                        ModConfig.Instance.Apply();
                    };
                }

                _tabstrip.AddTab("Advanced", _templateButton, true);
                _tabstrip.selectedIndex = 2;
                panel = _tabstrip.tabContainer.components[2] as UIPanel;

                if (panel != null)
                {
                    _advancedScrollablePanel = UIUtils.CreateScrollablePanel(panel, "AdvancedScrollablePanel");
                    _advancedScrollablePanel.width = panel.width - 25f;
                    _advancedScrollablePanel.height = panel.height;
                    _advancedScrollablePanel.relativePosition = new Vector3(0f, 0f);

                    _advancedScrollablePanel.autoLayout = true;
                    _advancedScrollablePanel.autoLayoutStart = LayoutStart.TopLeft;
                    _advancedScrollablePanel.autoLayoutDirection = LayoutDirection.Vertical;
                    _advancedScrollablePanel.autoLayoutPadding.left = 5;
                    _advancedScrollablePanel.autoLayoutPadding.right = 0;
                    _advancedScrollablePanel.autoLayoutPadding.top = 0;
                    _advancedScrollablePanel.autoLayoutPadding.bottom = 10;
                    _advancedScrollablePanel.scrollWheelDirection = UIOrientation.Vertical;
                    _advancedScrollablePanel.builtinKeyNavigation = true;
                    _advancedScrollablePanel.clipChildren = true;

                    _advancedScrollbar = UIUtils.CreateScrollbar(panel, "AdvancedScrollbar");
                    _advancedScrollbar.width = 20f;
                    _advancedScrollbar.height = _advancedScrollablePanel.height;
                    _advancedScrollbar.relativePosition = new Vector3(panel.width - 20f, 0f);
                    _advancedScrollbar.orientation = UIOrientation.Vertical;
                    _advancedScrollbar.incrementAmount = 38f;

                    _advancedScrollbarTrack = UIUtils.CreateSlicedSprite(_advancedScrollbar, "AdvancedScrollbarTrack");
                    _advancedScrollbarTrack.width = _advancedScrollbar.width;
                    _advancedScrollbarTrack.height = _advancedScrollbar.height;
                    _advancedScrollbarTrack.relativePosition = new Vector3(0f, 0f);
                    _advancedScrollbarTrack.spriteName = "ScrollbarTrack";
                    _advancedScrollbarTrack.fillDirection = UIFillDirection.Vertical;

                    _advancedScrollbarThumb = UIUtils.CreateSlicedSprite(_advancedScrollbar, "AdvancedScrollbarThumb");
                    _advancedScrollbarThumb.width = _advancedScrollbar.width - 5f;
                    _advancedScrollbarThumb.relativePosition = new Vector3(2.5f, 0f);
                    _advancedScrollbarThumb.spriteName = "ScrollbarThumb";
                    _advancedScrollbarThumb.fillDirection = UIFillDirection.Vertical;

                    _advancedScrollablePanel.verticalScrollbar = _advancedScrollbar;
                    _advancedScrollbar.trackObject = _advancedScrollbarTrack;
                    _advancedScrollbar.thumbObject = _advancedScrollbarThumb;

                    // --- FXAA ---
                    _advancedFXAATitle = UIUtils.CreateTitle(_advancedScrollablePanel, "AdvancedFXAATitle", "Fast Approximate Anti-aliasing (FXAA)");

                    _advancedFXAAQualityDropDownLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedFXAAQualityDropDownLabel", "Quality");

                    _advancedFXAAQualityDropDown = UIUtils.CreateDropDown(_advancedScrollablePanel, "AdvancedFXAAQualityDropDown");
                    _advancedFXAAQualityDropDown.items = ModInvariables.FXAAQuality;
                    _advancedFXAAQualityDropDown.selectedIndex = ModProperties.Instance.ActiveProfile.FXAAQuality;
                    _advancedFXAAQualityDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.FXAAQuality = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedFXAADivider = UIUtils.CreateDivider(_advancedScrollablePanel, "AdvancedFXAADivider");

                    // --- TAA ---
                    _advancedTAATitle = UIUtils.CreateTitle(_advancedScrollablePanel, "AdvancedTAATitle", "Temporal Anti-aliasing (TAA)");

                    _advancedTAAJitterSpreadSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedTAAJitterSpreadSliderLabel", "Jitter Spread");

                    _advancedTAAJitterSpreadSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedTAAJitterSpreadSlider", 0.1f, 1f, 0.01f, ModProperties.Instance.ActiveProfile.TAAJitterSpread);
                    _advancedTAAJitterSpreadSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.TAAJitterSpread = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedTAASharpenSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedTAASharpenSliderLabel", "Sharpen");

                    _advancedTAASharpenSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedTAAJitterSpreadSlider", 0f, 3f, 0.03f, ModProperties.Instance.ActiveProfile.TAASharpen);
                    _advancedTAASharpenSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.TAASharpen = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedTAAStationaryBlendingSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedTAAStationaryBlendingSliderLabel", "Stationary Blending");

                    _advancedTAAStationaryBlendingSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedTAAStationaryBlendingSlider", 0f, 0.99f, 0.01f, ModProperties.Instance.ActiveProfile.TAAStationaryBlending);
                    _advancedTAAStationaryBlendingSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.TAAStationaryBlending = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedTAAMotionBlendingSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedTAAMotionBlendingSliderLabel", "Motion Blending");

                    _advancedTAAMotionBlendingSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedTAAMotionBlendingSlider", 0f, 0.99f, 0.01f, ModProperties.Instance.ActiveProfile.TAAMotionBlending);
                    _advancedTAAMotionBlendingSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.TAAMotionBlending = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedTAADivider = UIUtils.CreateDivider(_advancedScrollablePanel, "AdvancedTAADivider");

                    // --- AO ---
                    _advancedAOTitle = UIUtils.CreateTitle(_advancedScrollablePanel, "AdvancedAOTitle", "Ambient Occlusion");

                    _advancedAOIntensitySliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedAOIntensitySliderLabel", "Intensity");

                    _advancedAOIntensitySlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedAOIntensitySlider", 0f, 4f, 0.1f, ModProperties.Instance.ActiveProfile.AOIntensity);
                    _advancedAOIntensitySlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.AOIntensity = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedAORadiusSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedAORadiusSliderLabel", "Radius");

                    _advancedAORadiusSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedAORadiusSlider", 0f, 4f, 0.1f, ModProperties.Instance.ActiveProfile.AORadius);
                    _advancedAORadiusSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.AORadius = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedAOSampleCountDropDownLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedAOSampleCountDropDownLabel", "Sample Count");

                    _advancedAOSampleCountDropDown = UIUtils.CreateDropDown(_advancedScrollablePanel, "AdvancedAOSampleCountDropDown");
                    _advancedAOSampleCountDropDown.items = ModInvariables.AOSampleCount;
                    _advancedAOSampleCountDropDown.selectedIndex = ModProperties.Instance.ActiveProfile.AOSampleCount;
                    _advancedAOSampleCountDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.AOSampleCount = ConvertAmbientOcclusionSampleCount(value);
                        ModConfig.Instance.Apply();
                    };

                    _advancedAODownsamplingCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedAODownsamplingCheckBox", "Downsampling", ModProperties.Instance.ActiveProfile.AODownsampling);
                    _advancedAODownsamplingCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.AODownsampling = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedAOForceForwardCompatibilityCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedAOForceForwardCompatibilityCheckBox", "Force Forward Compatibility", ModProperties.Instance.ActiveProfile.AOForceForwardCompatibility);
                    _advancedAOForceForwardCompatibilityCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.AOForceForwardCompatibility = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedAOAmbientOnlyCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedAOAmbientOnlyCheckBox", "Ambient Only", ModProperties.Instance.ActiveProfile.AOAmbientOnly);
                    _advancedAOAmbientOnlyCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.AOAmbientOnly = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedAOHighPrecisionCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedAOHighPrecisionCheckBox", "High Precision", ModProperties.Instance.ActiveProfile.AOHighPrecision);
                    _advancedAOHighPrecisionCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.AOHighPrecision = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedAODivider = UIUtils.CreateDivider(_advancedScrollablePanel, "AdvancedAODivider");

                    // --- Bloom ---
                    _advancedBloomTitle = UIUtils.CreateTitle(_advancedScrollablePanel, "AdvancedBloomTitle", "Bloom");

                    _advancedBloomVanillaBloomCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedBloomVanillaBloomCheckBox", "Vanilla Bloom Enabled", ModProperties.Instance.ActiveProfile.BloomVanillaBloomEnabled);
                    _advancedBloomVanillaBloomCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.BloomVanillaBloomEnabled = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedBloomIntensitySliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedBloomIntensitySliderLabel", "Intensity");

                    _advancedBloomIntensitySlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedBloomIntensitySlider", 0f, 1f, 0.1f, ModProperties.Instance.ActiveProfile.BloomIntensity);
                    _advancedBloomIntensitySlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.BloomIntensity = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedBloomThresholdSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedBloomThresholdSliderLabel", "Threshold");

                    _advancedBloomThresholdSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedBloomThresholdSlider", 0f, 2.2f, 0.1f, ModProperties.Instance.ActiveProfile.BloomThreshold);
                    _advancedAORadiusSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.BloomThreshold = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedBloomSoftKneeSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedBloomSoftKneeSliderLabel", "Soft Knee");

                    _advancedBloomSoftKneeSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedBloomSoftKneeSlider", 0f, 1f, 0.1f, ModProperties.Instance.ActiveProfile.BloomSoftKnee);
                    _advancedBloomSoftKneeSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.BloomSoftKnee = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedBloomRadiusSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedBloomRadiusSliderLabel", "Radius");

                    _advancedBloomRadiusSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedBloomRadiusSlider", 1f, 7f, 0.1f, ModProperties.Instance.ActiveProfile.BloomRadius);
                    _advancedBloomRadiusSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.BloomRadius = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedBloomAntiFlickerCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedBloomAntiFlickerCheckBox", "Anti Flicker", ModProperties.Instance.ActiveProfile.BloomAntiFlicker);
                    _advancedBloomAntiFlickerCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.BloomAntiFlicker = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedBloomDivider = UIUtils.CreateDivider(_advancedScrollablePanel, "AdvancedBloomDivider");

                    // --- Color Grading ---
                    _advancedCGTitle = UIUtils.CreateTitle(_advancedScrollablePanel, "AdvancedCGTitle", "Color Grading");

                    _advancedCGVanillaTonemappingCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedCGVanillaTonemappingCheckBox", "Vanilla Tonemapping Enabled", ModProperties.Instance.ActiveProfile.CGVanillaTonemappingEnabled);
                    _advancedCGVanillaTonemappingCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGVanillaTonemappingEnabled = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedCGVanillaColorCorrectionLUTCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedCGVanillaColorCorrectionLUTCheckBox", "Vanilla Color Correction LUT", ModProperties.Instance.ActiveProfile.CGVanillaColorCorrectionLUTEnabled);
                    _advancedCGVanillaColorCorrectionLUTCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGVanillaColorCorrectionLUTEnabled = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedCGPostExposureSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGPostExposureSliderLabel", "Post Exposure");

                    _advancedCGPostExposureSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGPostExposureSlider", -2f, 2f, 0.1f, ModProperties.Instance.ActiveProfile.CGPostExposure);
                    _advancedCGPostExposureSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGPostExposure = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedCGTemperatureSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGTemperatureSliderLabel", "Temperature");

                    _advancedCGTemperatureSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGTemperatureSlider", -100f, 100f, 1f, ModProperties.Instance.ActiveProfile.CGTemperature);
                    _advancedCGTemperatureSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGTemperature = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedCGTintSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGTintSliderLabel", "Tint");

                    _advancedCGTintSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGTintSlider", -100f, 100f, 1f, ModProperties.Instance.ActiveProfile.CGTint);
                    _advancedCGTintSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGTint = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedCGHueShiftSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGHueShiftSliderLabel", "Hue Shift");

                    _advancedCGHueShiftSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGHueShiftSlider", -180f, 180f, 1f, ModProperties.Instance.ActiveProfile.CGHueShift);
                    _advancedCGHueShiftSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGHueShift = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedCGSaturationSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGSaturationSliderLabel", "Saturation");

                    _advancedCGSaturationSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGSaturationSlider", 0f, 2f, 0.1f, ModProperties.Instance.ActiveProfile.CGSaturation);
                    _advancedCGSaturationSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGSaturation = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedCGContrastSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGContrastSliderLabel", "Contrast");

                    _advancedCGContrastSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGContrastSlider", 0f, 2f, 0.1f, ModProperties.Instance.ActiveProfile.CGContrast);
                    _advancedCGContrastSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGContrast = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedCGTonemapperDropDownLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGTonemapperDropDownLabel", "Tonemapper");

                    _advancedCGTonemapperDropDown = UIUtils.CreateDropDown(_advancedScrollablePanel, "AdvancedCGTonemapperDropDown");
                    _advancedCGTonemapperDropDown.items = ModInvariables.CGTonemapper;
                    _advancedCGTonemapperDropDown.selectedIndex = ModProperties.Instance.ActiveProfile.CGTonemapper;
                    _advancedCGTonemapperDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGTonemapper = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedCGNeutralBlackInSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralBlackInSliderLabel", "Neutral Black In");

                    _advancedCGNeutralBlackInSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralBlackInSlider", -0.1f, 0.1f, 0.01f, ModProperties.Instance.ActiveProfile.CGNeutralBlackIn);
                    _advancedCGNeutralBlackInSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGNeutralBlackIn = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedCGNeutralWhiteInSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralWhiteInSliderLabel", "Neutral White In");

                    _advancedCGNeutralWhiteInSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralWhiteInSlider", 1f, 20f, 1f, ModProperties.Instance.ActiveProfile.CGNeutralWhiteIn);
                    _advancedCGNeutralWhiteInSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGNeutralWhiteIn = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedCGNeutralBlackOutSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralBlackOutSliderLabel", "Neutral Black Out");

                    _advancedCGNeutralBlackOutSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralBlackOutSlider", -0.09f, 0.1f, 0.01f, ModProperties.Instance.ActiveProfile.CGNeutralBlackOut);
                    _advancedCGNeutralBlackOutSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGNeutralBlackOut = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedCGNeutralWhiteOutSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralWhiteOutSliderLabel", "Neutral White Out");

                    _advancedCGNeutralWhiteOutSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralWhiteOutSlider", 1f, 19f, 1f, ModProperties.Instance.ActiveProfile.CGNeutralWhiteOut);
                    _advancedCGNeutralWhiteOutSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGNeutralWhiteOut = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedCGNeutralWhiteLevelSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralWhiteLevelSliderLabel", "Neutral White Level");

                    _advancedCGNeutralWhiteLevelSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralWhiteLevelSlider", 0.1f, 20f, 1f, ModProperties.Instance.ActiveProfile.CGNeutralWhiteLevel);
                    _advancedCGNeutralWhiteLevelSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGNeutralWhiteLevel = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedCGNeutralWhiteClipSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralWhiteClipSliderLabel", "Neutral White Clip");

                    _advancedCGNeutralWhiteClipSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralWhiteClipSlider", 1f, 10f, 0.5f, ModProperties.Instance.ActiveProfile.CGNeutralWhiteClip);
                    _advancedCGNeutralWhiteClipSlider.eventValueChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGNeutralWhiteClip = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedCGDivider = UIUtils.CreateDivider(_advancedScrollablePanel, "AdvancedCGDivider");
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] MainPanel:CreateUI -> Exception: " + e.Message);
            }
        }

        private void UpdateUI()
        {
            try
            {
                absolutePosition = new Vector3(ModConfig.Instance.PanelPositionX, ModConfig.Instance.PanelPositionY);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] MainPanel:UpdateUI -> Exception: " + e.Message);
            }
        }

        private void ApplyActiveProfile()
        {
            try
            {
                _optionsAntiAliasingDropDown.selectedIndex = ModProperties.Instance.ActiveProfile.AntialiasingTechnique;
                _optionsAmbientOcclusionCheckBox.isChecked = ModProperties.Instance.ActiveProfile.AmbientOcclusionEnabled;
                _optionsBloomCheckBox.isChecked = ModProperties.Instance.ActiveProfile.BloomEnabled;
                _optionsColorGradingCheckBox.isChecked = ModProperties.Instance.ActiveProfile.ColorGradingEnabled;

                _advancedFXAAQualityDropDown.selectedIndex = ModProperties.Instance.ActiveProfile.FXAAQuality;

                _advancedTAAJitterSpreadSlider.value = ModProperties.Instance.ActiveProfile.TAAJitterSpread;
                _advancedTAASharpenSlider.value = ModProperties.Instance.ActiveProfile.TAASharpen;
                _advancedTAAStationaryBlendingSlider.value = ModProperties.Instance.ActiveProfile.TAAStationaryBlending;
                _advancedTAAMotionBlendingSlider.value = ModProperties.Instance.ActiveProfile.TAAMotionBlending;

                _advancedAOIntensitySlider.value = ModProperties.Instance.ActiveProfile.AOIntensity;
                _advancedAORadiusSlider.value = ModProperties.Instance.ActiveProfile.AORadius;
                _advancedAOSampleCountDropDown.selectedIndex = ModProperties.Instance.ActiveProfile.AOSampleCount;
                _advancedAODownsamplingCheckBox.isChecked = ModProperties.Instance.ActiveProfile.AODownsampling;
                _advancedAOForceForwardCompatibilityCheckBox.isChecked = ModProperties.Instance.ActiveProfile.AOForceForwardCompatibility;
                _advancedAOAmbientOnlyCheckBox.isChecked = ModProperties.Instance.ActiveProfile.AOAmbientOnly;
                _advancedAOHighPrecisionCheckBox.isChecked = ModProperties.Instance.ActiveProfile.AOHighPrecision;

                _advancedBloomVanillaBloomCheckBox.isChecked = ModProperties.Instance.ActiveProfile.BloomVanillaBloomEnabled;
                _advancedBloomIntensitySlider.value = ModProperties.Instance.ActiveProfile.BloomIntensity;
                _advancedBloomThresholdSlider.value = ModProperties.Instance.ActiveProfile.BloomThreshold;
                _advancedBloomSoftKneeSlider.value = ModProperties.Instance.ActiveProfile.BloomSoftKnee;
                _advancedBloomRadiusSlider.value = ModProperties.Instance.ActiveProfile.BloomRadius;
                _advancedBloomAntiFlickerCheckBox.isChecked = ModProperties.Instance.ActiveProfile.BloomAntiFlicker;

                _advancedCGVanillaTonemappingCheckBox.isChecked = ModProperties.Instance.ActiveProfile.CGVanillaTonemappingEnabled;
                _advancedCGVanillaColorCorrectionLUTCheckBox.isChecked = ModProperties.Instance.ActiveProfile.CGVanillaColorCorrectionLUTEnabled;
                _advancedCGPostExposureSlider.value = ModProperties.Instance.ActiveProfile.CGPostExposure;
                _advancedCGTemperatureSlider.value = ModProperties.Instance.ActiveProfile.CGTemperature;
                _advancedCGTintSlider.value = ModProperties.Instance.ActiveProfile.CGTint;
                _advancedCGHueShiftSlider.value = ModProperties.Instance.ActiveProfile.CGHueShift;
                _advancedCGSaturationSlider.value = ModProperties.Instance.ActiveProfile.CGSaturation;
                _advancedCGContrastSlider.value = ModProperties.Instance.ActiveProfile.CGContrast;
                _advancedCGTonemapperDropDown.selectedIndex = ModProperties.Instance.ActiveProfile.CGTonemapper;
                _advancedCGNeutralBlackInSlider.value = ModProperties.Instance.ActiveProfile.CGNeutralBlackIn;
                _advancedCGNeutralWhiteInSlider.value = ModProperties.Instance.ActiveProfile.CGNeutralWhiteIn;
                _advancedCGNeutralBlackOutSlider.value = ModProperties.Instance.ActiveProfile.CGNeutralBlackOut;
                _advancedCGNeutralWhiteOutSlider.value = ModProperties.Instance.ActiveProfile.CGNeutralWhiteOut;
                _advancedCGNeutralWhiteLevelSlider.value = ModProperties.Instance.ActiveProfile.CGNeutralWhiteLevel;
                _advancedCGNeutralWhiteClipSlider.value = ModProperties.Instance.ActiveProfile.CGNeutralWhiteClip;
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] MainPanel:ApplyActiveProfile -> Exception: " + e.Message);
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
