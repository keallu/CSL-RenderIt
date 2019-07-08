using ColossalFramework.UI;
using System;
using UnityEngine;
using UnityEngine.PostProcessing;

namespace RenderIt
{
    public class ModManager : MonoBehaviour
    {
        private bool _initialized;
        private Camera _camera;
        private UIButton _freeCameraButton;
        private UIComponent _optionsPanel;
        private OptionsMainPanel _optionsMainPanel;

        private PostProcessingBehaviour _postProcessingBehaviour;
        private AntialiasingModel _antialiasingModel;
        private AmbientOcclusionModel _ambientOcclusionModel;
        private BloomModel _bloomModel;
        private ColorGradingModel _colorGradingModel;

        private UITextureAtlas _renderItAtlas;
        private UIButton _renderItButton;

        public void Awake()
        {
            try
            {
                ModProperties.Instance.AssetBundle = AssetBundleUtils.LoadAssetBundle("renderit");
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
                _camera = Camera.main;
                _freeCameraButton = GameObject.Find("Freecamera").GetComponent<UIButton>();
                _optionsPanel = UIView.library.Get("OptionsPanel");
                _optionsMainPanel = GameObject.Find("(Library) OptionsPanel").GetComponent<OptionsMainPanel>();

                _postProcessingBehaviour = _camera.gameObject.GetComponent<PostProcessingBehaviour>();
                if (_postProcessingBehaviour == null)
                {
                    _postProcessingBehaviour = _camera.gameObject.AddComponent<PostProcessingBehaviour>();
                    _postProcessingBehaviour.profile = ScriptableObject.CreateInstance<PostProcessingProfile>();
                }
                _postProcessingBehaviour.enabled = true;

                _antialiasingModel = new AntialiasingModel();
                _ambientOcclusionModel = new AmbientOcclusionModel();
                _bloomModel = new BloomModel();
                _colorGradingModel = new ColorGradingModel();

                _renderItAtlas = LoadResources();
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
                    UpdateAntialiasing();
                    UpdateAmbientOcclusion();
                    UpdateBloom();
                    UpdateColorGrading();

                    UpdateUI();

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
                if (_postProcessingBehaviour != null)
                {
                    Destroy(_postProcessingBehaviour);
                }

                AssetBundleUtils.UnloadAndDestroyAssetBundle(ModProperties.Instance.AssetBundle);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:OnDestroy -> Exception: " + e.Message);
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
                        "ppslogo"
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
                _renderItButton = UIUtils.CreateButton("RenderItButton", _renderItAtlas, "ppslogo", "Render It!");
                _renderItButton.absolutePosition = new Vector3(_freeCameraButton.absolutePosition.x - (5 * 36f) - 5f, _freeCameraButton.absolutePosition.y);
                _renderItButton.eventClick += (component, eventParam) =>
                {
                    if (!eventParam.used)
                    {
                        if (_optionsPanel != null)
                        {
                            if (_optionsPanel.isVisible)
                            {
                                _optionsPanel.Hide();
                                ModProperties.Instance.IsOptionsPanelNonModal = false;
                            }
                            else
                            {
                                if (_optionsMainPanel != null)
                                {
                                    _optionsMainPanel.SelectMod("Render It!");
                                }

                                _optionsPanel.Show();
                                ModProperties.Instance.IsOptionsPanelNonModal = true;
                            }
                        }

                        eventParam.Use();
                    }
                };
                _renderItButton.eventMouseMove += (component, eventParam) =>
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
                _renderItButton.isVisible = ModConfig.Instance.ShowButton;
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

                switch (ModConfig.Instance.AntialiasingTechnique)
                {
                    case 0:
                        _antialiasingModel.enabled = false;
                        break;
                    case 1:
                        settings.method = AntialiasingModel.Method.Fxaa;
                        AntialiasingModel.FxaaPreset preset = (AntialiasingModel.FxaaPreset)ModConfig.Instance.FXAAQuality;
                        settings.fxaaSettings.preset = preset;
                        _antialiasingModel.settings = settings;
                        _antialiasingModel.enabled = true;
                        break;
                    case 2:
                        settings.method = AntialiasingModel.Method.Taa;
                        settings.taaSettings.jitterSpread = ModConfig.Instance.TAAJitterSpread;
                        settings.taaSettings.sharpen = ModConfig.Instance.TAASharpen;
                        settings.taaSettings.stationaryBlending = ModConfig.Instance.TAAStationaryBlending;
                        settings.taaSettings.motionBlending = ModConfig.Instance.TAAMotionBlending;
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

                if (ModConfig.Instance.AmbientOcclusionEnabled)
                {
                    settings.intensity = ModConfig.Instance.AOIntensity;
                    settings.radius = ModConfig.Instance.AORadius;
                    settings.sampleCount = (AmbientOcclusionModel.SampleCount)ModConfig.Instance.AOSampleCount;
                    settings.downsampling = ModConfig.Instance.AODownsampling;
                    settings.forceForwardCompatibility = ModConfig.Instance.AOForceForwardCompatibility;
                    settings.ambientOnly = ModConfig.Instance.AOAmbientOnly;
                    settings.highPrecision = ModConfig.Instance.AOHighPrecision;
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

                if (ModConfig.Instance.BloomEnabled)
                {
                    settings.bloom.intensity = ModConfig.Instance.BloomIntensity;
                    settings.bloom.threshold = ModConfig.Instance.BloomThreshold;
                    settings.bloom.softKnee = ModConfig.Instance.BloomSoftKnee;
                    settings.bloom.radius = ModConfig.Instance.BloomRadius;
                    settings.bloom.antiFlicker = ModConfig.Instance.BloomAntiFlicker;
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

                if (ModConfig.Instance.ColorGradingEnabled)
                {
                    settings.basic.postExposure = ModConfig.Instance.CGPostExposure;
                    settings.basic.temperature = ModConfig.Instance.CGTemperature;
                    settings.basic.tint = ModConfig.Instance.CGTint;
                    settings.basic.hueShift = ModConfig.Instance.CGHueShift;
                    settings.basic.saturation = ModConfig.Instance.CGSaturation;
                    settings.basic.contrast = ModConfig.Instance.CGContrast;
                    settings.tonemapping.tonemapper = (ColorGradingModel.Tonemapper)ModConfig.Instance.CGTonemapper;
                    settings.tonemapping.neutralBlackIn = ModConfig.Instance.CGNeutralBlackIn;
                    settings.tonemapping.neutralWhiteIn = ModConfig.Instance.CGNeutralWhiteIn;
                    settings.tonemapping.neutralBlackOut = ModConfig.Instance.CGNeutralBlackOut;
                    settings.tonemapping.neutralWhiteOut = ModConfig.Instance.CGNeutralWhiteOut;
                    settings.tonemapping.neutralWhiteLevel = ModConfig.Instance.CGNeutralWhiteLevel;
                    settings.tonemapping.neutralWhiteClip = ModConfig.Instance.CGNeutralWhiteClip;                    
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
