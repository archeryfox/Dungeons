using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons
{
    internal class Player
    {
        
        public dynamic[] Inv = new dynamic[6];
        public bool InvOpen = false;
        public int InvCount = 1;
        public void ShowInv(ref dynamic [] Inv) 
        {
            Console.WriteLine("\n Инвентарь:");
            dynamic itemStr = false;
            string [] RegItems = new string[6];
            for (int i = 1; i < Inv.Length; i++)
            {
                if(Inv[i].Lvl == -1)
                {
                    RegItems[i] = "";
                }
                else
                {
                    RegItems[i] = $"Lvl: {Inv[i].Lvl} ";
                }
            }
            string InvStr = 
                $" || Деньги: {Inv[0]} |" +
                $" {Inv[1].Type} {RegItems[1]}|" +
                $" {Inv[2].Type} {RegItems[2]}|" +
                $" {Inv[3].Type} {RegItems[3]}|" +
                $" {Inv[4].Type} {RegItems[4]}|" +
                $" {Inv[5].Type} {RegItems[5]}||";
            for (int y = 0; y <= 2; y++)
            {
                if(y == 0 || y ==  2)
                {
                    for (int i = 0; i < InvStr.Length; i++)
                    {
                        if(i == 0)
                        {
                            Console.Write(" ");
                        }
                        else Console.Write("=");
                    }
                }
                if (y==1)
                {
                    Console.Write(InvStr);
                }
                Console.WriteLine();
            }
        }
        public Player(Weapon weapon)
        {
            Money = 0;
            Hp = 100;
            Strenght = 5;
            Dmg = Strenght + weapon.Dmg;
            Inv = new dynamic[6];
        }

        public Player()
        {
            Money = 0;
            Hp = 100;
            Strenght = 5;
            Dmg = Strenght;
        }
        public int Def { get; set; }
        public int Dmg { get; set; }
        public int Lvl { get; set; }
        public bool StrengthUp;
        public bool TalkToTrainer;
        public int Money;
        private int hp;
        
        public int Hp
        {
            get { return hp; }
            private set { hp = value; }
        }
        private static int Strenght;
    }

}