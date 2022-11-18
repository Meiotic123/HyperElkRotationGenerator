namespace HyperElk.Core
{
    public class Talent
    {
        private string _name { get; }
        private int _id { get; }

        public Talent(string name, int id)
        {
            _name = name;
            _id = id;

            CombatRoutine.AddTalents(_id);
        }

        public bool Active()
        {
            return API.PlayerIsTalentSelected(_id);
        }
    }
}

