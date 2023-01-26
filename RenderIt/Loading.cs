using ColossalFramework.UI;
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
        private GameObject _colorsPanelGameObject;
        private GameObject _antiAliasingPanelGameObject;
        private GameObject _ambientOcclusionPanelGameObject;
        private GameObject _bloomPanelGameObject;
        private GameObject _colorGradingPanelGameObject;

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

                    _colorsPanelGameObject = new GameObject("RenderItColorsPanel");
                    _colorsPanelGameObject.transform.parent = uiView.transform;
                    _colorsPanelGameObject.AddComponent<ColorsPanel>();

                    _antiAliasingPanelGameObject = new GameObject("RenderItAntiAliasingPanel");
                    _antiAliasingPanelGameObject.transform.parent = uiView.transform;
                    _antiAliasingPanelGameObject.AddComponent<AntiAliasingPanel>();

                    _ambientOcclusionPanelGameObject = new GameObject("RenderItAmbientOcclusionPanel");
                    _ambientOcclusionPanelGameObject.transform.parent = uiView.transform;
                    _ambientOcclusionPanelGameObject.AddComponent<AmbientOcclusionPanel>();

                    _bloomPanelGameObject = new GameObject("RenderItBloomPanel");
                    _bloomPanelGameObject.transform.parent = uiView.transform;
                    _bloomPanelGameObject.AddComponent<BloomPanel>();

                    _colorGradingPanelGameObject = new GameObject("RenderItColorGradingPanel");
                    _colorGradingPanelGameObject.transform.parent = uiView.transform;
                    _colorGradingPanelGameObject.AddComponent<ColorGradingPanel>();
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
                if (_colorsPanelGameObject != null)
                {
                    UnityEngine.Object.Destroy(_colorsPanelGameObject);
                }

                if (_bloomPanelGameObject != null)
                {
                    UnityEngine.Object.Destroy(_bloomPanelGameObject);
                }

                if (_ambientOcclusionPanelGameObject != null)
                {
                    UnityEngine.Object.Destroy(_ambientOcclusionPanelGameObject);
                }

                if (_antiAliasingPanelGameObject != null)
                {
                    UnityEngine.Object.Destroy(_antiAliasingPanelGameObject);
                }

                if (_colorsPanelGameObject != null)
                {
                    UnityEngine.Object.Destroy(_colorsPanelGameObject);
                }

                if (_importExportPanelGameObject != null)
                {
                    UnityEngine.Object.Destroy(_importExportPanelGameObject);
                }

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