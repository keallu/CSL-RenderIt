using ColossalFramework;
using System;
using UnityEngine;

namespace RenderIt.Managers
{
    public class LutManager
    {
        private string[] _names;

        public string[] Names
        {
            get
            {
                if (_names == null)
                {
                    _names = SingletonResource<ColorCorrectionManager>.instance.items;
                }

                return _names;
            }
        }

        private string[] _localizedNames;

        public string[] LocalizedNames
        {
            get
            {
                if (_localizedNames == null)
                {
                    string[] array = new string[Names.Length];

                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = ColossalFramework.Globalization.Locale.Get("BUILTIN_COLORCORRECTION", Names[i]);
                    }

                    _localizedNames = array;
                }

                return _localizedNames;
            }
        }

        private static LutManager instance;

        public static LutManager Instance
        {
            get
            {
                return instance ?? (instance = new LutManager());
            }
        }

        public int IndexOf(string name)
        {
            try
            {
                int index = Array.FindIndex(Names, x => x.Equals(name));

                return index != -1 ? index : 0;
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] LutManager:IndexOf -> Exception: " + e.Message);
                return 0;
            }
        }

        public void Override(string name)
        {
            try
            {
                SingletonResource<ColorCorrectionManager>.instance.currentSelection = IndexOf(name);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] LutManager:Override -> Exception: " + e.Message);
            }
        }
    }
}
