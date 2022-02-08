using System;
using UnityEngine;
using RenderIt.Managers;

namespace RenderIt.Helpers
{
    public static class TextureHelper
    {
        public static void UpdateTexture()
        {
            try
            {
                Texture[] textures = UnityEngine.Object.FindObjectsOfType<Texture>();
                foreach (Texture texture in textures)
                {
                    texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.GeneralAnisoLevel];
                    texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.GeneralMipMapBias];
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] TextureHelper:UpdateTexture -> Exception: " + e.Message);
            }
        }

        public static void UpdateTexture2D()
        {
            try
            {
                Texture[] textures = UnityEngine.Object.FindObjectsOfType<Texture2D>();
                foreach (Texture texture in textures)
                {
                    texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.GeneralAnisoLevel];
                    texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.GeneralMipMapBias];
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] TextureHelper:UpdateTexture2D -> Exception: " + e.Message);
            }
        }

        public static void UpdateBuildings()
        {
            try
            {
                for (uint i = 0; i < PrefabCollection<BuildingInfo>.LoadedCount(); i++)
                {
                    BuildingInfo buildingInfo = PrefabCollection<BuildingInfo>.GetLoaded(i);

                    if (buildingInfo == null)
                    {
                        continue;
                    }
                    if (buildingInfo.m_material != null)
                    {
                        Texture texture = buildingInfo.m_material.GetTexture("_MainTex");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.BuildingsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.BuildingsMipMapBias];
                        }
                        texture = buildingInfo.m_material.GetTexture("_XYSMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.BuildingsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.BuildingsMipMapBias];
                        }
                        texture = buildingInfo.m_material.GetTexture("_ACIMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.BuildingsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.BuildingsMipMapBias];
                        }
                    }
                    if (ProfileManager.Instance.ActiveProfile.GeneralLODIncluded && buildingInfo.m_lodMaterial != null)
                    {
                        Texture texture = buildingInfo.m_lodMaterial.GetTexture("_MainTex");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.BuildingsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.BuildingsMipMapBias];
                        }
                        texture = buildingInfo.m_lodMaterial.GetTexture("_XYSMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.BuildingsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.BuildingsMipMapBias];
                        }
                        texture = buildingInfo.m_lodMaterial.GetTexture("_ACIMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.BuildingsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.BuildingsMipMapBias];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] TextureHelper:UpdateBuildings -> Exception: " + e.Message);
            }
        }

        public static void UpdateNetworks()
        {
            try
            {
                for (uint i = 0; i < PrefabCollection<NetInfo>.LoadedCount(); i++)
                {
                    NetInfo netInfo = PrefabCollection<NetInfo>.GetLoaded(i);

                    if (netInfo == null)
                    {
                        continue;
                    }

                    NetInfo.Segment[] segments = netInfo.m_segments;

                    foreach (NetInfo.Segment segment in segments)
                    {
                        if (segment.m_material != null)
                        {
                            Texture texture = segment.m_material.GetTexture("_MainTex");
                            if (texture != null)
                            {
                                texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.NetworksAnisoLevel];
                                texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.NetworksMipMapBias];
                            }
                            texture = segment.m_material.GetTexture("_XYSMap");
                            if (texture != null)
                            {
                                texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.NetworksAnisoLevel];
                                texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.NetworksMipMapBias];
                            }
                            texture = segment.m_material.GetTexture("_ACIMap");
                            if (texture != null)
                            {
                                texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.NetworksAnisoLevel];
                                texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.NetworksMipMapBias];
                            }
                        }
                        if (ProfileManager.Instance.ActiveProfile.NetworksLODIncluded && segment.m_lodMaterial != null)
                        {
                            Texture texture = segment.m_lodMaterial.GetTexture("_MainTex");
                            if (texture != null)
                            {
                                texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.NetworksAnisoLevel];
                                texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.NetworksMipMapBias];
                            }
                            texture = segment.m_lodMaterial.GetTexture("_XYSMap");
                            if (texture != null)
                            {
                                texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.NetworksAnisoLevel];
                                texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.NetworksMipMapBias];
                            }
                            texture = segment.m_lodMaterial.GetTexture("_ACIMap");
                            if (texture != null)
                            {
                                texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.NetworksAnisoLevel];
                                texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.NetworksMipMapBias];
                            }
                        }
                    }

                    NetInfo.Node[] nodes = netInfo.m_nodes;

                    foreach (NetInfo.Node node in nodes)
                    {
                        if (node.m_material != null)
                        {
                            Texture texture = node.m_material.GetTexture("_MainTex");
                            if (texture != null)
                            {
                                texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.NetworksAnisoLevel];
                                texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.NetworksMipMapBias];
                            }
                            texture = node.m_material.GetTexture("_XYSMap");
                            if (texture != null)
                            {
                                texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.NetworksAnisoLevel];
                                texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.NetworksMipMapBias];
                            }
                            texture = node.m_material.GetTexture("_ACIMap");
                            if (texture != null)
                            {
                                texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.NetworksAnisoLevel];
                                texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.NetworksMipMapBias];
                            }
                        }
                        if (ProfileManager.Instance.ActiveProfile.NetworksLODIncluded && node.m_lodMaterial != null)
                        {
                            Texture texture = node.m_lodMaterial.GetTexture("_MainTex");
                            if (texture != null)
                            {
                                texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.NetworksAnisoLevel];
                                texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.NetworksMipMapBias];
                            }
                            texture = node.m_lodMaterial.GetTexture("_XYSMap");
                            if (texture != null)
                            {
                                texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.NetworksAnisoLevel];
                                texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.NetworksMipMapBias];
                            }
                            texture = node.m_lodMaterial.GetTexture("_ACIMap");
                            if (texture != null)
                            {
                                texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.NetworksAnisoLevel];
                                texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.NetworksMipMapBias];
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] TextureHelper:UpdateNetworks -> Exception: " + e.Message);
            }
        }

        public static void UpdateProps()
        {
            try
            {
                for (uint i = 0; i < PrefabCollection<PropInfo>.LoadedCount(); i++)
                {
                    PropInfo propInfo = PrefabCollection<PropInfo>.GetLoaded(i);

                    if (propInfo == null)
                    {
                        continue;
                    }
                    if (propInfo.m_material != null)
                    {
                        Texture texture = propInfo.m_material.GetTexture("_MainTex");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                        texture = propInfo.m_material.GetTexture("_XYSMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                        texture = propInfo.m_material.GetTexture("_ACIMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                    }
                    if (ProfileManager.Instance.ActiveProfile.PropsLODIncluded && propInfo.m_lodMaterial != null)
                    {
                        Texture texture = propInfo.m_lodMaterial.GetTexture("_MainTex");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                        texture = propInfo.m_lodMaterial.GetTexture("_XYSMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                        texture = propInfo.m_lodMaterial.GetTexture("_ACIMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] TextureHelper:UpdateProps -> Exception: " + e.Message);
            }
        }

        public static void UpdateCitizens()
        {
            try
            {
                for (uint i = 0; i < PrefabCollection<CitizenInfo>.LoadedCount(); i++)
                {
                    CitizenInfo citizenInfo = PrefabCollection<CitizenInfo>.GetLoaded(i);

                    if (citizenInfo == null)
                    {
                        continue;
                    }
                    if (ProfileManager.Instance.ActiveProfile.CitizensLODIncluded && citizenInfo.m_lodMaterial != null)
                    {
                        Texture texture = citizenInfo.m_lodMaterial.GetTexture("_MainTex");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                        texture = citizenInfo.m_lodMaterial.GetTexture("_XYSMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                        texture = citizenInfo.m_lodMaterial.GetTexture("_ACIMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] TextureHelper:UpdateCitizens -> Exception: " + e.Message);
            }
        }

        public static void UpdateVehicles()
        {
            try
            {
                for (uint i = 0; i < PrefabCollection<VehicleInfo>.LoadedCount(); i++)
                {
                    VehicleInfo vehicleInfo = PrefabCollection<VehicleInfo>.GetLoaded(i);

                    if (vehicleInfo == null)
                    {
                        continue;
                    }
                    if (vehicleInfo.m_material != null)
                    {
                        Texture texture = vehicleInfo.m_material.GetTexture("_MainTex");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                        texture = vehicleInfo.m_material.GetTexture("_XYSMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                        texture = vehicleInfo.m_material.GetTexture("_ACIMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                    }
                    if (ProfileManager.Instance.ActiveProfile.VehiclesLODIncluded && vehicleInfo.m_lodMaterial != null)
                    {
                        Texture texture = vehicleInfo.m_lodMaterial.GetTexture("_MainTex");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                        texture = vehicleInfo.m_lodMaterial.GetTexture("_XYSMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                        texture = vehicleInfo.m_lodMaterial.GetTexture("_ACIMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] TextureHelper:UpdateVehicles -> Exception: " + e.Message);
            }
        }

        public static void UpdateTrees()
        {
            try
            {
                for (uint i = 0; i < PrefabCollection<TreeInfo>.LoadedCount(); i++)
                {
                    TreeInfo treeInfo = PrefabCollection<TreeInfo>.GetLoaded(i);

                    if (treeInfo == null)
                    {
                        continue;
                    }
                    if (treeInfo.m_material != null)
                    {
                        Texture texture = treeInfo.m_material.GetTexture("_MainTex");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                        texture = treeInfo.m_material.GetTexture("_XYSMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                        texture = treeInfo.m_material.GetTexture("_ACIMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                    }
                    if (ProfileManager.Instance.ActiveProfile.TreesLODIncluded && treeInfo.m_lodMaterial != null)
                    {
                        Texture texture = treeInfo.m_lodMaterial.GetTexture("_MainTex");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                        texture = treeInfo.m_lodMaterial.GetTexture("_XYSMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                        texture = treeInfo.m_lodMaterial.GetTexture("_ACIMap");
                        if (texture != null)
                        {
                            texture.anisoLevel = ModInvariables.AnisoLevelsValues[ProfileManager.Instance.ActiveProfile.PropsAnisoLevel];
                            texture.mipMapBias = ModInvariables.MipMapBiasValues[ProfileManager.Instance.ActiveProfile.PropsMipMapBias];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] TextureHelper:UpdateTrees -> Exception: " + e.Message);
            }
        }
    }
}
