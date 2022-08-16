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
        public dynamic[] Inv = { "Пусто", "Пусто", "Пусто", "Пусто", "Пусто", "Пусто"};
        public void ShowInv(ref dynamic [] Inv) 
        {
            
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (x==10)
                    {
                        Console.WriteLine();
                    }
                    switch (y,x)
                    {
                        case (0 or 3,>=0 and <= 10): Console.Write("__"); break;
                        case (1, 0): Console.Write($"{Inv[0]} {Inv[1]} {Inv[2]} {Inv[3]} {Inv[4]} {Inv[5]}"); break;
                        
                        default:
                            break;
                    }
                }

            }
            for(int i = 0; i < Inv.Length; i++)
            {

            }
        }
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
            private set { hp = value; }
        }

        private static int Strenght;
        public int Dmg;
    }

}