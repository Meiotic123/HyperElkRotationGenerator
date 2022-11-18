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
