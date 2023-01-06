using ColossalFramework;
using ColossalFramework.UI;
using RenderIt.Managers;
using System;
using UnityEngine;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace RenderIt.Panels
{
    public class ImportExportPanel : UIPanel
    {
        private bool _initialized;

        private MainPanel _mainPanel;

        private UITextureAtlas _ingameAtlas;
        private UILabel _title;
        private UIButton _close;
        private UIDragHandle _dragHandle;
        private UITextField _textField;
        private UIButton _copyButton;
        private UIButton _importButton;

        public override void Awake()
        {
            base.Awake();

            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ImportExportPanel:Awake -> Exception: " + e.Message);
            }
        }

        public override void Start()
        {
            base.Start();

            try
            {
                if (_mainPanel == null)
                {
                    _mainPanel = GameObject.Find("RenderItMainPanel")?.GetComponent<MainPanel>();
                }

                _ingameAtlas = ResourceLoader.GetAtlas("Ingame");

                CreateUI();
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ImportExportPanel:Start -> Exception: " + e.Message);
            }
        }

        public override void Update()
        {
            base.Update();

            try
            {
                if (!_initialized)
                {
                    UpdateUI();

                    _initialized = true;
                }

                if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.V)) || (Input.GetKey(KeyCode.RightControl) && Input.GetKeyDown(KeyCode.V)))
                {
                    _textField.text = Clipboard.text;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ImportExportPanel:Update -> Exception: " + e.Message);
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            try
            {
                DestroyGameObject(_title);
                DestroyGameObject(_close);
                DestroyGameObject(_dragHandle);
                DestroyGameObject(_textField);
                DestroyGameObject(_copyButton);
                DestroyGameObject(_importButton);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ImportExportPanel:OnDestroy -> Exception: " + e.Message);
            }
        }

        private void DestroyGameObject(UIComponent component)
        {
            if (component != null)
            {
                Destroy(component.gameObject);
            }
        }

        private void CreateUI()
        {
            try
            {
                backgroundSprite = "MenuPanel2";
                isVisible = false;
                canFocus = true;
                isInteractive = true;
                width = 750f;
                height = 650f;
                relativePosition = new Vector3(Mathf.Floor((GetUIView().fixedWidth - width) / 2f), Mathf.Floor((GetUIView().fixedHeight - height) / 2f));

                _title = UIUtils.CreateMenuPanelTitle(this, _ingameAtlas, "Render It! - Import/Export");
                _title.relativePosition = new Vector3(width / 2f - _title.width / 2f, 15f);

                _close = UIUtils.CreateMenuPanelCloseButton(this, _ingameAtlas);
                _close.relativePosition = new Vector3(width - 37f, 3f);
                _close.eventClick += (component, eventParam) =>
                {
                    if (!eventParam.used)
                    {
                        _close.parent.Hide();

                        eventParam.Use();
                    }
                };

                _dragHandle = UIUtils.CreateMenuPanelDragHandle(this);
                _dragHandle.width = width - 40f;
                _dragHandle.height = 40f;
                _dragHandle.relativePosition = Vector3.zero;

                _textField = UIUtils.CreateMultilineTextField(this, "TextField", _ingameAtlas, "");

                _textField.maxLength = 5000;
                _textField.width = width - 20f;
                _textField.height = height - 120f;
                _textField.relativePosition = new Vector3(10f, 60f);

                _copyButton = UIUtils.CreatePanelButton(this, "CopyButton", _ingameAtlas, "Copy");
                _copyButton.tooltip = "Click to copy YAML to or from clipboard";
                _copyButton.relativePosition = new Vector3(10f, height - 50f);
                _copyButton.eventClick += (component, eventParam) =>
                {
                    if (!eventParam.used)
                    {
                        if (_textField.text.Length > 0)
                        {
                            Clipboard.text = _textField.text;
                        }
                        else
                        {
                            _textField.text = Clipboard.text;
                        }

                        eventParam.Use();
                    }
                };

                _importButton = UIUtils.CreatePanelButton(this, "ImportButton", _ingameAtlas, "Import");
                _importButton.tooltip = "Click to import profile from YAML-format";
                _importButton.relativePosition = new Vector3(width / 2f - _importButton.width / 2f, height - 50f);
                _importButton.eventClick += (component, eventParam) =>
                {
                    if (!eventParam.used)
                    {
                        Profile profile = GetProfileFromYaml(_textField.text);

                        if (profile != null)
                        {
                            ProfileManager.Instance.AllProfiles.Add(profile);
                            ProfileManager.Instance.ActiveProfile = profile;
                            _mainPanel.ForceProfile(profile);
                        }
                        else
                        {
                            ConfirmPanel.ShowModal("Import was unsuccessful", "One or more errors were found in YAML-format. Do you want to try again?", (comp, ret) =>
                            {
                                if (ret == 0)
                                {
                                    Hide();
                                }
                            });
                        }

                        eventParam.Use();
                    }
                };
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ImportExportPanel:CreateUI -> Exception: " + e.Message);
            }
        }

        private void UpdateUI()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ImportExportPanel:UpdateUI -> Exception: " + e.Message);
            }
        }

        public void SetMode(bool importing)
        {
            try
            {
                if (importing)
                {
                    _title.text = "Render It! - Import";
                    _title.relativePosition = new Vector3(width / 2f - _title.width / 2f, 15f);
                    _textField.text = "";
                    _importButton.isVisible = true;
                }
                else
                {
                    _title.text = "Render It! - Import";
                    _title.relativePosition = new Vector3(width / 2f - _title.width / 2f, 15f);
                    _textField.text = GetYamlFromProfile(ProfileManager.Instance.ActiveProfile);
                    _importButton.isVisible = false;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ImportExportPanel:SetMode -> Exception: " + e.Message);
            }
        }

        private string GetYamlFromProfile(Profile profile)
        {
            string yaml = string.Empty;

            try
            {
                ISerializer serializer = new SerializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                yaml = serializer.Serialize(profile);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ImportExportPanel:GetYamlFromProfile -> Exception: " + e.Message);
            }

            return yaml;
        }

        private Profile GetProfileFromYaml(string yaml)
        {
            Profile profile = null;

            try
            {
                IDeserializer deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                profile = deserializer.Deserialize<Profile>(yaml);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ImportExportPanel:GetProfileFromYaml -> Exception: " + e.Message);
            }

            return profile;
        }
    }
}
