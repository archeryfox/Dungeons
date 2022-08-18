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
            var rnd = new Random();
            Player Player = new Player();
            bool EnemyDead = false;
            bool TalkToNPC = false;
            int EnemyHp = 50;
            int PlayerHp = 100;
            int EnemyDmg = 15;
            int PlayerDmg = 5 + WeaponDmg;
            var IsFight = true;
            Sword Sword = new Sword();
            Bow Bow = new Bow();
            Empty empt = new Empty();
            dynamic [] LocalInv = { Money, empt, empt, empt, empt, empt };
            
            //Спавн игрока
            int y = 2, x = 5;
            bool isSolid;
            //Буфер
            int yb = y, xb = x;

            while (true)
            {
            
            Player.Inv = LocalInv;
                //Console.WriteLine(Invt[1].Type); Тест инвентаря
                void Room1(string[,] zone, int y, int x)
                {
                    _proto_zone.RenderZone1(ref zone, ref y, ref x);
                }
                void Room2(string[,] zone, int y, int x)
                {
                    _proto_zone.RenderZone2(ref zone, ref y, ref x);
                }
                void Solid(ref int y, ref int x, ref int yb, ref int xb) { y = yb; x = xb; }

                switch (zone[y, x])
                {
                    case " Ш": NPC.Chest(ref ChestOpen, ref Book, ref Player); break;
                    case " U":
                        Obj.Door(ref Player, ref PlayerHp, ref x, rnd); break;
                    case " W":
                        NPC.Wizard(ref Book, ref SecondQuest, ref WizardMoney, ref WizardReward, ref Money, ref WizardHelp, ref WizardKill, ref NpcKilled); break;
                    case " !": Console.WriteLine("Управление - WASD. Выход - Esc. Инвентарь - I"); ; break;
                    case " M":
                        IsTalk = true;
                        NPC.Merchant(ref Book, ref IsTalk, ref BookReject, ref Money, ref ArmorDef, ref LightDef, ref HeavyDef,
                            ref WeaponDef, ref WeaponDmg, ref ShieldDef, ref ShieldDmg, ref BowDef, ref BowDmg, ref SwordDef, ref SwordDmg, ref Potion); break;
                    case " ?":
                        NPC.QuestNPC(ref EnemyDead, ref TalkToNPC, ref TalkTalk, ref RewardNPC, ref Money, ref SecondQuest, ref WizardMoney,
                        ref WizardKill, ref NpcKilled, ref NpcReward, ref PlayerHp, ref Player.StrengthUp); break;
                    case " X":
                        NPC.Monster(ref TalkToNPC, ref EnemyDead, ref IsFight, ref PlayerHp, ref EnemyHp, ref y, ref Potion, ref Heal,
                        ref EnemyDmg, ref WeaponDef, ref ArmorDef, ref WeaponDmg); break;
                    case " D": NPC.Doctor(ref PlayerHp, ref Money); break;
                    case " O": Obj.Trap(ref PlayerHp); break;
                    case " G": NPC.Warlock(); break;
                    case " T": NPC.Trainer(ref Player.StrengthUp, ref Player.TalkToTrainer); break;
                    case " %": NPC.Dumbbell(ref Player.StrengthUp, ref Player.TalkToTrainer); break;
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
                    case (" )", 1):  x = 1; _proto_zone.ZoneId = 2; break;
                    case (" )", 2): x = 13; _proto_zone.ZoneId = 1; break;
                }

                //Перезапись буфера

                yb = y;
                xb = x;

                //Рендер Игрока

                _proto_zone.RenderPlayer(zone, y, x);

                //Рендер зоны
                Console.Write($"Здоровье: {PlayerHp} Урон:{WeaponDmg + 5}\nМонет: {Money} Зелий: {Potion}\n");
                switch (_proto_zone.ZoneId)
                {
                    case 1: Room1(zone, y, x); break;
                    case 2: Room2(zone, y, x); break;
                }

                //Проверка на открытие инвентаря
                if (Player.InvOpen)
                {
                    Player.ShowInv(ref Player.Inv);
                }
                    if(Launcher.ExitLvl == 1)
                    {
                    Launcher.Centering("Вы хотите выйти в Лаунчер?");
                    Launcher.Centering(1, "> Esc - Да      > Tab - Нет");
                    }
                    if (Launcher.ExitLvl > 1)
                    {
                        Launcher.Main();
                    }
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
                    case ConsoleKey.I:
                        Player.InvCount++;
                        Player.InvOpen = (Player.InvCount % 2) == 0;
                        break;
                    case ConsoleKey.Escape:
                        Launcher.ExitLvl++;
                        break;
                    case ConsoleKey.Tab:
                        Launcher.ExitLvl= 0;
                        break;
                }
                Console.Clear();

            }
        }
    }
}