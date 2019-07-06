using UnityEngine;

namespace RenderIt
{
    public class ModProperties
    {
        public AssetBundle AssetBundle;

        private static ModProperties instance;

        public static ModProperties Instance
        {
            get
            {
                return instance ?? (instance = new ModProperties());
            }
        }
    }
}