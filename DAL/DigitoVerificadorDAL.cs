using System.Collections.Generic;

namespace DAL
{
    public class DigitoVerificadorDAL
    {
        private static readonly Dictionary<int, string> _dvhStore = new Dictionary<int, string>();
        private static string _dvvStore = string.Empty;

        public Dictionary<int, string> ObtenerDVHs()
        {
            return new Dictionary<int, string>(_dvhStore);
        }

        public string ObtenerDVV()
        {
            return _dvvStore;
        }

        public void GuardarDV(Dictionary<int, string> dvhs, string dvv)
        {
            _dvhStore.Clear();
            foreach (var kvp in dvhs)
            {
                _dvhStore[kvp.Key] = kvp.Value;
            }
            _dvvStore = dvv;
        }

        public void Corromper()
        {
            if (_dvhStore.Count > 0)
            {
                List<int> keys = new List<int>(_dvhStore.Keys);
                _dvhStore[keys[0]] = "CORRUPTO";
            }
        }
    }
}
