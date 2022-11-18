namespace HyperElk.Core
{
    public class Buff
    {
        private string _name { get; }
        private int _id { get; }

        public Buff(string name, int id)
        {
            _name = name;
            _id = id;

            CombatRoutine.AddBuff(_name, _id);
        }

        public bool Active(string target)
        {
            if (target == "player")
            {
                return API.PlayerHasBuff(_name);
            }

            if (target == "target")
            {
                return API.TargetHasBuff(_name);
            }

            if (target == "focus")
            {
                return API.FocusHasBuff(_name);
            }

            if (target == "mouseover")
            {
                return API.MouseoverHasBuff(_name);
            }

            return false;
        }

        public int TimeRemaining(string target)
        {
            if (target == "player")
            {
                return API.PlayerBuffTimeRemaining(_name);
            }

            if (target == "target")
            {
                return API.TargetBuffTimeRemaining(_name);
            }

            if (target == "focus")
            {
                return API.FocusBuffTimeRemaining(_name);
            }

            if (target == "mouseover")
            {
                return API.MouseoverBuffTimeRemaining(_name);
            }

            return 0;
        }

        public int Stacks(string target)
        {
            if (target == "player")
            {
                return API.PlayerBuffStacks(_name);
            }

            if (target == "target")
            {
                return API.TargetBuffStacks(_name);
            }

            if (target == "focus")
            {
                return API.FocusBuffStacks(_name);
            }

            if (target == "mouseover")
            {
                return API.MouseoverBuffStacks(_name);
            }

            return 0;
        }

        public static bool CheckBuffs(string target, int[] list)
        {
            foreach (int buff in list)
            {
                if (target == "player")
                {
                    if (API.PlayerHasBuff(buff.ToString()))
                    {
                        return true;
                    }
                }

                if (target == "target")
                {
                    if (API.TargetHasBuff(buff.ToString()))
                    {
                        return true;
                    }
                }

                if (target == "focus")
                {
                    if (API.FocusHasBuff(buff.ToString()))
                    {
                        return true;
                    }
                }

                if (target == "mouseover")
                {
                    if (API.MouseoverHasBuff(buff.ToString()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
