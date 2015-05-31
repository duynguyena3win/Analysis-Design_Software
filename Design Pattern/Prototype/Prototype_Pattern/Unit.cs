using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype_Pattern
{
    public class Unit
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _hp;

        public int Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }
        private int _def;

        public int Def
        {
            get { return _def; }
            set { _def = value; }
        }
        private int _attk;

        public int Attk
        {
            get { return _attk; }
            set { _attk = value; }
        }
        private int _lev;

        public int Lev
        {
            get { return _lev; }
            set { _lev = value; }
        }

        public string GetName()
        {
            return "Unit";
        }


        internal void Init(string name, int lev, int hp, int attk, int def)
        {
            Name = name; 
            Lev = lev;
            Hp = hp;
            Attk = attk;
            Def = def;
        }
        public abstract Unit Clone();
    }
}
