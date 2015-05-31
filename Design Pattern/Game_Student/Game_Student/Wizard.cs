using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Student
{
    public class Wizard : Character
    {
        public override int GetAttackDamageValue()
        {
            return 4+(Lev/10);
        }
    }
}
