using ColossalFramework;
using ColossalFramework.Plugins;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RenderIt
{
    public static class AssetBundleUtils
    {
        public static Dictionary<string, string> NameToFile = new Dictionary<string, string>()
        {
            { "Hidden/Post FX/Ambient Occlusion", "AmbientOcclusion.shader" },
            { "Hidden/Post FX/Blit", "Blit.shader" },
            { "Hidden/Post FX/Bloom", "Bloom.shader" },
            { "Hidden/Post FX/Builtin Debug Views", "BuiltinDebugViews.shader" },
            { "Hidden/Post FX/Depth Of Field", "DepthOfField.shader" },
            { "Hidden/Post FX/Eye Adaptation", "EyeAdaptation.shader" },
            { "Hidden/Post FX/Fog", "Fog.shader" },
            { "Hidden/Post FX/FXAA", "FXAA.shader" },
            { "Hidden/Post FX/Grain Generator", "GrainGen.shader" },
            { "Hidden/Post FX/Lut Generator", "LutGen.shader" },
            { "Hidden/Post FX/Motion Blur", "MotionBlur.shader" },
            { "Hidden/Post FX/Screen Space Reflection", "ScreenSpaceReflection.shader" },
            { "Hidden/Post FX/Temporal Anti-aliasing", "TAA.shader" },
            { "Hidden/Post FX/Uber Shader", "Uber.shader" }
        };

        public static AssetBundle LoadAssetBundle(string name)
        {
            try
            {
                string modPath = Singleton<PluginManager>.instance.FindPluginInfo(Assembly.GetAssembly(typeof(ModManager))).modPath;
                string platform = string.Empty;

                switch (Application.platform)
                {
                    case RuntimePlatform.WindowsPlayer:
                        platform = "win64";
                        break;
                    case RuntimePlatform.LinuxPlayer:
                        platform = "lin64";
                        break;
                    case RuntimePlatform.OSXPlayer:
                        platform = "osx64";
                        break;
                }

                return AssetBundle.LoadFromFile(modPath.Replace("\\", "/") + "/Resources/Shaders/" + platform + "/" + name);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] AssetBundleUtils:LoadAssetBundle -> Exception: " + e.Message);
                return null;
            }
        }

        public static void UnloadAndDestroyAssetBundle(AssetBundle assetBundle)
        {
            try
            {
                if (assetBundle != null)
                {
                    assetBundle.Unload(true);
                    UnityEngine.Object.Destroy(assetBundle);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] AssetBundleUtils:UnloadAndDestroyAssetBundle -> Exception: " + e.Message);
            }
        }

        public static Shader Find(AssetBundle assetBundle, string name)
        {
            try
            {
                return assetBundle.LoadAsset<Shader>(NameToFile[name]);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] AssetBundleUtils:Find -> Exception: " + e.Message);
                return null;
            }
        }
    }
}
