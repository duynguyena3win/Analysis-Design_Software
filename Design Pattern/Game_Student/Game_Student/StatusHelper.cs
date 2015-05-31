using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Student
{
    class StatusLevelHelper
    {
        internal int CalcSpeed(Character cha)
        {
            return (int)(1 + cha.AGI * 0.35);
        }

        internal double GetHPPerSec(Character character)
        {
            return (int)(1 + character.STR * 0.8);
        }
    }
}
