using System;
using UnityEngine;
using UnityEngine.PostProcessing;

namespace RenderIt
{
    public class ModManager : MonoBehaviour
    {
        private bool _initialized;
        private Camera _camera;

        private PostProcessingBehaviour _postProcessingBehaviour;
        private AntialiasingModel _antialiasingModel;
        private AmbientOcclusionModel _ambientOcclusionModel;
        private BloomModel _bloomModel;

        public void Awake()
        {
            try
            {
                _camera = Camera.main;

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
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:Start -> Exception: " + e.Message);
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

        public void Update()
        {
            try
            {
                if (!_initialized || ModConfig.Instance.ConfigUpdated)
                {
                    UpdateAntialiasing();
                    UpdateAmbientOcclusion();
                    UpdateBloom();

                    _initialized = true;
                    ModConfig.Instance.ConfigUpdated = false;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:Update -> Exception: " + e.Message);
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
    }
}
