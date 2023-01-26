using ColossalFramework;
using ColossalFramework.PlatformServices;
using ColossalFramework.UI;
using RenderIt.Helpers;
using RenderIt.Managers;
using System;
using System.Linq;
using UnityEngine;

namespace RenderIt.Panels
{
    public class MainPanel : UIPanel
    {
        private bool _initialized;

        private ImportExportPanel _importExportPanel;
        private ColorsPanel _colorsPanel;
        private AntiAliasingPanel _antiAliasingPanel;
        private AmbientOcclusionPanel _ambientOcclusionPanel;
        private BloomPanel _bloomPanel;
        private ColorGradingPanel _colorGradingPanel;

        private UITextureAtlas _ingameAtlas;
        private UILabel _title;
        private UIButton _close;
        private UIDragHandle _dragHandle;
        private UITabstrip _tabstrip;
        private UITabContainer _tabContainer;
        private UIButton _templateButton;

        private UILabel _profilesDropDownLabel;
        private UIDropDown _profilesDropDown;
        private UITextField _profilesTextField;
        private UIPanel _profilesButtonsPanel;
        private UIButton _profilesAddButton;
        private UIButton _profilesRemoveButton;
        private UIButton _profilesCopyButton;
        private UIButton _profilesImportButton;
        private UIButton _profilesExportButton;
        private UIButton _profilesRenameButton;
        private UIButton _profilesSaveButton;
        private UIButton _profilesRevertButton;
        private UIPanel _profilesMessagePanel;
        private UILabel _profilesMessageLabel;

        private UILabel _optionsDropDownLabel;
        private UIDropDown _optionsDropDown;

        private UIPanel _optionsLightingPanel;
        private UIScrollablePanel _optionsLightingScrollablePanel;
        private UIScrollbar _optionsLightingScrollbar;
        private UISlicedSprite _optionsLightingScrollbarTrack;
        private UISlicedSprite _optionsLightingScrollbarThumb;
        private UILabel _optionsSunTitle;
        private UILabel _optionsSunIntensitySliderLabel;
        private UILabel _optionsSunIntensitySliderNumeral;
        private UISlider _optionsSunIntensitySlider;
        private UILabel _optionsSunShadowStrengthSliderLabel;
        private UILabel _optionsSunShadowStrengthSliderNumeral;
        private UISlider _optionsSunShadowStrengthSlider;
        private UISprite _optionsSunDivider;
        private UILabel _optionsMoonTitle;
        private UILabel _optionsMoonIntensitySliderLabel;
        private UILabel _optionsMoonIntensitySliderNumeral;
        private UISlider _optionsMoonIntensitySlider;
        private UILabel _optionsMoonShadowStrengthSliderLabel;
        private UILabel _optionsMoonShadowStrengthSliderNumeral;
        private UISlider _optionsMoonShadowStrengthSlider;
        private UISprite _optionsMoonDivider;
        private UILabel _optionsSkyTitle;
        private UILabel _optionsSkyRayleighScatteringSliderLabel;
        private UILabel _optionsSkyRayleighScatteringSliderNumeral;
        private UISlider _optionsSkyRayleighScatteringSlider;
        private UILabel _optionsSkyMieScatteringSliderLabel;
        private UILabel _optionsSkyMieScatteringSliderNumeral;
        private UISlider _optionsSkyMieScatteringSlider;
        private UILabel _optionsSkyExposureSliderLabel;
        private UILabel _optionsSkyExposureSliderNumeral;
        private UISlider _optionsSkyExposureSlider;
        private UILabel _optionsSkyRedWaveLengthSliderLabel;
        private UILabel _optionsSkyRedWaveLengthSliderNumeral;
        private UISlider _optionsSkyRedWaveLengthSlider;
        private UILabel _optionsSkyGreenWaveLengthSliderLabel;
        private UILabel _optionsSkyGreenWaveLengthSliderNumeral;
        private UISlider _optionsSkyGreenWaveLengthSlider;
        private UILabel _optionsSkyBlueWaveLengthSliderLabel;
        private UILabel _optionsSkyBlueWaveLengthSliderNumeral;
        private UISlider _optionsSkyBlueWaveLengthSlider;
        private UIPanel _optionsSkyMessagePanel;
        private UILabel _optionsSkyMessageLabel;

        private UIPanel _optionsColorsPanel;
        private UILabel _optionsLightColorsTitle;
        private UICheckBox _optionsLightColorsCheckBox;
        private UIPanel _optionsLightColorsButtonPanel;
        private UIButton _optionsLightColorsResetButton;
        private UIButton _optionsLightColorsEditButton;
        private UICheckBox _optionsSkyColorsCheckBox;
        private UIPanel _optionsSkyColorsButtonPanel;
        private UIButton _optionsSkyColorsResetButton;
        private UIButton _optionsSkyColorsEditButton;
        private UICheckBox _optionsEquatorColorsCheckBox;
        private UIPanel _optionsEquatorColorsButtonPanel;
        private UIButton _optionsEquatorColorsResetButton;
        private UIButton _optionsEquatorColorsEditButton;
        private UICheckBox _optionsGroundColorsCheckBox;
        private UIPanel _optionsGroundColorsButtonPanel;
        private UIButton _optionsGroundColorsResetButton;
        private UIButton _optionsGroundColorsEditButton;
        private UIPanel _optionsLightColorsMessagePanel;
        private UILabel _optionsLightColorsMessageLabel;

        private UIPanel _optionsTexturesPanel;
        private UILabel _optionsSharpnessTitle;
        private UILabel _optionsSharpnessAssetTypeDropDownLabel;
        private UIDropDown _optionsSharpnessAssetTypeDropDown;
        private UILabel _optionsSharpnessAnisoLevelDropDownLabel;
        private UIDropDown _optionsSharpnessAnisoLevelDropDown;
        private UILabel _optionsSharpnessMipMapBiasDropDownLabel;
        private UIDropDown _optionsSharpnessMipMapBiasDropDown;
        private UICheckBox _optionsSharpnessLODCheckBox;

        private UIPanel _optionsEnvironmentPanel;
        private UILabel _optionsFogTitle;
        private UICheckBox _optionsFogCheckBox;
        private UICheckBox _optionsFogDayNightCheckBox;
        private UILabel _optionsFogHeightSliderLabel;
        private UILabel _optionsFogHeightSliderNumeral;
        private UISlider _optionsFogHeightSlider;
        private UILabel _optionsFogHorizonHeightSliderLabel;
        private UILabel _optionsFogHorizonHeightSliderNumeral;
        private UISlider _optionsFogHorizonHeightSlider;
        private UILabel _optionsFogDensitySliderLabel;
        private UILabel _optionsFogDensitySliderNumeral;
        private UISlider _optionsFogDensitySlider;
        private UILabel _optionsFogStartSliderLabel;
        private UILabel _optionsFogStartSliderNumeral;
        private UISlider _optionsFogStartSlider;
        private UILabel _optionsFogDistanceSliderLabel;
        private UILabel _optionsFogDistanceSliderNumeral;
        private UISlider _optionsFogDistanceSlider;
        private UILabel _optionsFogEdgeDistanceSliderLabel;
        private UILabel _optionsFogEdgeDistanceSliderNumeral;
        private UISlider _optionsFogEdgeDistanceSlider;
        private UILabel _optionsFogNoiseContributionSliderLabel;
        private UILabel _optionsFogNoiseContributionSliderNumeral;
        private UISlider _optionsFogNoiseContributionSlider;
        private UILabel _optionsFogPollutionAmountSliderLabel;
        private UILabel _optionsFogPollutionAmountSliderNumeral;
        private UISlider _optionsFogPollutionAmountSlider;
        private UILabel _optionsFogColorDecaySliderLabel;
        private UILabel _optionsFogColorDecaySliderNumeral;
        private UISlider _optionsFogColorDecaySlider;
        private UILabel _optionsFogScatteringSliderLabel;
        private UILabel _optionsFogScatteringSliderNumeral;
        private UISlider _optionsFogScatteringSlider;
        private UIPanel _optionsFogMessagePanel;
        private UILabel _optionsFogMessageLabel;

        private UIPanel _optionsPostProcessingPanel;
        private UILabel _optionsAntiAliasingTitle;
        private UILabel _optionsAntiAliasingDropDownLabel;
        private UIDropDown _optionsAntiAliasingDropDown;
        private UIPanel _optionsAntiAliasingButtonPanel;
        private UIButton _optionsAntiAliasingEditButton;
        private UISprite _optionsAntiAliasingDivider;
        private UILabel _optionsVanillaEffectsTitle;
        private UICheckBox _optionsVanillaBloomCheckBox;
        private UICheckBox _optionsVanillaTonemappingCheckBox;
        private UICheckBox _optionsVanillaColorCorrectionLutCheckBox;
        private UIDropDown _optionsVanillaColorCorrectionLutDropDown;
        private UISprite _optionsVanillaEffectsDivider;
        private UILabel _optionsEnhancedEffectsTitle;
        private UICheckBox _optionsAmbientOcclusionCheckBox;
        private UIPanel _optionsAmbientOcclusionButtonPanel;
        private UIButton _optionsAmbientOcclusionEditButton;
        private UICheckBox _optionsBloomCheckBox;
        private UIPanel _optionsBloomButtonPanel;
        private UIButton _optionsBloomEditButton;
        private UICheckBox _optionsColorGradingCheckBox;
        private UIPanel _optionsColorGradingButtonPanel;
        private UIButton _optionsColorGradingEditButton;

        private UILabel _advancedKeymappingsTitle;
        private UICheckBox _advancedKeymappingsEnabledCheckBox;
        private UILabel _advancedKeymappingsNextProfileDropDownLabel;
        private UIDropDown _advancedKeymappingsNextProfileDropDown;
        private UILabel _advancedKeymappingsPreviousProfileDropDownLabel;
        private UIDropDown _advancedKeymappingsPreviousProfileDropDown;

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
                if (_importExportPanel == null)
                {
                    _importExportPanel = GameObject.Find("RenderItImportExportPanel")?.GetComponent<ImportExportPanel>();
                }

                if (_colorsPanel == null)
                {
                    _colorsPanel = GameObject.Find("RenderItColorsPanel")?.GetComponent<ColorsPanel>();
                }

                if (_antiAliasingPanel == null)
                {
                    _antiAliasingPanel = GameObject.Find("RenderItAntiAliasingPanel")?.GetComponent<AntiAliasingPanel>();
                }

                if (_ambientOcclusionPanel == null)
                {
                    _ambientOcclusionPanel = GameObject.Find("RenderItAmbientOcclusionPanel")?.GetComponent<AmbientOcclusionPanel>();
                }

                if (_bloomPanel == null)
                {
                    _bloomPanel = GameObject.Find("RenderItBloomPanel")?.GetComponent<BloomPanel>();
                }

                if (_colorGradingPanel == null)
                {
                    _colorGradingPanel = GameObject.Find("RenderItColorGradingPanel")?.GetComponent<ColorGradingPanel>();
                }

                if (ModConfig.Instance.PanelPositionX == 0f && ModConfig.Instance.PanelPositionY == 0f)
                {
                    ModProperties.Instance.ResetPanelPosition();
                }

                _ingameAtlas = ResourceLoader.GetAtlas("Ingame");

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

