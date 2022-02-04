using UnityEngine;

namespace RenderIt.Managers
{
    public class AssetManager
    {
        public AssetBundle AssetBundle { get; set; }

        private static AssetManager instance;

        public static AssetManager Instance
        {
            get
            {
                return instance ?? (instance = new AssetManager());
            }
        }
    }
}
