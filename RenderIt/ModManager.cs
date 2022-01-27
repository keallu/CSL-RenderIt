using ColossalFramework;
using ColossalFramework.UI;
using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using RenderIt.Panels;

namespace RenderIt
{
    public class ModManager : MonoBehaviour
    {
        private bool _initialized;
        private Camera _camera;
        private UIMultiStateButton _zoomButton;

        private UITextureAtlas _renderItAtlas;
        private UIPanel _buttonPanel;
        private UIButton _button;

        private MainPanel _mainPanel;

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
                if (_camera == null)
                {
                    _camera = Camera.main;
                }

                if (_zoomButton == null)
                {
                    _zoomButton = GameObject.Find("ZoomButton")?.GetComponent<UIMultiStateButton>();
                }

                if (_mainPanel == null)
                {
                    _mainPanel = GameObject.Find("RenderItMainPanel")?.GetComponent<MainPanel>();
                }

                if (_zoomButton != null)
                {
                    ModProperties.Instance.ButtonDefaultPositionX = _zoomButton.absolutePosition.x;
                    ModProperties.Instance.ButtonDefaultPositionY = _zoomButton.absolutePosition.y - (2 * 36f) - 5f;
                }

                if (ModConfig.Instance.ButtonPositionX == 0f && ModConfig.Instance.ButtonPositionY == 0f)
                {
                    ModConfig.Instance.ButtonPositionX = ModProperties.Instance.ButtonDefaultPositionX;
                    ModConfig.Instance.ButtonPositionY = ModProperties.Instance.ButtonDefaultPositionY;
                }

                ModProperties.Instance.AssetBundle = AssetBundleUtils.LoadAssetBundle("renderit");

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

                SetActiveProfile();

                if (Singleton<InfoManager>.exists)
                {
                    Singleton<InfoManager>.instance.EventInfoModeChanged += Instance_EventInfoModeChanged;
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
                    SetActiveProfile();

                    ModUtils.UpdateOptionsGraphicsPanel();

                    UpdateAntialiasing();
                    UpdateAmbientOcclusion();
                    UpdateBloom();
                    UpdateColorGrading();

                    UpdateUI();
                    _mainPanel.ForceUpdateUI();

                    _initialized = true;
                    ModConfig.Instance.ConfigUpdated = false;
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
                    Singleton<InfoManager>.instance.EventInfoModeChanged -= Instance_EventInfoModeChanged;
                }

                if (_postProcessingBehaviour != null)
                {
                    Destroy(_postProcessingBehaviour.gameObject);
                }
                if (_renderItAtlas != null)
                {
                    Destroy(_renderItAtlas);
                }
                if (_button != null)
                {
                    Destroy(_button.gameObject);
                }
                if (_buttonPanel != null)
                {
                    Destroy(_buttonPanel.gameObject);
                }