                if (ModConfig.Instance.KeymappingsEnabled && KeyChecker.GetKeyCombo(out int key))
                {
                    if (ModConfig.Instance.KeymappingsNextProfile == key)
                    {
                        if (_profilesDropDown.items.Length > 1)
                        {
                            if (_profilesDropDown.selectedIndex < _profilesDropDown.items.Length - 1)
                            {
                                _profilesDropDown.selectedIndex++;
                            }
                            else
                            {
                                _profilesDropDown.selectedIndex = 0;
                            }
                        }
                    }

                    if (ModConfig.Instance.KeymappingsPreviousProfile == key)
                    {
                        if (_profilesDropDown.items.Length > 1)
                        {
                            if (_profilesDropDown.selectedIndex > 0)
                            {
                                _profilesDropDown.selectedIndex--;
                            }
                            else
                            {
                                _profilesDropDown.selectedIndex = _profilesDropDown.items.Length - 1;
                            }
                        }
                    }
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
                DestroyGameObject(_profilesTextField);
                DestroyGameObject(_profilesButtonsPanel);
                DestroyGameObject(_profilesAddButton);
                DestroyGameObject(_profilesRemoveButton);
                DestroyGameObject(_profilesCopyButton);
                DestroyGameObject(_profilesImportButton);
                DestroyGameObject(_profilesExportButton);
                DestroyGameObject(_profilesRenameButton);
                DestroyGameObject(_profilesSaveButton);
                DestroyGameObject(_profilesRevertButton);

                DestroyGameObject(_optionsDropDownLabel);
                DestroyGameObject(_optionsDropDown);

                DestroyGameObject(_optionsLightingPanel);
                DestroyGameObject(_optionsLightingScrollablePanel);
                DestroyGameObject(_optionsLightingScrollbar);
                DestroyGameObject(_optionsLightingScrollbarTrack);
                DestroyGameObject(_optionsLightingScrollbarThumb);
                DestroyGameObject(_optionsSunTitle);
                DestroyGameObject(_optionsSunIntensitySliderLabel);
                DestroyGameObject(_optionsSunIntensitySliderNumeral);
                DestroyGameObject(_optionsSunIntensitySlider);
                DestroyGameObject(_optionsSunShadowStrengthSliderLabel);
                DestroyGameObject(_optionsSunShadowStrengthSliderNumeral);
                DestroyGameObject(_optionsSunShadowStrengthSlider);
                DestroyGameObject(_optionsSunDivider);
                DestroyGameObject(_optionsMoonTitle);
                DestroyGameObject(_optionsMoonIntensitySliderLabel);
                DestroyGameObject(_optionsMoonIntensitySliderNumeral);
                DestroyGameObject(_optionsMoonIntensitySlider);
                DestroyGameObject(_optionsMoonShadowStrengthSliderLabel);
                DestroyGameObject(_optionsMoonShadowStrengthSliderNumeral);
                DestroyGameObject(_optionsMoonShadowStrengthSlider);
                DestroyGameObject(_optionsMoonDivider);
                DestroyGameObject(_optionsSkyTitle);
                DestroyGameObject(_optionsSkyRayleighScatteringSliderLabel);
                DestroyGameObject(_optionsSkyRayleighScatteringSliderNumeral);
                DestroyGameObject(_optionsSkyRayleighScatteringSlider);
                DestroyGameObject(_optionsSkyMieScatteringSliderLabel);
                DestroyGameObject(_optionsSkyMieScatteringSliderNumeral);
                DestroyGameObject(_optionsSkyMieScatteringSlider);
                DestroyGameObject(_optionsSkyExposureSliderLabel);
                DestroyGameObject(_optionsSkyExposureSliderNumeral);
                DestroyGameObject(_optionsSkyExposureSlider);
                DestroyGameObject(_optionsSkyRedWaveLengthSliderLabel);
                DestroyGameObject(_optionsSkyRedWaveLengthSliderNumeral);
                DestroyGameObject(_optionsSkyRedWaveLengthSlider);
                DestroyGameObject(_optionsSkyGreenWaveLengthSliderLabel);
                DestroyGameObject(_optionsSkyGreenWaveLengthSliderNumeral);
                DestroyGameObject(_optionsSkyGreenWaveLengthSlider);
                DestroyGameObject(_optionsSkyBlueWaveLengthSliderLabel);
                DestroyGameObject(_optionsSkyBlueWaveLengthSliderNumeral);
                DestroyGameObject(_optionsSkyBlueWaveLengthSlider);
                DestroyGameObject(_optionsSkyMessagePanel);
                DestroyGameObject(_optionsSkyMessageLabel);

                DestroyGameObject(_optionsColorsPanel);
                DestroyGameObject(_optionsLightColorsTitle);
                DestroyGameObject(_optionsLightColorsCheckBox);
                DestroyGameObject(_optionsLightColorsButtonPanel);
                DestroyGameObject(_optionsLightColorsResetButton);
                DestroyGameObject(_optionsLightColorsEditButton);
                DestroyGameObject(_optionsSkyColorsCheckBox);
                DestroyGameObject(_optionsSkyColorsButtonPanel);
                DestroyGameObject(_optionsSkyColorsResetButton);
                DestroyGameObject(_optionsSkyColorsEditButton);
                DestroyGameObject(_optionsEquatorColorsCheckBox);
                DestroyGameObject(_optionsEquatorColorsButtonPanel);
                DestroyGameObject(_optionsEquatorColorsResetButton);
                DestroyGameObject(_optionsEquatorColorsEditButton);
                DestroyGameObject(_optionsGroundColorsCheckBox);
                DestroyGameObject(_optionsGroundColorsButtonPanel);
                DestroyGameObject(_optionsGroundColorsResetButton);
                DestroyGameObject(_optionsGroundColorsEditButton);
                DestroyGameObject(_optionsLightColorsMessagePanel);
                DestroyGameObject(_optionsLightColorsMessageLabel);

                DestroyGameObject(_optionsTexturesPanel);
                DestroyGameObject(_optionsSharpnessTitle);
                DestroyGameObject(_optionsSharpnessAssetTypeDropDownLabel);
                DestroyGameObject(_optionsSharpnessAssetTypeDropDown);
                DestroyGameObject(_optionsSharpnessAnisoLevelDropDownLabel);
                DestroyGameObject(_optionsSharpnessAnisoLevelDropDown);
                DestroyGameObject(_optionsSharpnessMipMapBiasDropDownLabel);
                DestroyGameObject(_optionsSharpnessMipMapBiasDropDown);
                DestroyGameObject(_optionsSharpnessLODCheckBox);

                DestroyGameObject(_optionsEnvironmentPanel);
                DestroyGameObject(_optionsFogTitle);
                DestroyGameObject(_optionsFogCheckBox);
                DestroyGameObject(_optionsFogDayNightCheckBox);
                DestroyGameObject(_optionsFogHeightSliderLabel);
                DestroyGameObject(_optionsFogHeightSliderNumeral);
                DestroyGameObject(_optionsFogHeightSlider);
                DestroyGameObject(_optionsFogHorizonHeightSliderLabel);
                DestroyGameObject(_optionsFogHorizonHeightSliderNumeral);
                DestroyGameObject(_optionsFogHorizonHeightSlider);
                DestroyGameObject(_optionsFogDensitySliderLabel);
                DestroyGameObject(_optionsFogDensitySliderNumeral);
                DestroyGameObject(_optionsFogDensitySlider);
                DestroyGameObject(_optionsFogStartSliderLabel);
                DestroyGameObject(_optionsFogStartSliderNumeral);
                DestroyGameObject(_optionsFogStartSlider);
                DestroyGameObject(_optionsFogDistanceSliderLabel);
                DestroyGameObject(_optionsFogDistanceSliderNumeral);
                DestroyGameObject(_optionsFogDistanceSlider);
                DestroyGameObject(_optionsFogEdgeDistanceSliderLabel);
                DestroyGameObject(_optionsFogEdgeDistanceSliderNumeral);
                DestroyGameObject(_optionsFogEdgeDistanceSlider);
                DestroyGameObject(_optionsFogNoiseContributionSliderLabel);
                DestroyGameObject(_optionsFogNoiseContributionSliderNumeral);
                DestroyGameObject(_optionsFogNoiseContributionSlider);
                DestroyGameObject(_optionsFogPollutionAmountSliderLabel);
                DestroyGameObject(_optionsFogPollutionAmountSliderNumeral);
                DestroyGameObject(_optionsFogPollutionAmountSlider);
                DestroyGameObject(_optionsFogColorDecaySliderLabel);
                DestroyGameObject(_optionsFogColorDecaySliderNumeral);
                DestroyGameObject(_optionsFogColorDecaySlider);
                DestroyGameObject(_optionsFogScatteringSliderLabel);
                DestroyGameObject(_optionsFogScatteringSliderNumeral);
                DestroyGameObject(_optionsFogScatteringSlider);
                DestroyGameObject(_optionsFogMessagePanel);
                DestroyGameObject(_optionsFogMessageLabel);

                DestroyGameObject(_optionsPostProcessingPanel);
                DestroyGameObject(_optionsAntiAliasingTitle);
                DestroyGameObject(_optionsAntiAliasingDropDownLabel);
                DestroyGameObject(_optionsAntiAliasingDropDown);
                DestroyGameObject(_optionsAntiAliasingButtonPanel);
                DestroyGameObject(_optionsAntiAliasingEditButton);
                DestroyGameObject(_optionsAntiAliasingDivider);
                DestroyGameObject(_optionsVanillaEffectsTitle);
                DestroyGameObject(_optionsVanillaBloomCheckBox);
                DestroyGameObject(_optionsVanillaTonemappingCheckBox);
                DestroyGameObject(_optionsVanillaColorCorrectionLutCheckBox);
                DestroyGameObject(_optionsVanillaColorCorrectionLutDropDown);
                DestroyGameObject(_optionsVanillaEffectsDivider);
                DestroyGameObject(_optionsEnhancedEffectsTitle);
                DestroyGameObject(_optionsAmbientOcclusionCheckBox);
                DestroyGameObject(_optionsAmbientOcclusionButtonPanel);
                DestroyGameObject(_optionsAmbientOcclusionEditButton);
                DestroyGameObject(_optionsBloomCheckBox);
                DestroyGameObject(_optionsBloomButtonPanel);
                DestroyGameObject(_optionsBloomEditButton);
                DestroyGameObject(_optionsColorGradingCheckBox);
                DestroyGameObject(_optionsColorGradingButtonPanel);
                DestroyGameObject(_optionsColorGradingEditButton);

                DestroyGameObject(_advancedKeymappingsTitle);
                DestroyGameObject(_advancedKeymappingsEnabledCheckBox);
                DestroyGameObject(_advancedKeymappingsNextProfileDropDownLabel);
                DestroyGameObject(_advancedKeymappingsNextProfileDropDown);
                DestroyGameObject(_advancedKeymappingsPreviousProfileDropDownLabel);
                DestroyGameObject(_advancedKeymappingsPreviousProfileDropDown);
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

        public void ForceProfile(Profile profile)
        {
            _profilesDropDown.items = ProfileManager.Instance.AllProfiles.Select(x => x.Name).ToArray();
            _profilesDropDown.selectedValue = ProfileManager.Instance.ActiveProfile.Name;
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

                _title = UIUtils.CreateMenuPanelTitle(this, _ingameAtlas, "Render It!");
                _title.relativePosition = new Vector3(width / 2f - _title.width / 2f, 15f);

                _close = UIUtils.CreateMenuPanelCloseButton(this, _ingameAtlas);
                _close.relativePosition = new Vector3(width - 37f, 3f);
                _close.eventClick += (component, eventParam) =>
                {
                    if (!eventParam.used)
                    {
                        _close.parent.Hide();
                        ModConfig.Instance.ShowPanel = false;
                        ModConfig.Instance.Save();

                        eventParam.Use();
                    }
                };

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

                _tabstrip = UIUtils.CreateTabStrip(this, _ingameAtlas);
                _tabstrip.width = width - 40f;
                _tabstrip.relativePosition = new Vector3(20f, 50f);

                _tabContainer = UIUtils.CreateTabContainer(this, _ingameAtlas);
                _tabContainer.width = width - 40f;
                _tabContainer.height = height - 120f;
                _tabContainer.relativePosition = new Vector3(20f, 100f);

                _templateButton = UIUtils.CreateTabButton(this, _ingameAtlas);

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
                    _profilesDropDownLabel.tooltip = "Select profile to be active";

                    _profilesDropDown = UIUtils.CreateDropDown(panel, "ProfilesDropDown", _ingameAtlas);
                    _profilesDropDown.items = ProfileManager.Instance.AllProfiles.Select(x => x.Name).ToArray();
                    _profilesDropDown.selectedValue = ProfileManager.Instance.ActiveProfile.Name;
                    _profilesDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        if (value != -1)
                        {
                            if (_colorsPanel != null && _colorsPanel.isVisible)
                            {
                                _colorsPanel.Hide();
                            }

                            ProfileManager.Instance.ActiveProfile = ProfileManager.Instance.AllProfiles[value];

                            ApplyProfile(ProfileManager.Instance.ActiveProfile);
                        }
                    };

                    _profilesTextField = UIUtils.CreateTextField(panel, "ProfilesTextField", _ingameAtlas, "");
                    _profilesTextField.isVisible = false;
                    _profilesTextField.eventTextSubmitted += (component, value) =>
                    {
                        _profilesTextField.isVisible = false;

                        if (_profilesDropDown.items.Length > 0)
                        {
                            ProfileManager.Instance.AllProfiles[_profilesDropDown.selectedIndex].Name = value;

                            _profilesDropDown.items = ProfileManager.Instance.AllProfiles.Select(x => x.Name).ToArray();
                            _profilesDropDown.selectedValue = ProfileManager.Instance.ActiveProfile.Name;
                        }

                        _profilesDropDown.isVisible = true;
                    };

                    _profilesButtonsPanel = UIUtils.CreatePanel(panel, "ProfilesButtonsPanel");
                    _profilesButtonsPanel.width = panel.width - 10f;
                    _profilesButtonsPanel.height = 120f;

                    _profilesAddButton = UIUtils.CreatePanelButton(_profilesButtonsPanel, "ProfilesAddButton", _ingameAtlas, "Add");
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
                            ProfileManager.Instance.AllProfiles.Add(profile);
                            ProfileManager.Instance.ActiveProfile = profile;

                            _profilesDropDown.items = ProfileManager.Instance.AllProfiles.Select(x => x.Name).ToArray();
                            _profilesDropDown.selectedValue = ProfileManager.Instance.ActiveProfile.Name;

                            eventParam.Use();
                        }
                    };

                    _profilesRemoveButton = UIUtils.CreatePanelButton(_profilesButtonsPanel, "ProfilesRemoveButton", _ingameAtlas, "Remove");
                    _profilesRemoveButton.tooltip = "Click to remove current active profile";
                    _profilesRemoveButton.relativePosition = new Vector3(85f, 0f);
                    _profilesRemoveButton.eventClick += (component, eventParam) =>
                    {
                        if (!eventParam.used)
                        {
                            if (_profilesDropDown.items.Length > 0)
                            {
                                ProfileManager.Instance.AllProfiles.Remove(ProfileManager.Instance.AllProfiles[_profilesDropDown.selectedIndex]);

                                if (ProfileManager.Instance.AllProfiles.Count > 0)
                                {
                                    ProfileManager.Instance.ActiveProfile = ProfileManager.Instance.AllProfiles[0];
                                    _profilesDropDown.items = ProfileManager.Instance.AllProfiles.Select(x => x.Name).ToArray();
                                    _profilesDropDown.selectedIndex = 0;
                                }
                                else
                                {
                                    ProfileManager.Instance.ActiveProfile = null;
                                    _profilesDropDown.items = new string[] { };
                                    _profilesDropDown.selectedIndex = 0;
                                }
                            }

                            eventParam.Use();
                        }
                    };

                    _profilesCopyButton = UIUtils.CreatePanelButton(_profilesButtonsPanel, "ProfilesCopyButton", _ingameAtlas, "Copy");
                    _profilesCopyButton.tooltip = "Click to make a copy of current active profile";
                    _profilesCopyButton.relativePosition = new Vector3(0f, 40f);
                    _profilesCopyButton.eventClick += (component, eventParam) =>
                    {
                        if (!eventParam.used)
                        {
                            if (_profilesDropDown.items.Length > 0)
                            {
                                Profile profile = ProfileManager.Instance.ActiveProfile.Clone();
                                profile.Name = "Copy of " + profile.Name;

                                ProfileManager.Instance.AllProfiles.Add(profile);
                                ProfileManager.Instance.ActiveProfile = profile;

                                _profilesDropDown.items = ProfileManager.Instance.AllProfiles.Select(x => x.Name).ToArray();
                                _profilesDropDown.selectedValue = ProfileManager.Instance.ActiveProfile.Name;
                            }

                            eventParam.Use();
                        }
                    };

                    _profilesImportButton = UIUtils.CreatePanelButton(_profilesButtonsPanel, "ProfilesImportButton", _ingameAtlas, "Import");
                    _profilesImportButton.tooltip = "Click to open import of current active profile";
                    _profilesImportButton.relativePosition = new Vector3(0f, 80f);
                    _profilesImportButton.eventClick += (component, eventParam) =>
                    {
                        if (!eventParam.used)
                        {
                            if (_importExportPanel != null)
                            {
                                if (_importExportPanel.isVisible)
                                {
                                    _importExportPanel.Hide();
                                }
                                else
                                {
                                    _importExportPanel.SetMode(true);
                                    _importExportPanel.Show();
                                }
                            }

                            eventParam.Use();
                        }
                    };

                    _profilesExportButton = UIUtils.CreatePanelButton(_profilesButtonsPanel, "ProfilesExportButton", _ingameAtlas, "Export");
                    _profilesExportButton.tooltip = "Click to open export of current active profile";
                    _profilesExportButton.relativePosition = new Vector3(85f, 80f);
                    _profilesExportButton.eventClick += (component, eventParam) =>
                    {
                        if (!eventParam.used)
                        {
                            if (_importExportPanel.isVisible)
                            {
                                _importExportPanel.Hide();
                            }
                            else
                            {
                                _importExportPanel.SetMode(false);
                                _importExportPanel.Show();
                            }

                            eventParam.Use();
                        }
                    };

