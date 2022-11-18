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
