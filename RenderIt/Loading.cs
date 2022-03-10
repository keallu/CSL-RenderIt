﻿using ColossalFramework.UI;
using ICities;
using System;
using UnityEngine;
using RenderIt.Panels;

namespace RenderIt
{

    public class Loading : LoadingExtensionBase
    {
        private GameObject _modManagerGameObject;
        private GameObject _mainPanelGameObject;
        private GameObject _importExportPanelGameObject;

        public override void OnLevelLoaded(LoadMode mode)
        {
            try
            {
                _modManagerGameObject = new GameObject("RenderItModManager");
                _modManagerGameObject.AddComponent<ModManager>();

                UIView uiView = UnityEngine.Object.FindObjectOfType<UIView>();
                if (uiView != null)
                {
                    _mainPanelGameObject = new GameObject("RenderItMainPanel");
                    _mainPanelGameObject.transform.parent = uiView.transform;
                    _mainPanelGameObject.AddComponent<MainPanel>();

                    _importExportPanelGameObject = new GameObject("RenderItImportExportPanel");
                    _importExportPanelGameObject.transform.parent = uiView.transform;
                    _importExportPanelGameObject.AddComponent<ImportExportPanel>();
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] Loading:OnLevelLoaded -> Exception: " + e.Message);
            }
        }

        public override void OnLevelUnloading()
        {
            try
            {
                if (_mainPanelGameObject != null)
                {
                    UnityEngine.Object.Destroy(_mainPanelGameObject);
                }

                if (_modManagerGameObject != null)
                {
                    UnityEngine.Object.Destroy(_modManagerGameObject);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] Loading:OnLevelUnloading -> Exception: " + e.Message);
            }
        }
    }
}