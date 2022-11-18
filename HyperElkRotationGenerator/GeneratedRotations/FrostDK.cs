using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HyperElk.Core
{
    public class UniversalRoutine : CombatRoutine
    {
        private static CombatRoutine _instance = null;
        private static CombatRoutine _class = null;
        protected static CombatRoutine _spec = null;

        public UniversalRoutine()
        {
            // Dummy constructor that gets called when CombatRoutine is initialized.
        }

        public UniversalRoutine(bool real)
        {
           
        }

        public override void Initialize()
        {
            isAutoBindReady = true;

            if (_instance == null)
            {
                _instance = new UniversalRoutine(true);
                _class = new Deathknight(true)
;                _spec = new FrostDK()
;            }

            _class.Initialize();
        }

        public override void Pulse()
        {
            _class.Pulse();

        }

        public override void CombatPulse()
        {
             _class.CombatPulse();
        }

        public override void OutOfCombatPulse()
        {
            _class.OutOfCombatPulse();
        }
    }
}
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
namespace HyperElk.Core
{
    public class Deathknight : UniversalRoutine
    {
        #region Deathknight Spells
        protected static Spell AbominationLimb;
        protected static Spell AntiMagicShell;
        protected static Spell Asphyxiate;
        protected static Spell ChainsOfIce;
        protected static Spell DeathAndDecay;
        protected static Spell DeathCoil;
        protected static Spell DeathGrip;
        protected static Spell DeathPact;
        protected static Spell DeathStrike;
        protected static Spell EmpowerRuneWeapon;
        protected static Spell MindFreeze;
        protected static Spell SoulReaper;
        protected static Spell Strangulate;
        protected static Spell Lichborne;
        #endregion

        #region Deathknight Buffs
        protected static Buff LichborneBuff;
        protected static Buff DeathAndDecayBuff;
        #endregion

        #region Deathknight Debuffs
        protected static Debuff AsphyxiateDebuff;
        protected static Debuff ChainsOfIceDebuff;
        protected static Debuff StrangulateDebuff;
        #endregion

        #region Deathknight Macros
        protected static Macro AsphyxiateFocus;
        protected static Macro MindFreezeFocus;
        protected static Macro StrangulateFocus;
        protected static Macro DeathGripFocus;
        #endregion

        public Deathknight()
        {
            // Dummy constructor that gets called when CombatRoutine is initialized.
        }

        public Deathknight(bool real)
        {
            #region Deathknight Spells Initialized
            AbominationLimb = new Spell("Abomination Limb", 315443);
            AntiMagicShell = new Spell("Anti-Magic Shell", 48707);
            Asphyxiate = new Spell("Asphyxiate", 221562);
            ChainsOfIce = new Spell("Chains of Ice", 45524);
            DeathAndDecay = new Spell("Death and Decay", 43265);
            DeathCoil = new Spell("Death Coil", 47541);
            DeathGrip = new Spell("Death Grip", 49576);
            DeathPact = new Spell("Death Pact", 48743);
            DeathStrike = new Spell("Death Strike", 49998);
            EmpowerRuneWeapon = new Spell("Empower Rune Weapon", 47568);
            MindFreeze = new Spell("Mind Freeze", 47528);
            SoulReaper = new Spell("Soul Reaper", 343294);
            Strangulate = new Spell("Strangulate", 47476);
            Lichborne = new Spell("Lichborne", 49039);
            #endregion

            #region Deathknight Buffs Initialized
            LichborneBuff = new Buff("Lichborne", 49039);
            DeathAndDecayBuff = new Buff("Death and Decay", 188290);
            #endregion

            #region Deathknight Debuffs Initialized
            ChainsOfIceDebuff = new Debuff("Chains of Ice", 45524);
            AsphyxiateDebuff = new Debuff("Asphyxiate", 221562);
            StrangulateDebuff = new Debuff("Strangulate", 47476);
            #endregion

            #region Deathknight Macros Initialized
            AsphyxiateFocus = new Macro("AsphyxiateFocus", "None", "None", "None", "/cast [@focus, nodead, exists][] Asphyxiate");
            StrangulateFocus = new Macro("StrnagulateFocus", "None", "None", "None", "/cast [@focus, nodead, exists][] Strangulate");
            MindFreezeFocus = new Macro("MindFreezeFocus", "None", "None", "None", "/cast [@focus, nodead, exists][] Mind Freeze");
            DeathGripFocus = new Macro("DeathGripFocus", "None", "None", "None", "/cast [@focus, nodead, exists][] Death Grip");
            #endregion
        }

        public override void Initialize()
        {
            _spec.Initialize();
        }

        public override void Pulse()
        {
            _spec.Pulse();
        }

        public override void CombatPulse()
        {
            _spec.CombatPulse();
        }

