using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Student
{
    public abstract class Character
    {
        public int INT;
        public int STR;
        public int DEX;
        public int AGI;
        public int HP;
        public int MP;
        private int _Lev;
        protected List<StatusLevelHelper> LevelHelpers = new List<StatusLevelHelper>();
        public int Lev
        {
            get { return _Lev; }
            set
            {
                _Lev = value;
                if (_Lev < 10)
                    MyStatusHelper = new Lev1_10StatusHelper();
                else
                    if (_Lev <= 30)
                        MyStatusHelper = new Lev11_30StatusHelper();
                    else
                        MyStatusHelper = new Lev31_50StatusHelper();
            }
        }
        virtual public int GetAttackRange()
        {
            return 0;
        }

        virtual public int GetAttackDamageValue()
        {
            return 0;
        }
        protected StatusLevelHelper MyStatusHelper = new StatusLevelHelper();

        public int GetSpeed()
        {
            return MyStatusHelper.CalcSpeed(this);
            
        }

        public double HPPerSec()
        {
            return MyStatusHelper.GetHPPerSec(this);
            
        }
    }
}
