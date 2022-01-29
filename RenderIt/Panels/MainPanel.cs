using ColossalFramework.PlatformServices;
using ColossalFramework.UI;
using System;
using System.Linq;
using UnityEngine;

namespace RenderIt.Panels
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

        private UILabel _profilesDropDownLabel;
        private UIDropDown _profilesDropDown;
        private UITextField _profilesUITextField;
        private UIPanel _profilesButtonsPanel;
        private UIButton _profilesAddButton;
        private UIButton _profilesRemoveButton;
        private UIButton _profilesRenameButton;
        private UIButton _profilesSaveButton;

        private UILabel _advancedPostProcessingTitle;
        private UILabel _optionsAntiAliasingDropDownLabel;
        private UIDropDown _optionsAntiAliasingDropDown;
        private UICheckBox _optionsAmbientOcclusionCheckBox;
        private UICheckBox _optionsBloomCheckBox;
        private UICheckBox _optionsColorGradingCheckBox;

        private UIScrollablePanel _advancedScrollablePanel;
        private UIScrollbar _advancedScrollbar;
        private UISlicedSprite _advancedScrollbarTrack;
        private UISlicedSprite _advancedScrollbarThumb;

        private UILabel _advancedFXAATitle;
        private UILabel _advancedFXAAQualityDropDownLabel;
        private UIDropDown _advancedFXAAQualityDropDown;
        private UISprite _advancedFXAADivider;

        private UILabel _advancedTAATitle;
        private UILabel _advancedTAAJitterSpreadSliderLabel;
        private UILabel _advancedTAAJitterSpreadSliderNumeral;
        private UISlider _advancedTAAJitterSpreadSlider;
        private UILabel _advancedTAASharpenSliderLabel;
        private UILabel _advancedTAASharpenSliderNumeral;
        private UISlider _advancedTAASharpenSlider;
        private UILabel _advancedTAAStationaryBlendingSliderLabel;
        private UILabel _advancedTAAStationaryBlendingSliderNumeral;
        private UISlider _advancedTAAStationaryBlendingSlider;
        private UILabel _advancedTAAMotionBlendingSliderLabel;
        private UILabel _advancedTAAMotionBlendingSliderNumeral;
        private UISlider _advancedTAAMotionBlendingSlider;
        private UISprite _advancedTAADivider;

        private UILabel _advancedAOTitle;
        private UILabel _advancedAOIntensitySliderLabel;
        private UILabel _advancedAOIntensitySliderNumeral;
        private UISlider _advancedAOIntensitySlider;
        private UILabel _advancedAORadiusSliderLabel;
        private UILabel _advancedAORadiusSliderNumeral;
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
        private UILabel _advancedBloomIntensitySliderNumeral;
        private UISlider _advancedBloomIntensitySlider;
        private UILabel _advancedBloomThresholdSliderLabel;
        private UILabel _advancedBloomThresholdSliderNumeral;
        private UISlider _advancedBloomThresholdSlider;
        private UILabel _advancedBloomSoftKneeSliderLabel;
        private UILabel _advancedBloomSoftKneeSliderNumeral;
        private UISlider _advancedBloomSoftKneeSlider;
        private UILabel _advancedBloomRadiusSliderLabel;
        private UILabel _advancedBloomRadiusSliderNumeral;
        private UISlider _advancedBloomRadiusSlider;
        private UICheckBox _advancedBloomAntiFlickerCheckBox;
        private UISprite _advancedBloomDivider;

        private UILabel _advancedCGTitle;
        private UICheckBox _advancedCGVanillaTonemappingCheckBox;
        private UICheckBox _advancedCGVanillaColorCorrectionLUTCheckBox;
        private UILabel _advancedCGPostExposureSliderLabel;
        private UILabel _advancedCGPostExposureSliderNumeral;
        private UISlider _advancedCGPostExposureSlider;
        private UILabel _advancedCGTemperatureSliderLabel;
        private UILabel _advancedCGTemperatureSliderNumeral;
        private UISlider _advancedCGTemperatureSlider;
        private UILabel _advancedCGTintSliderLabel;
        private UILabel _advancedCGTintSliderNumeral;
        private UISlider _advancedCGTintSlider;
        private UILabel _advancedCGHueShiftSliderLabel;
        private UILabel _advancedCGHueShiftSliderNumeral;
        private UISlider _advancedCGHueShiftSlider;
        private UILabel _advancedCGSaturationSliderLabel;
        private UILabel _advancedCGSaturationSliderNumeral;
        private UISlider _advancedCGSaturationSlider;
        private UILabel _advancedCGContrastSliderLabel;
        private UILabel _advancedCGContrastSliderNumeral;
        private UISlider _advancedCGContrastSlider;
        private UILabel _advancedCGTonemapperDropDownLabel;
        private UIDropDown _advancedCGTonemapperDropDown;
        private UILabel _advancedCGNeutralBlackInSliderLabel;
        private UILabel _advancedCGNeutralBlackInSliderNumeral;
        private UISlider _advancedCGNeutralBlackInSlider;
        private UILabel _advancedCGNeutralWhiteInSliderLabel;
        private UILabel _advancedCGNeutralWhiteInSliderNumeral;
        private UISlider _advancedCGNeutralWhiteInSlider;
        private UILabel _advancedCGNeutralBlackOutSliderLabel;
        private UILabel _advancedCGNeutralBlackOutSliderNumeral;
        private UISlider _advancedCGNeutralBlackOutSlider;
        private UILabel _advancedCGNeutralWhiteOutSliderLabel;
        private UILabel _advancedCGNeutralWhiteOutSliderNumeral;
        private UISlider _advancedCGNeutralWhiteOutSlider;
        private UILabel _advancedCGNeutralWhiteLevelSliderLabel;
        private UILabel _advancedCGNeutralWhiteLevelSliderNumeral;
        private UISlider _advancedCGNeutralWhiteLevelSlider;
        private UILabel _advancedCGNeutralWhiteClipSliderLabel;
        private UILabel _advancedCGNeutralWhiteClipSliderNumeral;
        private UISlider _advancedCGNeutralWhiteClipSlider;
        private UILabel _advancedCGChannelDropDownLabel;
        private UIDropDown _advancedCGChannelDropDown;
        private UILabel _advancedCGChannelRedSliderLabel;
        private UILabel _advancedCGChannelRedSliderNumeral;
        private UISlider _advancedCGChannelRedSlider;
        private UILabel _advancedCGChannelGreenSliderLabel;
        private UILabel _advancedCGChannelGreenSliderNumeral;
        private UISlider _advancedCGChannelGreenSlider;
        private UILabel _advancedCGChannelBlueSliderLabel;
        private UILabel _advancedCGChannelBlueSliderNumeral;
        private UISlider _advancedCGChannelBlueSlider;

        private UISprite _advancedCGDivider;

        public override void Awake()
        {
            base.Awake();

            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] MainPanel:Awake -> Exception: " + e.Message);
            }
        }

        public override void Start()
        {
            base.Start();

            try
            {
                if (ModConfig.Instance.PanelPositionX == 0f && ModConfig.Instance.PanelPositionY == 0f)
                {
                    ModProperties.Instance.ResetPanelPosition();
                }

                CreateUI();
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] MainPanel:Start -> Exception: " + e.Message);
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
                Debug.Log("[Render It!] MainPanel:Update -> Exception: " + e.Message);
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
                DestroyGameObject(_tabstrip);
                DestroyGameObject(_tabContainer);
                DestroyGameObject(_templateButton);
                DestroyGameObject(_profilesDropDownLabel);
                DestroyGameObject(_profilesDropDown);
                DestroyGameObject(_profilesUITextField);
                DestroyGameObject(_profilesButtonsPanel);
                DestroyGameObject(_profilesAddButton);
                DestroyGameObject(_profilesRemoveButton);
                DestroyGameObject(_profilesRenameButton);
                DestroyGameObject(_profilesSaveButton);
                DestroyGameObject(_advancedPostProcessingTitle);
                DestroyGameObject(_optionsAntiAliasingDropDownLabel);
                DestroyGameObject(_optionsAntiAliasingDropDown);
                DestroyGameObject(_optionsAmbientOcclusionCheckBox);
                DestroyGameObject(_optionsBloomCheckBox);
                DestroyGameObject(_optionsColorGradingCheckBox);
                DestroyGameObject(_advancedScrollablePanel);
                DestroyGameObject(_advancedScrollbar);
                DestroyGameObject(_advancedScrollbarTrack);
                DestroyGameObject(_advancedScrollbarThumb);
                DestroyGameObject(_advancedFXAATitle);
                DestroyGameObject(_advancedFXAAQualityDropDownLabel);
                DestroyGameObject(_advancedFXAAQualityDropDown);
                DestroyGameObject(_advancedFXAADivider);
                DestroyGameObject(_advancedTAATitle);
                DestroyGameObject(_advancedTAAJitterSpreadSliderLabel);
                DestroyGameObject(_advancedTAAJitterSpreadSliderNumeral);
                DestroyGameObject(_advancedTAAJitterSpreadSlider);
                DestroyGameObject(_advancedTAASharpenSliderLabel);
                DestroyGameObject(_advancedTAASharpenSliderNumeral);
                DestroyGameObject(_advancedTAASharpenSlider);
                DestroyGameObject(_advancedTAAStationaryBlendingSliderLabel);
                DestroyGameObject(_advancedTAAStationaryBlendingSliderNumeral);
                DestroyGameObject(_advancedTAAStationaryBlendingSlider);
                DestroyGameObject(_advancedTAAMotionBlendingSliderLabel);
                DestroyGameObject(_advancedTAAMotionBlendingSliderNumeral);
                DestroyGameObject(_advancedTAAMotionBlendingSlider);
                DestroyGameObject(_advancedTAADivider);
                DestroyGameObject(_advancedAOTitle);
                DestroyGameObject(_advancedAOIntensitySliderLabel);
                DestroyGameObject(_advancedAOIntensitySliderNumeral);
                DestroyGameObject(_advancedAOIntensitySlider);
                DestroyGameObject(_advancedAORadiusSliderLabel);
                DestroyGameObject(_advancedAORadiusSliderNumeral);
                DestroyGameObject(_advancedAORadiusSlider);
                DestroyGameObject(_advancedAOSampleCountDropDownLabel);
                DestroyGameObject(_advancedAOSampleCountDropDown);
                DestroyGameObject(_advancedAODownsamplingCheckBox);
                DestroyGameObject(_advancedAOForceForwardCompatibilityCheckBox);
                DestroyGameObject(_advancedAOAmbientOnlyCheckBox);
                DestroyGameObject(_advancedAOHighPrecisionCheckBox);
                DestroyGameObject(_advancedAODivider);
                DestroyGameObject(_advancedBloomTitle);
                DestroyGameObject(_advancedBloomVanillaBloomCheckBox);
                DestroyGameObject(_advancedBloomIntensitySliderLabel);
                DestroyGameObject(_advancedBloomIntensitySliderNumeral);
                DestroyGameObject(_advancedBloomIntensitySlider);
                DestroyGameObject(_advancedBloomThresholdSliderLabel);
                DestroyGameObject(_advancedBloomThresholdSliderNumeral);
                DestroyGameObject(_advancedBloomThresholdSlider);
                DestroyGameObject(_advancedBloomSoftKneeSliderLabel);
                DestroyGameObject(_advancedBloomSoftKneeSliderNumeral);
                DestroyGameObject(_advancedBloomSoftKneeSlider);
                DestroyGameObject(_advancedBloomRadiusSliderLabel);
                DestroyGameObject(_advancedBloomRadiusSliderNumeral);
                DestroyGameObject(_advancedBloomRadiusSlider);
                DestroyGameObject(_advancedBloomAntiFlickerCheckBox);
                DestroyGameObject(_advancedBloomDivider);
                DestroyGameObject(_advancedCGTitle);
                DestroyGameObject(_advancedCGVanillaTonemappingCheckBox);
                DestroyGameObject(_advancedCGVanillaColorCorrectionLUTCheckBox);
                DestroyGameObject(_advancedCGVanillaColorCorrectionLUTCheckBox);
                DestroyGameObject(_advancedCGPostExposureSliderLabel);
                DestroyGameObject(_advancedCGPostExposureSliderNumeral);
                DestroyGameObject(_advancedCGPostExposureSlider);
                DestroyGameObject(_advancedCGTemperatureSliderLabel);
                DestroyGameObject(_advancedCGTemperatureSliderNumeral);
                DestroyGameObject(_advancedCGTemperatureSlider);
                DestroyGameObject(_advancedCGTintSliderLabel);
                DestroyGameObject(_advancedCGTintSliderNumeral);
                DestroyGameObject(_advancedCGTintSlider);
                DestroyGameObject(_advancedCGHueShiftSliderLabel);
                DestroyGameObject(_advancedCGHueShiftSliderNumeral);
                DestroyGameObject(_advancedCGHueShiftSlider);
                DestroyGameObject(_advancedCGSaturationSliderLabel);
                DestroyGameObject(_advancedCGSaturationSliderNumeral);
                DestroyGameObject(_advancedCGSaturationSlider);
                DestroyGameObject(_advancedCGContrastSliderLabel);
                DestroyGameObject(_advancedCGContrastSliderNumeral);
                DestroyGameObject(_advancedCGContrastSlider);
                DestroyGameObject(_advancedCGTonemapperDropDownLabel);
                DestroyGameObject(_advancedCGTonemapperDropDown);
                DestroyGameObject(_advancedCGNeutralBlackInSliderLabel);
                DestroyGameObject(_advancedCGNeutralBlackInSliderNumeral);
                DestroyGameObject(_advancedCGNeutralBlackInSlider);
                DestroyGameObject(_advancedCGNeutralWhiteInSliderLabel);
                DestroyGameObject(_advancedCGNeutralWhiteInSliderNumeral);
                DestroyGameObject(_advancedCGNeutralWhiteInSlider);
                DestroyGameObject(_advancedCGNeutralBlackOutSliderLabel);
                DestroyGameObject(_advancedCGNeutralBlackOutSliderNumeral);
                DestroyGameObject(_advancedCGNeutralBlackOutSlider);
                DestroyGameObject(_advancedCGNeutralWhiteOutSliderLabel);
                DestroyGameObject(_advancedCGNeutralWhiteOutSliderNumeral);
                DestroyGameObject(_advancedCGNeutralWhiteOutSlider);
                DestroyGameObject(_advancedCGNeutralWhiteLevelSliderLabel);
                DestroyGameObject(_advancedCGNeutralWhiteLevelSliderNumeral);
                DestroyGameObject(_advancedCGNeutralWhiteLevelSlider);
                DestroyGameObject(_advancedCGNeutralWhiteClipSliderLabel);
                DestroyGameObject(_advancedCGNeutralWhiteClipSliderNumeral);
                DestroyGameObject(_advancedCGNeutralWhiteClipSlider);
                DestroyGameObject(_advancedCGChannelDropDownLabel);
                DestroyGameObject(_advancedCGChannelDropDown);
                DestroyGameObject(_advancedCGChannelRedSliderLabel);
                DestroyGameObject(_advancedCGChannelRedSliderNumeral);
                DestroyGameObject(_advancedCGChannelRedSlider);
                DestroyGameObject(_advancedCGChannelGreenSliderLabel);
                DestroyGameObject(_advancedCGChannelGreenSliderNumeral);
                DestroyGameObject(_advancedCGChannelGreenSlider);
                DestroyGameObject(_advancedCGChannelBlueSliderLabel);
                DestroyGameObject(_advancedCGChannelBlueSliderNumeral);
                DestroyGameObject(_advancedCGChannelBlueSlider);

                DestroyGameObject(_advancedCGDivider);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] MainPanel:OnDestroy -> Exception: " + e.Message);
            }
        }

        private void DestroyGameObject(UIComponent component)
        {
            if (component != null)
            {
                Destroy(component.gameObject);
            }
        }

        public void ForceUpdateUI()
        {
            UpdateUI();
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

                    _profilesDropDownLabel = UIUtils.CreateLabel(panel, "ProfilesDropDownLabel", "Active");

                    _profilesDropDown = UIUtils.CreateDropDown(panel, "ProfilesDropDown");
                    foreach (Profile profile in ModConfig.Instance.Profiles)
                    {
                        _profilesDropDown.AddItem(profile.Name);
                    }
                    _profilesDropDown.selectedValue = ModConfig.Instance.Profiles.Find(x => x.Active == true).Name;
                    _profilesDropDown.eventSelectedIndexChanged += (component, value) =>
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

                    _profilesUITextField = UIUtils.CreateTextField(panel, "ProfilesTextField", "");
                    _profilesUITextField.isVisible = false;
                    _profilesUITextField.eventTextSubmitted += (component, value) =>
                    {
                        if (ModConfig.Instance.Profiles.Count > 1)
                        {
                            _profilesUITextField.isVisible = false;

                            ModConfig.Instance.Profiles[_profilesDropDown.selectedIndex].Name = value;

                            _profilesDropDown.items.SetValue(value, _profilesDropDown.selectedIndex);

                            _profilesDropDown.isVisible = true;
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
                            string profileName = string.Empty;

                            if (PlatformService.active && PlatformService.platformType == PlatformType.Steam)
                            {
                                profileName = PlatformService.personaName.ToString() + " - " + DateTime.Now.ToString("MM/dd/yy HH:mm:ss");
                            }
                            else
                            {
                                profileName = DateTime.Now.ToString("MM/dd/yy HH:mm:ss");
                            }

                            Profile profile = new Profile
                            {
                                Name = profileName,
                                Active = true
                            };
                            ModConfig.Instance.Profiles.Add(profile);
                            ModProperties.Instance.ActiveProfile = profile;

                            _profilesDropDown.AddItem(profile.Name);
                            _profilesDropDown.selectedValue = profile.Name;

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
                                ModConfig.Instance.Profiles.Remove(ModConfig.Instance.Profiles[_profilesDropDown.selectedIndex]);
                                ModProperties.Instance.ActiveProfile = ModConfig.Instance.Profiles[0];

                                _profilesDropDown.items = _profilesDropDown.items.Where((w, i) => i != _profilesDropDown.selectedIndex).ToArray();
                                _profilesDropDown.selectedValue = ModConfig.Instance.Profiles[0].Name;
                            }

                            eventParam.Use();
                        }
                    };

                    _profilesRenameButton = UIUtils.CreatePanelButton(_profilesButtonsPanel, "ProfilesRenameButton", "Rename");
                    _profilesRenameButton.tooltip = "Click to rename current active profile";
                    _profilesRenameButton.relativePosition = new Vector3(185f, 0f);
                    _profilesRenameButton.eventClick += (component, eventParam) =>
                    {
                        if (!eventParam.used)
                        {
                            if (ModConfig.Instance.Profiles.Count > 1)
                            {
                                _profilesDropDown.isVisible = false;

                                _profilesUITextField.text = ModConfig.Instance.Profiles[_profilesDropDown.selectedIndex].Name;

                                _profilesUITextField.isVisible = true;
                                _profilesUITextField.Focus();
                            }

                            eventParam.Use();
                        }
                    };

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

                    _advancedPostProcessingTitle = UIUtils.CreateTitle(panel, "AdvancedPostProcessingTitle", "Post-Processing");
                    _advancedPostProcessingTitle.tooltip = "Post-processing is the process of applying full-screen filters and effects to a camera's image buffer before it is displayed to screen";

                    _optionsAntiAliasingDropDownLabel = UIUtils.CreateLabel(panel, "OptionsAntiAliasingDropDownLabel", "Anti-aliasing Technique");
                    _optionsAntiAliasingDropDownLabel.tooltip = "The Anti-aliasing techniques offers a set of algorithms designed to prevent aliasing and give a smoother appearance to graphics.\n\nFor anti-aliasing, the game uses the default Enhanced Subpixel Morphological Anti-Aliasing (SMAA) technique\nbut this can be improved with either Fast Approximate Anti-Aliasing (FXAA) or Temporal Anti-Aliasing (TAA) techniques.";

                    _optionsAntiAliasingDropDown = UIUtils.CreateDropDown(panel, "OptionsAntiAliasingDropDown");
                    _optionsAntiAliasingDropDown.items = ModInvariables.AntialiasingTechnique;
                    _optionsAntiAliasingDropDown.selectedIndex = ModProperties.Instance.ActiveProfile.AntialiasingTechnique;
                    _optionsAntiAliasingDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.AntialiasingTechnique = value;
                        ModConfig.Instance.Apply();

                        if (value == 3)
                        {
                            ConfirmPanel.ShowModal("Depth of Field", "Depth of Field should be disabled when using TAA. Do you want to disable Depth of Field now?", delegate (UIComponent comp, int ret)
                            {
                                if (ret == 1)
                                {
                                    ModUtils.UpdateDepthOfField(false);
                                }
                            });
                        }
                    };

                    _optionsAmbientOcclusionCheckBox = UIUtils.CreateCheckBox(panel, "OptionsAmbientOcclusionCheckBox", "Ambient Occlusion Enabled", ModProperties.Instance.ActiveProfile.AmbientOcclusionEnabled);
                    _optionsAmbientOcclusionCheckBox.tooltip = "Ambient Occlusion darkens creases, holes, intersections and surfaces that are close to each other";
                    _optionsAmbientOcclusionCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.AmbientOcclusionEnabled = value;
                        ModConfig.Instance.Apply();
                    };
                    _optionsBloomCheckBox = UIUtils.CreateCheckBox(panel, "OptionsBloomCheckBox", "Bloom Enabled", ModProperties.Instance.ActiveProfile.BloomEnabled);
                    _optionsBloomCheckBox.tooltip = "Bloom creates fringes of light extending from the borders of bright areas in an image,\ncontributing to the illusion of an extremely bright light overwhelming the camera";
                    _optionsBloomCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.BloomEnabled = value;
                        ModConfig.Instance.Apply();
                    };
                    _optionsColorGradingCheckBox = UIUtils.CreateCheckBox(panel, "OptionsColorGradingCheckBox", "Color Grading Enabled", ModProperties.Instance.ActiveProfile.ColorGradingEnabled);
                    _optionsColorGradingCheckBox.tooltip = "Color Grading alters or corrects the color and luminance of the final image that is rendered";
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
                    _advancedFXAATitle.tooltip = "A fast technique for platforms that don’t support motion vectors. It contains multiple quality presets\nand as such is also suitable as a fallback solution for slower desktop hardware";

                    _advancedFXAAQualityDropDownLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedFXAAQualityDropDownLabel", "Quality");
                    _advancedFXAAQualityDropDownLabel.tooltip = "Set the quality to be used which provides a trade-off between performance and edge quality";

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
                    _advancedTAATitle.tooltip = "An advanced technique where frames are accumulated over time in a history buffer to be used to smooth edges more effectively.\nIt is substantially better at smoothing edges in motion but requires motion vectors and is more expensive than FXAA.\nIdeal for faster desktop hardware";

                    _advancedTAAJitterSpreadSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedTAAJitterSpreadSliderLabel", "Jitter Spread");
                    _advancedTAAJitterSpreadSliderLabel.tooltip = "Set the diameter (in texels) inside which jitter samples are spread. Smaller values result in crisper\nbut a more aliased output. Larger values result in more stable but blurrier output";

                    _advancedTAAJitterSpreadSliderNumeral = UIUtils.CreateLabel(_advancedTAAJitterSpreadSliderLabel, "AdvancedTAAJitterSpreadSliderNumeral", ModProperties.Instance.ActiveProfile.TAAJitterSpread.ToString());
                    _advancedTAAJitterSpreadSliderNumeral.width = 100f;
                    _advancedTAAJitterSpreadSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedTAAJitterSpreadSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedTAAJitterSpreadSliderNumeral.width - 10f, 0f);

                    _advancedTAAJitterSpreadSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedTAAJitterSpreadSlider", 0.1f, 1f, 0.01f, ModProperties.Instance.ActiveProfile.TAAJitterSpread);
                    _advancedTAAJitterSpreadSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedTAAJitterSpreadSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.TAAJitterSpread = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedTAAJitterSpreadSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedTAAJitterSpreadSlider.value = 0.75f;

                            _advancedTAAJitterSpreadSliderNumeral.text = _advancedTAAJitterSpreadSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.TAAJitterSpread = _advancedTAAJitterSpreadSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedTAAStationaryBlendingSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedTAAStationaryBlendingSliderLabel", "Stationary Blending");
                    _advancedTAAStationaryBlendingSliderLabel.tooltip = "Set the blend coefficient for stationary fragments. This setting controls the percentage of history sample\nblended into final color for fragments with minimal active motion";

                    _advancedTAAStationaryBlendingSliderNumeral = UIUtils.CreateLabel(_advancedTAAStationaryBlendingSliderLabel, "AdvancedTAAStationaryBlendingSliderNumeral", ModProperties.Instance.ActiveProfile.TAAStationaryBlending.ToString());
                    _advancedTAAStationaryBlendingSliderNumeral.width = 100f;
                    _advancedTAAStationaryBlendingSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedTAAStationaryBlendingSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedTAAStationaryBlendingSliderNumeral.width - 10f, 0f);

                    _advancedTAAStationaryBlendingSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedTAAStationaryBlendingSlider", 0f, 0.99f, 0.01f, ModProperties.Instance.ActiveProfile.TAAStationaryBlending);
                    _advancedTAAStationaryBlendingSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedTAAStationaryBlendingSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.TAAStationaryBlending = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedTAAStationaryBlendingSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedTAAStationaryBlendingSlider.value = 0.95f;

                            _advancedTAAStationaryBlendingSliderNumeral.text = _advancedTAAStationaryBlendingSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.TAAStationaryBlending = _advancedTAAStationaryBlendingSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedTAAMotionBlendingSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedTAAMotionBlendingSliderLabel", "Motion Blending");
                    _advancedTAAMotionBlendingSliderLabel.tooltip = "Set the blending coefficient for moving fragments. This setting controls the percentage of history sample\nblended into the final color for fragments with significant active motion";

                    _advancedTAAMotionBlendingSliderNumeral = UIUtils.CreateLabel(_advancedTAAMotionBlendingSliderLabel, "AdvancedTAAMotionBlendingSliderNumeral", ModProperties.Instance.ActiveProfile.TAAMotionBlending.ToString());
                    _advancedTAAMotionBlendingSliderNumeral.width = 100f;
                    _advancedTAAMotionBlendingSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedTAAMotionBlendingSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedTAAMotionBlendingSliderNumeral.width - 10f, 0f);

                    _advancedTAAMotionBlendingSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedTAAMotionBlendingSlider", 0f, 0.99f, 0.01f, ModProperties.Instance.ActiveProfile.TAAMotionBlending);
                    _advancedTAAMotionBlendingSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedTAAMotionBlendingSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.TAAMotionBlending = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedTAAMotionBlendingSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedTAAMotionBlendingSlider.value = 0.85f;

                            _advancedTAAMotionBlendingSliderNumeral.text = _advancedTAAMotionBlendingSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.TAAMotionBlending = _advancedTAAMotionBlendingSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedTAASharpenSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedTAASharpenSliderLabel", "Sharpen");
                    _advancedTAASharpenSliderLabel.tooltip = "Set the sharpness to alleviate the slight loss of details in high frequency regions";

                    _advancedTAASharpenSliderNumeral = UIUtils.CreateLabel(_advancedTAASharpenSliderLabel, "AdvancedTAASharpenSliderNumeral", ModProperties.Instance.ActiveProfile.TAASharpen.ToString());
                    _advancedTAASharpenSliderNumeral.width = 100f;
                    _advancedTAASharpenSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedTAASharpenSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedTAASharpenSliderNumeral.width - 10f, 0f);

                    _advancedTAASharpenSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedTAASharpenSlider", 0f, 3f, 0.03f, ModProperties.Instance.ActiveProfile.TAASharpen);
                    _advancedTAASharpenSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedTAASharpenSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.TAASharpen = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedTAASharpenSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedTAASharpenSlider.value = 0.3f;

                            _advancedTAASharpenSliderNumeral.text = _advancedTAASharpenSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.TAASharpen = _advancedTAASharpenSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedTAADivider = UIUtils.CreateDivider(_advancedScrollablePanel, "AdvancedTAADivider");

                    // --- AO ---
                    _advancedAOTitle = UIUtils.CreateTitle(_advancedScrollablePanel, "AdvancedAOTitle", "Ambient Occlusion");
                    _advancedAOTitle.tooltip = "Ambient Occlusion darkens creases, holes, intersections and surfaces that are close to each other";

                    _advancedAOIntensitySliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedAOIntensitySliderLabel", "Intensity");
                    _advancedAOIntensitySliderLabel.tooltip = "Degree of darkness produced";

                    _advancedAOIntensitySliderNumeral = UIUtils.CreateLabel(_advancedAOIntensitySliderLabel, "AdvancedAOIntensitySliderNumeral", ModProperties.Instance.ActiveProfile.AOIntensity.ToString());
                    _advancedAOIntensitySliderNumeral.width = 100f;
                    _advancedAOIntensitySliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedAOIntensitySliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedAOIntensitySliderNumeral.width - 10f, 0f);

                    _advancedAOIntensitySlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedAOIntensitySlider", 0f, 4f, 0.05f, ModProperties.Instance.ActiveProfile.AOIntensity);
                    _advancedAOIntensitySlider.eventValueChanged += (component, value) =>
                    {
                        _advancedAOIntensitySliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.AOIntensity = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedAOIntensitySlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedAOIntensitySlider.value = 1f;

                            _advancedAOIntensitySliderNumeral.text = _advancedAOIntensitySlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.AOIntensity = _advancedAOIntensitySlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedAORadiusSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedAORadiusSliderLabel", "Radius");
                    _advancedAORadiusSliderLabel.tooltip = "Radius of sample points, which affects extent of darkened areas";

                    _advancedAORadiusSliderNumeral = UIUtils.CreateLabel(_advancedAORadiusSliderLabel, "AdvancedAORadiusSliderNumeral", ModProperties.Instance.ActiveProfile.AORadius.ToString());
                    _advancedAORadiusSliderNumeral.width = 100f;
                    _advancedAORadiusSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedAORadiusSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedAORadiusSliderNumeral.width - 10f, 0f);

                    _advancedAORadiusSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedAORadiusSlider", 0f, 4f, 0.05f, ModProperties.Instance.ActiveProfile.AORadius);
                    _advancedAORadiusSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedAORadiusSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.AORadius = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedAORadiusSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedAORadiusSlider.value = 0.3f;

                            _advancedAORadiusSliderNumeral.text = _advancedAORadiusSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.AORadius = _advancedAORadiusSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedAOSampleCountDropDownLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedAOSampleCountDropDownLabel", "Sample Count");
                    _advancedAOSampleCountDropDownLabel.tooltip = "Number of sample points, which affects quality and performance";

                    _advancedAOSampleCountDropDown = UIUtils.CreateDropDown(_advancedScrollablePanel, "AdvancedAOSampleCountDropDown");
                    _advancedAOSampleCountDropDown.items = ModInvariables.AOSampleCount;
                    _advancedAOSampleCountDropDown.selectedIndex = ModProperties.Instance.ActiveProfile.AOSampleCount;
                    _advancedAOSampleCountDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.AOSampleCount = ConvertAmbientOcclusionSampleCount(value);
                        ModConfig.Instance.Apply();
                    };

                    _advancedAODownsamplingCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedAODownsamplingCheckBox", "Downsampling", ModProperties.Instance.ActiveProfile.AODownsampling);
                    _advancedAODownsamplingCheckBox.tooltip = "Halves the resolution of the effect to increase performance at the cost of visual quality";
                    _advancedAODownsamplingCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.AODownsampling = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedAOForceForwardCompatibilityCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedAOForceForwardCompatibilityCheckBox", "Force Forward Compatibility", ModProperties.Instance.ActiveProfile.AOForceForwardCompatibility);
                    _advancedAOForceForwardCompatibilityCheckBox.tooltip = "Forces compatibility with forward rendered objects when working with the deferred rendering path";
                    _advancedAOForceForwardCompatibilityCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.AOForceForwardCompatibility = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedAOHighPrecisionCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedAOHighPrecisionCheckBox", "High Precision", ModProperties.Instance.ActiveProfile.AOHighPrecision);
                    _advancedAOHighPrecisionCheckBox.tooltip = "Uses higher precision depth texture with the forward rendering path which may impact performances";
                    _advancedAOHighPrecisionCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.AOHighPrecision = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedAOAmbientOnlyCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedAOAmbientOnlyCheckBox", "Ambient Only", ModProperties.Instance.ActiveProfile.AOAmbientOnly);
                    _advancedAOAmbientOnlyCheckBox.tooltip = "Enables the ambient-only mode in that ambient occlusion only affects ambient lighting";
                    _advancedAOAmbientOnlyCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.AOAmbientOnly = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedAODivider = UIUtils.CreateDivider(_advancedScrollablePanel, "AdvancedAODivider");

                    // --- Bloom ---
                    _advancedBloomTitle = UIUtils.CreateTitle(_advancedScrollablePanel, "AdvancedBloomTitle", "Bloom");
                    _advancedBloomTitle.tooltip = "Bloom creates fringes of light extending from the borders of bright areas in an image,\ncontributing to the illusion of an extremely bright light overwhelming the camera";

                    _advancedBloomVanillaBloomCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedBloomVanillaBloomCheckBox", "Vanilla Bloom", ModProperties.Instance.ActiveProfile.BloomVanillaBloomEnabled);
                    _advancedBloomVanillaBloomCheckBox.tooltip = "Keeps bloom produced by the game";
                    _advancedBloomVanillaBloomCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.BloomVanillaBloomEnabled = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedBloomIntensitySliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedBloomIntensitySliderLabel", "Intensity");
                    _advancedBloomIntensitySliderLabel.tooltip = "Degree of bloom produced";

                    _advancedBloomIntensitySliderNumeral = UIUtils.CreateLabel(_advancedBloomIntensitySliderLabel, "AdvancedBloomIntensitySliderNumeral", ModProperties.Instance.ActiveProfile.BloomIntensity.ToString());
                    _advancedBloomIntensitySliderNumeral.width = 100f;
                    _advancedBloomIntensitySliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedBloomIntensitySliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedBloomIntensitySliderNumeral.width - 10f, 0f);

                    _advancedBloomIntensitySlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedBloomIntensitySlider", 0f, 1f, 0.01f, ModProperties.Instance.ActiveProfile.BloomIntensity);
                    _advancedBloomIntensitySlider.eventValueChanged += (component, value) =>
                    {
                        _advancedBloomIntensitySliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.BloomIntensity = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedBloomIntensitySlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedBloomIntensitySlider.value = 0.5f;

                            _advancedBloomIntensitySliderNumeral.text = _advancedBloomIntensitySlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.BloomIntensity = _advancedBloomIntensitySlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedBloomThresholdSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedBloomThresholdSliderLabel", "Threshold");
                    _advancedBloomThresholdSliderLabel.tooltip = "Filters out pixels under this level of brightness";

                    _advancedBloomThresholdSliderNumeral = UIUtils.CreateLabel(_advancedBloomThresholdSliderLabel, "AdvancedBloomThresholdSliderNumeral", ModProperties.Instance.ActiveProfile.BloomThreshold.ToString());
                    _advancedBloomThresholdSliderNumeral.width = 100f;
                    _advancedBloomThresholdSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedBloomThresholdSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedBloomThresholdSliderNumeral.width - 10f, 0f);

                    _advancedBloomThresholdSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedBloomThresholdSlider", 0f, 10f, 0.1f, ModProperties.Instance.ActiveProfile.BloomThreshold);
                    _advancedBloomThresholdSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedBloomThresholdSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.BloomThreshold = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedBloomThresholdSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedBloomThresholdSlider.value = 1.1f;

                            _advancedBloomThresholdSliderNumeral.text = _advancedBloomThresholdSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.BloomThreshold = _advancedBloomThresholdSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedBloomSoftKneeSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedBloomSoftKneeSliderLabel", "Soft Knee");
                    _advancedBloomSoftKneeSliderLabel.tooltip = "Makes transition between under/over-threshold gradual";

                    _advancedBloomSoftKneeSliderNumeral = UIUtils.CreateLabel(_advancedBloomSoftKneeSliderLabel, "AdvancedBloomSoftKneeSliderNumeral", ModProperties.Instance.ActiveProfile.BloomSoftKnee.ToString());
                    _advancedBloomSoftKneeSliderNumeral.width = 100f;
                    _advancedBloomSoftKneeSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedBloomSoftKneeSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedBloomSoftKneeSliderNumeral.width - 10f, 0f);

                    _advancedBloomSoftKneeSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedBloomSoftKneeSlider", 0f, 1f, 0.01f, ModProperties.Instance.ActiveProfile.BloomSoftKnee);
                    _advancedBloomSoftKneeSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedBloomSoftKneeSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.BloomSoftKnee = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedBloomSoftKneeSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedBloomSoftKneeSlider.value = 0.5f;

                            _advancedBloomSoftKneeSliderNumeral.text = _advancedBloomSoftKneeSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.BloomSoftKnee = _advancedBloomSoftKneeSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedBloomRadiusSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedBloomRadiusSliderLabel", "Radius");
                    _advancedBloomRadiusSliderLabel.tooltip = "Changes extent of veiling in a screen resolution-independent fashion";

                    _advancedBloomRadiusSliderNumeral = UIUtils.CreateLabel(_advancedBloomRadiusSliderLabel, "AdvancedBloomRadiusSliderNumeral", ModProperties.Instance.ActiveProfile.BloomRadius.ToString());
                    _advancedBloomRadiusSliderNumeral.width = 100f;
                    _advancedBloomRadiusSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedBloomRadiusSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedBloomRadiusSliderNumeral.width - 10f, 0f);

                    _advancedBloomRadiusSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedBloomRadiusSlider", 1f, 7f, 0.05f, ModProperties.Instance.ActiveProfile.BloomRadius);
                    _advancedBloomRadiusSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedBloomRadiusSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.BloomRadius = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedBloomRadiusSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedBloomRadiusSlider.value = 4f;

                            _advancedBloomRadiusSliderNumeral.text = _advancedBloomRadiusSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.BloomRadius = _advancedBloomRadiusSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedBloomAntiFlickerCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedBloomAntiFlickerCheckBox", "Anti Flicker", ModProperties.Instance.ActiveProfile.BloomAntiFlicker);
                    _advancedBloomAntiFlickerCheckBox.tooltip = "Reduces flashing noise with an additional filter";
                    _advancedBloomAntiFlickerCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.BloomAntiFlicker = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedBloomDivider = UIUtils.CreateDivider(_advancedScrollablePanel, "AdvancedBloomDivider");

                    // --- Color Grading ---
                    _advancedCGTitle = UIUtils.CreateTitle(_advancedScrollablePanel, "AdvancedCGTitle", "Color Grading");
                    _advancedCGTitle.tooltip = "Color Grading alters or corrects the color and luminance of the final image that is rendered";

                    _advancedCGVanillaTonemappingCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedCGVanillaTonemappingCheckBox", "Vanilla Tonemapping", ModProperties.Instance.ActiveProfile.CGVanillaTonemappingEnabled);
                    _advancedCGVanillaTonemappingCheckBox.tooltip = "Keeps tonemapping produced by the game";
                    _advancedCGVanillaTonemappingCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGVanillaTonemappingEnabled = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedCGVanillaColorCorrectionLUTCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedCGVanillaColorCorrectionLUTCheckBox", "Vanilla Color Correction LUT", ModProperties.Instance.ActiveProfile.CGVanillaColorCorrectionLUTEnabled);
                    _advancedCGVanillaColorCorrectionLUTCheckBox.tooltip = "Keeps color correction LUT produced by the game";
                    _advancedCGVanillaColorCorrectionLUTCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGVanillaColorCorrectionLUTEnabled = value;
                        ModConfig.Instance.Apply();
                    };

                    _advancedCGPostExposureSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGPostExposureSliderLabel", "Post Exposure");
                    _advancedCGPostExposureSliderLabel.tooltip = "Adjusts the overall exposure of the scene";

                    _advancedCGPostExposureSliderNumeral = UIUtils.CreateLabel(_advancedCGPostExposureSliderLabel, "AdvancedCGPostExposureSliderNumeral", ModProperties.Instance.ActiveProfile.CGPostExposure.ToString());
                    _advancedCGPostExposureSliderNumeral.width = 100f;
                    _advancedCGPostExposureSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGPostExposureSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGPostExposureSliderNumeral.width - 10f, 0f);

                    _advancedCGPostExposureSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGPostExposureSlider", -2f, 2f, 0.05f, ModProperties.Instance.ActiveProfile.CGPostExposure);
                    _advancedCGPostExposureSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGPostExposureSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.CGPostExposure = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedCGPostExposureSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGPostExposureSlider.value = 0f;

                            _advancedCGPostExposureSliderNumeral.text = _advancedCGPostExposureSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.CGPostExposure = _advancedCGPostExposureSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedCGTemperatureSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGTemperatureSliderLabel", "Temperature");
                    _advancedCGTemperatureSliderLabel.tooltip = "Sets the white balance to a custom color temperature";

                    _advancedCGTemperatureSliderNumeral = UIUtils.CreateLabel(_advancedCGTemperatureSliderLabel, "AdvancedCGTemperatureSliderNumeral", ModProperties.Instance.ActiveProfile.CGTemperature.ToString());
                    _advancedCGTemperatureSliderNumeral.width = 100f;
                    _advancedCGTemperatureSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGTemperatureSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGTemperatureSliderNumeral.width - 10f, 0f);

                    _advancedCGTemperatureSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGTemperatureSlider", -100f, 100f, 2f, ModProperties.Instance.ActiveProfile.CGTemperature);
                    _advancedCGTemperatureSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGTemperatureSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.CGTemperature = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedCGTemperatureSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGTemperatureSlider.value = 0f;

                            _advancedCGTemperatureSliderNumeral.text = _advancedCGTemperatureSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.CGTemperature = _advancedCGTemperatureSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedCGTintSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGTintSliderLabel", "Tint");
                    _advancedCGTintSliderLabel.tooltip = "Sets the white balance to compensate for a green or magenta tint";

                    _advancedCGTintSliderNumeral = UIUtils.CreateLabel(_advancedCGTintSliderLabel, "AdvancedCGTintSliderNumeral", ModProperties.Instance.ActiveProfile.CGTint.ToString());
                    _advancedCGTintSliderNumeral.width = 100f;
                    _advancedCGTintSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGTintSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGTintSliderNumeral.width - 10f, 0f);

                    _advancedCGTintSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGTintSlider", -100f, 100f, 2f, ModProperties.Instance.ActiveProfile.CGTint);
                    _advancedCGTintSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGTintSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.CGTint = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedCGTintSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGTintSlider.value = 0f;

                            _advancedCGTintSliderNumeral.text = _advancedCGTintSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.CGTint = _advancedCGTintSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedCGHueShiftSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGHueShiftSliderLabel", "Hue Shift");
                    _advancedCGHueShiftSliderLabel.tooltip = "Shift the hue of all colors";

                    _advancedCGHueShiftSliderNumeral = UIUtils.CreateLabel(_advancedCGHueShiftSliderLabel, "AdvancedCGHueShiftSliderNumeral", ModProperties.Instance.ActiveProfile.CGHueShift.ToString());
                    _advancedCGHueShiftSliderNumeral.width = 100f;
                    _advancedCGHueShiftSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGHueShiftSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGHueShiftSliderNumeral.width - 10f, 0f);

                    _advancedCGHueShiftSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGHueShiftSlider", -180f, 180f, 3f, ModProperties.Instance.ActiveProfile.CGHueShift);
                    _advancedCGHueShiftSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGHueShiftSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.CGHueShift = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedCGHueShiftSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGHueShiftSlider.value = 0f;

                            _advancedCGHueShiftSliderNumeral.text = _advancedCGHueShiftSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.CGHueShift = _advancedCGHueShiftSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedCGSaturationSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGSaturationSliderLabel", "Saturation");
                    _advancedCGSaturationSliderLabel.tooltip = "Pushes the intensity of all colors";

                    _advancedCGSaturationSliderNumeral = UIUtils.CreateLabel(_advancedCGSaturationSliderLabel, "AdvancedCGSaturationSliderNumeral", ModProperties.Instance.ActiveProfile.CGSaturation.ToString());
                    _advancedCGSaturationSliderNumeral.width = 100f;
                    _advancedCGSaturationSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGSaturationSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGSaturationSliderNumeral.width - 10f, 0f);

                    _advancedCGSaturationSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGSaturationSlider", 0f, 2f, 0.02f, ModProperties.Instance.ActiveProfile.CGSaturation);
                    _advancedCGSaturationSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGSaturationSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.CGSaturation = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedCGSaturationSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGSaturationSlider.value = 1f;

                            _advancedCGSaturationSliderNumeral.text = _advancedCGSaturationSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.CGSaturation = _advancedCGSaturationSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedCGContrastSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGContrastSliderLabel", "Contrast");
                    _advancedCGContrastSliderLabel.tooltip = "Expands or shrinks the overall range of tonal values";

                    _advancedCGContrastSliderNumeral = UIUtils.CreateLabel(_advancedCGContrastSliderLabel, "AdvancedCGContrastSliderNumeral", ModProperties.Instance.ActiveProfile.CGContrast.ToString());
                    _advancedCGContrastSliderNumeral.width = 100f;
                    _advancedCGContrastSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGContrastSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGContrastSliderNumeral.width - 10f, 0f);

                    _advancedCGContrastSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGContrastSlider", 0f, 2f, 0.02f, ModProperties.Instance.ActiveProfile.CGContrast);
                    _advancedCGContrastSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGContrastSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.CGContrast = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedCGContrastSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGContrastSlider.value = 1f;

                            _advancedCGContrastSliderNumeral.text = _advancedCGContrastSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.CGContrast = _advancedCGContrastSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedCGTonemapperDropDownLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGTonemapperDropDownLabel", "Tonemapper");
                    _advancedCGTonemapperDropDownLabel.tooltip = "Tonemapping is the process of remapping HDR values of an image into a range suitable to be displayed on screen.\n\nThe Neutral tonemapper only does range-remapping with minimal impact on color hue & saturation.\nThe Filmic (ACES) tonemapper uses a close approximation of the reference ACES tonemapper for a more filmic look";

                    _advancedCGTonemapperDropDown = UIUtils.CreateDropDown(_advancedScrollablePanel, "AdvancedCGTonemapperDropDown");
                    _advancedCGTonemapperDropDown.items = ModInvariables.CGTonemapper;
                    

                    _advancedCGNeutralBlackInSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralBlackInSliderLabel", "Neutral Black In");
                    _advancedCGNeutralBlackInSliderLabel.tooltip = "Inner control point for the black point when using neutral tonemapper";

                    _advancedCGNeutralBlackInSliderNumeral = UIUtils.CreateLabel(_advancedCGNeutralBlackInSliderLabel, "AdvancedCGNeutralBlackInSliderNumeral", ModProperties.Instance.ActiveProfile.CGNeutralBlackIn.ToString());
                    _advancedCGNeutralBlackInSliderNumeral.width = 100f;
                    _advancedCGNeutralBlackInSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGNeutralBlackInSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGNeutralBlackInSliderNumeral.width - 10f, 0f);

                    _advancedCGNeutralBlackInSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralBlackInSlider", -0.1f, 0.1f, 0.002f, ModProperties.Instance.ActiveProfile.CGNeutralBlackIn);
                    _advancedCGNeutralBlackInSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGNeutralBlackInSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.CGNeutralBlackIn = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedCGNeutralBlackInSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGNeutralBlackInSlider.value = 0.02f;

                            _advancedCGNeutralBlackInSliderNumeral.text = _advancedCGNeutralBlackInSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.CGNeutralBlackIn = _advancedCGNeutralBlackInSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedCGNeutralWhiteInSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralWhiteInSliderLabel", "Neutral White In");
                    _advancedCGNeutralWhiteInSliderLabel.tooltip = "Inner control point for the white point when using neutral tonemapper";

                    _advancedCGNeutralWhiteInSliderNumeral = UIUtils.CreateLabel(_advancedCGNeutralWhiteInSliderLabel, "AdvancedCGNeutralWhiteInSliderNumeral", ModProperties.Instance.ActiveProfile.CGNeutralWhiteIn.ToString());
                    _advancedCGNeutralWhiteInSliderNumeral.width = 100f;
                    _advancedCGNeutralWhiteInSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGNeutralWhiteInSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGNeutralWhiteInSliderNumeral.width - 10f, 0f);

                    _advancedCGNeutralWhiteInSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralWhiteInSlider", 1f, 20f, 0.2f, ModProperties.Instance.ActiveProfile.CGNeutralWhiteIn);
                    _advancedCGNeutralWhiteInSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGNeutralWhiteInSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.CGNeutralWhiteIn = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedCGNeutralWhiteInSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGNeutralWhiteInSlider.value = 10f;

                            _advancedCGNeutralWhiteInSliderNumeral.text = _advancedCGNeutralWhiteInSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.CGNeutralWhiteIn = _advancedCGNeutralWhiteInSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedCGNeutralBlackOutSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralBlackOutSliderLabel", "Neutral Black Out");
                    _advancedCGNeutralBlackOutSliderLabel.tooltip = "Outer control point for the black point when using neutral tonemapper";

                    _advancedCGNeutralBlackOutSliderNumeral = UIUtils.CreateLabel(_advancedCGNeutralBlackOutSliderLabel, "AdvancedCGNeutralBlackOutSliderNumeral", ModProperties.Instance.ActiveProfile.CGNeutralBlackOut.ToString());
                    _advancedCGNeutralBlackOutSliderNumeral.width = 100f;
                    _advancedCGNeutralBlackOutSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGNeutralBlackOutSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGNeutralBlackOutSliderNumeral.width - 10f, 0f);

                    _advancedCGNeutralBlackOutSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralBlackOutSlider", -0.09f, 0.1f, 0.002f, ModProperties.Instance.ActiveProfile.CGNeutralBlackOut);
                    _advancedCGNeutralBlackOutSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGNeutralBlackOutSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.CGNeutralBlackOut = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedCGNeutralBlackOutSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGNeutralBlackOutSlider.value = 0f;

                            _advancedCGNeutralBlackOutSliderNumeral.text = _advancedCGNeutralBlackOutSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.CGNeutralBlackOut = _advancedCGNeutralBlackOutSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedCGNeutralWhiteOutSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralWhiteOutSliderLabel", "Neutral White Out");
                    _advancedCGNeutralWhiteOutSliderLabel.tooltip = "Outer control point for the white point when using neutral tonemapper";

                    _advancedCGNeutralWhiteOutSliderNumeral = UIUtils.CreateLabel(_advancedCGNeutralWhiteOutSliderLabel, "AdvancedCGNeutralWhiteOutSliderNumeral", ModProperties.Instance.ActiveProfile.CGNeutralWhiteOut.ToString());
                    _advancedCGNeutralWhiteOutSliderNumeral.width = 100f;
                    _advancedCGNeutralWhiteOutSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGNeutralWhiteOutSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGNeutralWhiteOutSliderNumeral.width - 10f, 0f);

                    _advancedCGNeutralWhiteOutSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralWhiteOutSlider", 1f, 19f, 0.2f, ModProperties.Instance.ActiveProfile.CGNeutralWhiteOut);
                    _advancedCGNeutralWhiteOutSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGNeutralWhiteOutSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.CGNeutralWhiteOut = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedCGNeutralWhiteOutSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGNeutralWhiteOutSlider.value = 10f;

                            _advancedCGNeutralWhiteOutSliderNumeral.text = _advancedCGNeutralWhiteOutSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.CGNeutralWhiteOut = _advancedCGNeutralWhiteOutSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedCGNeutralWhiteLevelSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralWhiteLevelSliderLabel", "Neutral White Level");
                    _advancedCGNeutralWhiteLevelSliderLabel.tooltip = "Pre-curve white point adjustment when using neutral tonemapper";

                    _advancedCGNeutralWhiteLevelSliderNumeral = UIUtils.CreateLabel(_advancedCGNeutralWhiteLevelSliderLabel, "AdvancedCGNeutralWhiteLevelSliderNumeral", ModProperties.Instance.ActiveProfile.CGNeutralWhiteLevel.ToString());
                    _advancedCGNeutralWhiteLevelSliderNumeral.width = 100f;
                    _advancedCGNeutralWhiteLevelSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGNeutralWhiteLevelSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGNeutralWhiteLevelSliderNumeral.width - 10f, 0f);

                    _advancedCGNeutralWhiteLevelSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralWhiteLevelSlider", 0.1f, 20f, 0.1f, ModProperties.Instance.ActiveProfile.CGNeutralWhiteLevel);
                    _advancedCGNeutralWhiteLevelSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGNeutralWhiteLevelSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.CGNeutralWhiteLevel = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedCGNeutralWhiteLevelSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGNeutralWhiteLevelSlider.value = 5.3f;

                            _advancedCGNeutralWhiteLevelSliderNumeral.text = _advancedCGNeutralWhiteLevelSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.CGNeutralWhiteLevel = _advancedCGNeutralWhiteLevelSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedCGNeutralWhiteClipSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralWhiteClipSliderLabel", "Neutral White Clip");
                    _advancedCGNeutralWhiteClipSliderLabel.tooltip = "Post-curve white point adjustment using neutral tonemapper";

                    _advancedCGNeutralWhiteClipSliderNumeral = UIUtils.CreateLabel(_advancedCGNeutralWhiteClipSliderLabel, "AdvancedCGNeutralWhiteClipSliderNumeral", ModProperties.Instance.ActiveProfile.CGNeutralWhiteClip.ToString());
                    _advancedCGNeutralWhiteClipSliderNumeral.width = 100f;
                    _advancedCGNeutralWhiteClipSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGNeutralWhiteClipSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGNeutralWhiteClipSliderNumeral.width - 10f, 0f);

                    _advancedCGNeutralWhiteClipSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralWhiteClipSlider", 1f, 10f, 0.1f, ModProperties.Instance.ActiveProfile.CGNeutralWhiteClip);
                    _advancedCGNeutralWhiteClipSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGNeutralWhiteClipSliderNumeral.text = value.ToString();
                        ModProperties.Instance.ActiveProfile.CGNeutralWhiteClip = value;
                        ModConfig.Instance.Apply();
                    };
                    _advancedCGNeutralWhiteClipSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGNeutralWhiteClipSlider.value = 10f;

                            _advancedCGNeutralWhiteClipSliderNumeral.text = _advancedCGNeutralWhiteClipSlider.value.ToString();
                            ModProperties.Instance.ActiveProfile.CGNeutralWhiteClip = _advancedCGNeutralWhiteClipSlider.value;
                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedCGChannelDropDownLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGChannelDropDownLabel", "Channel");
                    _advancedCGChannelDropDownLabel.tooltip = "The Channel Mixer is used to modify the influence of each input color channel (RGB) on the overall mix of the output channel";

                    _advancedCGChannelDropDown = UIUtils.CreateDropDown(_advancedScrollablePanel, "AdvancedCGChannelDropDown");
                    _advancedCGChannelDropDown.items = ModInvariables.CGChannel;

                    _advancedCGChannelRedSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGChannelRedSliderLabel", "Red");

                    _advancedCGChannelRedSliderNumeral = UIUtils.CreateLabel(_advancedCGChannelRedSliderLabel, "AdvancedCGChannelRedSliderNumeral", "");
                    _advancedCGChannelRedSliderNumeral.width = 100f;
                    _advancedCGChannelRedSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGChannelRedSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGChannelRedSliderNumeral.width - 10f, 0f);

                    _advancedCGChannelRedSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGChannelRedSlider", 0f, 1f, 0.01f, 0f);
                    _advancedCGChannelRedSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGChannelRedSliderNumeral.text = value.ToString();

                        switch (_advancedCGChannelDropDown.selectedIndex)
                        {
                            case 0:
                                ModProperties.Instance.ActiveProfile.CGChannelMixerRedRed = value;
                                break;
                            case 1:
                                ModProperties.Instance.ActiveProfile.CGChannelMixerGreenRed = value;
                                break;
                            case 2:
                                ModProperties.Instance.ActiveProfile.CGChannelMixerBlueRed = value;
                                break;
                        }

                        ModConfig.Instance.Apply();
                    };
                    _advancedCGChannelRedSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            switch (_advancedCGChannelDropDown.selectedIndex)
                            {
                                case 0:
                                    _advancedCGChannelRedSlider.value = 1f;
                                    _advancedCGChannelRedSliderNumeral.text = _advancedCGChannelRedSlider.value.ToString();
                                    ModProperties.Instance.ActiveProfile.CGChannelMixerRedRed = _advancedCGChannelRedSlider.value;
                                    break;
                                case 1:
                                    _advancedCGChannelRedSlider.value = 0f;
                                    _advancedCGChannelRedSliderNumeral.text = _advancedCGChannelRedSlider.value.ToString();
                                    ModProperties.Instance.ActiveProfile.CGChannelMixerGreenRed = _advancedCGChannelRedSlider.value;
                                    break;
                                case 2:
                                    _advancedCGChannelRedSlider.value = 0f;
                                    _advancedCGChannelRedSliderNumeral.text = _advancedCGChannelRedSlider.value.ToString();
                                    ModProperties.Instance.ActiveProfile.CGChannelMixerBlueRed = _advancedCGChannelRedSlider.value;
                                    break;
                            }

                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedCGChannelGreenSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGChannelGreenSliderLabel", "Green");

                    _advancedCGChannelGreenSliderNumeral = UIUtils.CreateLabel(_advancedCGChannelGreenSliderLabel, "AdvancedCGChannelGreenSliderNumeral", "");
                    _advancedCGChannelGreenSliderNumeral.width = 100f;
                    _advancedCGChannelGreenSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGChannelGreenSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGChannelGreenSliderNumeral.width - 10f, 0f);

                    _advancedCGChannelGreenSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGChannelGreenSlider", 0f, 1f, 0.01f, 0f);
                    _advancedCGChannelGreenSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGChannelGreenSliderNumeral.text = value.ToString();

                        switch (_advancedCGChannelDropDown.selectedIndex)
                        {
                            case 0:
                                ModProperties.Instance.ActiveProfile.CGChannelMixerRedGreen = value;
                                break;
                            case 1:
                                ModProperties.Instance.ActiveProfile.CGChannelMixerGreenGreen = value;
                                break;
                            case 2:
                                ModProperties.Instance.ActiveProfile.CGChannelMixerBlueGreen = value;
                                break;
                        }

                        ModConfig.Instance.Apply();
                    };
                    _advancedCGChannelGreenSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            switch (_advancedCGChannelDropDown.selectedIndex)
                            {
                                case 0:
                                    _advancedCGChannelGreenSlider.value = 0f;
                                    _advancedCGChannelGreenSliderNumeral.text = _advancedCGChannelGreenSlider.value.ToString();
                                    ModProperties.Instance.ActiveProfile.CGChannelMixerRedGreen = _advancedCGChannelGreenSlider.value;
                                    break;
                                case 1:
                                    _advancedCGChannelGreenSlider.value = 1f;
                                    _advancedCGChannelGreenSliderNumeral.text = _advancedCGChannelGreenSlider.value.ToString();
                                    ModProperties.Instance.ActiveProfile.CGChannelMixerGreenGreen = _advancedCGChannelGreenSlider.value;
                                    break;
                                case 2:
                                    _advancedCGChannelGreenSlider.value = 0f;
                                    _advancedCGChannelGreenSliderNumeral.text = _advancedCGChannelGreenSlider.value.ToString();
                                    ModProperties.Instance.ActiveProfile.CGChannelMixerBlueGreen = _advancedCGChannelGreenSlider.value;
                                    break;
                            }

                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedCGChannelBlueSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGChannelBlueSliderLabel", "Blue");

                    _advancedCGChannelBlueSliderNumeral = UIUtils.CreateLabel(_advancedCGChannelBlueSliderLabel, "AdvancedCGChannelBlueSliderNumeral", "");
                    _advancedCGChannelBlueSliderNumeral.width = 100f;
                    _advancedCGChannelBlueSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGChannelBlueSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGChannelBlueSliderNumeral.width - 10f, 0f);

                    _advancedCGChannelBlueSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGChannelBlueSlider", 0f, 1f, 0.01f, 0f);
                    _advancedCGChannelBlueSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGChannelBlueSliderNumeral.text = value.ToString();

                        switch (_advancedCGChannelDropDown.selectedIndex)
                        {
                            case 0:
                                ModProperties.Instance.ActiveProfile.CGChannelMixerRedBlue = value;
                                break;
                            case 1:
                                ModProperties.Instance.ActiveProfile.CGChannelMixerGreenBlue = value;
                                break;
                            case 2:
                                ModProperties.Instance.ActiveProfile.CGChannelMixerBlueBlue = value;
                                break;
                        }

                        ModConfig.Instance.Apply();
                    };
                    _advancedCGChannelBlueSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            switch (_advancedCGChannelDropDown.selectedIndex)
                            {
                                case 0:
                                    _advancedCGChannelBlueSlider.value = 0f;
                                    _advancedCGChannelBlueSliderNumeral.text = _advancedCGChannelBlueSlider.value.ToString();
                                    ModProperties.Instance.ActiveProfile.CGChannelMixerRedBlue = _advancedCGChannelBlueSlider.value;
                                    break;
                                case 1:
                                    _advancedCGChannelBlueSlider.value = 0f;
                                    _advancedCGChannelBlueSliderNumeral.text = _advancedCGChannelBlueSlider.value.ToString();
                                    ModProperties.Instance.ActiveProfile.CGChannelMixerGreenBlue = _advancedCGChannelBlueSlider.value;
                                    break;
                                case 2:
                                    _advancedCGChannelBlueSlider.value = 1f;
                                    _advancedCGChannelBlueSliderNumeral.text = _advancedCGChannelBlueSlider.value.ToString();
                                    ModProperties.Instance.ActiveProfile.CGChannelMixerBlueBlue = _advancedCGChannelBlueSlider.value;
                                    break;
                            }

                            ModConfig.Instance.Apply();
                        }
                    };

                    _advancedCGTonemapperDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        ModProperties.Instance.ActiveProfile.CGTonemapper = value;
                        ModConfig.Instance.Apply();

                        if (value == 2)
                        {
                            _advancedCGNeutralBlackInSliderLabel.isVisible = true;
                            _advancedCGNeutralBlackInSliderNumeral.isVisible = true;
                            _advancedCGNeutralBlackInSlider.isVisible = true;
                            _advancedCGNeutralWhiteInSliderLabel.isVisible = true;
                            _advancedCGNeutralWhiteInSliderNumeral.isVisible = true;
                            _advancedCGNeutralWhiteInSlider.isVisible = true;
                            _advancedCGNeutralBlackOutSliderLabel.isVisible = true;
                            _advancedCGNeutralBlackOutSliderNumeral.isVisible = true;
                            _advancedCGNeutralBlackOutSlider.isVisible = true;
                            _advancedCGNeutralWhiteOutSliderLabel.isVisible = true;
                            _advancedCGNeutralWhiteOutSliderNumeral.isVisible = true;
                            _advancedCGNeutralWhiteOutSlider.isVisible = true;
                            _advancedCGNeutralWhiteLevelSliderLabel.isVisible = true;
                            _advancedCGNeutralWhiteLevelSliderNumeral.isVisible = true;
                            _advancedCGNeutralWhiteLevelSlider.isVisible = true;
                            _advancedCGNeutralWhiteClipSliderLabel.isVisible = true;
                            _advancedCGNeutralWhiteClipSliderNumeral.isVisible = true;
                            _advancedCGNeutralWhiteClipSlider.isVisible = true;
                        }
                        else
                        {
                            _advancedCGNeutralBlackInSliderLabel.isVisible = false;
                            _advancedCGNeutralBlackInSliderNumeral.isVisible = false;
                            _advancedCGNeutralBlackInSlider.isVisible = false;
                            _advancedCGNeutralWhiteInSliderLabel.isVisible = false;
                            _advancedCGNeutralWhiteInSliderNumeral.isVisible = false;
                            _advancedCGNeutralWhiteInSlider.isVisible = false;
                            _advancedCGNeutralBlackOutSliderLabel.isVisible = false;
                            _advancedCGNeutralBlackOutSliderNumeral.isVisible = false;
                            _advancedCGNeutralBlackOutSlider.isVisible = false;
                            _advancedCGNeutralWhiteOutSliderLabel.isVisible = false;
                            _advancedCGNeutralWhiteOutSliderNumeral.isVisible = false;
                            _advancedCGNeutralWhiteOutSlider.isVisible = false;
                            _advancedCGNeutralWhiteLevelSliderLabel.isVisible = false;
                            _advancedCGNeutralWhiteLevelSliderNumeral.isVisible = false;
                            _advancedCGNeutralWhiteLevelSlider.isVisible = false;
                            _advancedCGNeutralWhiteClipSliderLabel.isVisible = false;
                            _advancedCGNeutralWhiteClipSliderNumeral.isVisible = false;
                            _advancedCGNeutralWhiteClipSlider.isVisible = false;
                        }
                    };
                    _advancedCGTonemapperDropDown.selectedIndex = ModProperties.Instance.ActiveProfile.CGTonemapper;

                    _advancedCGChannelDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        switch (value)
                        {
                            case 0:
                                _advancedCGChannelRedSliderNumeral.text = ModProperties.Instance.ActiveProfile.CGChannelMixerRedRed.ToString();
                                _advancedCGChannelGreenSliderNumeral.text = ModProperties.Instance.ActiveProfile.CGChannelMixerRedGreen.ToString();
                                _advancedCGChannelBlueSliderNumeral.text = ModProperties.Instance.ActiveProfile.CGChannelMixerRedBlue.ToString();
                                _advancedCGChannelRedSlider.value = ModProperties.Instance.ActiveProfile.CGChannelMixerRedRed;
                                _advancedCGChannelGreenSlider.value = ModProperties.Instance.ActiveProfile.CGChannelMixerRedGreen;
                                _advancedCGChannelBlueSlider.value = ModProperties.Instance.ActiveProfile.CGChannelMixerRedBlue;
                                break;
                            case 1:
                                _advancedCGChannelRedSliderNumeral.text = ModProperties.Instance.ActiveProfile.CGChannelMixerGreenRed.ToString();
                                _advancedCGChannelGreenSliderNumeral.text = ModProperties.Instance.ActiveProfile.CGChannelMixerGreenGreen.ToString();
                                _advancedCGChannelBlueSliderNumeral.text = ModProperties.Instance.ActiveProfile.CGChannelMixerGreenBlue.ToString();
                                _advancedCGChannelRedSlider.value = ModProperties.Instance.ActiveProfile.CGChannelMixerGreenRed;
                                _advancedCGChannelGreenSlider.value = ModProperties.Instance.ActiveProfile.CGChannelMixerGreenGreen;
                                _advancedCGChannelBlueSlider.value = ModProperties.Instance.ActiveProfile.CGChannelMixerGreenBlue;
                                break;
                            case 2:
                                _advancedCGChannelRedSliderNumeral.text = ModProperties.Instance.ActiveProfile.CGChannelMixerBlueRed.ToString();
                                _advancedCGChannelGreenSliderNumeral.text = ModProperties.Instance.ActiveProfile.CGChannelMixerBlueGreen.ToString();
                                _advancedCGChannelBlueSliderNumeral.text = ModProperties.Instance.ActiveProfile.CGChannelMixerBlueBlue.ToString();
                                _advancedCGChannelRedSlider.value = ModProperties.Instance.ActiveProfile.CGChannelMixerBlueRed;
                                _advancedCGChannelGreenSlider.value = ModProperties.Instance.ActiveProfile.CGChannelMixerBlueGreen;
                                _advancedCGChannelBlueSlider.value = ModProperties.Instance.ActiveProfile.CGChannelMixerBlueBlue;
                                break;
                        }
                    };
                    _advancedCGChannelDropDown.selectedIndex = 0;

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
                isVisible = ModConfig.Instance.ShowPanel;
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