        public override void OutOfCombatPulse()
        {
            _spec.OutOfCombatPulse();
        }
    }
}
namespace HyperElk.Core
{
    public class FrostDK : Deathknight
    {
        private static bool VarRimeBuffs = false;
        private static bool VarRPBuffs = false;
        private static bool VarFrostScythePriority = false;

        #region Frost Spells
        private static Spell ChillStreak;
        private static Spell FrostStrike;
        private static Spell FrostwyrmsFury;
        private static Spell GlacialAdvance;
        private static Spell HowlingBlast;
        private static Spell Obliterate;
        private static Spell PillarOfFrost;
        private static Spell RemorselessWinter;
        #endregion

        #region Frost Buffs
        private static Buff KillingMachineBuff;
        private static Buff RimeBuff;
        private static Buff EmpowerRuneWeaponBuff;
        private static Buff PillarOfFrostBuff;
        private static Buff UnleashedFrenzyBuff;
        private static Buff IcyTalonsBuff;
        private static Buff BreathOfSindragosaBuff;
        #endregion

        #region Frost Debuffs
        private static Debuff FrostFeverDebuff;
        #endregion

        #region Frost Talents
        private static Talent ObliterationTalent;
        private static Talent IcyTalonsTalent;
        private static Talent UnleashedFrenzyTalent;
        private static Talent RageOfTheFrozenChampionTalent;
        private static Talent AvalancheTalent;
        private static Talent IcebreakerTalent;
        private static Talent BreathOfSindragosaTalent;
        private static Talent FrostscytheTalent;
        private static Talent ImprovedObliterateTalent;
        private static Talent FrigidExecutionTalent;
        private static Talent MightOfTheFrozenWastesTalent;
        private static Talent CleavingStrikesTalent;
        private static Talent GlacialAdvanceTalent;
        #endregion

        public FrostDK()
        {
            #region Frost Spells Initialized
            ChillStreak = new Spell("Chill Streak", 305392);
            FrostStrike = new Spell("Frost Strike", 49143);
            FrostwyrmsFury = new Spell("Frostwyrm's Fury", 279302);
            GlacialAdvance = new Spell("Glacial Advance", 194913);
            HowlingBlast = new Spell("Howling Blast", 49184);
            Obliterate = new Spell("Obliterate", 49020);
            PillarOfFrost = new Spell("Pillar of Frost", 51271);
            RemorselessWinter = new Spell("Remorseless Winter", 196770);
            #endregion

            #region Frost Buffs Initialized
            KillingMachineBuff = new Buff("Killing Machine", 51124);
            RimeBuff = new Buff("Rime", 59052);
            EmpowerRuneWeaponBuff = new Buff("Empower Rune Weapon", 47568);
            PillarOfFrostBuff = new Buff("Pillar of Frost", 51271);
            UnleashedFrenzyBuff = new Buff("Unleashed Frenzy", 376907);
            IcyTalonsBuff = new Buff("Icy Talons", 194879);
            BreathOfSindragosaBuff = new Buff("Breath of Sindragosa", 152279); // TODO: CHECK BUFF ID
            #endregion

            #region Frost Debuffs Initialized
            FrostFeverDebuff = new Debuff("Frost Fever", 55095);
            #endregion

            #region Frost Talents Initialized
            ObliterationTalent = new Talent("Obliteration", 96220);
            IcyTalonsTalent = new Talent("Icy Talons", 96179);
            UnleashedFrenzyTalent = new Talent("Unleashed Frenzy", 96248);
            RageOfTheFrozenChampionTalent = new Talent("Rage of the Frozen Champion", 96250);
            AvalancheTalent = new Talent("Avalanche", 96235);
            IcebreakerTalent = new Talent("Icebreaker", 96161);
            BreathOfSindragosaTalent = new Talent("Breath of Sindragosa", 96222);
            FrostscytheTalent = new Talent("Frostscythe", 96225);
            ImprovedObliterateTalent = new Talent("Improved Obliterate", 96249);
            FrigidExecutionTalent = new Talent("Frigid Executioner", 96251);
            MightOfTheFrozenWastesTalent = new Talent("Might of the Frozen Wastes", 96219);
            CleavingStrikesTalent = new Talent("Cleaving Strikes", 96202);
            GlacialAdvanceTalent = new Talent("Glacial Advance", 96221);
            #endregion
        }

        public override void Initialize()
        {
            API.WriteLog("\n" +
                "***************************************************\n" +
                "Frost DK Dragonflight Rotation 1.0.0 \n" +
                "***************************************************"
            );
        }

        public override void Pulse()
        {

        }

        public override void CombatPulse()
        {

        }

        public override void OutOfCombatPulse()
        {

        }
    }
}
