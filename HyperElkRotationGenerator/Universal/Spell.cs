namespace HyperElk.Core
{
    public class Spell
    {
        private string _name { get; }
        private int _id { get; }
        private int _range { get; }

        public Spell(string name, int id)
        {
            _name = name;
            _id = id;
            _range = 0;

            CombatRoutine.AddSpell(_name, _id);
        }

        public Spell(string name, int id, int range)
        {
            _name = name;
            _id = id;
            _range = range;

            CombatRoutine.AddSpell(_name, _id);
        }

        public bool CanCast()
        {
            return API.CanCast(_name);
        }

        public bool CanCast(string target)
        {
            if (API.UnitRange(target) <= _range)
            {
                return API.CanCast(_name);
            }

            return false;
        }

        public bool Cast()
        {
            API.CastSpell(_name);
            return true;
        }

        public int Charges()
        {
            return API.SpellCharges(_name);
        }

        public int CooldownRemaining()
        {
            return API.SpellCDDuration(_name);
        }
    }
}
