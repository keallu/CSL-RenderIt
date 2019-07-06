using System;
using UnityEngine;
using UnityEngine.PostProcessing;

namespace RenderIt
{
    public class ModManager : MonoBehaviour
    {
        private bool _initialized;

        private PostProcessingBehaviour _postProcessingBehaviour;
        private AntialiasingModel _antialiasingModel;

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
                _postProcessingBehaviour = Camera.main.gameObject.GetComponent<PostProcessingBehaviour>();

                if (_postProcessingBehaviour == null)
                {
                    _postProcessingBehaviour = Camera.main.gameObject.AddComponent<PostProcessingBehaviour>();
                    _postProcessingBehaviour.profile = ScriptableObject.CreateInstance<PostProcessingProfile>();
                }

                _postProcessingBehaviour.enabled = true;

                _antialiasingModel = new AntialiasingModel();
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
                        _antialiasingModel.enabled = true;
                        settings.method = AntialiasingModel.Method.Fxaa;
                        AntialiasingModel.FxaaPreset preset = (AntialiasingModel.FxaaPreset)ModConfig.Instance.FXAAQuality;
                        settings.fxaaSettings.preset = preset;
                        _antialiasingModel.settings = settings;
                        break;
                    case 2:
                        _antialiasingModel.enabled = true;
                        settings.method = AntialiasingModel.Method.Taa;
                        settings.taaSettings.jitterSpread = ModConfig.Instance.TAAJitterSpread;
                        settings.taaSettings.sharpen = ModConfig.Instance.TAASharpen;
                        settings.taaSettings.stationaryBlending = ModConfig.Instance.TAAStationaryBlending;
                        settings.taaSettings.motionBlending = ModConfig.Instance.TAAMotionBlending;
                        _antialiasingModel.settings = settings;
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
    }
}