                AssetBundleUtils.UnloadAndDestroyAssetBundle(ModProperties.Instance.AssetBundle);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:OnDestroy -> Exception: " + e.Message);
            }
        }

        private void Instance_EventInfoModeChanged(InfoManager.InfoMode mode, InfoManager.SubInfoMode subMode)
        {
            if (mode == InfoManager.InfoMode.None)
            {
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

        private void SetActiveProfile()
        {
            try
            {
                if (ModConfig.Instance.Profiles.Count == 0)
                {
                    Profile profile = new Profile
                    {
                        Name = "Default",
                        Active = true
                    };
                    ModConfig.Instance.Profiles.Add(profile);
                    ModProperties.Instance.ActiveProfile = profile;
                }
                else if (ModConfig.Instance.Profiles.Count == 1)
                {
                    ModProperties.Instance.ActiveProfile = ModConfig.Instance.Profiles[0];
                }
                else
                {
                    Profile profile = ModConfig.Instance.Profiles.Find(x => x.Active == true);

                    if (profile == null)
                    {
                        profile = ModConfig.Instance.Profiles[0];
                    }

                    ModProperties.Instance.ActiveProfile = profile;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:SetActiveProfile -> Exception: " + e.Message);
            }
        }

        private void CreateUI()
        {
            try
            {
                _buttonPanel = UIUtils.CreatePanel("RenderItButtonPanel");
                _buttonPanel.zOrder = 25;
                _buttonPanel.size = new Vector2(36f, 36f);
                _buttonPanel.eventMouseUp += (component, eventParam) =>
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

        private void UpdateAntialiasing()
        {
            try
            {
                AntialiasingModel.Settings settings = _antialiasingModel.settings;

                switch (ModProperties.Instance.ActiveProfile.AntialiasingTechnique)
                {
                    case 0:
                        _antialiasingModel.enabled = false;
                        break;
                    case 1:
                        _antialiasingModel.enabled = false;
                        break;
                    case 2:
                        settings.method = AntialiasingModel.Method.Fxaa;
                        AntialiasingModel.FxaaPreset preset = (AntialiasingModel.FxaaPreset)ModProperties.Instance.ActiveProfile.FXAAQuality;
                        settings.fxaaSettings.preset = preset;
                        _antialiasingModel.settings = settings;
                        _antialiasingModel.enabled = true;
                        break;
                    case 3:
                        settings.method = AntialiasingModel.Method.Taa;
                        settings.taaSettings.jitterSpread = ModProperties.Instance.ActiveProfile.TAAJitterSpread;
                        settings.taaSettings.sharpen = ModProperties.Instance.ActiveProfile.TAASharpen;
                        settings.taaSettings.stationaryBlending = ModProperties.Instance.ActiveProfile.TAAStationaryBlending;
                        settings.taaSettings.motionBlending = ModProperties.Instance.ActiveProfile.TAAMotionBlending;
                        _antialiasingModel.settings = settings;
                        _antialiasingModel.enabled = true;
                        break;
                    default:
                        _antialiasingModel.enabled = false;
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

        private void UpdateAmbientOcclusion()
        {
            try
            {
                AmbientOcclusionModel.Settings settings = _ambientOcclusionModel.settings;

                if (ModProperties.Instance.ActiveProfile.AmbientOcclusionEnabled)
                {
                    settings.intensity = ModProperties.Instance.ActiveProfile.AOIntensity;
                    settings.radius = ModProperties.Instance.ActiveProfile.AORadius;
                    settings.sampleCount = (AmbientOcclusionModel.SampleCount)ModProperties.Instance.ActiveProfile.AOSampleCount;
                    settings.downsampling = ModProperties.Instance.ActiveProfile.AODownsampling;
                    settings.forceForwardCompatibility = ModProperties.Instance.ActiveProfile.AOForceForwardCompatibility;
                    settings.ambientOnly = ModProperties.Instance.ActiveProfile.AOAmbientOnly;
                    settings.highPrecision = ModProperties.Instance.ActiveProfile.AOHighPrecision;
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
                UnityStandardAssets.ImageEffects.Bloom vanillaBloom = _camera.gameObject?.GetComponent<UnityStandardAssets.ImageEffects.Bloom>();

                BloomModel.Settings settings = _bloomModel.settings;

                if (ModProperties.Instance.ActiveProfile.BloomEnabled)
                {
                    if (vanillaBloom != null)
                    {
                        vanillaBloom.enabled = ModProperties.Instance.ActiveProfile.BloomVanillaBloomEnabled;
                    }
                    settings.bloom.intensity = ModProperties.Instance.ActiveProfile.BloomIntensity;
                    settings.bloom.threshold = ModProperties.Instance.ActiveProfile.BloomThreshold;
                    settings.bloom.softKnee = ModProperties.Instance.ActiveProfile.BloomSoftKnee;
                    settings.bloom.radius = ModProperties.Instance.ActiveProfile.BloomRadius;
                    settings.bloom.antiFlicker = ModProperties.Instance.ActiveProfile.BloomAntiFlicker;
                    _bloomModel.settings = settings;
                    _bloomModel.enabled = true;
                }
                else
                {
                    if (vanillaBloom != null)
                    {
                        vanillaBloom.enabled = true;
                    }
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
                ToneMapping vanillaToneMapping = _camera.gameObject?.GetComponent<ToneMapping>();
                ColorCorrectionLut vanillaColorCorrectionLut = _camera.gameObject?.GetComponent<ColorCorrectionLut>();

                ColorGradingModel.Settings settings = _colorGradingModel.settings;

                if (ModProperties.Instance.ActiveProfile.ColorGradingEnabled)
                {
                    if (vanillaToneMapping != null)
                    {
                        vanillaToneMapping.enabled = ModProperties.Instance.ActiveProfile.CGVanillaTonemappingEnabled;
                    }
                    if (vanillaColorCorrectionLut != null)
                    {
                        vanillaColorCorrectionLut.enabled = ModProperties.Instance.ActiveProfile.CGVanillaColorCorrectionLUTEnabled;
                    }
                    settings.basic.postExposure = ModProperties.Instance.ActiveProfile.CGPostExposure;
                    settings.basic.temperature = ModProperties.Instance.ActiveProfile.CGTemperature;
                    settings.basic.tint = ModProperties.Instance.ActiveProfile.CGTint;
                    settings.basic.hueShift = ModProperties.Instance.ActiveProfile.CGHueShift;
                    settings.basic.saturation = ModProperties.Instance.ActiveProfile.CGSaturation;
                    settings.basic.contrast = ModProperties.Instance.ActiveProfile.CGContrast;
                    settings.tonemapping.tonemapper = (ColorGradingModel.Tonemapper)ModProperties.Instance.ActiveProfile.CGTonemapper;
                    settings.tonemapping.neutralBlackIn = ModProperties.Instance.ActiveProfile.CGNeutralBlackIn;
                    settings.tonemapping.neutralWhiteIn = ModProperties.Instance.ActiveProfile.CGNeutralWhiteIn;
                    settings.tonemapping.neutralBlackOut = ModProperties.Instance.ActiveProfile.CGNeutralBlackOut;
                    settings.tonemapping.neutralWhiteOut = ModProperties.Instance.ActiveProfile.CGNeutralWhiteOut;
                    settings.tonemapping.neutralWhiteLevel = ModProperties.Instance.ActiveProfile.CGNeutralWhiteLevel;
                    settings.tonemapping.neutralWhiteClip = ModProperties.Instance.ActiveProfile.CGNeutralWhiteClip;
                    _colorGradingModel.settings = settings;
                    _colorGradingModel.enabled = true;
                }
                else
                {
                    if (vanillaToneMapping != null)
                    {
                        vanillaToneMapping.enabled = true;
                    }
                    if (vanillaColorCorrectionLut != null)
                    {
                        vanillaColorCorrectionLut.enabled = true;
                    }
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
