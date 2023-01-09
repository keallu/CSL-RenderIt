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

        private UILabel _optionsDropDownLabel;
        private UIDropDown _optionsDropDown;
        private UIPanel _optionsLightingPanel;
        private UILabel _optionsSunTitle;
        private UILabel _optionsSunIntensitySliderLabel;
        private UILabel _optionsSunIntensitySliderNumeral;
        private UISlider _optionsSunIntensitySlider;
        private UILabel _optionsSunShadowStrengthSliderLabel;
        private UILabel _optionsSunShadowStrengthSliderNumeral;
        private UISlider _optionsSunShadowStrengthSlider;
        private UILabel _optionsMoonTitle;
        private UILabel _optionsMoonIntensitySliderLabel;
        private UILabel _optionsMoonIntensitySliderNumeral;
        private UISlider _optionsMoonIntensitySlider;
        private UILabel _optionsMoonShadowStrengthSliderLabel;
        private UILabel _optionsMoonShadowStrengthSliderNumeral;
        private UISlider _optionsMoonShadowStrengthSlider;
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
        private UILabel _optionsAntiAliasingTitle;
        private UIPanel _optionsPostProcessingPanel;
        private UILabel _optionsAntiAliasingDropDownLabel;
        private UIDropDown _optionsAntiAliasingDropDown;
        private UILabel _optionsEffectsTitle;
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
        private UILabel _advancedTAAStationaryBlendingSliderLabel;
        private UILabel _advancedTAAStationaryBlendingSliderNumeral;
        private UISlider _advancedTAAStationaryBlendingSlider;
        private UILabel _advancedTAAMotionBlendingSliderLabel;
        private UILabel _advancedTAAMotionBlendingSliderNumeral;
        private UISlider _advancedTAAMotionBlendingSlider;
        private UILabel _advancedTAASharpenSliderLabel;
        private UILabel _advancedTAASharpenSliderNumeral;
        private UISlider _advancedTAASharpenSlider;
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
                if (_importExportPanel == null)
                {
                    _importExportPanel = GameObject.Find("RenderItImportExportPanel")?.GetComponent<ImportExportPanel>();
                }

                if (_colorsPanel == null)
                {
                    _colorsPanel = GameObject.Find("RenderItColorsPanel")?.GetComponent<ColorsPanel>();
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
                DestroyGameObject(_optionsSunTitle);
                DestroyGameObject(_optionsSunIntensitySliderLabel);
                DestroyGameObject(_optionsSunIntensitySliderNumeral);
                DestroyGameObject(_optionsSunIntensitySlider);
                DestroyGameObject(_optionsSunShadowStrengthSliderLabel);
                DestroyGameObject(_optionsSunShadowStrengthSliderNumeral);
                DestroyGameObject(_optionsSunShadowStrengthSlider);
                DestroyGameObject(_optionsMoonTitle);
                DestroyGameObject(_optionsMoonIntensitySliderLabel);
                DestroyGameObject(_optionsMoonIntensitySliderNumeral);
                DestroyGameObject(_optionsMoonIntensitySlider);
                DestroyGameObject(_optionsMoonShadowStrengthSliderLabel);
                DestroyGameObject(_optionsMoonShadowStrengthSliderNumeral);
                DestroyGameObject(_optionsMoonShadowStrengthSlider);
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
                DestroyGameObject(_optionsAntiAliasingTitle);
                DestroyGameObject(_optionsPostProcessingPanel);
                DestroyGameObject(_optionsAntiAliasingDropDownLabel);
                DestroyGameObject(_optionsAntiAliasingDropDown);
                DestroyGameObject(_optionsEffectsTitle);
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
                DestroyGameObject(_advancedTAAStationaryBlendingSliderLabel);
                DestroyGameObject(_advancedTAAStationaryBlendingSliderNumeral);
                DestroyGameObject(_advancedTAAStationaryBlendingSlider);
                DestroyGameObject(_advancedTAAMotionBlendingSliderLabel);
                DestroyGameObject(_advancedTAAMotionBlendingSliderNumeral);
                DestroyGameObject(_advancedTAAMotionBlendingSlider);
                DestroyGameObject(_advancedTAASharpenSliderLabel);
                DestroyGameObject(_advancedTAASharpenSliderNumeral);
                DestroyGameObject(_advancedTAASharpenSlider);
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

        public void ForceProfile(Profile profile)
        {
            _profilesDropDown.AddItem(profile.Name);
            _profilesDropDown.selectedIndex = _profilesDropDown.items.Length - 1;
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
                            ProfileManager.Instance.ActiveProfile = ProfileManager.Instance.AllProfiles[value];

                            ApplyProfile(ProfileManager.Instance.ActiveProfile);
                        }
                    };

                    _profilesTextField = UIUtils.CreateTextField(panel, "ProfilesTextField", _ingameAtlas, "");
                    _profilesTextField.isVisible = false;
                    _profilesTextField.eventTextSubmitted += (component, value) =>
                    {
                        if (ProfileManager.Instance.AllProfiles.Count > 1)
                        {
                            _profilesTextField.isVisible = false;

                            ProfileManager.Instance.AllProfiles[_profilesDropDown.selectedIndex].Name = value;

                            _profilesDropDown.items.SetValue(value, _profilesDropDown.selectedIndex);

                            _profilesDropDown.isVisible = true;
                        }
                    };

                    _profilesButtonsPanel = UIUtils.CreatePanel(panel, "ProfilesButtonsPanel");
                    _profilesButtonsPanel.width = panel.width - 10f;
                    _profilesButtonsPanel.height = 100f;

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

                            _profilesDropDown.AddItem(profile.Name);
                            _profilesDropDown.selectedIndex = _profilesDropDown.items.Length - 1;

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
                            if (ProfileManager.Instance.AllProfiles.Count > 1)
                            {
                                ProfileManager.Instance.AllProfiles.Remove(ProfileManager.Instance.AllProfiles[_profilesDropDown.selectedIndex]);
                                ProfileManager.Instance.ActiveProfile = ProfileManager.Instance.AllProfiles[0];

                                _profilesDropDown.items = _profilesDropDown.items.Where((w, i) => i != _profilesDropDown.selectedIndex).ToArray();
                                _profilesDropDown.selectedIndex = 0;
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
                            Profile profile = ProfileManager.Instance.ActiveProfile.Clone();
                            profile.Name = "Copy of " + profile.Name;

                            ProfileManager.Instance.AllProfiles.Add(profile);
                            ProfileManager.Instance.ActiveProfile = profile;

                            _profilesDropDown.AddItem(profile.Name);
                            _profilesDropDown.selectedIndex = _profilesDropDown.items.Length - 1;

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
                            if (ProfileManager.Instance.AllProfiles.Count > 1)
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

                            ApplyProfile(ProfileManager.Instance.ActiveProfile);

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

                    _optionsDropDownLabel = UIUtils.CreateLabel(panel, "OptionsDropDownLabel", "Options");
                    _optionsDropDownLabel.tooltip = "Select which type of options you want to change";

                    _optionsDropDown = UIUtils.CreateDropDown(panel, "OptionsDropDown", _ingameAtlas);
                    _optionsDropDown.items = new string[] { "Lighting", "Colors", "Textures", "Post-Processing" };

                    _optionsLightingPanel = UIUtils.CreatePanel(panel, "OptionsLightingPanel");
                    _optionsLightingPanel.isVisible = false;
                    _optionsLightingPanel.width = _optionsLightingPanel.parent.width;
                    _optionsLightingPanel.height = 500f;
                    _optionsLightingPanel.autoLayout = true;
                    _optionsLightingPanel.autoLayoutStart = LayoutStart.TopLeft;
                    _optionsLightingPanel.autoLayoutDirection = LayoutDirection.Vertical;
                    _optionsLightingPanel.autoLayoutPadding.left = 0;
                    _optionsLightingPanel.autoLayoutPadding.right = 0;
                    _optionsLightingPanel.autoLayoutPadding.top = 0;
                    _optionsLightingPanel.autoLayoutPadding.bottom = 10;

                    _optionsSunTitle = UIUtils.CreateTitle(_optionsLightingPanel, "OptionsSunTitle", "Sun");

                    _optionsSunIntensitySliderLabel = UIUtils.CreateLabel(_optionsLightingPanel, "OptionsSunIntensitySliderLabel", "Intensity");
                    _optionsSunIntensitySliderLabel.tooltip = "Set the intensity (brightness) of the sun";

                    _optionsSunIntensitySliderNumeral = UIUtils.CreateLabel(_optionsSunIntensitySliderLabel, "OptionsSunIntensitySliderNumeral", ProfileManager.Instance.ActiveProfile.SunIntensity.ToString());
                    _optionsSunIntensitySliderNumeral.width = 100f;
                    _optionsSunIntensitySliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _optionsSunIntensitySliderNumeral.relativePosition = new Vector3(_optionsLightingPanel.width - _optionsSunIntensitySliderNumeral.width - 10f, 0f);

                    _optionsSunIntensitySlider = UIUtils.CreateSlider(_optionsLightingPanel, "OptionsSunIntensitySlider", _ingameAtlas, 0f, 8f, 0.1f, 0.1f, ProfileManager.Instance.ActiveProfile.SunIntensity);
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

                    _optionsSunShadowStrengthSliderLabel = UIUtils.CreateLabel(_optionsLightingPanel, "OptionsSunShadowStrengthSliderLabel", "Shadow Strength");
                    _optionsSunShadowStrengthSliderLabel.tooltip = "Set the strength (darkness) of cast shadow from the sun";

                    _optionsSunShadowStrengthSliderNumeral = UIUtils.CreateLabel(_optionsSunShadowStrengthSliderLabel, "OptionsSunShadowStrengthSliderNumeral", ProfileManager.Instance.ActiveProfile.SunShadowStrength.ToString());
                    _optionsSunShadowStrengthSliderNumeral.width = 100f;
                    _optionsSunShadowStrengthSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _optionsSunShadowStrengthSliderNumeral.relativePosition = new Vector3(_optionsLightingPanel.width - _optionsSunShadowStrengthSliderNumeral.width - 10f, 0f);

                    _optionsSunShadowStrengthSlider = UIUtils.CreateSlider(_optionsLightingPanel, "OptionsSunShadowStrengthSlider", _ingameAtlas, 0f, 1f, 0.01f, 0.01f, ProfileManager.Instance.ActiveProfile.SunShadowStrength);
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

                    _optionsMoonTitle = UIUtils.CreateTitle(_optionsLightingPanel, "OptionsMoonTitle", "Moon");

                    _optionsMoonIntensitySliderLabel = UIUtils.CreateLabel(_optionsLightingPanel, "OptionsMoonIntensitySliderLabel", "Intensity");
                    _optionsMoonIntensitySliderLabel.tooltip = "Set the intensity (brightness) of the moon";

                    _optionsMoonIntensitySliderNumeral = UIUtils.CreateLabel(_optionsMoonIntensitySliderLabel, "OptionsMoonIntensitySliderNumeral", ProfileManager.Instance.ActiveProfile.MoonIntensity.ToString());
                    _optionsMoonIntensitySliderNumeral.width = 100f;
                    _optionsMoonIntensitySliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _optionsMoonIntensitySliderNumeral.relativePosition = new Vector3(_optionsLightingPanel.width - _optionsMoonIntensitySliderNumeral.width - 10f, 0f);

                    _optionsMoonIntensitySlider = UIUtils.CreateSlider(_optionsLightingPanel, "OptionsMoonIntensitySlider", _ingameAtlas, 0f, 8f, 0.1f, 0.1f, ProfileManager.Instance.ActiveProfile.MoonIntensity);
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

                    _optionsMoonShadowStrengthSliderLabel = UIUtils.CreateLabel(_optionsLightingPanel, "OptionsMoonShadowStrengthSliderLabel", "Shadow Strength");
                    _optionsMoonShadowStrengthSliderLabel.tooltip = "Set the strength (darkness) of cast shadow from the moon";

                    _optionsMoonShadowStrengthSliderNumeral = UIUtils.CreateLabel(_optionsMoonShadowStrengthSliderLabel, "OptionsMoonShadowStrengthSliderNumeral", ProfileManager.Instance.ActiveProfile.MoonShadowStrength.ToString());
                    _optionsMoonShadowStrengthSliderNumeral.width = 100f;
                    _optionsMoonShadowStrengthSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _optionsMoonShadowStrengthSliderNumeral.relativePosition = new Vector3(_optionsLightingPanel.width - _optionsMoonShadowStrengthSliderNumeral.width - 10f, 0f);

                    _optionsMoonShadowStrengthSlider = UIUtils.CreateSlider(_optionsLightingPanel, "OptionsMoonShadowStrengthSlider", _ingameAtlas, 0f, 1f, 0.01f, 0.01f, ProfileManager.Instance.ActiveProfile.MoonShadowStrength);
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

                    _optionsSkyTitle = UIUtils.CreateTitle(_optionsLightingPanel, "OptionsSkyTitle", "Sky");

                    if (!CompatibilityHelper.IsAnySkyManipulatingModsEnabled())
                    {
                        _optionsSkyRayleighScatteringSliderLabel = UIUtils.CreateLabel(_optionsLightingPanel, "OptionsSkyRayleighScatteringSliderLabel", "Rayleigh Scattering");
                        _optionsSkyRayleighScatteringSliderLabel.tooltip = "Set the strength of rayleigh scattering in the sky";

                        _optionsSkyRayleighScatteringSliderNumeral = UIUtils.CreateLabel(_optionsSkyRayleighScatteringSliderLabel, "OptionsSkyRayleighScatteringSliderNumeral", ProfileManager.Instance.ActiveProfile.SkyRayleighScattering.ToString());
                        _optionsSkyRayleighScatteringSliderNumeral.width = 100f;
                        _optionsSkyRayleighScatteringSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                        _optionsSkyRayleighScatteringSliderNumeral.relativePosition = new Vector3(_optionsLightingPanel.width - _optionsSkyRayleighScatteringSliderNumeral.width - 10f, 0f);

                        _optionsSkyRayleighScatteringSlider = UIUtils.CreateSlider(_optionsLightingPanel, "OptionsSkyRayleighScatteringSlider", _ingameAtlas, 0f, 5f, 0.1f, 0.1f, ProfileManager.Instance.ActiveProfile.SkyRayleighScattering);
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

                        _optionsSkyMieScatteringSliderLabel = UIUtils.CreateLabel(_optionsLightingPanel, "OptionsMieScatteringSliderLabel", "Mie Scattering");
                        _optionsSkyMieScatteringSliderLabel.tooltip = "Set the strength of mie scattering in the sky";

                        _optionsSkyMieScatteringSliderNumeral = UIUtils.CreateLabel(_optionsSkyMieScatteringSliderLabel, "OptionsMieScatteringSliderNumeral", ProfileManager.Instance.ActiveProfile.SkyMieScattering.ToString());
                        _optionsSkyMieScatteringSliderNumeral.width = 100f;
                        _optionsSkyMieScatteringSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                        _optionsSkyMieScatteringSliderNumeral.relativePosition = new Vector3(_optionsLightingPanel.width - _optionsSkyMieScatteringSliderNumeral.width - 10f, 0f);

                        _optionsSkyMieScatteringSlider = UIUtils.CreateSlider(_optionsLightingPanel, "OptionsMieScatteringSlider", _ingameAtlas, 0f, 5f, 0.1f, 0.1f, ProfileManager.Instance.ActiveProfile.SkyMieScattering);
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

                        _optionsSkyExposureSliderLabel = UIUtils.CreateLabel(_optionsLightingPanel, "OptionsSkyExposureSliderLabel", "Exposure");
                        _optionsSkyExposureSliderLabel.tooltip = "Set the strength of exposure through the sky";

                        _optionsSkyExposureSliderNumeral = UIUtils.CreateLabel(_optionsSkyExposureSliderLabel, "OptionsSkyExposureSliderNumeral", ProfileManager.Instance.ActiveProfile.SkyExposure.ToString());
                        _optionsSkyExposureSliderNumeral.width = 100f;
                        _optionsSkyExposureSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                        _optionsSkyExposureSliderNumeral.relativePosition = new Vector3(_optionsLightingPanel.width - _optionsSkyExposureSliderNumeral.width - 10f, 0f);

                        _optionsSkyExposureSlider = UIUtils.CreateSlider(_optionsLightingPanel, "OptionsSkyExposureSlider", _ingameAtlas, 0f, 5f, 0.1f, 0.1f, ProfileManager.Instance.ActiveProfile.SkyExposure);
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
                        _optionsSkyMessagePanel = UIUtils.CreatePanel(_optionsLightingPanel, "OptionsSkyMessagePanel");
                        _optionsSkyMessagePanel.backgroundSprite = "GenericPanelLight";
                        _optionsSkyMessagePanel.color = new Color32(206, 206, 206, 255);
                        _optionsSkyMessagePanel.height = 60f;
                        _optionsSkyMessagePanel.width = _optionsSkyMessagePanel.parent.width - 16f;
                        _optionsSkyMessagePanel.relativePosition = new Vector3(8f, 8f);

                        _optionsSkyMessageLabel = UIUtils.CreateLabel(_optionsSkyMessagePanel, "OptionsSkyMessageLabel", "Adjustment of sky lighting in Render It! has been disabled because you have Theme Mixer 2 enabled.");
                        _optionsSkyMessageLabel.autoHeight = true;
                        _optionsSkyMessageLabel.width = _optionsSkyMessageLabel.parent.width - 16f;
                        _optionsSkyMessageLabel.relativePosition = new Vector3(8f, 8f);
                        _optionsSkyMessageLabel.wordWrap = true;
                    }

                    _optionsColorsPanel = UIUtils.CreatePanel(panel, "OptionsColorsPanel");
                    _optionsColorsPanel.isVisible = false;
                    _optionsColorsPanel.width = _optionsLightingPanel.parent.width;
                    _optionsColorsPanel.height = 500f;
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
                    _optionsTexturesPanel.width = _optionsLightingPanel.parent.width;
                    _optionsTexturesPanel.height = 500f;
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

                    _optionsPostProcessingPanel = UIUtils.CreatePanel(panel, "OptionsPostProcessingPanel");
                    _optionsPostProcessingPanel.isVisible = false;
                    _optionsPostProcessingPanel.width = _optionsPostProcessingPanel.parent.width;
                    _optionsPostProcessingPanel.height = 500f;
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

                    _optionsEffectsTitle = UIUtils.CreateTitle(_optionsPostProcessingPanel, "OptionsEffectsTitle", "Effects");

                    _optionsAmbientOcclusionCheckBox = UIUtils.CreateCheckBox(_optionsPostProcessingPanel, "OptionsAmbientOcclusionCheckBox", _ingameAtlas, "Ambient Occlusion Enabled", ProfileManager.Instance.ActiveProfile.AmbientOcclusionEnabled);
                    _optionsAmbientOcclusionCheckBox.tooltip = "Ambient Occlusion darkens creases, holes, intersections and surfaces that are close to each other";
                    _optionsAmbientOcclusionCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ProfileManager.Instance.ActiveProfile.AmbientOcclusionEnabled = value;
                        ProfileManager.Instance.Apply();
                    };
                    _optionsBloomCheckBox = UIUtils.CreateCheckBox(_optionsPostProcessingPanel, "OptionsBloomCheckBox", _ingameAtlas, "Bloom Enabled", ProfileManager.Instance.ActiveProfile.BloomEnabled);
                    _optionsBloomCheckBox.tooltip = "Bloom creates fringes of light extending from the borders of bright areas in an image,\ncontributing to the illusion of an extremely bright light overwhelming the camera";
                    _optionsBloomCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ProfileManager.Instance.ActiveProfile.BloomEnabled = value;
                        ProfileManager.Instance.Apply();
                    };
                    _optionsColorGradingCheckBox = UIUtils.CreateCheckBox(_optionsPostProcessingPanel, "OptionsColorGradingCheckBox", _ingameAtlas, "Color Grading Enabled", ProfileManager.Instance.ActiveProfile.ColorGradingEnabled);
                    _optionsColorGradingCheckBox.tooltip = "Color Grading alters or corrects the color and luminance of the final image that is rendered";
                    _optionsColorGradingCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ProfileManager.Instance.ActiveProfile.ColorGradingEnabled = value;
                        ProfileManager.Instance.Apply();
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
                                    _optionsPostProcessingPanel.isVisible = false;
                                    break;
                                case 1:
                                    _optionsLightingPanel.isVisible = false;
                                    _optionsColorsPanel.isVisible = true;
                                    _optionsTexturesPanel.isVisible = false;
                                    _optionsPostProcessingPanel.isVisible = false;
                                    break;
                                case 2:
                                    _optionsLightingPanel.isVisible = false;
                                    _optionsColorsPanel.isVisible = false;
                                    _optionsTexturesPanel.isVisible = true;
                                    _optionsPostProcessingPanel.isVisible = false;
                                    break;
                                case 3:
                                    _optionsLightingPanel.isVisible = false;
                                    _optionsColorsPanel.isVisible = false;
                                    _optionsTexturesPanel.isVisible = false;
                                    _optionsPostProcessingPanel.isVisible = true;
                                    break;
                                default:
                                    _optionsLightingPanel.isVisible = true;
                                    _optionsColorsPanel.isVisible = false;
                                    _optionsTexturesPanel.isVisible = false;
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

                    _advancedFXAAQualityDropDown = UIUtils.CreateDropDown(_advancedScrollablePanel, "AdvancedFXAAQualityDropDown", _ingameAtlas);
                    _advancedFXAAQualityDropDown.items = ModInvariables.FXAAQuality;
                    _advancedFXAAQualityDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.FXAAQuality;
                    _advancedFXAAQualityDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        if (value != -1)
                        {
                            ProfileManager.Instance.ActiveProfile.FXAAQuality = value;
                            ProfileManager.Instance.Apply();
                        }
                    };

                    _advancedFXAADivider = UIUtils.CreateDivider(_advancedScrollablePanel, "AdvancedFXAADivider", _ingameAtlas);

                    // --- TAA ---
                    _advancedTAATitle = UIUtils.CreateTitle(_advancedScrollablePanel, "AdvancedTAATitle", "Temporal Anti-aliasing (TAA)");
                    _advancedTAATitle.tooltip = "An advanced technique where frames are accumulated over time in a history buffer to be used to smooth edges more effectively.\nIt is substantially better at smoothing edges in motion but requires motion vectors and is more expensive than FXAA.\nIdeal for faster desktop hardware";

                    _advancedTAAJitterSpreadSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedTAAJitterSpreadSliderLabel", "Jitter Spread");
                    _advancedTAAJitterSpreadSliderLabel.tooltip = "Set the diameter (in texels) inside which jitter samples are spread. Smaller values result in crisper\nbut a more aliased output. Larger values result in more stable but blurrier output";

                    _advancedTAAJitterSpreadSliderNumeral = UIUtils.CreateLabel(_advancedTAAJitterSpreadSliderLabel, "AdvancedTAAJitterSpreadSliderNumeral", ProfileManager.Instance.ActiveProfile.TAAJitterSpread.ToString());
                    _advancedTAAJitterSpreadSliderNumeral.width = 100f;
                    _advancedTAAJitterSpreadSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedTAAJitterSpreadSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedTAAJitterSpreadSliderNumeral.width - 10f, 0f);

                    _advancedTAAJitterSpreadSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedTAAJitterSpreadSlider", _ingameAtlas, 0.1f, 1f, 0.01f, 0.01f, ProfileManager.Instance.ActiveProfile.TAAJitterSpread);
                    _advancedTAAJitterSpreadSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedTAAJitterSpreadSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.TAAJitterSpread = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedTAAJitterSpreadSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedTAAJitterSpreadSlider.value = 0.75f;
                        }
                    };

                    _advancedTAAStationaryBlendingSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedTAAStationaryBlendingSliderLabel", "Stationary Blending");
                    _advancedTAAStationaryBlendingSliderLabel.tooltip = "Set the blend coefficient for stationary fragments. This setting controls the percentage of history sample\nblended into final color for fragments with minimal active motion";

                    _advancedTAAStationaryBlendingSliderNumeral = UIUtils.CreateLabel(_advancedTAAStationaryBlendingSliderLabel, "AdvancedTAAStationaryBlendingSliderNumeral", ProfileManager.Instance.ActiveProfile.TAAStationaryBlending.ToString());
                    _advancedTAAStationaryBlendingSliderNumeral.width = 100f;
                    _advancedTAAStationaryBlendingSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedTAAStationaryBlendingSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedTAAStationaryBlendingSliderNumeral.width - 10f, 0f);

                    _advancedTAAStationaryBlendingSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedTAAStationaryBlendingSlider", _ingameAtlas, 0f, 0.99f, 0.01f, 0.01f, ProfileManager.Instance.ActiveProfile.TAAStationaryBlending);
                    _advancedTAAStationaryBlendingSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedTAAStationaryBlendingSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.TAAStationaryBlending = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedTAAStationaryBlendingSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedTAAStationaryBlendingSlider.value = 0.95f;
                        }
                    };

                    _advancedTAAMotionBlendingSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedTAAMotionBlendingSliderLabel", "Motion Blending");
                    _advancedTAAMotionBlendingSliderLabel.tooltip = "Set the blending coefficient for moving fragments. This setting controls the percentage of history sample\nblended into the final color for fragments with significant active motion";

                    _advancedTAAMotionBlendingSliderNumeral = UIUtils.CreateLabel(_advancedTAAMotionBlendingSliderLabel, "AdvancedTAAMotionBlendingSliderNumeral", ProfileManager.Instance.ActiveProfile.TAAMotionBlending.ToString());
                    _advancedTAAMotionBlendingSliderNumeral.width = 100f;
                    _advancedTAAMotionBlendingSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedTAAMotionBlendingSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedTAAMotionBlendingSliderNumeral.width - 10f, 0f);

                    _advancedTAAMotionBlendingSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedTAAMotionBlendingSlider", _ingameAtlas, 0f, 0.99f, 0.01f, 0.01f, ProfileManager.Instance.ActiveProfile.TAAMotionBlending);
                    _advancedTAAMotionBlendingSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedTAAMotionBlendingSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.TAAMotionBlending = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedTAAMotionBlendingSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedTAAMotionBlendingSlider.value = 0.85f;
                        }
                    };

                    _advancedTAASharpenSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedTAASharpenSliderLabel", "Sharpen");
                    _advancedTAASharpenSliderLabel.tooltip = "Set the sharpness to alleviate the slight loss of details in high frequency regions";

                    _advancedTAASharpenSliderNumeral = UIUtils.CreateLabel(_advancedTAASharpenSliderLabel, "AdvancedTAASharpenSliderNumeral", ProfileManager.Instance.ActiveProfile.TAASharpen.ToString());
                    _advancedTAASharpenSliderNumeral.width = 100f;
                    _advancedTAASharpenSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedTAASharpenSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedTAASharpenSliderNumeral.width - 10f, 0f);

                    _advancedTAASharpenSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedTAASharpenSlider", _ingameAtlas, 0f, 3f, 0.03f, 0.03f, ProfileManager.Instance.ActiveProfile.TAASharpen);
                    _advancedTAASharpenSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedTAASharpenSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.TAASharpen = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedTAASharpenSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedTAASharpenSlider.value = 0.3f;
                        }
                    };

                    _advancedTAADivider = UIUtils.CreateDivider(_advancedScrollablePanel, "AdvancedTAADivider", _ingameAtlas);

                    // --- AO ---
                    _advancedAOTitle = UIUtils.CreateTitle(_advancedScrollablePanel, "AdvancedAOTitle", "Ambient Occlusion");
                    _advancedAOTitle.tooltip = "Ambient Occlusion darkens creases, holes, intersections and surfaces that are close to each other";

                    _advancedAOIntensitySliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedAOIntensitySliderLabel", "Intensity");
                    _advancedAOIntensitySliderLabel.tooltip = "Degree of darkness produced";

                    _advancedAOIntensitySliderNumeral = UIUtils.CreateLabel(_advancedAOIntensitySliderLabel, "AdvancedAOIntensitySliderNumeral", ProfileManager.Instance.ActiveProfile.AOIntensity.ToString());
                    _advancedAOIntensitySliderNumeral.width = 100f;
                    _advancedAOIntensitySliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedAOIntensitySliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedAOIntensitySliderNumeral.width - 10f, 0f);

                    _advancedAOIntensitySlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedAOIntensitySlider", _ingameAtlas, 0f, 4f, 0.05f, 0.05f, ProfileManager.Instance.ActiveProfile.AOIntensity);
                    _advancedAOIntensitySlider.eventValueChanged += (component, value) =>
                    {
                        _advancedAOIntensitySliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.AOIntensity = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedAOIntensitySlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedAOIntensitySlider.value = 1f;
                        }
                    };

                    _advancedAORadiusSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedAORadiusSliderLabel", "Radius");
                    _advancedAORadiusSliderLabel.tooltip = "Radius of sample points, which affects extent of darkened areas";

                    _advancedAORadiusSliderNumeral = UIUtils.CreateLabel(_advancedAORadiusSliderLabel, "AdvancedAORadiusSliderNumeral", ProfileManager.Instance.ActiveProfile.AORadius.ToString());
                    _advancedAORadiusSliderNumeral.width = 100f;
                    _advancedAORadiusSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedAORadiusSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedAORadiusSliderNumeral.width - 10f, 0f);

                    _advancedAORadiusSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedAORadiusSlider", _ingameAtlas, 0f, 4f, 0.05f, 0.05f, ProfileManager.Instance.ActiveProfile.AORadius);
                    _advancedAORadiusSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedAORadiusSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.AORadius = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedAORadiusSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedAORadiusSlider.value = 0.3f;
                        }
                    };

                    _advancedAOSampleCountDropDownLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedAOSampleCountDropDownLabel", "Sample Count");
                    _advancedAOSampleCountDropDownLabel.tooltip = "Number of sample points, which affects quality and performance";

                    _advancedAOSampleCountDropDown = UIUtils.CreateDropDown(_advancedScrollablePanel, "AdvancedAOSampleCountDropDown", _ingameAtlas);
                    _advancedAOSampleCountDropDown.items = ModInvariables.AOSampleCount;
                    _advancedAOSampleCountDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.AOSampleCount;
                    _advancedAOSampleCountDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        if (value != -1)
                        {
                            ProfileManager.Instance.ActiveProfile.AOSampleCount = ConvertAmbientOcclusionSampleCount(value);
                            ProfileManager.Instance.Apply();
                        }
                    };

                    _advancedAODownsamplingCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedAODownsamplingCheckBox", _ingameAtlas, "Downsampling", ProfileManager.Instance.ActiveProfile.AODownsampling);
                    _advancedAODownsamplingCheckBox.tooltip = "Halves the resolution of the effect to increase performance at the cost of visual quality";
                    _advancedAODownsamplingCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ProfileManager.Instance.ActiveProfile.AODownsampling = value;
                        ProfileManager.Instance.Apply();
                    };

                    _advancedAOForceForwardCompatibilityCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedAOForceForwardCompatibilityCheckBox", _ingameAtlas, "Force Forward Compatibility", ProfileManager.Instance.ActiveProfile.AOForceForwardCompatibility);
                    _advancedAOForceForwardCompatibilityCheckBox.tooltip = "Forces compatibility with forward rendered objects when working with the deferred rendering path";
                    _advancedAOForceForwardCompatibilityCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ProfileManager.Instance.ActiveProfile.AOForceForwardCompatibility = value;
                        ProfileManager.Instance.Apply();
                    };

                    _advancedAOHighPrecisionCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedAOHighPrecisionCheckBox", _ingameAtlas, "High Precision", ProfileManager.Instance.ActiveProfile.AOHighPrecision);
                    _advancedAOHighPrecisionCheckBox.tooltip = "Uses higher precision depth texture with the forward rendering path which may impact performances";
                    _advancedAOHighPrecisionCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ProfileManager.Instance.ActiveProfile.AOHighPrecision = value;
                        ProfileManager.Instance.Apply();
                    };

                    _advancedAOAmbientOnlyCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedAOAmbientOnlyCheckBox", _ingameAtlas, "Ambient Only", ProfileManager.Instance.ActiveProfile.AOAmbientOnly);
                    _advancedAOAmbientOnlyCheckBox.tooltip = "Enables the ambient-only mode in that ambient occlusion only affects ambient lighting";
                    _advancedAOAmbientOnlyCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ProfileManager.Instance.ActiveProfile.AOAmbientOnly = value;
                        ProfileManager.Instance.Apply();
                    };

                    _advancedAODivider = UIUtils.CreateDivider(_advancedScrollablePanel, "AdvancedAODivider", _ingameAtlas);

                    // --- Bloom ---
                    _advancedBloomTitle = UIUtils.CreateTitle(_advancedScrollablePanel, "AdvancedBloomTitle", "Bloom");
                    _advancedBloomTitle.tooltip = "Bloom creates fringes of light extending from the borders of bright areas in an image,\ncontributing to the illusion of an extremely bright light overwhelming the camera";

                    _advancedBloomVanillaBloomCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedBloomVanillaBloomCheckBox", _ingameAtlas, "Vanilla Bloom", ProfileManager.Instance.ActiveProfile.BloomVanillaBloomEnabled);
                    _advancedBloomVanillaBloomCheckBox.tooltip = "Keeps bloom produced by the game";
                    _advancedBloomVanillaBloomCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ProfileManager.Instance.ActiveProfile.BloomVanillaBloomEnabled = value;
                        ProfileManager.Instance.Apply();
                    };

                    _advancedBloomIntensitySliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedBloomIntensitySliderLabel", "Intensity");
                    _advancedBloomIntensitySliderLabel.tooltip = "Degree of bloom produced";

                    _advancedBloomIntensitySliderNumeral = UIUtils.CreateLabel(_advancedBloomIntensitySliderLabel, "AdvancedBloomIntensitySliderNumeral", ProfileManager.Instance.ActiveProfile.BloomIntensity.ToString());
                    _advancedBloomIntensitySliderNumeral.width = 100f;
                    _advancedBloomIntensitySliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedBloomIntensitySliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedBloomIntensitySliderNumeral.width - 10f, 0f);

                    _advancedBloomIntensitySlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedBloomIntensitySlider", _ingameAtlas, 0f, 1f, 0.01f, 0.01f, ProfileManager.Instance.ActiveProfile.BloomIntensity);
                    _advancedBloomIntensitySlider.eventValueChanged += (component, value) =>
                    {
                        _advancedBloomIntensitySliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.BloomIntensity = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedBloomIntensitySlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedBloomIntensitySlider.value = 0.5f;
                        }
                    };

                    _advancedBloomThresholdSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedBloomThresholdSliderLabel", "Threshold");
                    _advancedBloomThresholdSliderLabel.tooltip = "Filters out pixels under this level of brightness";

                    _advancedBloomThresholdSliderNumeral = UIUtils.CreateLabel(_advancedBloomThresholdSliderLabel, "AdvancedBloomThresholdSliderNumeral", ProfileManager.Instance.ActiveProfile.BloomThreshold.ToString());
                    _advancedBloomThresholdSliderNumeral.width = 100f;
                    _advancedBloomThresholdSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedBloomThresholdSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedBloomThresholdSliderNumeral.width - 10f, 0f);

                    _advancedBloomThresholdSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedBloomThresholdSlider", _ingameAtlas, 0f, 10f, 0.1f, 0.1f, ProfileManager.Instance.ActiveProfile.BloomThreshold);
                    _advancedBloomThresholdSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedBloomThresholdSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.BloomThreshold = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedBloomThresholdSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedBloomThresholdSlider.value = 1.1f;
                        }
                    };

                    _advancedBloomSoftKneeSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedBloomSoftKneeSliderLabel", "Soft Knee");
                    _advancedBloomSoftKneeSliderLabel.tooltip = "Makes transition between under/over-threshold gradual";

                    _advancedBloomSoftKneeSliderNumeral = UIUtils.CreateLabel(_advancedBloomSoftKneeSliderLabel, "AdvancedBloomSoftKneeSliderNumeral", ProfileManager.Instance.ActiveProfile.BloomSoftKnee.ToString());
                    _advancedBloomSoftKneeSliderNumeral.width = 100f;
                    _advancedBloomSoftKneeSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedBloomSoftKneeSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedBloomSoftKneeSliderNumeral.width - 10f, 0f);

                    _advancedBloomSoftKneeSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedBloomSoftKneeSlider", _ingameAtlas, 0f, 1f, 0.01f, 0.01f, ProfileManager.Instance.ActiveProfile.BloomSoftKnee);
                    _advancedBloomSoftKneeSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedBloomSoftKneeSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.BloomSoftKnee = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedBloomSoftKneeSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedBloomSoftKneeSlider.value = 0.5f;
                        }
                    };

                    _advancedBloomRadiusSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedBloomRadiusSliderLabel", "Radius");
                    _advancedBloomRadiusSliderLabel.tooltip = "Changes extent of veiling in a screen resolution-independent fashion";

                    _advancedBloomRadiusSliderNumeral = UIUtils.CreateLabel(_advancedBloomRadiusSliderLabel, "AdvancedBloomRadiusSliderNumeral", ProfileManager.Instance.ActiveProfile.BloomRadius.ToString());
                    _advancedBloomRadiusSliderNumeral.width = 100f;
                    _advancedBloomRadiusSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedBloomRadiusSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedBloomRadiusSliderNumeral.width - 10f, 0f);

                    _advancedBloomRadiusSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedBloomRadiusSlider", _ingameAtlas, 1f, 7f, 0.05f, 0.05f, ProfileManager.Instance.ActiveProfile.BloomRadius);
                    _advancedBloomRadiusSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedBloomRadiusSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.BloomRadius = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedBloomRadiusSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedBloomRadiusSlider.value = 4f;
                        }
                    };

                    _advancedBloomAntiFlickerCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedBloomAntiFlickerCheckBox", _ingameAtlas, "Anti Flicker", ProfileManager.Instance.ActiveProfile.BloomAntiFlicker);
                    _advancedBloomAntiFlickerCheckBox.tooltip = "Reduces flashing noise with an additional filter";
                    _advancedBloomAntiFlickerCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ProfileManager.Instance.ActiveProfile.BloomAntiFlicker = value;
                        ProfileManager.Instance.Apply();
                    };

                    _advancedBloomDivider = UIUtils.CreateDivider(_advancedScrollablePanel, "AdvancedBloomDivider", _ingameAtlas);

                    // --- Color Grading ---
                    _advancedCGTitle = UIUtils.CreateTitle(_advancedScrollablePanel, "AdvancedCGTitle", "Color Grading");
                    _advancedCGTitle.tooltip = "Color Grading alters or corrects the color and luminance of the final image that is rendered";

                    _advancedCGVanillaTonemappingCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedCGVanillaTonemappingCheckBox", _ingameAtlas, "Vanilla Tonemapping", ProfileManager.Instance.ActiveProfile.CGVanillaTonemappingEnabled);
                    _advancedCGVanillaTonemappingCheckBox.tooltip = "Keeps tonemapping produced by the game";
                    _advancedCGVanillaTonemappingCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ProfileManager.Instance.ActiveProfile.CGVanillaTonemappingEnabled = value;
                        ProfileManager.Instance.Apply();
                    };

                    _advancedCGVanillaColorCorrectionLUTCheckBox = UIUtils.CreateCheckBox(_advancedScrollablePanel, "AdvancedCGVanillaColorCorrectionLUTCheckBox", _ingameAtlas, "Vanilla Color Correction LUT", ProfileManager.Instance.ActiveProfile.CGVanillaColorCorrectionLUTEnabled);
                    _advancedCGVanillaColorCorrectionLUTCheckBox.tooltip = "Keeps color correction LUT produced by the game";
                    _advancedCGVanillaColorCorrectionLUTCheckBox.eventCheckChanged += (component, value) =>
                    {
                        ProfileManager.Instance.ActiveProfile.CGVanillaColorCorrectionLUTEnabled = value;
                        ProfileManager.Instance.Apply();
                    };

                    _advancedCGPostExposureSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGPostExposureSliderLabel", "Post Exposure");
                    _advancedCGPostExposureSliderLabel.tooltip = "Adjusts the overall exposure of the scene";

                    _advancedCGPostExposureSliderNumeral = UIUtils.CreateLabel(_advancedCGPostExposureSliderLabel, "AdvancedCGPostExposureSliderNumeral", ProfileManager.Instance.ActiveProfile.CGPostExposure.ToString());
                    _advancedCGPostExposureSliderNumeral.width = 100f;
                    _advancedCGPostExposureSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGPostExposureSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGPostExposureSliderNumeral.width - 10f, 0f);

                    _advancedCGPostExposureSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGPostExposureSlider", _ingameAtlas, -2f, 2f, 0.05f, 0.05f, ProfileManager.Instance.ActiveProfile.CGPostExposure);
                    _advancedCGPostExposureSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGPostExposureSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.CGPostExposure = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedCGPostExposureSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGPostExposureSlider.value = 0f;
                        }
                    };

                    _advancedCGTemperatureSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGTemperatureSliderLabel", "Temperature");
                    _advancedCGTemperatureSliderLabel.tooltip = "Sets the white balance to a custom color temperature";

                    _advancedCGTemperatureSliderNumeral = UIUtils.CreateLabel(_advancedCGTemperatureSliderLabel, "AdvancedCGTemperatureSliderNumeral", ProfileManager.Instance.ActiveProfile.CGTemperature.ToString());
                    _advancedCGTemperatureSliderNumeral.width = 100f;
                    _advancedCGTemperatureSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGTemperatureSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGTemperatureSliderNumeral.width - 10f, 0f);

                    _advancedCGTemperatureSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGTemperatureSlider", _ingameAtlas, -100f, 100f, 2f, 2f, ProfileManager.Instance.ActiveProfile.CGTemperature);
                    _advancedCGTemperatureSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGTemperatureSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.CGTemperature = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedCGTemperatureSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGTemperatureSlider.value = 0f;
                        }
                    };

                    _advancedCGTintSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGTintSliderLabel", "Tint");
                    _advancedCGTintSliderLabel.tooltip = "Sets the white balance to compensate for a green or magenta tint";

                    _advancedCGTintSliderNumeral = UIUtils.CreateLabel(_advancedCGTintSliderLabel, "AdvancedCGTintSliderNumeral", ProfileManager.Instance.ActiveProfile.CGTint.ToString());
                    _advancedCGTintSliderNumeral.width = 100f;
                    _advancedCGTintSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGTintSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGTintSliderNumeral.width - 10f, 0f);

                    _advancedCGTintSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGTintSlider", _ingameAtlas, -100f, 100f, 2f, 2f, ProfileManager.Instance.ActiveProfile.CGTint);
                    _advancedCGTintSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGTintSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.CGTint = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedCGTintSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGTintSlider.value = 0f;
                        }
                    };

                    _advancedCGHueShiftSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGHueShiftSliderLabel", "Hue Shift");
                    _advancedCGHueShiftSliderLabel.tooltip = "Shift the hue of all colors";

                    _advancedCGHueShiftSliderNumeral = UIUtils.CreateLabel(_advancedCGHueShiftSliderLabel, "AdvancedCGHueShiftSliderNumeral", ProfileManager.Instance.ActiveProfile.CGHueShift.ToString());
                    _advancedCGHueShiftSliderNumeral.width = 100f;
                    _advancedCGHueShiftSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGHueShiftSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGHueShiftSliderNumeral.width - 10f, 0f);

                    _advancedCGHueShiftSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGHueShiftSlider", _ingameAtlas, -180f, 180f, 3f, 3f, ProfileManager.Instance.ActiveProfile.CGHueShift);
                    _advancedCGHueShiftSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGHueShiftSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.CGHueShift = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedCGHueShiftSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGHueShiftSlider.value = 0f;
                        }
                    };

                    _advancedCGSaturationSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGSaturationSliderLabel", "Saturation");
                    _advancedCGSaturationSliderLabel.tooltip = "Pushes the intensity of all colors";

                    _advancedCGSaturationSliderNumeral = UIUtils.CreateLabel(_advancedCGSaturationSliderLabel, "AdvancedCGSaturationSliderNumeral", ProfileManager.Instance.ActiveProfile.CGSaturation.ToString());
                    _advancedCGSaturationSliderNumeral.width = 100f;
                    _advancedCGSaturationSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGSaturationSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGSaturationSliderNumeral.width - 10f, 0f);

                    _advancedCGSaturationSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGSaturationSlider", _ingameAtlas, 0f, 2f, 0.02f, 0.02f, ProfileManager.Instance.ActiveProfile.CGSaturation);
                    _advancedCGSaturationSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGSaturationSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.CGSaturation = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedCGSaturationSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGSaturationSlider.value = 1f;
                        }
                    };

                    _advancedCGContrastSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGContrastSliderLabel", "Contrast");
                    _advancedCGContrastSliderLabel.tooltip = "Expands or shrinks the overall range of tonal values";

                    _advancedCGContrastSliderNumeral = UIUtils.CreateLabel(_advancedCGContrastSliderLabel, "AdvancedCGContrastSliderNumeral", ProfileManager.Instance.ActiveProfile.CGContrast.ToString());
                    _advancedCGContrastSliderNumeral.width = 100f;
                    _advancedCGContrastSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGContrastSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGContrastSliderNumeral.width - 10f, 0f);

                    _advancedCGContrastSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGContrastSlider", _ingameAtlas, 0f, 2f, 0.02f, 0.02f, ProfileManager.Instance.ActiveProfile.CGContrast);
                    _advancedCGContrastSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGContrastSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.CGContrast = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedCGContrastSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGContrastSlider.value = 1f;
                        }
                    };

                    _advancedCGTonemapperDropDownLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGTonemapperDropDownLabel", "Tonemapper");
                    _advancedCGTonemapperDropDownLabel.tooltip = "Tonemapping is the process of remapping HDR values of an image into a range suitable to be displayed on screen.\n\nThe Neutral tonemapper only does range-remapping with minimal impact on color hue & saturation.\nThe Filmic (ACES) tonemapper uses a close approximation of the reference ACES tonemapper for a more filmic look";

                    _advancedCGTonemapperDropDown = UIUtils.CreateDropDown(_advancedScrollablePanel, "AdvancedCGTonemapperDropDown", _ingameAtlas);
                    _advancedCGTonemapperDropDown.items = ModInvariables.CGTonemapper;


                    _advancedCGNeutralBlackInSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralBlackInSliderLabel", "Neutral Black In");
                    _advancedCGNeutralBlackInSliderLabel.tooltip = "Inner control point for the black point when using neutral tonemapper";

                    _advancedCGNeutralBlackInSliderNumeral = UIUtils.CreateLabel(_advancedCGNeutralBlackInSliderLabel, "AdvancedCGNeutralBlackInSliderNumeral", ProfileManager.Instance.ActiveProfile.CGNeutralBlackIn.ToString());
                    _advancedCGNeutralBlackInSliderNumeral.width = 100f;
                    _advancedCGNeutralBlackInSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGNeutralBlackInSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGNeutralBlackInSliderNumeral.width - 10f, 0f);

                    _advancedCGNeutralBlackInSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralBlackInSlider", _ingameAtlas, -0.1f, 0.1f, 0.002f, 0.002f, ProfileManager.Instance.ActiveProfile.CGNeutralBlackIn);
                    _advancedCGNeutralBlackInSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGNeutralBlackInSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.CGNeutralBlackIn = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedCGNeutralBlackInSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGNeutralBlackInSlider.value = 0.02f;
                        }
                    };

                    _advancedCGNeutralWhiteInSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralWhiteInSliderLabel", "Neutral White In");
                    _advancedCGNeutralWhiteInSliderLabel.tooltip = "Inner control point for the white point when using neutral tonemapper";

                    _advancedCGNeutralWhiteInSliderNumeral = UIUtils.CreateLabel(_advancedCGNeutralWhiteInSliderLabel, "AdvancedCGNeutralWhiteInSliderNumeral", ProfileManager.Instance.ActiveProfile.CGNeutralWhiteIn.ToString());
                    _advancedCGNeutralWhiteInSliderNumeral.width = 100f;
                    _advancedCGNeutralWhiteInSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGNeutralWhiteInSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGNeutralWhiteInSliderNumeral.width - 10f, 0f);

                    _advancedCGNeutralWhiteInSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralWhiteInSlider", _ingameAtlas, 1f, 20f, 0.2f, 0.2f, ProfileManager.Instance.ActiveProfile.CGNeutralWhiteIn);
                    _advancedCGNeutralWhiteInSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGNeutralWhiteInSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.CGNeutralWhiteIn = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedCGNeutralWhiteInSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGNeutralWhiteInSlider.value = 10f;
                        }
                    };

                    _advancedCGNeutralBlackOutSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralBlackOutSliderLabel", "Neutral Black Out");
                    _advancedCGNeutralBlackOutSliderLabel.tooltip = "Outer control point for the black point when using neutral tonemapper";

                    _advancedCGNeutralBlackOutSliderNumeral = UIUtils.CreateLabel(_advancedCGNeutralBlackOutSliderLabel, "AdvancedCGNeutralBlackOutSliderNumeral", ProfileManager.Instance.ActiveProfile.CGNeutralBlackOut.ToString());
                    _advancedCGNeutralBlackOutSliderNumeral.width = 100f;
                    _advancedCGNeutralBlackOutSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGNeutralBlackOutSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGNeutralBlackOutSliderNumeral.width - 10f, 0f);

                    _advancedCGNeutralBlackOutSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralBlackOutSlider", _ingameAtlas, -0.09f, 0.1f, 0.002f, 0.002f, ProfileManager.Instance.ActiveProfile.CGNeutralBlackOut);
                    _advancedCGNeutralBlackOutSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGNeutralBlackOutSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.CGNeutralBlackOut = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedCGNeutralBlackOutSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGNeutralBlackOutSlider.value = 0f;
                        }
                    };

                    _advancedCGNeutralWhiteOutSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralWhiteOutSliderLabel", "Neutral White Out");
                    _advancedCGNeutralWhiteOutSliderLabel.tooltip = "Outer control point for the white point when using neutral tonemapper";

                    _advancedCGNeutralWhiteOutSliderNumeral = UIUtils.CreateLabel(_advancedCGNeutralWhiteOutSliderLabel, "AdvancedCGNeutralWhiteOutSliderNumeral", ProfileManager.Instance.ActiveProfile.CGNeutralWhiteOut.ToString());
                    _advancedCGNeutralWhiteOutSliderNumeral.width = 100f;
                    _advancedCGNeutralWhiteOutSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGNeutralWhiteOutSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGNeutralWhiteOutSliderNumeral.width - 10f, 0f);

                    _advancedCGNeutralWhiteOutSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralWhiteOutSlider", _ingameAtlas, 1f, 19f, 0.2f, 0.2f, ProfileManager.Instance.ActiveProfile.CGNeutralWhiteOut);
                    _advancedCGNeutralWhiteOutSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGNeutralWhiteOutSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.CGNeutralWhiteOut = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedCGNeutralWhiteOutSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGNeutralWhiteOutSlider.value = 10f;
                        }
                    };

                    _advancedCGNeutralWhiteLevelSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralWhiteLevelSliderLabel", "Neutral White Level");
                    _advancedCGNeutralWhiteLevelSliderLabel.tooltip = "Pre-curve white point adjustment when using neutral tonemapper";

                    _advancedCGNeutralWhiteLevelSliderNumeral = UIUtils.CreateLabel(_advancedCGNeutralWhiteLevelSliderLabel, "AdvancedCGNeutralWhiteLevelSliderNumeral", ProfileManager.Instance.ActiveProfile.CGNeutralWhiteLevel.ToString());
                    _advancedCGNeutralWhiteLevelSliderNumeral.width = 100f;
                    _advancedCGNeutralWhiteLevelSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGNeutralWhiteLevelSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGNeutralWhiteLevelSliderNumeral.width - 10f, 0f);

                    _advancedCGNeutralWhiteLevelSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralWhiteLevelSlider", _ingameAtlas, 0.1f, 20f, 0.1f, 0.1f, ProfileManager.Instance.ActiveProfile.CGNeutralWhiteLevel);
                    _advancedCGNeutralWhiteLevelSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGNeutralWhiteLevelSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.CGNeutralWhiteLevel = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedCGNeutralWhiteLevelSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGNeutralWhiteLevelSlider.value = 5.3f;
                        }
                    };

                    _advancedCGNeutralWhiteClipSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGNeutralWhiteClipSliderLabel", "Neutral White Clip");
                    _advancedCGNeutralWhiteClipSliderLabel.tooltip = "Post-curve white point adjustment using neutral tonemapper";

                    _advancedCGNeutralWhiteClipSliderNumeral = UIUtils.CreateLabel(_advancedCGNeutralWhiteClipSliderLabel, "AdvancedCGNeutralWhiteClipSliderNumeral", ProfileManager.Instance.ActiveProfile.CGNeutralWhiteClip.ToString());
                    _advancedCGNeutralWhiteClipSliderNumeral.width = 100f;
                    _advancedCGNeutralWhiteClipSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGNeutralWhiteClipSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGNeutralWhiteClipSliderNumeral.width - 10f, 0f);

                    _advancedCGNeutralWhiteClipSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGNeutralWhiteClipSlider", _ingameAtlas, 1f, 10f, 0.1f, 0.1f, ProfileManager.Instance.ActiveProfile.CGNeutralWhiteClip);
                    _advancedCGNeutralWhiteClipSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGNeutralWhiteClipSliderNumeral.text = value.ToString();
                        ProfileManager.Instance.ActiveProfile.CGNeutralWhiteClip = value;
                        ProfileManager.Instance.Apply();
                    };
                    _advancedCGNeutralWhiteClipSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            _advancedCGNeutralWhiteClipSlider.value = 10f;
                        }
                    };

                    _advancedCGChannelDropDownLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGChannelDropDownLabel", "Channel");
                    _advancedCGChannelDropDownLabel.tooltip = "The Channel Mixer is used to modify the influence of each input color channel (RGB) on the overall mix of the output channel";

                    _advancedCGChannelDropDown = UIUtils.CreateDropDown(_advancedScrollablePanel, "AdvancedCGChannelDropDown", _ingameAtlas);
                    _advancedCGChannelDropDown.items = ModInvariables.CGChannel;

                    _advancedCGChannelRedSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGChannelRedSliderLabel", "Red");

                    _advancedCGChannelRedSliderNumeral = UIUtils.CreateLabel(_advancedCGChannelRedSliderLabel, "AdvancedCGChannelRedSliderNumeral", "");
                    _advancedCGChannelRedSliderNumeral.width = 100f;
                    _advancedCGChannelRedSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGChannelRedSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGChannelRedSliderNumeral.width - 10f, 0f);

                    _advancedCGChannelRedSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGChannelRedSlider", _ingameAtlas, 0f, 1f, 0.01f, 0.01f, 0f);
                    _advancedCGChannelRedSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGChannelRedSliderNumeral.text = value.ToString();

                        switch (_advancedCGChannelDropDown.selectedIndex)
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
                    _advancedCGChannelRedSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            switch (_advancedCGChannelDropDown.selectedIndex)
                            {
                                case 0:
                                    _advancedCGChannelRedSlider.value = 1f;
                                    break;
                                case 1:
                                    _advancedCGChannelRedSlider.value = 0f;
                                    break;
                                case 2:
                                    _advancedCGChannelRedSlider.value = 0f;
                                    break;
                            }

                            ProfileManager.Instance.Apply();
                        }
                    };

                    _advancedCGChannelGreenSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGChannelGreenSliderLabel", "Green");

                    _advancedCGChannelGreenSliderNumeral = UIUtils.CreateLabel(_advancedCGChannelGreenSliderLabel, "AdvancedCGChannelGreenSliderNumeral", "");
                    _advancedCGChannelGreenSliderNumeral.width = 100f;
                    _advancedCGChannelGreenSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGChannelGreenSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGChannelGreenSliderNumeral.width - 10f, 0f);

                    _advancedCGChannelGreenSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGChannelGreenSlider", _ingameAtlas, 0f, 1f, 0.01f, 0.01f, 0f);
                    _advancedCGChannelGreenSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGChannelGreenSliderNumeral.text = value.ToString();

                        switch (_advancedCGChannelDropDown.selectedIndex)
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
                    _advancedCGChannelGreenSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            switch (_advancedCGChannelDropDown.selectedIndex)
                            {
                                case 0:
                                    _advancedCGChannelGreenSlider.value = 0f;
                                    break;
                                case 1:
                                    _advancedCGChannelGreenSlider.value = 1f;
                                    break;
                                case 2:
                                    _advancedCGChannelGreenSlider.value = 0f;
                                    break;
                            }

                            ProfileManager.Instance.Apply();
                        }
                    };

                    _advancedCGChannelBlueSliderLabel = UIUtils.CreateLabel(_advancedScrollablePanel, "AdvancedCGChannelBlueSliderLabel", "Blue");

                    _advancedCGChannelBlueSliderNumeral = UIUtils.CreateLabel(_advancedCGChannelBlueSliderLabel, "AdvancedCGChannelBlueSliderNumeral", "");
                    _advancedCGChannelBlueSliderNumeral.width = 100f;
                    _advancedCGChannelBlueSliderNumeral.textAlignment = UIHorizontalAlignment.Right;
                    _advancedCGChannelBlueSliderNumeral.relativePosition = new Vector3(_advancedScrollablePanel.width - _advancedCGChannelBlueSliderNumeral.width - 10f, 0f);

                    _advancedCGChannelBlueSlider = UIUtils.CreateSlider(_advancedScrollablePanel, "AdvancedCGChannelBlueSlider", _ingameAtlas, 0f, 1f, 0.01f, 0.01f, 0f);
                    _advancedCGChannelBlueSlider.eventValueChanged += (component, value) =>
                    {
                        _advancedCGChannelBlueSliderNumeral.text = value.ToString();

                        switch (_advancedCGChannelDropDown.selectedIndex)
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
                    _advancedCGChannelBlueSlider.eventMouseUp += (component, eventParam) =>
                    {
                        if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                        {
                            switch (_advancedCGChannelDropDown.selectedIndex)
                            {
                                case 0:
                                    _advancedCGChannelBlueSlider.value = 0f;
                                    break;
                                case 1:
                                    _advancedCGChannelBlueSlider.value = 0f;
                                    break;
                                case 2:
                                    _advancedCGChannelBlueSlider.value = 1f;
                                    break;
                            }

                            ProfileManager.Instance.Apply();
                        }
                    };

                    _advancedCGTonemapperDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        if (value != -1)
                        {
                            ProfileManager.Instance.ActiveProfile.CGTonemapper = value;
                            ProfileManager.Instance.Apply();

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
                        }
                    };
                    _advancedCGTonemapperDropDown.selectedIndex = ProfileManager.Instance.ActiveProfile.CGTonemapper;

                    _advancedCGChannelDropDown.eventSelectedIndexChanged += (component, value) =>
                    {
                        if (value != -1)
                        {
                            switch (value)
                            {
                                case 0:
                                    _advancedCGChannelRedSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerRedRed.ToString();
                                    _advancedCGChannelGreenSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerRedGreen.ToString();
                                    _advancedCGChannelBlueSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerRedBlue.ToString();
                                    _advancedCGChannelRedSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerRedRed;
                                    _advancedCGChannelGreenSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerRedGreen;
                                    _advancedCGChannelBlueSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerRedBlue;
                                    break;
                                case 1:
                                    _advancedCGChannelRedSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenRed.ToString();
                                    _advancedCGChannelGreenSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenGreen.ToString();
                                    _advancedCGChannelBlueSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenBlue.ToString();
                                    _advancedCGChannelRedSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenRed;
                                    _advancedCGChannelGreenSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenGreen;
                                    _advancedCGChannelBlueSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenBlue;
                                    break;
                                case 2:
                                    _advancedCGChannelRedSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueRed.ToString();
                                    _advancedCGChannelGreenSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueGreen.ToString();
                                    _advancedCGChannelBlueSliderNumeral.text = ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueBlue.ToString();
                                    _advancedCGChannelRedSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueRed;
                                    _advancedCGChannelGreenSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueGreen;
                                    _advancedCGChannelBlueSlider.value = ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueBlue;
                                    break;
                            }
                        }
                    };
                    _advancedCGChannelDropDown.selectedIndex = 0;

                    _advancedCGDivider = UIUtils.CreateDivider(_advancedScrollablePanel, "AdvancedCGDivider", _ingameAtlas);
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

                    if (!CompatibilityHelper.IsAnyLightColorsManipulatingModsEnabled())
                    {
                        _optionsLightColorsCheckBox.isChecked = profile.LightColorsEnabled;
                        _optionsSkyColorsCheckBox.isChecked = profile.SkyColorsEnabled;
                        _optionsEquatorColorsCheckBox.isChecked = profile.EquatorColorsEnabled;
                        _optionsGroundColorsCheckBox.isChecked = profile.GroundColorsEnabled;
                    }

                    _optionsSharpnessAssetTypeDropDown.selectedIndex = -1;
                    _optionsSharpnessAssetTypeDropDown.selectedIndex = 0;

                    _optionsAntiAliasingDropDown.selectedIndex = profile.AntialiasingTechnique;
                    _optionsAmbientOcclusionCheckBox.isChecked = profile.AmbientOcclusionEnabled;
                    _optionsBloomCheckBox.isChecked = profile.BloomEnabled;
                    _optionsColorGradingCheckBox.isChecked = profile.ColorGradingEnabled;

                    _advancedFXAAQualityDropDown.selectedIndex = profile.FXAAQuality;

                    _advancedTAAJitterSpreadSlider.value = profile.TAAJitterSpread;
                    _advancedTAAStationaryBlendingSlider.value = profile.TAAStationaryBlending;
                    _advancedTAAMotionBlendingSlider.value = profile.TAAMotionBlending;
                    _advancedTAASharpenSlider.value = profile.TAASharpen;

                    _advancedAOIntensitySlider.value = profile.AOIntensity;
                    _advancedAORadiusSlider.value = profile.AORadius;
                    _advancedAOSampleCountDropDown.selectedIndex = profile.AOSampleCount;
                    _advancedAODownsamplingCheckBox.isChecked = profile.AODownsampling;
                    _advancedAOForceForwardCompatibilityCheckBox.isChecked = profile.AOForceForwardCompatibility;
                    _advancedAOAmbientOnlyCheckBox.isChecked = profile.AOAmbientOnly;
                    _advancedAOHighPrecisionCheckBox.isChecked = profile.AOHighPrecision;

                    _advancedBloomVanillaBloomCheckBox.isChecked = profile.BloomVanillaBloomEnabled;
                    _advancedBloomIntensitySlider.value = profile.BloomIntensity;
                    _advancedBloomThresholdSlider.value = profile.BloomThreshold;
                    _advancedBloomSoftKneeSlider.value = profile.BloomSoftKnee;
                    _advancedBloomRadiusSlider.value = profile.BloomRadius;
                    _advancedBloomAntiFlickerCheckBox.isChecked = profile.BloomAntiFlicker;

                    _advancedCGVanillaTonemappingCheckBox.isChecked = profile.CGVanillaTonemappingEnabled;
                    _advancedCGVanillaColorCorrectionLUTCheckBox.isChecked = profile.CGVanillaColorCorrectionLUTEnabled;
                    _advancedCGPostExposureSlider.value = profile.CGPostExposure;
                    _advancedCGTemperatureSlider.value = profile.CGTemperature;
                    _advancedCGTintSlider.value = profile.CGTint;
                    _advancedCGHueShiftSlider.value = profile.CGHueShift;
                    _advancedCGSaturationSlider.value = profile.CGSaturation;
                    _advancedCGContrastSlider.value = profile.CGContrast;
                    _advancedCGTonemapperDropDown.selectedIndex = profile.CGTonemapper;
                    _advancedCGNeutralBlackInSlider.value = profile.CGNeutralBlackIn;
                    _advancedCGNeutralWhiteInSlider.value = profile.CGNeutralWhiteIn;
                    _advancedCGNeutralBlackOutSlider.value = profile.CGNeutralBlackOut;
                    _advancedCGNeutralWhiteOutSlider.value = profile.CGNeutralWhiteOut;
                    _advancedCGNeutralWhiteLevelSlider.value = profile.CGNeutralWhiteLevel;
                    _advancedCGNeutralWhiteClipSlider.value = profile.CGNeutralWhiteClip;

                    _advancedCGChannelDropDown.selectedIndex = -1;
                    _advancedCGChannelDropDown.selectedIndex = 0;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] MainPanel:ApplyProfile -> Exception: " + e.Message);
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
