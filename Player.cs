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
        public dynamic[] Invt = new dynamic[6];
        public bool InvtVisible = true;
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
            for (int i = 0; i < Invt.Length; i++)
            {
                Invt[i] = "[\t]";
            }
        }
        public void ShowInvt(ref dynamic [] Invt)
        {
            
            for (int y = 0; y < 4; y++)
            {
                if (y == 2)
                {
                    for (int i = 0; i < Invt.Length; i++)
                    {
                        Console.Write($" {Convert.ToString(Invt[i])} ");
                    }
                }
                for (int x = 0;  x < 12* Invt.Length; x++)
                {
                    if (y == 0 || y == 3)
                    {
                    Console.Write("_");
                    }
                    

                }
                Console.WriteLine();
            }
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