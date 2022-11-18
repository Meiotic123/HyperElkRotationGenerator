namespace HyperElk.Core
{
    public class Macro
    {
        private string _name { get; }
        private string _keybind { get; }
        private string _mod { get; }
        private string _mod2 { get; }
        private string _text { get; }

        public Macro(string name, string keybind, string mod, string mod2, string text)
        {
            _name = name;
            _keybind = keybind;
            _mod = mod;
            _mod2 = mod2;
            _text = text;

            CombatRoutine.AddMacro(_name, _keybind, _mod, _mod2, _text);
        }

        public bool CastMacro()
        {
            API.CastSpell(_name);
            return true;
        }
    }
}