                    _profilesRenameButton = UIUtils.CreatePanelButton(_profilesButtonsPanel, "ProfilesRenameButton", _ingameAtlas, "Rename");
                    _profilesRenameButton.tooltip = "Click to rename current active profile";
                    _profilesRenameButton.relativePosition = new Vector3(185f, 0f);
                    _profilesRenameButton.eventClick += (component, eventParam) =>
                    {
                        if (!eventParam.used)
                        {
                            if (_profilesDropDown.items.Length > 0)
                            {
                                _profilesDropDown.isVisible = false;

                                _profilesTextField.text = ProfileManager.Instance.AllProfiles[_profilesDropDown.selectedIndex].Name;

                                _profilesTextField.isVisible = true;
                                _profilesTextField.Focus();
                            }

                            eventParam.Use();
                        }
                    };

                    _profilesSaveButton = UIUtils.CreatePanelButton(_profilesButtonsPanel, "ProfilesSaveButton", _ingameAtlas, "Save");
                    _profilesSaveButton.tooltip = "Click to save all profiles and their specific values";
                    _profilesSaveButton.relativePosition = new Vector3(270f, 0f);
                    _profilesSaveButton.eventClick += (component, eventParam) =>
                    {
                        if (!eventParam.used)
                        {
                            ProfileManager.Instance.Save();

                            eventParam.Use();
                        }
                    };

                    _profilesRevertButton = UIUtils.CreatePanelButton(_profilesButtonsPanel, "ProfilesRevertButton", _ingameAtlas, "Revert");
                    _profilesRevertButton.tooltip = "Click to revert all profiles back to latest save";
                    _profilesRevertButton.relativePosition = new Vector3(270f, 40f);
                    _profilesRevertButton.eventClick += (component, eventParam) =>
                    {
                        if (!eventParam.used)
                        {
                            ProfileManager.Instance.Reset();

                            _profilesDropDown.items = ProfileManager.Instance.AllProfiles.Select(x => x.Name).ToArray();
                            _profilesDropDown.selectedValue = ProfileManager.Instance.ActiveProfile.Name;

                            eventParam.Use();
                        }
                    };

                    _profilesMessagePanel = UIUtils.CreatePanel(panel, "ProfilesMessagePanel");
                    _profilesMessagePanel.isVisible = false;
                    _profilesMessagePanel.backgroundSprite = "GenericPanelLight";
                    _profilesMessagePanel.color = new Color32(206, 206, 206, 255);
                    _profilesMessagePanel.height = 80f;
                    _profilesMessagePanel.width = _profilesMessagePanel.parent.width - 16f;
                    _profilesMessagePanel.relativePosition = new Vector3(8f, 8f);

                    _profilesMessageLabel = UIUtils.CreateLabel(_profilesMessagePanel, "ProfilesMessageLabel", "Automatic Color Correction Override is active. Render It! automatically applies Color Correction LUT from the active profile if enabled.");
                    _profilesMessageLabel.autoHeight = true;
                    _profilesMessageLabel.width = _profilesMessageLabel.parent.width - 16f;
                    _profilesMessageLabel.relativePosition = new Vector3(8f, 8f);
                    _profilesMessageLabel.wordWrap = true;
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

                    _optionsDropDownLabel = UIUtils.CreateLabel(panel, "OptionsDropDownLabel", "Options");
                    _optionsDropDownLabel.tooltip = "Select which type of options you want to change";

                    _optionsDropDown = UIUtils.CreateDropDown(panel, "OptionsDropDown", _ingameAtlas);
                    _optionsDropDown.items = new string[] { "Lighting", "Colors", "Textures", "Environment", "Post-Processing" };

                    _optionsLightingPanel = UIUtils.CreatePanel(panel, "OptionsLightingPanel");
                    _optionsLightingPanel.isVisible = false;
                    _optionsLightingPanel.width = _optionsLightingPanel.parent.width;
                    _optionsLightingPanel.height = _optionsLightingPanel.parent.height - 72f;

                    _optionsLightingScrollablePanel = UIUtils.CreateScrollablePanel(_optionsLightingPanel, "OptionsLightingScrollablePanel");
                    _optionsLightingScrollablePanel.width = _optionsLightingScrollablePanel.parent.width - 25f;
                    _optionsLightingScrollablePanel.height = _optionsLightingScrollablePanel.parent.height;
                    _optionsLightingScrollablePanel.relativePosition = new Vector3(0f, 0f);

                    _optionsLightingScrollablePanel.autoLayout = true;
                    _optionsLightingScrollablePanel.autoLayoutStart = LayoutStart.TopLeft;
                    _optionsLightingScrollablePanel.autoLayoutDirection = LayoutDirection.Vertical;
                    _optionsLightingScrollablePanel.autoLayoutPadding.left = 0;
                    _optionsLightingScrollablePanel.autoLayoutPadding.right = 0;
                    _optionsLightingScrollablePanel.autoLayoutPadding.top = 0;
                    _optionsLightingScrollablePanel.autoLayoutPadding.bottom = 10;
                    _optionsLightingScrollablePanel.scrollWheelDirection = UIOrientation.Vertical;
                    _optionsLightingScrollablePanel.builtinKeyNavigation = true;
                    _optionsLightingScrollablePanel.clipChildren = true;

                    _optionsLightingScrollbar = UIUtils.CreateScrollbar(_optionsLightingPanel, "OptionsLightingScrollbar");
                    _optionsLightingScrollbar.width = 20f;
                    _optionsLightingScrollbar.height = _optionsLightingScrollablePanel.height;
                    _optionsLightingScrollbar.relativePosition = new Vector3(_optionsLightingPanel.width - 25f, 0f);
                    _optionsLightingScrollbar.orientation = UIOrientation.Vertical;
                    _optionsLightingScrollbar.incrementAmount = 38f;

                    _optionsLightingScrollbarTrack = UIUtils.CreateSlicedSprite(_optionsLightingScrollbar, "OptionsLightingScrollbarTrack");
                    _optionsLightingScrollbarTrack.width = _optionsLightingScrollbar.width;
                    _optionsLightingScrollbarTrack.height = _optionsLightingScrollbar.height;
                    _optionsLightingScrollbarTrack.relativePosition = new Vector3(0f, 0f);
                    _optionsLightingScrollbarTrack.spriteName = "ScrollbarTrack";
                    _optionsLightingScrollbarTrack.fillDirection = UIFillDirection.Vertical;

                    _optionsLightingScrollbarThumb = UIUtils.CreateSlicedSprite(_optionsLightingScrollbar, "OptionsLightingScrollbarThumb");
                    _optionsLightingScrollbarThumb.width = _optionsLightingScrollbar.width - 6f;
                    _optionsLightingScrollbarThumb.relativePosition = new Vector3(3f, 0f);
                    _optionsLightingScrollbarThumb.spriteName = "ScrollbarThumb";
                    _optionsLightingScrollbarThumb.fillDirection = UIFillDirection.Vertical;

                    _optionsLightingScrollablePanel.verticalScrollbar = _optionsLightingScrollbar;
                    _optionsLightingScrollbar.trackObject = _optionsLightingScrollbarTrack;
                    _optionsLightingScrollbar.thumbObject = _optionsLightingScrollbarThumb;

                    _optionsSunTitle = UIUtils.CreateTitle(_optionsLightingScrollablePanel, "OptionsSunTitle", "Sun");

                    _optionsSunIntensitySliderLabel = UIUtils.CreateLabel(_optionsLightingScrollablePanel, "OptionsSunIntensitySliderLabel", "Intensity");
                    _optionsSunIntensitySliderLabel.tooltip = "Set the intensity (brightness) of the sun";

                    _optionsSunIntensitySliderNumeral = UIUtils.CreateLabel(_optionsSunIntensitySliderLabel, "OptionsSunIntensitySliderNumeral", ProfileManager.Instance.ActiveProfile.SunIntensity.ToString());
                    _optionsSunIntensitySliderNumeral.width = 100f;
                    _optionsSunIntensitySliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _optionsSunIntensitySliderNumeral.relativePosition = new Vector3(_optionsLightingScrollablePanel.width - _optionsSunIntensitySliderNumeral.width - 10f, 0f);

