using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype_Pattern
{
    public class Zealot : Unit
    {
        public override Unit Clone()
        {
            Unit unit = new Zealot();
            unit.Init(Name, Lev, Hp, Attk, Def);
            return unit;
        }
    }
}
