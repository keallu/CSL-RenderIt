using UnityEngine;

namespace RenderIt
{
    public class ModProperties
    {
        public AssetBundle AssetBundle { get; set; }
        public Profile ActiveProfile { get; set; }

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