using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons
{
    internal class Weapon
    {
        static public string Type { get; set; }
        int Def { get; set; }
        public int Dmg { get; set; }
    }

        class Sword : Weapon
        {
            public int Def;

            public int Dmg;
            Sword()
            {
                Dmg = 15;
                Def = 2;
            }

        }
        class Shield : Weapon
        {
            private int def = 12;

            public int Def
            {
                get { return def; }
                private set { }
            }

            public int Dmg { get; private set; }
        }
        class Bow : Weapon
        {
            public readonly string Type = "Bow";

            private int def = 12;

            public int Def
            {
                get { return def; }
                private set { }
            }

            public int Dmg { get; private set; }


        }
    
}
