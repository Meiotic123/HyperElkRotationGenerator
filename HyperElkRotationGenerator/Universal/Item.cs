namespace HyperElk.Core
{
    public class Item
    {
        private string _name { get; }
        private int _id { get; }

        public Item(string name, int id)
        {
            _name = name;
            _id = id;

            CombatRoutine.AddItem(_name, _id);
        }

        public bool CanUse()
        {
            return API.PlayerItemCanUse(_name);
        }
    }
}
