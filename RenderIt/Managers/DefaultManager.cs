using System.Collections.Generic;

namespace RenderIt.Managers
{
    public class DefaultManager
    {
        private Dictionary<string, object> _defaults { get; set; } = new Dictionary<string, object>();

        private static DefaultManager instance;

        public static DefaultManager Instance
        {
            get
            {
                return instance ?? (instance = new DefaultManager());
            }
        }

        public void Initialize()
        {
            _defaults.Clear();

            _defaults.Add("SunIntensity", DayNightProperties.instance.m_SunIntensity);
            _defaults.Add("MoonIntensity", DayNightProperties.instance.m_MoonIntensity);
        }

        public object Get(string name)
        {
            _defaults.TryGetValue(name, out object value);

            if (value != null)
            {
                return value;
            }
            else
            {
                return null;
            }
        }
    }
}
