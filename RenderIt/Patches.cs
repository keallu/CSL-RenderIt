using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

namespace RenderIt
{
    [HarmonyPatch(typeof(MaterialFactory), "Get")]
    public static class MaterialFactoryGetPatch
    {
        static bool Prefix(Dictionary<string, Material> ___m_Materials, ref Material __result, string shaderName)
        {
            try
            {
                Material material;

                if (!___m_Materials.TryGetValue(shaderName, out material))
                {
                    var shader = AssetBundleUtils.Find(ModProperties.Instance.AssetBundle, shaderName);

                    if (shader == null)
                        throw new ArgumentException(string.Format("Shader not found ({0})", shaderName));

                    material = new Material(shader)
                    {
                        name = string.Format("PostFX - {0}", shaderName.Substring(shaderName.LastIndexOf("/") + 1)),
                        hideFlags = HideFlags.DontSave
                    };

                    ___m_Materials.Add(shaderName, material);
                }

                __result = material;

                return false;
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] MaterialFactoryGetPatch:Prefix -> Exception: " + e.Message);
                return false;
            }
        }
    }
}
