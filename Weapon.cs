using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons
{
    internal class Weapon
    {
        public string Type { get; set; }
        public int Def { get; set; }
        public int Dmg { get; set; }
        public int Lvl { get; set; }
    }
    class Sword : Weapon
    {
        public Sword()
        {
            Type = "Меч";
            Lvl = 1;
        }
        private string type;
        public string Type
        {
            get { return type; }
            private set { type = "Меч"; }
        }
        private int dmg;
        public int Dmg
        {
            get { return dmg; }
            private set { dmg = 11 + lvl; }
        }
        private int def;
        public int Def
        {
            get { return def; }
            private set { def = 2 + lvl; }
        }
        private int lvl;
        public int Lvl
        {
            get { return lvl; }
            set { lvl = 1; }
        }
        public int LvlUp()
        {
            return lvl + 1;
        }
    }
    class Bow : Weapon
    {
        public Bow()
        {
            Type = "Лук";
            Lvl = 1;
        }
        private string type;
        public string Type
        {
            get { return type; }
            private set { type = "Лук"; }
        }
        private int dmg;
        public int Dmg
        {
            get { return dmg; }
            private set { dmg = 11+lvl; }
        }
        private int def;
        public int Def
        {
            get { return def; }
            private set { def = 2+lvl; }
        }
        private int lvl;
        public int Lvl
        {
            get { return lvl; }
            set { lvl = 1; }
        }
        public int LvlUp()
        {
            return lvl+1;
        }
    }
    class Shield : Weapon
    {
        public Shield()
        {
            Type = "Меч";
            Lvl = 1;
        }
        private string type;
        public string Type
        {
            get { return type; }
            private set { type = "Щит"; }
        }
        private int dmg;
        public int Dmg
        {
            get { return dmg; }
            private set { dmg = 11 + lvl; }
        }
        private int def;
        public int Def
        {
            get { return def; }
            private set { def = 2 + lvl; }
        }
        private int lvl;
        public int Lvl
        {
            get { return lvl; }
            set { lvl = 1; }
        }
        public int LvlUp()
        {
            return lvl + 1;
        }
    }
}