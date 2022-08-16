using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dungeons
{
    internal class R 
    {
       public void Run()
        {
            bool NpcReward;
            bool WizardReward = false;
            bool NpcKilled;
            bool WizardKill;
            bool WizardMoney;
            bool SecondQuest;
            bool TalkTalk = false;
            bool RewardNPC = false;
            int WizardHelp = 0;
            bool WizardReject;
            bool IsTalk = false;
            WizardReject = SecondQuest = WizardMoney = WizardKill = NpcKilled = NpcReward = false;
            int Heal = 40;
            bool Book = false;
            bool ChestOpen = false;
            int Potion = 0;
            int ArmorDef = 0;
            int LightDef = 5;
            int HeavyDef = 12;
            int Money = 0;
            bool BookReject = false;
            int WeaponDmg = 0;
            int WeaponDef = 0;
            int SwordDef = 0;
            int SwordDmg = 15;
            int BowDmg = 12;
            int BowDef = 5;
            int ShieldDmg = 5;
            int ShieldDef = 12;
            string[,] zone = new string[9, 16];
            Zone _proto_zone = new Zone();
            _proto_zone.ZoneId = 1;              // Номер зоны
            bool EnemyDead = false;
            bool TalkToNPC = false;
            var rnd = new Random();
            Player Player = new Player();
            int EnemyHp = 50;
            int PlayerHp = 100;
            int EnemyDmg = 15;
            int PlayerDmg = 5 + WeaponDmg;
            var IsFight = true;
            var Bow = new Bow();
            
            //Спавн игрока
            int y = 2, x = 5;
            bool isSolid;
            //Буфер
            int yb = y, xb = x;

            while (true)
            {
            
                //Console.WriteLine(Invt[1].Type); Тест инвентаря
                void Room1(string[,] zone, int y, int x)
                {
                    _proto_zone.RenderZone1(ref zone, ref y, ref x);
                }
                void Room2(string[,] zone, int y, int x)
                {
                    _proto_zone.RenderZone2(ref zone, ref y, ref x);
                }
                void Solid(ref int y, ref int x, ref int yb, ref int xb)
                {
                    y = yb;
                    x = xb;
                }

                if (zone[y, x] == " Ш")
                {
                    NPC.Chest(ref ChestOpen, ref Book);
                }
                if (zone[y, x] == " U")
                {
                    Obj.Door(ref Player, ref PlayerHp, ref x, rnd);
                }
                if (zone[y, x] == " !")
                {
                    Console.WriteLine("Управление - WASD. Выход - Esc. ");
                }
                if (zone[y, x] == " W")
                {
                    NPC.Wizard(ref Book, ref SecondQuest, ref WizardMoney, ref WizardReward, ref Money, ref WizardHelp, ref WizardKill, ref NpcKilled);
                }
                if (zone[y, x] == " M")
                {
                    IsTalk = true;
                    NPC.Merchant(ref Book, ref IsTalk, ref BookReject, ref Money, ref ArmorDef, ref LightDef, ref HeavyDef,
                        ref WeaponDef, ref WeaponDmg, ref ShieldDef, ref ShieldDmg, ref BowDef, ref BowDmg, ref SwordDef, ref SwordDmg, ref Potion);
                }
                if (zone[y, x] == " ?")
                {
            
                    NPC.QuestNPC(ref EnemyDead, ref TalkToNPC, ref TalkTalk, ref RewardNPC, ref Money, ref SecondQuest, ref  WizardMoney,
                        ref  WizardKill, ref  NpcKilled, ref NpcReward, ref PlayerHp, ref Player.StrengthUp);
                }
                if (zone[y, x] == " X")
                {
                    NPC.Monster(ref TalkToNPC, ref EnemyDead, ref IsFight, ref PlayerHp, ref EnemyHp, ref y, ref Potion, ref Heal, 
                        ref EnemyDmg, ref WeaponDef, ref ArmorDef, ref WeaponDmg);
                }
                if (zone[y, x] == " D")
                {
                    NPC.Doctor(ref PlayerHp, ref Money);
                }
                if (zone[y, x] == " O")
                {
                    Obj.Trap(ref PlayerHp);
                }
                if (zone[y, x] == " G")
                {
                    Solid(ref y, ref x, ref yb, ref xb);
                    NPC.Warlock();
                }
                if (zone[y, x] == " T")
                {
                    Solid(ref y, ref x, ref yb, ref xb);
                    NPC.Trainer(ref Player.StrengthUp, ref Player.TalkToTrainer);
                }
                if (zone[y, x] == " %")
                {
                    NPC.Dumbbell(ref Player.StrengthUp, ref Player.TalkToTrainer);
                }

                //Твёрдые объекты
                {
                    isSolid = zone[y, x] == " #" || zone[y, x] == " |" || zone[y, x] == "| "
                           || zone[y, x] == "__" || zone[y, x] == "|_" || zone[y, x] == "_|" 
                           || zone[y, x] == " Ш" || zone[y, x] == " W" || zone[y, x] == " %"
                           || zone[y, x] == " U" || zone[y, x] == " G" || zone[y, x] == " T"
                           || zone[y, x] == " O" || zone[y, x] == " D" || zone[y, x] == " X";
                    if (isSolid)
                    {
                        Solid(ref y, ref x, ref yb, ref xb);
                    }
                }

                switch (zone[y, x], _proto_zone.ZoneId)
                {
                    case (" )", 1):
                        Solid(ref y, ref x, ref yb, ref xb);
                        x = 1;
                        _proto_zone.ZoneId = 2;
                        break;
                    case (" )", 2):
                        Solid(ref y, ref x, ref yb, ref xb);
                        x = 13;
                        _proto_zone.ZoneId = 1;
                        break;
                    default:
                        break;
                }

                //Перезапись буфера

                yb = y;
                xb = x;

                //Создание поля / get

                _proto_zone.RenderPlayer(zone, y, x);

                //Заполнение поля / set

                            Console.Write($"Здоровье: {PlayerHp} Урон:{WeaponDmg + 5}\nМонет: {Money} Зелий: {Potion}\n");
                switch (_proto_zone.ZoneId)
                {
                    case 1: Room1(zone, y, x); break;
                    case 2: Room2(zone, y, x); break;
                }
                Player.ShowInv(ref Player.Inv);
                //Управление
                ConsoleKey consoleKey = Console.ReadKey(true).Key;
                switch (consoleKey)
                {
                    case ConsoleKey.S:
                        y++;
                        break;
                    case ConsoleKey.W:
                        y--;
                        break;
                    case ConsoleKey.D:
                        x++;
                        break;
                    case ConsoleKey.A:
                        x--;
                        break;
                    default:

                        break;
                }
                Console.Clear();

            }
        }
    }
}