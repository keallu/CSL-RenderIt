using ColossalFramework;
using ColossalFramework.UI;
using RenderIt.Helpers;
using RenderIt.Managers;
using RenderIt.Panels;
using System;
using UnityEngine;
using UnityEngine.PostProcessing;

namespace RenderIt
{
    public class ModManager : MonoBehaviour
    {
        private bool _initialized;
        private Camera _camera;

        private UITextureAtlas _renderItAtlas;
        private UIPanel _buttonPanel;
        private UIButton _button;

        private MainPanel _mainPanel;

        private FogEffect _fogEffect;
        private DayNightFogEffect _dayNightFogEffect;
        private FogProperties _fogProperties;
        private RenderProperties _renderProperties;

        private PostProcessingBehaviour _postProcessingBehaviour;
        private AntialiasingModel _antialiasingModel;
        private AmbientOcclusionModel _ambientOcclusionModel;
        private BloomModel _bloomModel;
        private ColorGradingModel _colorGradingModel;

        public void Awake()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:Awake -> Exception: " + e.Message);
            }
        }

        public void Start()
        {
            try
            {
                DefaultManager.Instance.Initialize();

                if (_camera == null)
                {
                    _camera = Camera.main;
                }

                if (_mainPanel == null)
                {
                    _mainPanel = GameObject.Find("RenderItMainPanel")?.GetComponent<MainPanel>();
                }

                if (ModConfig.Instance.ButtonPositionX == 0f && ModConfig.Instance.ButtonPositionY == 0f)
                {
                    ModProperties.Instance.ResetButtonPosition();
                }

                AssetManager.Instance.AssetBundle = AssetBundleUtils.LoadAssetBundle("renderit");

                _fogEffect = FindObjectOfType<FogEffect>();
                _dayNightFogEffect = FindObjectOfType<DayNightFogEffect>();
                _fogProperties = FindObjectOfType<FogProperties>();
                _renderProperties = FindObjectOfType<RenderProperties>();

                _postProcessingBehaviour = _camera.gameObject?.GetComponent<PostProcessingBehaviour>();
                if (_postProcessingBehaviour == null)
                {
                    _postProcessingBehaviour = _camera.gameObject?.AddComponent<PostProcessingBehaviour>();
                    _postProcessingBehaviour.profile = ScriptableObject.CreateInstance<PostProcessingProfile>();
                }
                _postProcessingBehaviour.enabled = true;

                _antialiasingModel = new AntialiasingModel();
                _ambientOcclusionModel = new AmbientOcclusionModel();
                _bloomModel = new BloomModel();
                _colorGradingModel = new ColorGradingModel();

                _renderItAtlas = LoadResources();

                if (Singleton<InfoManager>.exists)
                {
                    Singleton<InfoManager>.instance.EventInfoModeChanged += InfoManagerEventInfoModeChanged;
                }

                CreateUI();
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:Start -> Exception: " + e.Message);
            }
        }

        public void Update()
        {
            try
            {
                if (!_initialized || ModConfig.Instance.ConfigUpdated)
                {
                    UpdateUI();
                    _mainPanel.ForceUpdateUI();

                    _initialized = true;
                    ModConfig.Instance.ConfigUpdated = false;
                }

                if (ProfileManager.Instance.IsActiveProfileUpdated)
                {
                    UpdateLighting();
                    UpdateColors();
                    UpdateTextures();
                    UpdateEnvironment();
                    UpdateAntialiasing();
                    UpdateVanillaBloom();
                    UpdateVanillaToneMapping();
                    UpdateVanillaColorCorrectionLut();
                    UpdateAmbientOcclusion();
                    UpdateBloom();
                    UpdateColorGrading();

                    ProfileManager.Instance.IsActiveProfileUpdated = false;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:Update -> Exception: " + e.Message);
            }
        }

        public void OnDestroy()
        {
            try
            {
                if (Singleton<InfoManager>.exists)
                {
                    Singleton<InfoManager>.instance.EventInfoModeChanged -= InfoManagerEventInfoModeChanged;
                }

                if (_postProcessingBehaviour != null)
                {
                    Destroy(_postProcessingBehaviour.gameObject);
                }
                if (_button != null)
                {
                    Destroy(_button.gameObject);
                }
                if (_buttonPanel != null)
                {
                    Destroy(_buttonPanel.gameObject);
                }
                if (_renderItAtlas != null)
                {
                    Destroy(_renderItAtlas);
                }

                AssetBundleUtils.UnloadAndDestroyAssetBundle(AssetManager.Instance.AssetBundle);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:OnDestroy -> Exception: " + e.Message);
            }
        }

        private void InfoManagerEventInfoModeChanged(InfoManager.InfoMode mode, InfoManager.SubInfoMode subMode)
        {
            if (mode == InfoManager.InfoMode.None)
            {
                UpdateVanillaBloom();
                UpdateVanillaToneMapping();
                UpdateVanillaColorCorrectionLut();
                UpdateAmbientOcclusion();
                UpdateBloom();
                UpdateColorGrading();
            }
        }

        private UITextureAtlas LoadResources()
        {
            try
            {
                if (_renderItAtlas == null)
                {
                    string[] spriteNames = new string[]
                    {
                        "renderit"
                    };

                    _renderItAtlas = ResourceLoader.CreateTextureAtlas("RenderItAtlas", spriteNames, "RenderIt.Icons.");

                    UITextureAtlas defaultAtlas = ResourceLoader.GetAtlas("Ingame");
                    Texture2D[] textures = new Texture2D[]
                    {
                        defaultAtlas["OptionBase"].texture,
                        defaultAtlas["OptionBaseFocused"].texture,
                        defaultAtlas["OptionBaseHovered"].texture,
                        defaultAtlas["OptionBasePressed"].texture,
                        defaultAtlas["OptionBaseDisabled"].texture
                    };

                    ResourceLoader.AddTexturesInAtlas(_renderItAtlas, textures);
                }

                return _renderItAtlas;
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:LoadResources -> Exception: " + e.Message);
                return null;
            }
        }

        private void CreateUI()
        {
            try
            {
                _buttonPanel = UIUtils.CreatePanel("RenderItButtonPanel");
                _buttonPanel.zOrder = 25;
                _buttonPanel.size = new Vector2(36f, 36f);
                _buttonPanel.eventMouseMove += (component, eventParam) =>
                {
                    if (eventParam.buttons.IsFlagSet(UIMouseButton.Right))
                    {
                        var ratio = UIView.GetAView().ratio;
                        component.position = new Vector3(component.position.x + (eventParam.moveDelta.x * ratio), component.position.y + (eventParam.moveDelta.y * ratio), component.position.z);

                        ModConfig.Instance.ButtonPositionX = component.absolutePosition.x;
                        ModConfig.Instance.ButtonPositionY = component.absolutePosition.y;
                        ModConfig.Instance.Save();
                    }
                };

                _button = UIUtils.CreateButton(_buttonPanel, "RenderItButton", _renderItAtlas, "renderit");
                _button.tooltip = "Render It!";
                _button.size = new Vector2(36f, 36f);
                _button.relativePosition = new Vector3(0f, 0f);
                _button.eventClick += (component, eventParam) =>
                {
                    if (!eventParam.used)
                    {
                        if (_mainPanel != null)
                        {
                            if (_mainPanel.isVisible)
                            {
                                _mainPanel.Hide();
                                ModConfig.Instance.ShowPanel = false;
                                ModConfig.Instance.Save();
                            }
                            else
                            {
                                _mainPanel.Show();
                                ModConfig.Instance.ShowPanel = true;
                                ModConfig.Instance.Save();
                            }
                        }

                        eventParam.Use();
                    }
                };
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:CreateUI -> Exception: " + e.Message);
            }
        }

        private void UpdateUI()
        {
            try
            {
                _buttonPanel.isVisible = ModConfig.Instance.ShowButton;
                _buttonPanel.absolutePosition = new Vector3(ModConfig.Instance.ButtonPositionX, ModConfig.Instance.ButtonPositionY);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:UpdateUI -> Exception: " + e.Message);
            }
        }

        private void UpdateLighting()
        {
            try
            {
                DayNightProperties.instance.m_SunIntensity = ProfileManager.Instance.ActiveProfile.SunIntensity;
                DayNightProperties.instance.sunLightSource.shadowStrength = ProfileManager.Instance.ActiveProfile.SunShadowStrength;
                DayNightProperties.instance.m_MoonIntensity = ProfileManager.Instance.ActiveProfile.MoonIntensity;
                DayNightProperties.instance.moonLightSource.shadowStrength = ProfileManager.Instance.ActiveProfile.MoonShadowStrength;

                if (!CompatibilityHelper.IsAnySkyManipulatingModsEnabled())
                {
                    DayNightProperties.instance.m_RayleighScattering = ProfileManager.Instance.ActiveProfile.SkyRayleighScattering;
                    DayNightProperties.instance.m_MieScattering = ProfileManager.Instance.ActiveProfile.SkyMieScattering;
                    DayNightProperties.instance.m_Exposure = ProfileManager.Instance.ActiveProfile.SkyExposure;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:UpdateLighting -> Exception: " + e.Message);
            }
        }

        private void UpdateColors()
        {
            try
            {
                if (!CompatibilityHelper.IsAnyLightColorsManipulatingModsEnabled())
                {
                    if (ProfileManager.Instance.ActiveProfile.LightColorsEnabled)
                    {
                        GradientColorKey[] gradientColorKeys = ColorsHelper.ConvertToGradientColorKeyArray(ProfileManager.Instance.ActiveProfile.LightColors);

                        if (gradientColorKeys != null)
                        {
                            DayNightProperties.instance.m_LightColor.colorKeys = gradientColorKeys;
                        }
                    }
                    else
                    {
                        DayNightProperties.instance.m_LightColor.colorKeys = (GradientColorKey[])DefaultManager.Instance.Get("LightColors");
                    }

                    if (ProfileManager.Instance.ActiveProfile.SkyColorsEnabled)
                    {
                        GradientColorKey[] gradientColorKeys = ColorsHelper.ConvertToGradientColorKeyArray(ProfileManager.Instance.ActiveProfile.SkyColors);

                        if (gradientColorKeys != null)
                        {
                            DayNightProperties.instance.m_AmbientColor.skyColor.colorKeys = gradientColorKeys;
                        }
                    }
                    else
                    {
                        DayNightProperties.instance.m_AmbientColor.skyColor.colorKeys = (GradientColorKey[])DefaultManager.Instance.Get("SkyColors");
                    }

                    if (ProfileManager.Instance.ActiveProfile.EquatorColorsEnabled)
                    {
                        GradientColorKey[] gradientColorKeys = ColorsHelper.ConvertToGradientColorKeyArray(ProfileManager.Instance.ActiveProfile.EquatorColors);

                        if (gradientColorKeys != null)
                        {
                            DayNightProperties.instance.m_AmbientColor.equatorColor.colorKeys = gradientColorKeys;
                        }
                    }
                    else
                    {
                        DayNightProperties.instance.m_AmbientColor.equatorColor.colorKeys = (GradientColorKey[])DefaultManager.Instance.Get("EquatorColors");
                    }

                    if (ProfileManager.Instance.ActiveProfile.GroundColorsEnabled)
                    {
                        GradientColorKey[] gradientColorKeys = ColorsHelper.ConvertToGradientColorKeyArray(ProfileManager.Instance.ActiveProfile.GroundColors);

                        if (gradientColorKeys != null)
                        {
                            DayNightProperties.instance.m_AmbientColor.groundColor.colorKeys = gradientColorKeys;
                        }
                    }
                    else
                    {
                        DayNightProperties.instance.m_AmbientColor.groundColor.colorKeys = (GradientColorKey[])DefaultManager.Instance.Get("GroundColors");
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:UpdateColors -> Exception: " + e.Message);
            }
        }

        private void UpdateTextures()
        {
            try
            {
                TextureHelper.UpdateTexture();
                TextureHelper.UpdateTexture2D();
                TextureHelper.UpdateBuildings();
                TextureHelper.UpdateNetworks();
                TextureHelper.UpdateProps();
                TextureHelper.UpdateCitizens();
                TextureHelper.UpdateVehicles();
                TextureHelper.UpdateTrees();
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:UpdateTextures -> Exception: " + e.Message);
            }
        }
        private void UpdateEnvironment()
        {
            try
            {
                if (!CompatibilityHelper.IsAnyFogManipulatingModsEnabled())
                {
                    if (_fogEffect != null)
                    {
                        _fogEffect.enabled = ProfileManager.Instance.ActiveProfile.FogEnabled;
                        _fogEffect.m_edgeFog = ProfileManager.Instance.ActiveProfile.FogEdgeDistance < 3800f;
                        _fogEffect.m_UseVolumeFog = ProfileManager.Instance.ActiveProfile.FogDistance > 0f;
                        _fogEffect.m_FogHeight = ProfileManager.Instance.ActiveProfile.FogHeight;
                        _fogEffect.m_3DFogStart = ProfileManager.Instance.ActiveProfile.FogStart;
                        _fogEffect.m_3DFogDistance = ProfileManager.Instance.ActiveProfile.FogDistance;
                        _fogEffect.m_edgeFogDistance = ProfileManager.Instance.ActiveProfile.FogEdgeDistance;
                    }

                    if (_dayNightFogEffect != null)
                    {
                        _dayNightFogEffect.enabled = ProfileManager.Instance.ActiveProfile.FogDayNightEnabled;
                    }

                    if (_fogProperties != null)
                    {
                        _fogProperties.m_edgeFog = ProfileManager.Instance.ActiveProfile.FogEdgeDistance < 3800f;
                        _fogProperties.m_FogHeight = ProfileManager.Instance.ActiveProfile.FogHeight;
                        _fogProperties.m_HorizonHeight = ProfileManager.Instance.ActiveProfile.FogHorizonHeight;
                        _fogProperties.m_FogDensity = ProfileManager.Instance.ActiveProfile.FogDensity;
                        _fogProperties.m_FoggyFogDensity = ProfileManager.Instance.ActiveProfile.FogDensity;
                        _fogProperties.m_FogStart = ProfileManager.Instance.ActiveProfile.FogStart;
                        _fogProperties.m_FoggyFogStart = ProfileManager.Instance.ActiveProfile.FogStart;
                        _fogProperties.m_FogDistance = ProfileManager.Instance.ActiveProfile.FogDistance;
                        _fogProperties.m_EdgeFogDistance = ProfileManager.Instance.ActiveProfile.FogEdgeDistance;
                        _fogProperties.m_NoiseContribution = ProfileManager.Instance.ActiveProfile.FogNoiseContribution;
                        _fogProperties.m_FoggyNoiseContribution = ProfileManager.Instance.ActiveProfile.FogNoiseContribution;
                        _fogProperties.m_PollutionAmount = ProfileManager.Instance.ActiveProfile.FogPollutionAmount;
                        _fogProperties.m_ColorDecay = ProfileManager.Instance.ActiveProfile.FogColorDecay;
                        _fogProperties.m_Scattering = ProfileManager.Instance.ActiveProfile.FogScattering;
                    }

                    if (_renderProperties != null)
                    {
                        _renderProperties.m_useVolumeFog = ProfileManager.Instance.ActiveProfile.FogDistance > 0f;
                        _renderProperties.m_fogHeight = ProfileManager.Instance.ActiveProfile.FogHeight;
                        _renderProperties.m_volumeFogDensity = ProfileManager.Instance.ActiveProfile.FogDensity;
                        _renderProperties.m_volumeFogStart = ProfileManager.Instance.ActiveProfile.FogStart;
                        _renderProperties.m_volumeFogDistance = ProfileManager.Instance.ActiveProfile.FogDistance / 4.2f;
                        _renderProperties.m_edgeFogDistance = ProfileManager.Instance.ActiveProfile.FogEdgeDistance;
                        _renderProperties.m_pollutionFogIntensity = ProfileManager.Instance.ActiveProfile.FogPollutionAmount * 8f;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:UpdateEnvironment -> Exception: " + e.Message);
            }
        }

        private void UpdateAntialiasing()
        {
            try
            {
                AntialiasingModel.Settings settings = _antialiasingModel.settings;

                switch (ProfileManager.Instance.ActiveProfile.AntialiasingTechnique)
                {
                    case 0:
                        _antialiasingModel.enabled = false;
                        GameOptionsHelper.SetAntialiasingInOptionsGraphicsPanel(false);
                        break;
                    case 1:
                        _antialiasingModel.enabled = false;
                        GameOptionsHelper.SetAntialiasingInOptionsGraphicsPanel(true);
                        break;
                    case 2:
                        settings.method = AntialiasingModel.Method.Fxaa;
                        AntialiasingModel.FxaaPreset preset = (AntialiasingModel.FxaaPreset)ProfileManager.Instance.ActiveProfile.FXAAQuality;
                        settings.fxaaSettings.preset = preset;
                        _antialiasingModel.settings = settings;
                        _antialiasingModel.enabled = true;
                        GameOptionsHelper.SetAntialiasingInOptionsGraphicsPanel(false);
                        break;
                    case 3:
                        settings.method = AntialiasingModel.Method.Taa;
                        settings.taaSettings.jitterSpread = ProfileManager.Instance.ActiveProfile.TAAJitterSpread;
                        settings.taaSettings.sharpen = ProfileManager.Instance.ActiveProfile.TAASharpen;
                        settings.taaSettings.stationaryBlending = ProfileManager.Instance.ActiveProfile.TAAStationaryBlending;
                        settings.taaSettings.motionBlending = ProfileManager.Instance.ActiveProfile.TAAMotionBlending;
                        _antialiasingModel.settings = settings;
                        _antialiasingModel.enabled = true;
                        GameOptionsHelper.SetAntialiasingInOptionsGraphicsPanel(false);
                        break;
                    default:
                        _antialiasingModel.enabled = false;
                        GameOptionsHelper.SetAntialiasingInOptionsGraphicsPanel(true);
                        break;
                }

                _postProcessingBehaviour.profile.antialiasing.settings = _antialiasingModel.settings;
                _postProcessingBehaviour.profile.antialiasing.enabled = _antialiasingModel.enabled;
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:UpdateAntialiasing -> Exception: " + e.Message);
            }
        }

        private void UpdateVanillaBloom()
        {
            try
            {
                UnityStandardAssets.ImageEffects.Bloom vanillaBloom = _camera.gameObject?.GetComponent<UnityStandardAssets.ImageEffects.Bloom>();

                if (vanillaBloom != null)
                {
                    vanillaBloom.enabled = ProfileManager.Instance.ActiveProfile.VanillaBloomEnabled;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:UpdateVanillaBloom -> Exception: " + e.Message);
            }
        }

        private void UpdateVanillaToneMapping()
        {
            try
            {
                ToneMapping vanillaToneMapping = _camera.gameObject?.GetComponent<ToneMapping>();

                if (vanillaToneMapping != null)
                {
                    vanillaToneMapping.enabled = ProfileManager.Instance.ActiveProfile.VanillaTonemappingEnabled;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:UpdateVanillaToneMapping -> Exception: " + e.Message);
            }
        }

        private void UpdateVanillaColorCorrectionLut()
        {
            try
            {
                ColorCorrectionLut vanillaColorCorrectionLut = _camera.gameObject?.GetComponent<ColorCorrectionLut>();

                if (vanillaColorCorrectionLut != null)
                {
                    vanillaColorCorrectionLut.enabled = ProfileManager.Instance.ActiveProfile.VanillaColorCorrectionLutEnabled;

                    if (ModConfig.Instance.AutomaticColorCorrectionOverride)
                    {
                        int indexOfSelectedColorCorrectionLut = LutManager.Instance.IndexOf(ProfileManager.Instance.ActiveProfile.VanillaColorCorrectionLutName);

                        if (GameOptionsHelper.GetColorCorrectionOverrideInOptionsGraphicsPanel() != indexOfSelectedColorCorrectionLut)
                        {
                            GameOptionsHelper.SetColorCorrectionOverrideInOptionsGraphicsPanel(indexOfSelectedColorCorrectionLut);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:UpdateVanillaColorCorrectionLut -> Exception: " + e.Message);
            }
        }

        private void UpdateAmbientOcclusion()
        {
            try
            {
                AmbientOcclusionModel.Settings settings = _ambientOcclusionModel.settings;

                if (ProfileManager.Instance.ActiveProfile.AmbientOcclusionEnabled)
                {
                    settings.intensity = ProfileManager.Instance.ActiveProfile.AOIntensity;
                    settings.radius = ProfileManager.Instance.ActiveProfile.AORadius;
                    settings.sampleCount = (AmbientOcclusionModel.SampleCount)ProfileManager.Instance.ActiveProfile.AOSampleCount;
                    settings.downsampling = ProfileManager.Instance.ActiveProfile.AODownsampling;
                    settings.forceForwardCompatibility = ProfileManager.Instance.ActiveProfile.AOForceForwardCompatibility;
                    settings.ambientOnly = ProfileManager.Instance.ActiveProfile.AOAmbientOnly;
                    settings.highPrecision = ProfileManager.Instance.ActiveProfile.AOHighPrecision;
                    _ambientOcclusionModel.settings = settings;
                    _ambientOcclusionModel.enabled = true;
                }
                else
                {
                    _ambientOcclusionModel.enabled = false;
                }

                _postProcessingBehaviour.profile.ambientOcclusion.settings = _ambientOcclusionModel.settings;
                _postProcessingBehaviour.profile.ambientOcclusion.enabled = _ambientOcclusionModel.enabled;
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:UpdateAmbientOcclusion -> Exception: " + e.Message);
            }
        }

        private void UpdateBloom()
        {
            try
            {
                BloomModel.Settings settings = _bloomModel.settings;

                if (ProfileManager.Instance.ActiveProfile.BloomEnabled)
                {
                    settings.bloom.intensity = ProfileManager.Instance.ActiveProfile.BloomIntensity;
                    settings.bloom.threshold = ProfileManager.Instance.ActiveProfile.BloomThreshold;
                    settings.bloom.softKnee = ProfileManager.Instance.ActiveProfile.BloomSoftKnee;
                    settings.bloom.radius = ProfileManager.Instance.ActiveProfile.BloomRadius;
                    settings.bloom.antiFlicker = ProfileManager.Instance.ActiveProfile.BloomAntiFlicker;
                    _bloomModel.settings = settings;
                    _bloomModel.enabled = true;
                }
                else
                {
                    _bloomModel.enabled = false;
                }

                _postProcessingBehaviour.profile.bloom.settings = _bloomModel.settings;
                _postProcessingBehaviour.profile.bloom.enabled = _bloomModel.enabled;
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:UpdateBloom -> Exception: " + e.Message);
            }
        }

        private void UpdateColorGrading()
        {
            try
            {
                ColorGradingModel.Settings settings = _colorGradingModel.settings;

                if (ProfileManager.Instance.ActiveProfile.ColorGradingEnabled)
                {
                    settings.basic.postExposure = ProfileManager.Instance.ActiveProfile.CGPostExposure;
                    settings.basic.temperature = ProfileManager.Instance.ActiveProfile.CGTemperature;
                    settings.basic.tint = ProfileManager.Instance.ActiveProfile.CGTint;
                    settings.basic.hueShift = ProfileManager.Instance.ActiveProfile.CGHueShift;
                    settings.basic.saturation = ProfileManager.Instance.ActiveProfile.CGSaturation;
                    settings.basic.contrast = ProfileManager.Instance.ActiveProfile.CGContrast;
                    settings.tonemapping.tonemapper = (ColorGradingModel.Tonemapper)ProfileManager.Instance.ActiveProfile.CGTonemapper;
                    settings.tonemapping.neutralBlackIn = ProfileManager.Instance.ActiveProfile.CGNeutralBlackIn;
                    settings.tonemapping.neutralWhiteIn = ProfileManager.Instance.ActiveProfile.CGNeutralWhiteIn;
                    settings.tonemapping.neutralBlackOut = ProfileManager.Instance.ActiveProfile.CGNeutralBlackOut;
                    settings.tonemapping.neutralWhiteOut = ProfileManager.Instance.ActiveProfile.CGNeutralWhiteOut;
                    settings.tonemapping.neutralWhiteLevel = ProfileManager.Instance.ActiveProfile.CGNeutralWhiteLevel;
                    settings.tonemapping.neutralWhiteClip = ProfileManager.Instance.ActiveProfile.CGNeutralWhiteClip;
                    settings.channelMixer.red = new Vector3(ProfileManager.Instance.ActiveProfile.CGChannelMixerRedRed, ProfileManager.Instance.ActiveProfile.CGChannelMixerRedGreen, ProfileManager.Instance.ActiveProfile.CGChannelMixerRedBlue);
                    settings.channelMixer.green = new Vector3(ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenRed, ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenGreen, ProfileManager.Instance.ActiveProfile.CGChannelMixerGreenBlue);
                    settings.channelMixer.blue = new Vector3(ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueRed, ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueGreen, ProfileManager.Instance.ActiveProfile.CGChannelMixerBlueBlue);
                    _colorGradingModel.settings = settings;
                    _colorGradingModel.enabled = true;
                }
                else
                {
                    _colorGradingModel.enabled = false;
                }

                _postProcessingBehaviour.profile.colorGrading.settings = _colorGradingModel.settings;
                _postProcessingBehaviour.profile.colorGrading.enabled = _colorGradingModel.enabled;
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:UpdateColorGrading -> Exception: " + e.Message);
            }
        }
    }
}
