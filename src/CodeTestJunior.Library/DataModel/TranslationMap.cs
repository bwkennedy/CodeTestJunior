using System.Collections.Generic;

namespace CodonTestJunior.DataModel
{
    public class TranslationMap
    {
        private List<string> _starts = new List<string>();
        private List<string> _stops = new List<string>();
        private Dictionary<string, string> _codonMap = new Dictionary<string,string>();

        public List<string> Starts { get { return _starts; } set { _starts = value; } }
        public List<string> Stops { get { return _stops; } set { _stops = value; } }
        public Dictionary<string,string> CodonMap { get { return _codonMap; } set { _codonMap = value; } }
    }
}