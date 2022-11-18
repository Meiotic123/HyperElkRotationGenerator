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
                //_class = new UniversalRoutine(true);
                //_spec = new UniversalRoutine();
            }

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
