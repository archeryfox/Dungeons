using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons
{

internal class Player : Weapon
{
        public Player(Weapon weapon)
        {
            Money = 0;
            Hp = 100;
            Strenght = 5;
            Dmg = Strenght + weapon.Dmg;

        }
        public bool StrengthUp;
        public bool TalkToTrainer;
        public Player()
        {
            Money = 0;
            Hp = 100;
            Strenght = 5;
            Dmg = Strenght;
        }
        public int Money;
        private int hp;

        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        private static int Strenght;
        public int Dmg;
    }

}