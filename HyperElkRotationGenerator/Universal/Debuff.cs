namespace HyperElk.Core
{
    public class Debuff
    {
        private string _name { get; }
        private int _id { get; }

        public Debuff(string name, int id)
        {
            _name = name;
            _id = id;

            CombatRoutine.AddDebuff(_name, _id);
        }

        public int TimeRemaining(string target)
        {
            if (target == "player")
            {
                return API.PlayerDebuffRemainingTime(_name);
            }

            if (target == "target")
            {
                return API.TargetDebuffRemainingTime(_name);
            }

            if (target == "focus")
            {
                return API.FocusDebuffRemainingTime(_name);
            }

            if (target == "mouseover")
            {
                return API.MouseoverDebuffRemainingTime(_name);
            }

            return 0;
        }

        public int Stacks(string target)
        {
            if (target == "player")
            {
                return API.PlayerDebuffStacks(_name);
            }

            if (target == "target")
            {
                return API.TargetDebuffStacks(_name);
            }

            if (target == "focus")
            {
                return API.FocusDebuffStacks(_name);
            }

            if (target == "mouseover")
            {
                return API.MouseoverDebuffStacks(_name);
            }

            return 0;
        }

        public bool Active(string target)
        {
            if (target == "player")
            {
                return API.PlayerHasDebuff(_name);
            }

            if (target == "target")
            {
                return API.TargetHasDebuff(_name);
            }

            if (target == "focus")
            {
                return API.FocusHasDebuff(_name);
            }

            if (target == "mouseover")
            {
                return API.MouseoverHasDebuff(_name);
            }

            return false;
        }

        public static bool CheckDebuffs(string target, List<int> list)
        {
            foreach (int debuff in list)
            {
                if (target == "player")
                {
                    if (API.PlayerHasDebuff(debuff.ToString()))
                    {
                        return true;
                    }
                }

                if (target == "target")
                {
                    if (API.TargetHasDebuff(debuff.ToString()))
                    {
                        return true;
                    }
                }

                if (target == "focus")
                {
                    if (API.FocusHasDebuff(debuff.ToString()))
                    {
                        return true;
                    }
                }

                if (target == "mouseover")
                {
                    if (API.MouseoverHasDebuff(debuff.ToString()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