                    _optionsSunIntensitySlider = UIUtils.CreateSlider(_optionsLightingScrollablePanel, "OptionsSunIntensitySlider", _ingameAtlas, 0f, 8f, 0.1f, 0.1f, ProfileManager.Instance.ActiveProfile.SunIntensity);
                    _optionsSunIntensitySlider.eventValueChanged += (component, value) =>
                    {
                        _optionsSunIntensitySliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.SunIntensity = value;
                        ProfileManager.Instance.Apply();
                    };
                    _optionsSunIntensitySlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _optionsSunIntensitySlider.value = (float)DefaultManager.Instance.Get("SunIntensity");
                        }
                    };

                    _optionsSunShadowStrengthSliderLabel = UIUtils.CreateLabel(_optionsLightingScrollablePanel, "OptionsSunShadowStrengthSliderLabel", "Shadow Strength");
                    _optionsSunShadowStrengthSliderLabel.tooltip = "Set the strength (darkness) of cast shadow from the sun";

                    _optionsSunShadowStrengthSliderNumeral = UIUtils.CreateLabel(_optionsSunShadowStrengthSliderLabel, "OptionsSunShadowStrengthSliderNumeral", ProfileManager.Instance.ActiveProfile.SunShadowStrength.ToString());
                    _optionsSunShadowStrengthSliderNumeral.width = 100f;
                    _optionsSunShadowStrengthSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _optionsSunShadowStrengthSliderNumeral.relativePosition = new Vector3(_optionsLightingScrollablePanel.width - _optionsSunShadowStrengthSliderNumeral.width - 10f, 0f);

                    _optionsSunShadowStrengthSlider = UIUtils.CreateSlider(_optionsLightingScrollablePanel, "OptionsSunShadowStrengthSlider", _ingameAtlas, 0f, 1f, 0.01f, 0.01f, ProfileManager.Instance.ActiveProfile.SunShadowStrength);
                    _optionsSunShadowStrengthSlider.eventValueChanged += (component, value) =>
                    {
                        _optionsSunShadowStrengthSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.SunShadowStrength = value;
                        ProfileManager.Instance.Apply();
                    };
                    _optionsSunShadowStrengthSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _optionsSunShadowStrengthSlider.value = (float)DefaultManager.Instance.Get("SunShadowStrength");
                        }
                    };

                    _optionsSunDivider = UIUtils.CreateDivider(_optionsLightingScrollablePanel, "OptionsSunDivider", _ingameAtlas);

                    _optionsMoonTitle = UIUtils.CreateTitle(_optionsLightingScrollablePanel, "OptionsMoonTitle", "Moon");

                    _optionsMoonIntensitySliderLabel = UIUtils.CreateLabel(_optionsLightingScrollablePanel, "OptionsMoonIntensitySliderLabel", "Intensity");
                    _optionsMoonIntensitySliderLabel.tooltip = "Set the intensity (brightness) of the moon";

                    _optionsMoonIntensitySliderNumeral = UIUtils.CreateLabel(_optionsMoonIntensitySliderLabel, "OptionsMoonIntensitySliderNumeral", ProfileManager.Instance.ActiveProfile.MoonIntensity.ToString());
                    _optionsMoonIntensitySliderNumeral.width = 100f;
                    _optionsMoonIntensitySliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _optionsMoonIntensitySliderNumeral.relativePosition = new Vector3(_optionsLightingScrollablePanel.width - _optionsMoonIntensitySliderNumeral.width - 10f, 0f);

                    _optionsMoonIntensitySlider = UIUtils.CreateSlider(_optionsLightingScrollablePanel, "OptionsMoonIntensitySlider", _ingameAtlas, 0f, 8f, 0.1f, 0.1f, ProfileManager.Instance.ActiveProfile.MoonIntensity);
                    _optionsMoonIntensitySlider.eventValueChanged += (component, value) =>
                    {
                        _optionsMoonIntensitySliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.MoonIntensity = value;
                        ProfileManager.Instance.Apply();
                    };
                    _optionsMoonIntensitySlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _optionsMoonIntensitySlider.value = (float)DefaultManager.Instance.Get("MoonIntensity");
                        }
                    };

                    _optionsMoonShadowStrengthSliderLabel = UIUtils.CreateLabel(_optionsLightingScrollablePanel, "OptionsMoonShadowStrengthSliderLabel", "Shadow Strength");
                    _optionsMoonShadowStrengthSliderLabel.tooltip = "Set the strength (darkness) of cast shadow from the moon";

                    _optionsMoonShadowStrengthSliderNumeral = UIUtils.CreateLabel(_optionsMoonShadowStrengthSliderLabel, "OptionsMoonShadowStrengthSliderNumeral", ProfileManager.Instance.ActiveProfile.MoonShadowStrength.ToString());
                    _optionsMoonShadowStrengthSliderNumeral.width = 100f;
                    _optionsMoonShadowStrengthSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _optionsMoonShadowStrengthSliderNumeral.relativePosition = new Vector3(_optionsLightingScrollablePanel.width - _optionsMoonShadowStrengthSliderNumeral.width - 10f, 0f);

                    _optionsMoonShadowStrengthSlider = UIUtils.CreateSlider(_optionsLightingScrollablePanel, "OptionsMoonShadowStrengthSlider", _ingameAtlas, 0f, 1f, 0.01f, 0.01f, ProfileManager.Instance.ActiveProfile.MoonShadowStrength);
                    _optionsMoonShadowStrengthSlider.eventValueChanged += (component, value) =>
                    {
                        _optionsMoonShadowStrengthSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.MoonShadowStrength = value;
                        ProfileManager.Instance.Apply();
                    };
                    _optionsMoonShadowStrengthSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _optionsMoonShadowStrengthSlider.value = (float)DefaultManager.Instance.Get("MoonShadowStrength");
                        }
                    };

                    _optionsMoonDivider = UIUtils.CreateDivider(_optionsLightingScrollablePanel, "OptionsMoonDivider", _ingameAtlas);

                    _optionsSkyTitle = UIUtils.CreateTitle(_optionsLightingScrollablePanel, "OptionsSkyTitle", "Sky");

                    if (!CompatibilityHelper.IsAnySkyManipulatingModsEnabled())
                    {
                        _optionsSkyRayleighScatteringSliderLabel = UIUtils.CreateLabel(_optionsLightingScrollablePanel, "OptionsSkyRayleighScatteringSliderLabel", "Rayleigh Scattering");
                        _optionsSkyRayleighScatteringSliderLabel.tooltip = "Set the strength of rayleigh scattering in the sky";

                        _optionsSkyRayleighScatteringSliderNumeral = UIUtils.CreateLabel(_optionsSkyRayleighScatteringSliderLabel, "OptionsSkyRayleighScatteringSliderNumeral", ProfileManager.Instance.ActiveProfile.SkyRayleighScattering.ToString());
                        _optionsSkyRayleighScatteringSliderNumeral.width = 100f;
                        _optionsSkyRayleighScatteringSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                        _optionsSkyRayleighScatteringSliderNumeral.relativePosition = new Vector3(_optionsLightingScrollablePanel.width - _optionsSkyRayleighScatteringSliderNumeral.width - 10f, 0f);

                        _optionsSkyRayleighScatteringSlider = UIUtils.CreateSlider(_optionsLightingScrollablePanel, "OptionsSkyRayleighScatteringSlider", _ingameAtlas, 0f, 5f, 0.1f, 0.1f, ProfileManager.Instance.ActiveProfile.SkyRayleighScattering);
                        _optionsSkyRayleighScatteringSlider.eventValueChanged += (component, value) =>
                        {
                            _optionsSkyRayleighScatteringSliderNumeral.text = value.ToString();
                            ProfileManager.Instance.ActiveProfile.SkyRayleighScattering = value;
                            ProfileManager.Instance.Apply();
                        };
                        _optionsSkyRayleighScatteringSlider.eventMouseUp += (component, eventParam) =>
                        {
                            if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                            {
                                _optionsSkyRayleighScatteringSlider.value = (float)DefaultManager.Instance.Get("SkyRayleighScattering");
                            }
                        };

                        _optionsSkyMieScatteringSliderLabel = UIUtils.CreateLabel(_optionsLightingScrollablePanel, "OptionsMieScatteringSliderLabel", "Mie Scattering");
                        _optionsSkyMieScatteringSliderLabel.tooltip = "Set the strength of mie scattering in the sky";

                        _optionsSkyMieScatteringSliderNumeral = UIUtils.CreateLabel(_optionsSkyMieScatteringSliderLabel, "OptionsMieScatteringSliderNumeral", ProfileManager.Instance.ActiveProfile.SkyMieScattering.ToString());
                        _optionsSkyMieScatteringSliderNumeral.width = 100f;
                        _optionsSkyMieScatteringSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                        _optionsSkyMieScatteringSliderNumeral.relativePosition = new Vector3(_optionsLightingScrollablePanel.width - _optionsSkyMieScatteringSliderNumeral.width - 10f, 0f);

                        _optionsSkyMieScatteringSlider = UIUtils.CreateSlider(_optionsLightingScrollablePanel, "OptionsMieScatteringSlider", _ingameAtlas, 0f, 5f, 0.1f, 0.1f, ProfileManager.Instance.ActiveProfile.SkyMieScattering);
                        _optionsSkyMieScatteringSlider.eventValueChanged += (component, value) =>
                        {
                            _optionsSkyMieScatteringSliderNumeral.text = value.ToString();
                            ProfileManager.Instance.ActiveProfile.SkyMieScattering = value;
                            ProfileManager.Instance.Apply();
                        };
                        _optionsSkyMieScatteringSlider.eventMouseUp += (component, eventParam) =>
                        {
                            if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                            {
                                _optionsSkyMieScatteringSlider.value = (float)DefaultManager.Instance.Get("SkyMieScattering");
                            }
                        };

                        _optionsSkyExposureSliderLabel = UIUtils.CreateLabel(_optionsLightingScrollablePanel, "OptionsSkyExposureSliderLabel", "Exposure");
                        _optionsSkyExposureSliderLabel.tooltip = "Set the strength of exposure through the sky";

                        _optionsSkyExposureSliderNumeral = UIUtils.CreateLabel(_optionsSkyExposureSliderLabel, "OptionsSkyExposureSliderNumeral", ProfileManager.Instance.ActiveProfile.SkyExposure.ToString());
                        _optionsSkyExposureSliderNumeral.width = 100f;
                        _optionsSkyExposureSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                        _optionsSkyExposureSliderNumeral.relativePosition = new Vector3(_optionsLightingScrollablePanel.width - _optionsSkyExposureSliderNumeral.width - 10f, 0f);

                        _optionsSkyExposureSlider = UIUtils.CreateSlider(_optionsLightingScrollablePanel, "OptionsSkyExposureSlider", _ingameAtlas, 0f, 5f, 0.1f, 0.1f, ProfileManager.Instance.ActiveProfile.SkyExposure);
                        _optionsSkyExposureSlider.eventValueChanged += (component, value) =>
                        {
                            _optionsSkyExposureSliderNumeral.text = value.ToString();
                            ProfileManager.Instance.ActiveProfile.SkyExposure = value;
                            ProfileManager.Instance.Apply();
                        };
                        _optionsSkyExposureSlider.eventMouseUp += (component, eventParam) =>
                        {
                            if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                            {
                                _optionsSkyExposureSlider.value = (float)DefaultManager.Instance.Get("SkyExposure");
                            }
                        };
                    }
                    else
                    {
                        _optionsSkyMessagePanel = UIUtils.CreatePanel(_optionsLightingScrollablePanel, "OptionsSkyMessagePanel");
                        _optionsSkyMessagePanel.backgroundSprite = "GenericPanelLight";
                        _optionsSkyMessagePanel.color = new Color32(206, 206, 206, 255);
                        _optionsSkyMessagePanel.height = 80f;
                        _optionsSkyMessagePanel.width = _optionsSkyMessagePanel.parent.width - 16f;
                        _optionsSkyMessagePanel.relativePosition = new Vector3(8f, 8f);

                        _optionsSkyMessageLabel = UIUtils.CreateLabel(_optionsSkyMessagePanel, "OptionsSkyMessageLabel", "Adjustment of rayleigh scattering, mie scattering and exposure in Render It! has been disabled because you have Theme Mixer 2 enabled.");
                        _optionsSkyMessageLabel.autoHeight = true;
                        _optionsSkyMessageLabel.width = _optionsSkyMessageLabel.parent.width - 16f;
                        _optionsSkyMessageLabel.relativePosition = new Vector3(8f, 8f);
                        _optionsSkyMessageLabel.wordWrap = true;
                    }

                    _optionsSkyRedWaveLengthSliderLabel = UIUtils.CreateLabel(_optionsLightingScrollablePanel, "OptionsSkyRedWaveLengthSliderLabel", "Red Wave Length");
                    _optionsSkyRedWaveLengthSliderLabel.tooltip = "Set the wave length of the red color";

                    _optionsSkyRedWaveLengthSliderNumeral = UIUtils.CreateLabel(_optionsSkyRedWaveLengthSliderLabel, "OptionsSkyRedWaveLengthSliderNumeral", ProfileManager.Instance.ActiveProfile.SkyRedWaveLength.ToString());
                    _optionsSkyRedWaveLengthSliderNumeral.width = 100f;
                    _optionsSkyRedWaveLengthSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _optionsSkyRedWaveLengthSliderNumeral.relativePosition = new Vector3(_optionsLightingScrollablePanel.width - _optionsSkyRedWaveLengthSliderNumeral.width - 10f, 0f);

                    _optionsSkyRedWaveLengthSlider = UIUtils.CreateSlider(_optionsLightingScrollablePanel, "OptionsSkyRedWaveLengthSlider", _ingameAtlas, 0f, 1000f, 10f, 50f, ProfileManager.Instance.ActiveProfile.SkyRedWaveLength);
                    _optionsSkyRedWaveLengthSlider.eventValueChanged += (component, value) =>
                    {
                        _optionsSkyRedWaveLengthSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.SkyRedWaveLength = value;
                        ProfileManager.Instance.Apply();
                    };
                    _optionsSkyRedWaveLengthSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _optionsSkyRedWaveLengthSlider.value = (float)DefaultManager.Instance.Get("SkyRedWaveLength");
                        }
                    };

                    _optionsSkyGreenWaveLengthSliderLabel = UIUtils.CreateLabel(_optionsLightingScrollablePanel, "OptionsSkyGreenWaveLengthSliderLabel", "Green Wave Length");
                    _optionsSkyGreenWaveLengthSliderLabel.tooltip = "Set the wave length of the green color";

                    _optionsSkyGreenWaveLengthSliderNumeral = UIUtils.CreateLabel(_optionsSkyGreenWaveLengthSliderLabel, "OptionsSkyGreenWaveLengthSliderNumeral", ProfileManager.Instance.ActiveProfile.SkyGreenWaveLength.ToString());
                    _optionsSkyGreenWaveLengthSliderNumeral.width = 100f;
                    _optionsSkyGreenWaveLengthSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _optionsSkyGreenWaveLengthSliderNumeral.relativePosition = new Vector3(_optionsLightingScrollablePanel.width - _optionsSkyGreenWaveLengthSliderNumeral.width - 10f, 0f);

                    _optionsSkyGreenWaveLengthSlider = UIUtils.CreateSlider(_optionsLightingScrollablePanel, "OptionsSkyGreenWaveLengthSlider", _ingameAtlas, 0f, 1000f, 10f, 50f, ProfileManager.Instance.ActiveProfile.SkyGreenWaveLength);
                    _optionsSkyGreenWaveLengthSlider.eventValueChanged += (component, value) =>
                    {
                        _optionsSkyGreenWaveLengthSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.SkyGreenWaveLength = value;
                        ProfileManager.Instance.Apply();
                    };
                    _optionsSkyGreenWaveLengthSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _optionsSkyGreenWaveLengthSlider.value = (float)DefaultManager.Instance.Get("SkyGreenWaveLength");
                        }
                    };

                    _optionsSkyBlueWaveLengthSliderLabel = UIUtils.CreateLabel(_optionsLightingScrollablePanel, "OptionsSkyBlueWaveLengthSliderLabel", "Blue Wave Length");
                    _optionsSkyBlueWaveLengthSliderLabel.tooltip = "Set the wave length of the blue color";

                    _optionsSkyBlueWaveLengthSliderNumeral = UIUtils.CreateLabel(_optionsSkyBlueWaveLengthSliderLabel, "OptionsSkyBlueWaveLengthSliderNumeral", ProfileManager.Instance.ActiveProfile.SkyBlueWaveLength.ToString());
                    _optionsSkyBlueWaveLengthSliderNumeral.width = 100f;
                    _optionsSkyBlueWaveLengthSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _optionsSkyBlueWaveLengthSliderNumeral.relativePosition = new Vector3(_optionsLightingScrollablePanel.width - _optionsSkyBlueWaveLengthSliderNumeral.width - 10f, 0f);

                    _optionsSkyBlueWaveLengthSlider = UIUtils.CreateSlider(_optionsLightingScrollablePanel, "OptionsSkyBlueWaveLengthSlider", _ingameAtlas, 0f, 1000f, 10f, 50f, ProfileManager.Instance.ActiveProfile.SkyBlueWaveLength);
                    _optionsSkyBlueWaveLengthSlider.eventValueChanged += (component, value) =>
                    {
                        _optionsSkyBlueWaveLengthSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.SkyBlueWaveLength = value;
                        ProfileManager.Instance.Apply();
                    };
                    _optionsSkyBlueWaveLengthSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _optionsSkyBlueWaveLengthSlider.value = (float)DefaultManager.Instance.Get("SkyBlueWaveLength");
                        }
                    };

                    _optionsColorsPanel = UIUtils.CreatePanel(panel, "OptionsColorsPanel");
                    _optionsColorsPanel.isVisible = false;
                    _optionsColorsPanel.width = _optionsColorsPanel.parent.width;
                    _optionsColorsPanel.height = _optionsColorsPanel.parent.height - 72f;
                    _optionsColorsPanel.autoLayout = true;
                    _optionsColorsPanel.autoLayoutStart = LayoutStart.TopLeft;
                    _optionsColorsPanel.autoLayoutDirection = LayoutDirection.Vertical;
                    _optionsColorsPanel.autoLayoutPadding.left = 0;
                    _optionsColorsPanel.autoLayoutPadding.right = 0;
                    _optionsColorsPanel.autoLayoutPadding.top = 0;
                    _optionsColorsPanel.autoLayoutPadding.bottom = 10;

                    _optionsLightColorsTitle = UIUtils.CreateTitle(_optionsColorsPanel, "OptionsLightColorsTitle", "Directional and Ambient Light Colors");

                    if (!CompatibilityHelper.IsAnyLightColorsManipulatingModsEnabled())
                    {
                        _optionsLightColorsCheckBox = UIUtils.CreateCheckBox(_optionsColorsPanel, "OptionsLightColorsCheckBox", _ingameAtlas, "Sun & Moon Colors Enabled", ProfileManager.Instance.ActiveProfile.LightColorsEnabled);
                        _optionsLightColorsCheckBox.tooltip = "Adjust colors for directional light from sun & moon";
                        _optionsLightColorsCheckBox.eventCheckChanged += (component, value) =>
                        {
                            ProfileManager.Instance.ActiveProfile.LightColorsEnabled = value;
                            ProfileManager.Instance.Apply();
                        };

                        _optionsLightColorsButtonPanel = UIUtils.CreatePanel(_optionsColorsPanel, "OptionsLightColorsButtonPanel");
                        _optionsLightColorsButtonPanel.width = panel.width - 10f;
                        _optionsLightColorsButtonPanel.height = 50f;

                        _optionsLightColorsResetButton = UIUtils.CreatePanelButton(_optionsLightColorsButtonPanel, "OptionsLightColorsResetButton", _ingameAtlas, "Reset");
                        _optionsLightColorsResetButton.tooltip = "Click to reset sun & moon directional light colors";
                        _optionsLightColorsResetButton.relativePosition = new Vector3(185f, 0f);
                        _optionsLightColorsResetButton.eventClick += (component, eventParam) =>
                        {
                            if (!eventParam.used)
                            {
                                ProfileManager.Instance.ActiveProfile.LightColors = ColorsHelper.ConvertToTimedColorList((GradientColorKey[])DefaultManager.Instance.Get("LightColors"));
                                ProfileManager.Instance.Apply();

                                if (_colorsPanel != null)
                                {
                                    if (_colorsPanel.isVisible)
                                    {
                                        _colorsPanel.SetColors(1);
                                    }
                                }

                                eventParam.Use();
                            }
                        };

                        _optionsLightColorsEditButton = UIUtils.CreatePanelButton(_optionsLightColorsButtonPanel, "OptionsLightColorsEditButton", _ingameAtlas, "Edit");
                        _optionsLightColorsEditButton.tooltip = "Click to edit sun & moon directional light colors";
                        _optionsLightColorsEditButton.relativePosition = new Vector3(270f, 0f);
                        _optionsLightColorsEditButton.eventClick += (component, eventParam) =>
                        {
                            if (!eventParam.used)
                            {
                                if (_colorsPanel != null)
                                {
                                    _colorsPanel.SetColors(1);

                                    if (!_colorsPanel.isVisible)
                                    {
                                        _colorsPanel.Show();
                                    }
                                }

                                eventParam.Use();
                            }
                        };

                        _optionsSkyColorsCheckBox = UIUtils.CreateCheckBox(_optionsColorsPanel, "OptionsSkyColorsCheckBox", _ingameAtlas, "Sky Colors Enabled", ProfileManager.Instance.ActiveProfile.SkyColorsEnabled);
                        _optionsSkyColorsCheckBox.tooltip = "Adjust colors for ambient light from the top. This affects terrain and building roofs the most";
                        _optionsSkyColorsCheckBox.eventCheckChanged += (component, value) =>
                        {
                            ProfileManager.Instance.ActiveProfile.SkyColorsEnabled = value;
                            ProfileManager.Instance.Apply();
                        };

                        _optionsSkyColorsButtonPanel = UIUtils.CreatePanel(_optionsColorsPanel, "OptionsSkyColorsButtonPanel");
                        _optionsSkyColorsButtonPanel.width = panel.width - 10f;
                        _optionsSkyColorsButtonPanel.height = 50f;

                        _optionsSkyColorsResetButton = UIUtils.CreatePanelButton(_optionsSkyColorsButtonPanel, "OptionsSkyColorsResetButton", _ingameAtlas, "Reset");
                        _optionsSkyColorsResetButton.tooltip = "Click to reset sky ambient light colors";
                        _optionsSkyColorsResetButton.relativePosition = new Vector3(185f, 0f);
                        _optionsSkyColorsResetButton.eventClick += (component, eventParam) =>
                        {
                            if (!eventParam.used)
                            {
                                ProfileManager.Instance.ActiveProfile.SkyColors = ColorsHelper.ConvertToTimedColorList((GradientColorKey[])DefaultManager.Instance.Get("SkyColors"));
                                ProfileManager.Instance.Apply();

                                if (_colorsPanel != null)
                                {
                                    if (_colorsPanel.isVisible)
                                    {
                                        _colorsPanel.SetColors(2);
                                    }
                                }

                                eventParam.Use();
                            }
                        };

                        _optionsSkyColorsEditButton = UIUtils.CreatePanelButton(_optionsSkyColorsButtonPanel, "OptionsSkyColorsEditButton", _ingameAtlas, "Edit");
                        _optionsSkyColorsEditButton.tooltip = "Click to edit sky ambient light colors";
                        _optionsSkyColorsEditButton.relativePosition = new Vector3(270f, 0f);
                        _optionsSkyColorsEditButton.eventClick += (component, eventParam) =>
                        {
                            if (!eventParam.used)
                            {
                                if (_colorsPanel != null)
                                {
                                    _colorsPanel.SetColors(2);

                                    if (!_colorsPanel.isVisible)
                                    {
                                        _colorsPanel.Show();
                                    }
                                }

                                eventParam.Use();
                            }
                        };

                        _optionsEquatorColorsCheckBox = UIUtils.CreateCheckBox(_optionsColorsPanel, "OptionsEquatorColorsCheckBox", _ingameAtlas, "Equator Colors Enabled", ProfileManager.Instance.ActiveProfile.EquatorColorsEnabled);
                        _optionsEquatorColorsCheckBox.tooltip = "Adjust colors for ambient light from the sides. This affects sides of buildings the most";
                        _optionsEquatorColorsCheckBox.eventCheckChanged += (component, value) =>
                        {
                            ProfileManager.Instance.ActiveProfile.EquatorColorsEnabled = value;
                            ProfileManager.Instance.Apply();
                        };

                        _optionsEquatorColorsButtonPanel = UIUtils.CreatePanel(_optionsColorsPanel, "OptionsEquatorColorsButtonPanel");
                        _optionsEquatorColorsButtonPanel.width = panel.width - 10f;
                        _optionsEquatorColorsButtonPanel.height = 50f;

                        _optionsEquatorColorsResetButton = UIUtils.CreatePanelButton(_optionsEquatorColorsButtonPanel, "OptionsEquatorColorsResetButton", _ingameAtlas, "Reset");
                        _optionsEquatorColorsResetButton.tooltip = "Click to reset equator ambient light colors";
                        _optionsEquatorColorsResetButton.relativePosition = new Vector3(185f, 0f);
                        _optionsEquatorColorsResetButton.eventClick += (component, eventParam) =>
                        {
                            if (!eventParam.used)
                            {
                                ProfileManager.Instance.ActiveProfile.EquatorColors = ColorsHelper.ConvertToTimedColorList((GradientColorKey[])DefaultManager.Instance.Get("EquatorColors"));
                                ProfileManager.Instance.Apply();

                                if (_colorsPanel != null)
                                {
                                    if (_colorsPanel.isVisible)
                                    {
                                        _colorsPanel.SetColors(3);
                                    }
                                }

                                eventParam.Use();
                            }
                        };

                        _optionsEquatorColorsEditButton = UIUtils.CreatePanelButton(_optionsEquatorColorsButtonPanel, "OptionsEquatorColorsEditButton", _ingameAtlas, "Edit");
                        _optionsEquatorColorsEditButton.tooltip = "Click to edit equator ambient light colors";
                        _optionsEquatorColorsEditButton.relativePosition = new Vector3(270f, 0f);
                        _optionsEquatorColorsEditButton.eventClick += (component, eventParam) =>
                        {
                            if (!eventParam.used)
                            {
                                if (_colorsPanel != null)
                                {
                                    _colorsPanel.SetColors(3);

                                    if (!_colorsPanel.isVisible)
                                    {
                                        _colorsPanel.Show();
                                    }
                                }

                                eventParam.Use();
                            }
                        };

                        _optionsGroundColorsCheckBox = UIUtils.CreateCheckBox(_optionsColorsPanel, "OptionsGroundColorsCheckBox", _ingameAtlas, "Ground Colors Enabled", ProfileManager.Instance.ActiveProfile.GroundColorsEnabled);
                        _optionsGroundColorsCheckBox.tooltip = "Adjust colors for ambient light from below. This affects road undersides the most";
                        _optionsGroundColorsCheckBox.eventCheckChanged += (component, value) =>
                        {
                            ProfileManager.Instance.ActiveProfile.GroundColorsEnabled = value;
                            ProfileManager.Instance.Apply();
                        };

                        _optionsGroundColorsButtonPanel = UIUtils.CreatePanel(_optionsColorsPanel, "OptionsGroundColorsButtonPanel");
                        _optionsGroundColorsButtonPanel.width = panel.width - 10f;
                        _optionsGroundColorsButtonPanel.height = 50f;

                        _optionsGroundColorsResetButton = UIUtils.CreatePanelButton(_optionsGroundColorsButtonPanel, "OptionsGroundColorsResetButton", _ingameAtlas, "Reset");
                        _optionsGroundColorsResetButton.tooltip = "Click to reset ground ambient light colors";
                        _optionsGroundColorsResetButton.relativePosition = new Vector3(185f, 0f);
                        _optionsGroundColorsResetButton.eventClick += (component, eventParam) =>
                        {
                            if (!eventParam.used)
                            {
                                ProfileManager.Instance.ActiveProfile.GroundColors = ColorsHelper.ConvertToTimedColorList((GradientColorKey[])DefaultManager.Instance.Get("GroundColors"));
                                ProfileManager.Instance.Apply();

                                if (_colorsPanel != null)
                                {
                                    if (_colorsPanel.isVisible)
                                    {
                                        _colorsPanel.SetColors(4);
                                    }
                                }

                                eventParam.Use();
                            }
                        };

                        _optionsGroundColorsEditButton = UIUtils.CreatePanelButton(_optionsGroundColorsButtonPanel, "OptionsGroundColorsEditButton", _ingameAtlas, "Edit");
                        _optionsGroundColorsEditButton.tooltip = "Click to edit ground ambient light colors";
                        _optionsGroundColorsEditButton.relativePosition = new Vector3(270f, 0f);
                        _optionsGroundColorsEditButton.eventClick += (component, eventParam) =>
                        {
                            if (!eventParam.used)
                            {
                                if (_colorsPanel != null)
                                {
                                    _colorsPanel.SetColors(4);

                                    if (!_colorsPanel.isVisible)
                                    {
                                        _colorsPanel.Show();
                                    }
                                }

                                eventParam.Use();
                            }
                        };
                    }
                    else
                    {
                        _optionsLightColorsMessagePanel = UIUtils.CreatePanel(_optionsColorsPanel, "OptionsLightColorsMessagePanel");
                        _optionsLightColorsMessagePanel.backgroundSprite = "GenericPanelLight";
                        _optionsLightColorsMessagePanel.color = new Color32(206, 206, 206, 255);
                        _optionsLightColorsMessagePanel.height = 80f;
                        _optionsLightColorsMessagePanel.width = _optionsLightColorsMessagePanel.parent.width - 16f;
                        _optionsLightColorsMessagePanel.relativePosition = new Vector3(8f, 8f);

                        _optionsLightColorsMessageLabel = UIUtils.CreateLabel(_optionsLightColorsMessagePanel, "OptionsLightColorsMessageLabel", "Adjustment of light colors in Render It! has been disabled because you have either Relight, Daylight Classic or Softer Shadows enabled.");
                        _optionsLightColorsMessageLabel.autoHeight = true;
                        _optionsLightColorsMessageLabel.width = _optionsLightColorsMessageLabel.parent.width - 16f;
                        _optionsLightColorsMessageLabel.relativePosition = new Vector3(8f, 8f);
                        _optionsLightColorsMessageLabel.wordWrap = true;

                    }

                    _optionsTexturesPanel = UIUtils.CreatePanel(panel, "OptionsTexturesPanel");
                    _optionsTexturesPanel.isVisible = false;
                    _optionsTexturesPanel.width = _optionsTexturesPanel.parent.width;
                    _optionsTexturesPanel.height = _optionsTexturesPanel.parent.height - 72f;
                    _optionsTexturesPanel.autoLayout = true;
                    _optionsTexturesPanel.autoLayoutStart = LayoutStart.TopLeft;
                    _optionsTexturesPanel.autoLayoutDirection = LayoutDirection.Vertical;
                    _optionsTexturesPanel.autoLayoutPadding.left = 0;
                    _optionsTexturesPanel.autoLayoutPadding.right = 0;
                    _optionsTexturesPanel.autoLayoutPadding.top = 0;
                    _optionsTexturesPanel.autoLayoutPadding.bottom = 10;

                    _optionsSharpnessTitle = UIUtils.CreateTitle(_optionsTexturesPanel, "OptionsSharpnessTitle", "Sharpness");

                    _optionsSharpnessAssetTypeDropDownLabel = UIUtils.CreateLabel(_optionsTexturesPanel, "OptionsSharpnessAssetTypeDropDownLabel", "Type");
                    _optionsSharpnessAssetTypeDropDownLabel.tooltip = "Select the asset type for which to set sharpness of textures";

                    _optionsSharpnessAssetTypeDropDown = UIUtils.CreateDropDown(_optionsTexturesPanel, "OptionsSharpnessAssetTypeDropDown", _ingameAtlas);
                    _optionsSharpnessAssetTypeDropDown.items = ModInvariables.SharpnessAssetType;

                    _optionsSharpnessAnisoLevelDropDownLabel = UIUtils.CreateLabel(_optionsTexturesPanel, "OptionsSharpnessAnisoLevelDropDownLabel", "Anisotropic Filtering Level");
                    _optionsSharpnessAnisoLevelDropDownLabel.tooltip = "Set the anisotropic filtering level which makes texture look better when viewed at a shallow angle";

                    _optionsSharpnessAnisoLevelDropDown = UIUtils.CreateDropDown(_optionsTexturesPanel, "OptionsSharpnessAnisoLevelDropDown", _ingameAtlas);
                    _optionsSharpnessAnisoLevelDropDown.items = ModInvariables.AnisoLevels;
                    _optionsSharpnessAnisoLevelDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        if (value != -1)
                        {
                            switch (_optionsSharpnessAssetTypeDropDown.selectedIndex)
                            {
                                case 0:
                                    ProfileManager.Instance.ActiveProfile.GeneralAnisoLevel = value;
                                    break;
                                case 1:
                                    ProfileManager.Instance.ActiveProfile.BuildingsAnisoLevel = value;
                                    break;
                                case 2:
                                    ProfileManager.Instance.ActiveProfile.NetworksAnisoLevel = value;
                                    break;
                                case 3:
                                    ProfileManager.Instance.ActiveProfile.PropsAnisoLevel = value;
                                    break;
                                case 4:
                                    ProfileManager.Instance.ActiveProfile.CitizensAnisoLevel = value;
                                    break;
                                case 5:
                                    ProfileManager.Instance.ActiveProfile.VehiclesAnisoLevel = value;
                                    break;
                                case 6:
                                    ProfileManager.Instance.ActiveProfile.TreesAnisoLevel = value;
                                    break;
                            }

                            ProfileManager.Instance.Apply();
                        }
                    };

                    _optionsSharpnessMipMapBiasDropDownLabel = UIUtils.CreateLabel(_optionsTexturesPanel, "OptionsSharpnessMipMapBiasDropDownLabel", "Mip Map Bias");
                    _optionsSharpnessMipMapBiasDropDownLabel.tooltip = "Set the mip map bias which sharpens or blurs the texture";

                    _optionsSharpnessMipMapBiasDropDown = UIUtils.CreateDropDown(_optionsTexturesPanel, "OptionsSharpnessMipMapBiasDropDown", _ingameAtlas);
                    _optionsSharpnessMipMapBiasDropDown.items = ModInvariables.MipMapBias;
                    _optionsSharpnessMipMapBiasDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        if (value != -1)
                        {
                            switch (_optionsSharpnessAssetTypeDropDown.selectedIndex)
                            {
                                case 0:
                                    ProfileManager.Instance.ActiveProfile.GeneralMipMapBias = value;
                                    break;
                                case 1:
                                    ProfileManager.Instance.ActiveProfile.BuildingsMipMapBias = value;
                                    break;
                                case 2:
                                    ProfileManager.Instance.ActiveProfile.NetworksMipMapBias = value;
                                    break;
                                case 3:
                                    ProfileManager.Instance.ActiveProfile.PropsMipMapBias = value;
                                    break;
                                case 4:
                                    ProfileManager.Instance.ActiveProfile.CitizensMipMapBias = value;
                                    break;
                                case 5:
                                    ProfileManager.Instance.ActiveProfile.VehiclesMipMapBias = value;
                                    break;
                                case 6:
                                    ProfileManager.Instance.ActiveProfile.TreesMipMapBias = value;
                                    break;
                            }

                            ProfileManager.Instance.Apply();
                        }
                    };

                    _optionsSharpnessLODCheckBox = UIUtils.CreateCheckBox(_optionsTexturesPanel, "OptionsSharpnessLODCheckBox", _ingameAtlas, "Apply also to LOD textures", false);
                    _optionsSharpnessLODCheckBox.tooltip = "Sharpness will also be applied to Level of Detail (LOD) textures";
                    _optionsSharpnessLODCheckBox.eventCheckChanged += (component, value) =>
                    {
                        switch (_optionsSharpnessAssetTypeDropDown.selectedIndex)
                        {
                            case 0:
                                ProfileManager.Instance.ActiveProfile.GeneralLODIncluded = value;
                                break;
                            case 1:
                                ProfileManager.Instance.ActiveProfile.BuildingsLODIncluded = value;
                                break;
                            case 2:
                                ProfileManager.Instance.ActiveProfile.NetworksLODIncluded = value;
                                break;
                            case 3:
                                ProfileManager.Instance.ActiveProfile.PropsLODIncluded = value;
                                break;
                            case 4:
                                ProfileManager.Instance.ActiveProfile.CitizensLODIncluded = value;
                                break;
                            case 5:
                                ProfileManager.Instance.ActiveProfile.VehiclesLODIncluded = value;
                                break;
                            case 6:
                                ProfileManager.Instance.ActiveProfile.TreesLODIncluded = value;
                                break;
                        }

                        ProfileManager.Instance.Apply();
                    };

                    _optionsSharpnessAssetTypeDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        if (value != -1)
                        {
                            switch (value)
                            {
                                case 0:
                                    _optionsSharpnessAnisoLevelDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.GeneralAnisoLevel;
                                    _optionsSharpnessMipMapBiasDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.GeneralMipMapBias;
                                    _optionsSharpnessLODCheckBox.isChecked = ProfileManager.Instance.ActiveProfile.GeneralLODIncluded;
                                    break;
                                case 1:
                                    _optionsSharpnessAnisoLevelDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.BuildingsAnisoLevel;
                                    _optionsSharpnessMipMapBiasDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.BuildingsMipMapBias;
                                    _optionsSharpnessLODCheckBox.isChecked = ProfileManager.Instance.ActiveProfile.BuildingsLODIncluded;
                                    break;
                                case 2:
                                    _optionsSharpnessAnisoLevelDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.NetworksAnisoLevel;
                                    _optionsSharpnessMipMapBiasDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.NetworksMipMapBias;
                                    _optionsSharpnessLODCheckBox.isChecked = ProfileManager.Instance.ActiveProfile.NetworksLODIncluded;
                                    break;
                                case 3:
                                    _optionsSharpnessAnisoLevelDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.PropsAnisoLevel;
                                    _optionsSharpnessMipMapBiasDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.PropsMipMapBias;
                                    _optionsSharpnessLODCheckBox.isChecked = ProfileManager.Instance.ActiveProfile.PropsLODIncluded;
                                    break;
                                case 4:
                                    _optionsSharpnessAnisoLevelDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.CitizensAnisoLevel;
                                    _optionsSharpnessMipMapBiasDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.CitizensMipMapBias;
                                    _optionsSharpnessLODCheckBox.isChecked = ProfileManager.Instance.ActiveProfile.CitizensLODIncluded;
                                    break;
                                case 5:
                                    _optionsSharpnessAnisoLevelDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.VehiclesAnisoLevel;
                                    _optionsSharpnessMipMapBiasDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.VehiclesMipMapBias;
                                    _optionsSharpnessLODCheckBox.isChecked = ProfileManager.Instance.ActiveProfile.VehiclesLODIncluded;
                                    break;
                                case 6:
                                    _optionsSharpnessAnisoLevelDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.TreesAnisoLevel;
                                    _optionsSharpnessMipMapBiasDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.TreesMipMapBias;
                                    _optionsSharpnessLODCheckBox.isChecked = ProfileManager.Instance.ActiveProfile.TreesLODIncluded;
                                    break;
                            }
                        }
                    };
                    _optionsSharpnessAssetTypeDropDown.selectedIndex = 0;

                    _optionsEnvironmentPanel = UIUtils.CreatePanel(panel, "OptionsEnvironmentPanel");
                    _optionsEnvironmentPanel.isVisible = false;
                    _optionsEnvironmentPanel.width = _optionsEnvironmentPanel.parent.width;
                    _optionsEnvironmentPanel.height = _optionsEnvironmentPanel.parent.height - 72f;
                    _optionsEnvironmentPanel.autoLayout = true;
                    _optionsEnvironmentPanel.autoLayoutStart = LayoutStart.TopLeft;
                    _optionsEnvironmentPanel.autoLayoutDirection = LayoutDirection.Vertical;
                    _optionsEnvironmentPanel.autoLayoutPadding.left = 0;
                    _optionsEnvironmentPanel.autoLayoutPadding.right = 0;
                    _optionsEnvironmentPanel.autoLayoutPadding.top = 0;
                    _optionsEnvironmentPanel.autoLayoutPadding.bottom = 10;

                    _optionsFogTitle = UIUtils.CreateTitle(_optionsEnvironmentPanel, "OptionsFogTitle", "Fog");

                    if (!CompatibilityHelper.IsAnyFogManipulatingModsEnabled())
                    {
                        _optionsFogCheckBox = UIUtils.CreateCheckBox(_optionsEnvironmentPanel, "OptionsFogCheckBox", _ingameAtlas, "Static Fog Enabled", ProfileManager.Instance.ActiveProfile.FogEnabled);
                        _optionsFogCheckBox.tooltip = "Enables static fog - also known as classic fog. Not all sliders below applies to static fog.";
                        _optionsFogCheckBox.eventCheckChanged += (component, value) =>
                        {
                            ProfileManager.Instance.ActiveProfile.FogEnabled = value;
                            ProfileManager.Instance.Apply();
                        };

                        _optionsFogDayNightCheckBox = UIUtils.CreateCheckBox(_optionsEnvironmentPanel, "OptionsFogDayNightCheckBox", _ingameAtlas, "Dynamic Fog Enabled", ProfileManager.Instance.ActiveProfile.FogDayNightEnabled);
                        _optionsFogDayNightCheckBox.tooltip = "Enables dynamic fog - also known as day/night fog. All sliders below applies to dynamic fog.";
                        _optionsFogDayNightCheckBox.eventCheckChanged += (component, value) =>
                        {
                            ProfileManager.Instance.ActiveProfile.FogDayNightEnabled = value;
                            ProfileManager.Instance.Apply();
                        };

                        _optionsFogHeightSliderLabel = UIUtils.CreateLabel(_optionsEnvironmentPanel, "OptionsFogHeightSliderLabel", "Height");
                        _optionsFogHeightSliderLabel.tooltip = "Set the height of fog";

                        _optionsFogHeightSliderNumeral = UIUtils.CreateLabel(_optionsFogHeightSliderLabel, "OptionsFogHeightSliderNumeral", ProfileManager.Instance.ActiveProfile.FogHeight.ToString());
                        _optionsFogHeightSliderNumeral.width = 100f;
                        _optionsFogHeightSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                        _optionsFogHeightSliderNumeral.relativePosition = new Vector3(_optionsEnvironmentPanel.width - _optionsFogHeightSliderNumeral.width - 10f, 0f);

                        _optionsFogHeightSlider = UIUtils.CreateSlider(_optionsEnvironmentPanel, "OptionsFogHeightSlider", _ingameAtlas, 0f, 5000f, 50f, 200f, ProfileManager.Instance.ActiveProfile.FogHeight);
                        _optionsFogHeightSlider.eventValueChanged += (component, value) =>
                        {
                            _optionsFogHeightSliderNumeral.text = value.ToString();
                            ProfileManager.Instance.ActiveProfile.FogHeight = value;
                            ProfileManager.Instance.Apply();
                        };
                        _optionsFogHeightSlider.eventMouseUp += (component, eventParam) =>
                        {
                            if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                            {
                                _optionsFogHeightSlider.value = (float)DefaultManager.Instance.Get("FogHeight");
                            }
                        };

                        _optionsFogHorizonHeightSliderLabel = UIUtils.CreateLabel(_optionsEnvironmentPanel, "OptionsFogHorizonHeightSliderLabel", "Horizon Height");
                        _optionsFogHorizonHeightSliderLabel.tooltip = "Set the horizon height of fog";

                        _optionsFogHorizonHeightSliderNumeral = UIUtils.CreateLabel(_optionsFogHorizonHeightSliderLabel, "OptionsFogHorizonHeightSliderNumeral", ProfileManager.Instance.ActiveProfile.FogHorizonHeight.ToString());
                        _optionsFogHorizonHeightSliderNumeral.width = 100f;
                        _optionsFogHorizonHeightSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                        _optionsFogHorizonHeightSliderNumeral.relativePosition = new Vector3(_optionsEnvironmentPanel.width - _optionsFogHorizonHeightSliderNumeral.width - 10f, 0f);

                        _optionsFogHorizonHeightSlider = UIUtils.CreateSlider(_optionsEnvironmentPanel, "OptionsFogHorizonHeightSlider", _ingameAtlas, 0f, 5000f, 50f, 200f, ProfileManager.Instance.ActiveProfile.FogHorizonHeight);
                        _optionsFogHorizonHeightSlider.eventValueChanged += (component, value) =>
                        {
                            _optionsFogHorizonHeightSliderNumeral.text = value.ToString();
                            ProfileManager.Instance.ActiveProfile.FogHorizonHeight = value;
                            ProfileManager.Instance.Apply();
                        };
                        _optionsFogHorizonHeightSlider.eventMouseUp += (component, eventParam) =>
                        {
                            if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                            {
                                _optionsFogHorizonHeightSlider.value = (float)DefaultManager.Instance.Get("FogHorizonHeight");
                            }
                        };

                        _optionsFogDensitySliderLabel = UIUtils.CreateLabel(_optionsEnvironmentPanel, "OptionsFogDensitySliderLabel", "Density");
                        _optionsFogDensitySliderLabel.tooltip = "Set the density of fog";

                        _optionsFogDensitySliderNumeral = UIUtils.CreateLabel(_optionsFogDensitySliderLabel, "OptionsFogDensitySliderNumeral", ProfileManager.Instance.ActiveProfile.FogDensity.ToString());
                        _optionsFogDensitySliderNumeral.width = 100f;
                        _optionsFogDensitySliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                        _optionsFogDensitySliderNumeral.relativePosition = new Vector3(_optionsEnvironmentPanel.width - _optionsFogDensitySliderNumeral.width - 10f, 0f);

                        _optionsFogDensitySlider = UIUtils.CreateSlider(_optionsEnvironmentPanel, "OptionsFogDensitySlider", _ingameAtlas, 0f, 0.003f, 0.00001f, 0.00005f, ProfileManager.Instance.ActiveProfile.FogDensity);
                        _optionsFogDensitySlider.eventValueChanged += (component, value) =>
                        {
                            _optionsFogDensitySliderNumeral.text = value.ToString();
                            ProfileManager.Instance.ActiveProfile.FogDensity = value;
                            ProfileManager.Instance.Apply();
                        };
                        _optionsFogDensitySlider.eventMouseUp += (component, eventParam) =>
                        {
                            if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                            {
                                _optionsFogDensitySlider.value = (float)DefaultManager.Instance.Get("FogDensity");
                            }
                        };

                        _optionsFogStartSliderLabel = UIUtils.CreateLabel(_optionsEnvironmentPanel, "OptionsFogStartSliderLabel", "Start");
                        _optionsFogStartSliderLabel.tooltip = "Set the start of fog";

                        _optionsFogStartSliderNumeral = UIUtils.CreateLabel(_optionsFogStartSliderLabel, "OptionsFogStartSliderNumeral", ProfileManager.Instance.ActiveProfile.FogStart.ToString());
                        _optionsFogStartSliderNumeral.width = 100f;
                        _optionsFogStartSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                        _optionsFogStartSliderNumeral.relativePosition = new Vector3(_optionsEnvironmentPanel.width - _optionsFogStartSliderNumeral.width - 10f, 0f);

                        _optionsFogStartSlider = UIUtils.CreateSlider(_optionsEnvironmentPanel, "OptionsFogStartSlider", _ingameAtlas, 0f, 4800f, 50f, 200f, ProfileManager.Instance.ActiveProfile.FogStart);
                        _optionsFogStartSlider.eventValueChanged += (component, value) =>
                        {
                            _optionsFogStartSliderNumeral.text = value.ToString();
                            ProfileManager.Instance.ActiveProfile.FogStart = value;
                            ProfileManager.Instance.Apply();
                        };
                        _optionsFogStartSlider.eventMouseUp += (component, eventParam) =>
                        {
                            if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                            {
                                _optionsFogStartSlider.value = (float)DefaultManager.Instance.Get("FogStart");
                            }
                        };

                        _optionsFogDistanceSliderLabel = UIUtils.CreateLabel(_optionsEnvironmentPanel, "OptionsFogDistanceSliderLabel", "Distance");
                        _optionsFogDistanceSliderLabel.tooltip = "Set the distance of fog";

                        _optionsFogDistanceSliderNumeral = UIUtils.CreateLabel(_optionsFogDistanceSliderLabel, "OptionsFogDistanceSliderNumeral", ProfileManager.Instance.ActiveProfile.FogDistance.ToString());
                        _optionsFogDistanceSliderNumeral.width = 100f;
                        _optionsFogDistanceSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                        _optionsFogDistanceSliderNumeral.relativePosition = new Vector3(_optionsEnvironmentPanel.width - _optionsFogDistanceSliderNumeral.width - 10f, 0f);

                        _optionsFogDistanceSlider = UIUtils.CreateSlider(_optionsEnvironmentPanel, "OptionsFogDistanceSlider", _ingameAtlas, 0f, 20000f, 10f, 200f, ProfileManager.Instance.ActiveProfile.FogDistance);
                        _optionsFogDistanceSlider.eventValueChanged += (component, value) =>
                        {
                            _optionsFogDistanceSliderNumeral.text = value.ToString();
                            ProfileManager.Instance.ActiveProfile.FogDistance = value;
                            ProfileManager.Instance.Apply();
                        };
                        _optionsFogDistanceSlider.eventMouseUp += (component, eventParam) =>
                        {
                            if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                            {
                                _optionsFogDistanceSlider.value = (float)DefaultManager.Instance.Get("FogDistance");
                            }
                        };

                        _optionsFogEdgeDistanceSliderLabel = UIUtils.CreateLabel(_optionsEnvironmentPanel, "OptionsFogEdgeDistanceSliderLabel", "Edge Distance");
                        _optionsFogEdgeDistanceSliderLabel.tooltip = "Set the edge distance of fog";

                        _optionsFogEdgeDistanceSliderNumeral = UIUtils.CreateLabel(_optionsFogEdgeDistanceSliderLabel, "OptionsFogEdgeDistanceSliderNumeral", ProfileManager.Instance.ActiveProfile.FogEdgeDistance.ToString());
                        _optionsFogEdgeDistanceSliderNumeral.width = 100f;
                        _optionsFogEdgeDistanceSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                        _optionsFogEdgeDistanceSliderNumeral.relativePosition = new Vector3(_optionsEnvironmentPanel.width - _optionsFogEdgeDistanceSliderNumeral.width - 10f, 0f);

                        _optionsFogEdgeDistanceSlider = UIUtils.CreateSlider(_optionsEnvironmentPanel, "OptionsFogEdgeDistanceSlider", _ingameAtlas, 0f, 3800f, 50f, 200f, ProfileManager.Instance.ActiveProfile.FogEdgeDistance);
                        _optionsFogEdgeDistanceSlider.eventValueChanged += (component, value) =>
                        {
                            _optionsFogEdgeDistanceSliderNumeral.text = value.ToString();
                            ProfileManager.Instance.ActiveProfile.FogEdgeDistance = value;
                            ProfileManager.Instance.Apply();
                        };
                        _optionsFogEdgeDistanceSlider.eventMouseUp += (component, eventParam) =>
                        {
                            if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                            {
                                _optionsFogEdgeDistanceSlider.value = (float)DefaultManager.Instance.Get("FogEdgeDistance");
                            }
                        };

                        _optionsFogNoiseContributionSliderLabel = UIUtils.CreateLabel(_optionsEnvironmentPanel, "OptionsFogNoiseContributionSliderLabel", "Noise Contribution");
                        _optionsFogNoiseContributionSliderLabel.tooltip = "Set the noise contribution of fog";

                        _optionsFogNoiseContributionSliderNumeral = UIUtils.CreateLabel(_optionsFogNoiseContributionSliderLabel, "OptionsFogNoiseContributionSliderNumeral", ProfileManager.Instance.ActiveProfile.FogNoiseContribution.ToString());
                        _optionsFogNoiseContributionSliderNumeral.width = 100f;
                        _optionsFogNoiseContributionSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                        _optionsFogNoiseContributionSliderNumeral.relativePosition = new Vector3(_optionsEnvironmentPanel.width - _optionsFogNoiseContributionSliderNumeral.width - 10f, 0f);

                        _optionsFogNoiseContributionSlider = UIUtils.CreateSlider(_optionsEnvironmentPanel, "OptionsFogNoiseContributionSlider", _ingameAtlas, 0f, 1f, 0.01f, 0.1f, ProfileManager.Instance.ActiveProfile.FogNoiseContribution);
                        _optionsFogNoiseContributionSlider.eventValueChanged += (component, value) =>
                        {
                            _optionsFogNoiseContributionSliderNumeral.text = value.ToString();
                            ProfileManager.Instance.ActiveProfile.FogNoiseContribution = value;
                            ProfileManager.Instance.Apply();
                        };
                        _optionsFogNoiseContributionSlider.eventMouseUp += (component, eventParam) =>
                        {
                            if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                            {
                                _optionsFogNoiseContributionSlider.value = (float)DefaultManager.Instance.Get("FogNoiseContribution");
                            }
                        };

                        _optionsFogPollutionAmountSliderLabel = UIUtils.CreateLabel(_optionsEnvironmentPanel, "OptionsFogPollutionAmountSliderLabel", "Pollution Amount");
                        _optionsFogPollutionAmountSliderLabel.tooltip = "Set the pollution amount of fog";

                        _optionsFogPollutionAmountSliderNumeral = UIUtils.CreateLabel(_optionsFogPollutionAmountSliderLabel, "OptionsFogPollutionAmountSliderNumeral", ProfileManager.Instance.ActiveProfile.FogPollutionAmount.ToString());
                        _optionsFogPollutionAmountSliderNumeral.width = 100f;
                        _optionsFogPollutionAmountSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                        _optionsFogPollutionAmountSliderNumeral.relativePosition = new Vector3(_optionsEnvironmentPanel.width - _optionsFogPollutionAmountSliderNumeral.width - 10f, 0f);

                        _optionsFogPollutionAmountSlider = UIUtils.CreateSlider(_optionsEnvironmentPanel, "OptionsFogPollutionAmountSlider", _ingameAtlas, 0f, 1f, 0.01f, 0.1f, ProfileManager.Instance.ActiveProfile.FogPollutionAmount);
                        _optionsFogPollutionAmountSlider.eventValueChanged += (component, value) =>
                        {
                            _optionsFogPollutionAmountSliderNumeral.text = value.ToString();
                            ProfileManager.Instance.ActiveProfile.FogPollutionAmount = value;
                            ProfileManager.Instance.Apply();
                        };
                        _optionsFogPollutionAmountSlider.eventMouseUp += (component, eventParam) =>
                        {
                            if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                            {
                                _optionsFogPollutionAmountSlider.value = (float)DefaultManager.Instance.Get("FogPollutionAmount");
                            }
                        };

                        _optionsFogColorDecaySliderLabel = UIUtils.CreateLabel(_optionsEnvironmentPanel, "OptionsFogColorDecaySliderLabel", "Color Decay");
                        _optionsFogColorDecaySliderLabel.tooltip = "Set the color decay of fog";

                        _optionsFogColorDecaySliderNumeral = UIUtils.CreateLabel(_optionsFogColorDecaySliderLabel, "OptionsFogColorDecaySliderNumeral", ProfileManager.Instance.ActiveProfile.FogColorDecay.ToString());
                        _optionsFogColorDecaySliderNumeral.width = 100f;
                        _optionsFogColorDecaySliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                        _optionsFogColorDecaySliderNumeral.relativePosition = new Vector3(_optionsEnvironmentPanel.width - _optionsFogColorDecaySliderNumeral.width - 10f, 0f);

                        _optionsFogColorDecaySlider = UIUtils.CreateSlider(_optionsEnvironmentPanel, "OptionsFogColorDecaySlider", _ingameAtlas, 0f, 1f, 0.005f, 0.01f, ProfileManager.Instance.ActiveProfile.FogColorDecay);
                        _optionsFogColorDecaySlider.eventValueChanged += (component, value) =>
                        {
                            _optionsFogColorDecaySliderNumeral.text = value.ToString();
                            ProfileManager.Instance.ActiveProfile.FogColorDecay = value;
                            ProfileManager.Instance.Apply();
                        };
                        _optionsFogColorDecaySlider.eventMouseUp += (component, eventParam) =>
                        {
                            if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                            {
                                _optionsFogColorDecaySlider.value = (float)DefaultManager.Instance.Get("FogColorDecay");
                            }
                        };

                        _optionsFogScatteringSliderLabel = UIUtils.CreateLabel(_optionsEnvironmentPanel, "OptionsFogScatteringSliderLabel", "Scattering");
                        _optionsFogScatteringSliderLabel.tooltip = "Set the scattering of fog";

                        _optionsFogScatteringSliderNumeral = UIUtils.CreateLabel(_optionsFogScatteringSliderLabel, "OptionsFogScatteringSliderNumeral", ProfileManager.Instance.ActiveProfile.FogScattering.ToString());
                        _optionsFogScatteringSliderNumeral.width = 100f;
                        _optionsFogScatteringSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                        _optionsFogScatteringSliderNumeral.relativePosition = new Vector3(_optionsEnvironmentPanel.width - _optionsFogScatteringSliderNumeral.width - 10f, 0f);

                        _optionsFogScatteringSlider = UIUtils.CreateSlider(_optionsEnvironmentPanel, "OptionsFogScatteringSlider", _ingameAtlas, 0f, 1f, 0.01f, 0.1f, ProfileManager.Instance.ActiveProfile.FogScattering);
                        _optionsFogScatteringSlider.eventValueChanged += (component, value) =>
                        {
                            _optionsFogScatteringSliderNumeral.text = value.ToString();
                            ProfileManager.Instance.ActiveProfile.FogScattering = value;
                            ProfileManager.Instance.Apply();
                        };
                        _optionsFogScatteringSlider.eventMouseUp += (component, eventParam) =>
                        {
                            if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                            {
                                _optionsFogScatteringSlider.value = (float)DefaultManager.Instance.Get("FogScattering");
                            }
                        };
                    }
                    else
                    {
                        _optionsFogMessagePanel = UIUtils.CreatePanel(_optionsEnvironmentPanel, "OptionsFogMessagePanel");
                        _optionsFogMessagePanel.backgroundSprite = "GenericPanelLight";
                        _optionsFogMessagePanel.color = new Color32(206, 206, 206, 255);
                        _optionsFogMessagePanel.height = 80f;
                        _optionsFogMessagePanel.width = _optionsFogMessagePanel.parent.width - 16f;
                        _optionsFogMessagePanel.relativePosition = new Vector3(8f, 8f);

                        _optionsFogMessageLabel = UIUtils.CreateLabel(_optionsFogMessagePanel, "OptionsFogMessageLabel", "Adjustment of fog in Render It! has been disabled because you have either Fog Controller, Clouds & Fog Toggler or Daylight Classic enabled.");
                        _optionsFogMessageLabel.autoHeight = true;
                        _optionsFogMessageLabel.width = _optionsFogMessageLabel.parent.width - 16f;
                        _optionsFogMessageLabel.relativePosition = new Vector3(8f, 8f);
                        _optionsFogMessageLabel.wordWrap = true;
                    }

                    _optionsPostProcessingPanel = UIUtils.CreatePanel(panel, "OptionsPostProcessingPanel");
                    _optionsPostProcessingPanel.isVisible = false;
                    _optionsPostProcessingPanel.width = _optionsPostProcessingPanel.parent.width;
                    _optionsPostProcessingPanel.height = _optionsPostProcessingPanel.parent.height - 72f;
                    _optionsPostProcessingPanel.autoLayout = true;
                    _optionsPostProcessingPanel.autoLayoutStart = LayoutStart.TopLeft;
                    _optionsPostProcessingPanel.autoLayoutDirection = LayoutDirection.Vertical;
                    _optionsPostProcessingPanel.autoLayoutPadding.left = 0;
                    _optionsPostProcessingPanel.autoLayoutPadding.right = 0;
                    _optionsPostProcessingPanel.autoLayoutPadding.top = 0;
                    _optionsPostProcessingPanel.autoLayoutPadding.bottom = 10;

                    _optionsAntiAliasingTitle = UIUtils.CreateTitle(_optionsPostProcessingPanel, "OptionsAntiAliasingTitle", "Anti-aliasing");

                    _optionsAntiAliasingDropDownLabel = UIUtils.CreateLabel(_optionsPostProcessingPanel, "OptionsAntiAliasingDropDownLabel", "Technique");
                    _optionsAntiAliasingDropDownLabel.tooltip = "The Anti-aliasing techniques offers a set of algorithms designed to prevent aliasing and give a smoother appearance to graphics.\n\nFor anti-aliasing, the game uses the default Enhanced Subpixel Morphological Anti-Aliasing (SMAA) technique\nbut this can be improved with either Fast Approximate Anti-Aliasing (FXAA) or Temporal Anti-Aliasing (TAA) techniques.";

                    _optionsAntiAliasingDropDown = UIUtils.CreateDropDown(_optionsPostProcessingPanel, "OptionsAntiAliasingDropDown", _ingameAtlas);
                    _optionsAntiAliasingDropDown.items = ModInvariables.AntialiasingTechnique;
                    _optionsAntiAliasingDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.AntialiasingTechnique;
                    _optionsAntiAliasingDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        if (value != -1)
                        {
                            ProfileManager.Instance.ActiveProfile.AntialiasingTechnique = value;
                            ProfileManager.Instance.Apply();

                            if (value == 3)
                            {
                                if (GameOptionsHelper.GetDepthOfFieldInOptionsGraphicsPanel() != 0)
                                {
                                    ConfirmPanel.ShowModal("Depth of Field", "Depth of Field should be disabled when using TAA. Do you want to disable Depth of Field now?", (comp, ret) =>
                                    {
                                        if (ret == 1)
                                        {
                                            GameOptionsHelper.SetDepthOfFieldInOptionsGraphicsPanel(false);
                                        }
                                    });
                                }
                            }
                        }
                    };

                    _optionsAntiAliasingButtonPanel = UIUtils.CreatePanel(_optionsPostProcessingPanel, "OptionsAntiAliasingButtonPanel");
                    _optionsAntiAliasingButtonPanel.width = panel.width - 10f;
                    _optionsAntiAliasingButtonPanel.height = 32f;

                    _optionsAntiAliasingEditButton = UIUtils.CreatePanelButton(_optionsAntiAliasingButtonPanel, "OptionsAntiAliasingEditButton", _ingameAtlas, "Edit");
                    _optionsAntiAliasingEditButton.tooltip = "Click to edit anti-aliasing settings";
                    _optionsAntiAliasingEditButton.relativePosition = new Vector3(270f, 0f);
                    _optionsAntiAliasingEditButton.eventClick += (component, eventParam) =>
                    {
                        if (!eventParam.used)
                        {
                            if (_antiAliasingPanel != null)
                            {
                                if (!_antiAliasingPanel.isVisible)
                                {
                                    _antiAliasingPanel.Show();
                                }
                            }

                            eventParam.Use();
                        }
                    };

                    _optionsAntiAliasingDivider = UIUtils.CreateDivider(_optionsPostProcessingPanel, "OptionsAntiAliasingDivider", _ingameAtlas);

                    _optionsVanillaEffectsTitle = UIUtils.CreateTitle(_optionsPostProcessingPanel, "OptionsVanillaEffectsTitle", "Vanilla Effects");

                    _optionsVanillaBloomCheckBox = UIUtils.CreateCheckBox(_optionsPostProcessingPanel, "OptionsVanillaBloomCheckBox", _ingameAtlas, "Bloom Enabled", ProfileManager.Instance.ActiveProfile.VanillaBloomEnabled);
                    _optionsVanillaBloomCheckBox.tooltip = "Keep bloom from the vanilla game";
                    _optionsVanillaBloomCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ProfileManager.Instance.ActiveProfile.VanillaBloomEnabled = value;
                        ProfileManager.Instance.Apply();
                    };

                    _optionsVanillaTonemappingCheckBox = UIUtils.CreateCheckBox(_optionsPostProcessingPanel, "OptionsVanillaTonemappingCheckBox", _ingameAtlas, "Tonemapping Enabled", ProfileManager.Instance.ActiveProfile.VanillaTonemappingEnabled);
                    _optionsVanillaTonemappingCheckBox.tooltip = "Keep tonemapping from the vanilla game";
                    _optionsVanillaTonemappingCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ProfileManager.Instance.ActiveProfile.VanillaTonemappingEnabled = value;
                        ProfileManager.Instance.Apply();
                    };

                    _optionsVanillaColorCorrectionLutCheckBox = UIUtils.CreateCheckBox(_optionsPostProcessingPanel, "OptionsVanillaColorCorrectionLutCheckBox", _ingameAtlas, "Color Correction LUT Enabled", ProfileManager.Instance.ActiveProfile.VanillaColorCorrectionLutEnabled);
                    _optionsVanillaColorCorrectionLutCheckBox.tooltip = "Keep color correction LUT from the vanilla game";
                    _optionsVanillaColorCorrectionLutCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ProfileManager.Instance.ActiveProfile.VanillaColorCorrectionLutEnabled = value;
                        ProfileManager.Instance.Apply();
                    };

                    _optionsVanillaColorCorrectionLutDropDown = UIUtils.CreateDropDown(_optionsPostProcessingPanel, "OptionsVanillaColorCorrectionLutDropDown", _ingameAtlas);
                    _optionsVanillaColorCorrectionLutDropDown.items = LutManager.Instance.LocalizedNames;
                    _optionsVanillaColorCorrectionLutDropDown.selectedIndex = LutManager.Instance.IndexOf(ProfileManager.Instance.ActiveProfile.VanillaColorCorrectionLutName);
                    _optionsVanillaColorCorrectionLutDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        if (value != -1)
                        {
                            ProfileManager.Instance.ActiveProfile.VanillaColorCorrectionLutName = LutManager.Instance.Names[value];
                            ProfileManager.Instance.Apply();
                        }
                    };

                    _optionsVanillaEffectsDivider = UIUtils.CreateDivider(_optionsPostProcessingPanel, "OptionsVanillaEffectsDivider", _ingameAtlas);

                    _optionsEnhancedEffectsTitle = UIUtils.CreateTitle(_optionsPostProcessingPanel, "OptionsExtendedEffectsTitle", " Enhanced Effects");

                    _optionsAmbientOcclusionCheckBox = UIUtils.CreateCheckBox(_optionsPostProcessingPanel, "OptionsAmbientOcclusionCheckBox", _ingameAtlas, "Ambient Occlusion Enabled", ProfileManager.Instance.ActiveProfile.AmbientOcclusionEnabled);
                    _optionsAmbientOcclusionCheckBox.tooltip = "Ambient Occlusion darkens creases, holes, intersections and surfaces that are close to each other";
                    _optionsAmbientOcclusionCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ProfileManager.Instance.ActiveProfile.AmbientOcclusionEnabled = value;
                        ProfileManager.Instance.Apply();
                    };

                    _optionsAmbientOcclusionButtonPanel = UIUtils.CreatePanel(_optionsPostProcessingPanel, "OptionsAmbientOcclusionButtonPanel");
                    _optionsAmbientOcclusionButtonPanel.width = panel.width - 10f;
                    _optionsAmbientOcclusionButtonPanel.height = 32f;

                    _optionsAmbientOcclusionEditButton = UIUtils.CreatePanelButton(_optionsAmbientOcclusionButtonPanel, "OptionsAmbientOcclusionEditButton", _ingameAtlas, "Edit");
                    _optionsAmbientOcclusionEditButton.tooltip = "Click to edit ambient occlusion settings";
                    _optionsAmbientOcclusionEditButton.relativePosition = new Vector3(270f, 0f);
                    _optionsAmbientOcclusionEditButton.eventClick += (component, eventParam) =>
                    {
                        if (!eventParam.used)
                        {
                            if (_ambientOcclusionPanel != null)
                            {
                                if (!_ambientOcclusionPanel.isVisible)
                                {
                                    _ambientOcclusionPanel.Show();
                                }
                            }

                            eventParam.Use();
                        }
                    };

                    _optionsBloomCheckBox = UIUtils.CreateCheckBox(_optionsPostProcessingPanel, "OptionsBloomCheckBox", _ingameAtlas, "Bloom Enabled", ProfileManager.Instance.ActiveProfile.BloomEnabled);
                    _optionsBloomCheckBox.tooltip = "Bloom creates fringes of light extending from the borders of bright areas in an image,\ncontributing to the illusion of an extremely bright light overwhelming the camera";
                    _optionsBloomCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ProfileManager.Instance.ActiveProfile.BloomEnabled = value;
                        ProfileManager.Instance.Apply();
                    };

                    _optionsBloomButtonPanel = UIUtils.CreatePanel(_optionsPostProcessingPanel, "OptionsBloomButtonPanel");
                    _optionsBloomButtonPanel.width = panel.width - 10f;
                    _optionsBloomButtonPanel.height = 32f;

                    _optionsBloomEditButton = UIUtils.CreatePanelButton(_optionsBloomButtonPanel, "OptionsBloomEditButton", _ingameAtlas, "Edit");
                    _optionsBloomEditButton.tooltip = "Click to edit bloom settings";
                    _optionsBloomEditButton.relativePosition = new Vector3(270f, 0f);
                    _optionsBloomEditButton.eventClick += (component, eventParam) =>
                    {
                        if (!eventParam.used)
                        {
                            if (_bloomPanel != null)
                            {
                                if (!_bloomPanel.isVisible)
                                {
                                    _bloomPanel.Show();
                                }
                            }

                            eventParam.Use();
                        }
                    };

                    _optionsColorGradingCheckBox = UIUtils.CreateCheckBox(_optionsPostProcessingPanel, "OptionsColorGradingCheckBox", _ingameAtlas, "Color Grading Enabled", ProfileManager.Instance.ActiveProfile.ColorGradingEnabled);
                    _optionsColorGradingCheckBox.tooltip = "Color Grading alters or corrects the color and luminance of the final image that is rendered";
                    _optionsColorGradingCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ProfileManager.Instance.ActiveProfile.ColorGradingEnabled = value;
                        ProfileManager.Instance.Apply();
                    };

                    _optionsColorGradingButtonPanel = UIUtils.CreatePanel(_optionsPostProcessingPanel, "OptionsColorGradingButtonPanel");
                    _optionsColorGradingButtonPanel.width = panel.width - 10f;
                    _optionsColorGradingButtonPanel.height = 32f;

                    _optionsColorGradingEditButton = UIUtils.CreatePanelButton(_optionsColorGradingButtonPanel, "OptionsColorGradingEditButton", _ingameAtlas, "Edit");
                    _optionsColorGradingEditButton.tooltip = "Click to edit color grading settings";
                    _optionsColorGradingEditButton.relativePosition = new Vector3(270f, 0f);
                    _optionsColorGradingEditButton.eventClick += (component, eventParam) =>
                    {
                        if (!eventParam.used)
                        {
                            if (_colorGradingPanel != null)
                            {
                                if (!_colorGradingPanel.isVisible)
                                {
                                    _colorGradingPanel.Show();
                                }
                            }

                            eventParam.Use();
                        }
                    };

                    _optionsDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        if (value != -1)
                        {
                            switch (value)
                            {
                                case 0:
                                    _optionsLightingPanel.isVisible = true;
                                    _optionsColorsPanel.isVisible = false;
                                    _optionsTexturesPanel.isVisible = false;
                                    _optionsEnvironmentPanel.isVisible = false;
                                    _optionsPostProcessingPanel.isVisible = false;
                                    break;
                                case 1:
                                    _optionsLightingPanel.isVisible = false;
                                    _optionsColorsPanel.isVisible = true;
                                    _optionsTexturesPanel.isVisible = false;
                                    _optionsEnvironmentPanel.isVisible = false;
                                    _optionsPostProcessingPanel.isVisible = false;
                                    break;
                                case 2:
                                    _optionsLightingPanel.isVisible = false;
                                    _optionsColorsPanel.isVisible = false;
                                    _optionsTexturesPanel.isVisible = true;
                                    _optionsEnvironmentPanel.isVisible = false;
                                    _optionsPostProcessingPanel.isVisible = false;
                                    break;
                                case 3:
                                    _optionsLightingPanel.isVisible = false;
                                    _optionsColorsPanel.isVisible = false;
                                    _optionsTexturesPanel.isVisible = false;
                                    _optionsEnvironmentPanel.isVisible = true;
                                    _optionsPostProcessingPanel.isVisible = false;
                                    break;
                                case 4:
                                    _optionsLightingPanel.isVisible = false;
                                    _optionsColorsPanel.isVisible = false;
                                    _optionsTexturesPanel.isVisible = false;
                                    _optionsEnvironmentPanel.isVisible = false;
                                    _optionsPostProcessingPanel.isVisible = true;
                                    break;
                                default:
                                    _optionsLightingPanel.isVisible = true;
                                    _optionsColorsPanel.isVisible = false;
                                    _optionsTexturesPanel.isVisible = false;
                                    _optionsEnvironmentPanel.isVisible = false;
                                    _optionsPostProcessingPanel.isVisible = false;
                                    break;
                            }
                        }
                    };
                    _optionsDropDown.selectedIndex = 0;
                }

                _tabstrip.AddTab("Advanced", _templateButton, true);
                _tabstrip.selectedIndex = 2;
                panel = _tabstrip.tabContainer.components[2] as UIPanel;
                if (panel != null)
                {
                    panel.autoLayout = true;
                    panel.autoLayoutStart = LayoutStart.TopLeft;
                    panel.autoLayoutDirection = LayoutDirection.Vertical;
                    panel.autoLayoutPadding.left = 5;
                    panel.autoLayoutPadding.right = 0;
                    panel.autoLayoutPadding.top = 0;
                    panel.autoLayoutPadding.bottom = 10;

                    _advancedKeymappingsTitle = UIUtils.CreateTitle(panel, "AdvancedKeymappingsTitle", "Keymappings");
                    _advancedKeymappingsTitle.tooltip = "Advanced options for Keymappings";

                    _advancedKeymappingsEnabledCheckBox = UIUtils.CreateCheckBox(panel, "AdvancedKeymappingsEnabledCheckBox", _ingameAtlas, "Keymappings Enabled", ModConfig.Instance.KeymappingsEnabled);
                    _advancedKeymappingsEnabledCheckBox.tooltip = "Set if keymappings should be enabled";
                    _advancedKeymappingsEnabledCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ModConfig.Instance.KeymappingsEnabled = value;
                        ModConfig.Instance.Save();
                    };

                    _advancedKeymappingsNextProfileDropDownLabel = UIUtils.CreateLabel(panel, "AdvancedKeymappingsNextProfileDropDownLabel", "Next profile");
                    _advancedKeymappingsNextProfileDropDownLabel.tooltip = "Set the keymapping for next profile";

                    _advancedKeymappingsNextProfileDropDown = UIUtils.CreateDropDown(panel, "AdvancedKeymappingsNextProfileDropDown", _ingameAtlas);
                    _advancedKeymappingsNextProfileDropDown.items = ModInvariables.KeymappingNames;
                    _advancedKeymappingsNextProfileDropDown.selectedIndex = ModConfig.Instance.KeymappingsNextProfile;
                    _advancedKeymappingsNextProfileDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        ModConfig.Instance.KeymappingsNextProfile = value;
                        ModConfig.Instance.Save();
                    };

                    _advancedKeymappingsPreviousProfileDropDownLabel = UIUtils.CreateLabel(panel, "AdvancedKeymappingsPreviousProfileDropDownLabel", "Previous profile");
                    _advancedKeymappingsPreviousProfileDropDownLabel.tooltip = "Set the keymapping for previous profile";

                    _advancedKeymappingsPreviousProfileDropDown = UIUtils.CreateDropDown(panel, "AdvancedKeymappingsPreviousProfileDropDown", _ingameAtlas);
                    _advancedKeymappingsPreviousProfileDropDown.items = ModInvariables.KeymappingNames;
                    _advancedKeymappingsPreviousProfileDropDown.selectedIndex = ModConfig.Instance.KeymappingsPreviousProfile;
                    _advancedKeymappingsPreviousProfileDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        ModConfig.Instance.KeymappingsPreviousProfile = value;
                        ModConfig.Instance.Save();
                    };
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
                _profilesMessagePanel.isVisible = ModConfig.Instance.AutomaticColorCorrectionOverride;
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] MainPanel:UpdateUI -> Exception: " + e.Message);
            }
        }

        private void ApplyProfile(Profile profile)
        {
            try
            {
                if (profile != null)
                {
                    _optionsSunIntensitySlider.value = profile.SunIntensity;
                    _optionsSunShadowStrengthSlider.value = profile.SunShadowStrength;
                    _optionsMoonIntensitySlider.value = profile.MoonIntensity;
                    _optionsMoonShadowStrengthSlider.value = profile.MoonShadowStrength;

                    if (!CompatibilityHelper.IsAnySkyManipulatingModsEnabled())
                    {
                        _optionsSkyRayleighScatteringSlider.value = profile.SkyRayleighScattering;
                        _optionsSkyMieScatteringSlider.value = profile.SkyMieScattering;
                        _optionsSkyExposureSlider.value = profile.SkyExposure;
                    }

                    _optionsSkyRedWaveLengthSlider.value = profile.SkyRedWaveLength;
                    _optionsSkyGreenWaveLengthSlider.value = profile.SkyGreenWaveLength;
                    _optionsSkyBlueWaveLengthSlider.value = profile.SkyBlueWaveLength;

                    if (!CompatibilityHelper.IsAnyLightColorsManipulatingModsEnabled())
                    {
                        _optionsLightColorsCheckBox.isChecked = profile.LightColorsEnabled;
                        _optionsSkyColorsCheckBox.isChecked = profile.SkyColorsEnabled;
                        _optionsEquatorColorsCheckBox.isChecked = profile.EquatorColorsEnabled;
                        _optionsGroundColorsCheckBox.isChecked = profile.GroundColorsEnabled;
                    }

                    _optionsSharpnessAssetTypeDropDown.selectedIndex = -1;
                    _optionsSharpnessAssetTypeDropDown.selectedIndex = 0;

                    if (!CompatibilityHelper.IsAnyFogManipulatingModsEnabled())
                    {
                        _optionsFogCheckBox.isChecked = profile.FogEnabled;
                        _optionsFogDayNightCheckBox.isChecked = profile.FogDayNightEnabled;
                        _optionsFogHeightSlider.value = profile.FogHeight;
                        _optionsFogHorizonHeightSlider.value = profile.FogHorizonHeight;
                        _optionsFogDensitySlider.value = profile.FogDensity;
                        _optionsFogStartSlider.value = profile.FogStart;
                        _optionsFogDistanceSlider.value = profile.FogDistance;
                        _optionsFogEdgeDistanceSlider.value = profile.FogEdgeDistance;
                        _optionsFogNoiseContributionSlider.value = profile.FogNoiseContribution;
                        _optionsFogPollutionAmountSlider.value = profile.FogPollutionAmount;
                        _optionsFogColorDecaySlider.value = profile.FogColorDecay;
                        _optionsFogScatteringSlider.value = profile.FogScattering;
                    }

                    _optionsAntiAliasingDropDown.selectedIndex = profile.AntialiasingTechnique;
                    _optionsVanillaBloomCheckBox.isChecked = profile.VanillaBloomEnabled;
                    _optionsVanillaTonemappingCheckBox.isChecked = profile.VanillaTonemappingEnabled;
                    _optionsVanillaColorCorrectionLutCheckBox.isChecked = profile.VanillaColorCorrectionLutEnabled;
                    _optionsVanillaColorCorrectionLutDropDown.selectedIndex = LutManager.Instance.IndexOf(profile.VanillaColorCorrectionLutName);
                    _optionsAmbientOcclusionCheckBox.isChecked = profile.AmbientOcclusionEnabled;
                    _optionsBloomCheckBox.isChecked = profile.BloomEnabled;
                    _optionsColorGradingCheckBox.isChecked = profile.ColorGradingEnabled;

                    _antiAliasingPanel.ApplyProfile(profile);
                    _ambientOcclusionPanel.ApplyProfile(profile);
                    _bloomPanel.ApplyProfile(profile);
                    _colorGradingPanel.ApplyProfile(profile);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] MainPanel:ApplyProfile -> Exception: " + e.Message);
            }
        }
    }
}
