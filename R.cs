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
<<<<<<< Updated upstream

            {
                bool TalkTalk = false;
                bool RewardNPC = false;
                bool IsTalk = false;
                int Heal = 40;
                bool Book = false;
                bool ChestOpen = false;
                int Potion = 0;
                int ArmorDef = 0;
                int LightDef = 5;
                int HeavyDef = 12;
                int Money = 0;
                int Weapon = 0;
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
                bool EnemyDead = false;
                bool TalkToNPC = false;
                int EnemyHp = 50;
                int PlayerHp = 100;
                int EnemyDmg = 15;
                int PlayerDmg = 5 + WeaponDmg;
                var IsFight = true;
                dynamic[] Invenetary = { Money, Weapon };
=======
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
            WizardReject = SecondQuest = WizardMoney 
            = WizardKill = NpcKilled = NpcReward = false;
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
>>>>>>> Stashed changes

                //Спавн игрока
                int y = 2, x = 5;
                bool isSolid;
                //Буфер
                int yb = y, xb = x;

                while (true)
                {
                    isSolid = zone[y, x] == " #" || zone[y, x] == " |" || zone[y, x] == "| "
                           || zone[y, x] == "__" || zone[y, x] == "|_" || zone[y, x] == "_|";
                    if (isSolid)
                    {
                        y = yb;
                        x = xb;
                    }

                    if (zone[y, x] == " Ш")
                    {
                        y = yb;
                        x = xb;
                        if (ChestOpen == false)
                        {
                            Console.WriteLine("Перед вами сундук. Вы открываете его.");
                            Console.WriteLine("Внутри не было ничего кроме старой пыльной книги под названием Утопия. Вы взяли ее с собой.");
                            ChestOpen = true;
                            Book = true;
                        }
                        else
                        {
                            Console.WriteLine("Вы уже открывали этот сундук. Теперь он пуст.");
                        }
                    }
                    if (zone[y, x] == " M")
                    {
                        y = yb;
                        x = xb;
                        IsTalk = true;
                        if (Book == true && IsTalk == true && BookReject == false)
                        {
                            Console.WriteLine("Здравствуй, приключенец! Проходи, посмотри на мои товары.");
                            Console.WriteLine("Я чую ауру книги у тебя в рюкзаке. Я куплю ее за 300 монет.\nY - Принять N - Отказ");
                            ConsoleKeyInfo BookSell = Console.ReadKey(true);
                            switch (BookSell.Key)
                            {
                                case ConsoleKey.Y:
                                    Console.WriteLine("Спасибо. Вот твои деньги.");
                                    Money = Money + 300;
                                    Console.WriteLine($"У вас теперь {Money} монет.");
                                    Book = false;
                                    IsTalk = false;
                                    break;
                                case ConsoleKey.N:
                                    Console.WriteLine("Ну пожалуйста! Давай я дам 340 монет!\n\tY - Принять N - Отказ");
                                    ConsoleKeyInfo Torg = Console.ReadKey(true);
                                    switch (Torg.Key)
                                    {
                                        case ConsoleKey.Y:
                                            Console.WriteLine("Ну вот! Так бы сразу! С вами приятно иметь дело.");
                                            Money = Money + 340;
                                            Console.WriteLine($"У вас теперь {Money} монет.");
                                            IsTalk = false;
                                            Book = false;
                                            break;
                                        case ConsoleKey.N:
                                            Console.WriteLine("Эх, зря вы так, я ведь предложил хорошую цену!");
                                            IsTalk = false;
                                            BookReject = true;
                                            break;
                                    }
                                    break;
                                default: return;
                            }
                        }
                        if (Book == false && IsTalk == true || Book == true && IsTalk == true && BookReject == true)
                        {
                            Console.WriteLine("Привет! Хочешь что-нибудь купить?");
                            Console.WriteLine($"Ваш баланс - {Money} монет.");
                            Console.WriteLine("Легкие доспехи - 150(A), Тяжелые доспехи - 350(S), Щит - 150(D)");
                            Console.WriteLine("Лук - 100(F), Меч - 80(G), Зелье Исцеления - 30(H)");
                            Console.WriteLine("Выйти - W");
                            ConsoleKeyInfo BuyMenu = Console.ReadKey(true);
                            switch (BuyMenu.Key)
                            {
                                case ConsoleKey.A:
                                    if (Money >= 150)
                                    {
                                        Money = Money - 150;
                                        Console.WriteLine($"Вы купили Легкие доспехи! У вас осталось {Money} монет.");
                                        ArmorDef = LightDef;
                                        IsTalk = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас недостаточно денег.");
                                        IsTalk = false;
                                    }
                                    break;
                                case ConsoleKey.S:
                                    if (Money >= 350)
                                    {
                                        Money = Money - 350;
                                        Console.WriteLine($"Вы купили Тяжелые доспехи! У вас осталось {Money} монет.");
                                        ArmorDef = HeavyDef;
                                        IsTalk = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас недостаточно денег.");
                                        IsTalk = false;
                                    }
                                    break;
                                case ConsoleKey.D:
                                    if (Money >= 150)
                                    {
                                        Money = Money - 150;
                                        Console.WriteLine($"Вы купили Щит! У вас осталось {Money} монет.");
                                        WeaponDef = ShieldDef;
                                        WeaponDmg = ShieldDmg;
                                        IsTalk = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас недостаточно денег.");
                                        IsTalk = false;
                                    }
                                    break;
                                case ConsoleKey.F:
                                    if (Money >= 100)
                                    {
                                        Money = Money - 100;
                                        Console.WriteLine($"Вы купили Лук! У вас осталось {Money} монет.");
                                        WeaponDef = BowDef;
                                        WeaponDmg = BowDmg;
                                        IsTalk = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас недостаточно денег.");
                                        IsTalk = false;
                                    }
                                    break;
                                case ConsoleKey.G:
                                    if (Money >= 80)
                                    {
                                        Money = Money - 80;
                                        Console.WriteLine($"Вы купили Меч! У вас осталось {Money} монет.");
                                        WeaponDef = SwordDef;
                                        WeaponDmg = SwordDmg;
                                        IsTalk = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас недостаточно денег.");
                                        IsTalk = false;
                                    }
                                    break;
                                case ConsoleKey.H:
                                    if (Money >= 30)
                                    {
                                        Money = Money - 30;
                                        Console.WriteLine($"Вы купили Зелье исцеления! У вас осталось {Money} монет.");
                                        Potion++;
                                        IsTalk = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас недостаточно денег.");
                                        IsTalk = false;
                                    }
                                    break;
                                case ConsoleKey.W:
                                    break;
                                default:
                                    {
                                        Console.WriteLine("У меня всего 6 ячеек с предметами. Введите номер ячейки.");
                                        break;
                                    }
                            }
                        }
                    }
                    if (zone[y, x] == " ?")
                    {
                        y = yb;
                        x = xb;
                        if ((EnemyDead == false) && (TalkToNPC == false))
                        {
                            Console.WriteLine("Здравствуй путник! Меня зовут Витя! Что привело тебя в эти темные и непроглядные пучины подземелья?");
                            Console.WriteLine("Помоги мне убить монстра и я тебя вознагражу! Для начала тебе нужно купить оружие. Держи 80 монет для покупки меча.");
                            Money = Money + 80;
                            Console.WriteLine($"У вас теперь {Money} монет.");
                            TalkToNPC = true;
                            TalkTalk = true;
                        }
                        else if ((EnemyDead == true) && (RewardNPC == false))
                        {
                            Console.WriteLine("Ты убил его! Огромное тебе спасибо. Вот, возьми это в качестве платы.");
                            Console.WriteLine("Вы получили 150 золотых монет!");
                            Money = Money + 150;
                            Console.WriteLine($"У вас теперь {Money} монет.");
                            RewardNPC = true;
                        }
                        else if ((EnemyDead == false) && (TalkToNPC == true))
                        {
                            Console.WriteLine("Прошу, поторопись. Не стоит заставлять монстра ждать, он многое может натворить.");
                        }
                        else if ((EnemyDead == true) && (RewardNPC == true))
                        {
                            Console.WriteLine("О, мой дорогой друг! Я снова нуждаюсь в твоей помощи. \nМой давний знакомый задолжал мне деньги. Половина твоя. Он находится в соседней комнате, удачи!");
                        }
                    }
                    if (zone[y, x] == " X")
                    {
                        y = yb;
                        x = xb;
                        if (TalkToNPC == false)
                        {
                            Console.WriteLine("Вы встретили монстра! Он опасен, лучше не драться с ним без причины.");
                        }
                        if (TalkToNPC == true && EnemyDead == true)
                        {
                            Console.WriteLine("Вы горделиво возвышаетесь над трупом поверженного монстра. \nДля других - это мелочь, а для вас - первая победа в вашем приключении.");
                        }
                        if ((TalkToNPC == true) && (EnemyDead == false))
                        {
                            Console.WriteLine("Вы встретили монстра, о котором говорил Витя!");
                            IsFight = true;
                            while ((PlayerHp > 0 && EnemyHp > 0) && IsFight)
                            {
                                Console.WriteLine("*Злобный рык*");
                                Console.WriteLine("W - Уйти, A - Атака оружием, D - Исцеление, S - Пропуск хода.");
                                ConsoleKeyInfo FightKey = Console.ReadKey(true);
                                switch (FightKey.Key)
                                {
                                    case ConsoleKey.W:
                                        y--;
                                        IsFight = false;
                                        break;
                                    case ConsoleKey.D:
                                        if (Potion > 0)
                                        {
                                            PlayerHp = PlayerHp + Heal - EnemyDmg;
                                            if (PlayerHp > 100)
                                            {
                                                PlayerHp = 100;
                                            }
                                            Console.WriteLine($"Вы выпили зелье! Но враг нанёс вам {EnemyDmg}. Ваше здоровье - {PlayerHp}.");
                                            Console.WriteLine($"У вас осталось {Potion} зелий.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("У вас не осталось зелий!");
                                        }
                                        break;
                                    case ConsoleKey.A:
                                        PlayerHp = PlayerHp - (EnemyDmg - WeaponDef - ArmorDef);
                                        EnemyHp = EnemyHp - WeaponDmg - 5;
                                        Console.WriteLine($"Ваше здоровье - {PlayerHp}.");
                                        Console.WriteLine($"Здоровье врага - {EnemyHp}.");
                                        break;
                                    case ConsoleKey.S:
                                        PlayerHp = PlayerHp - EnemyDmg;
                                        Console.WriteLine($"Ваше здоровье - {PlayerHp}.");
                                        Console.WriteLine($"Здоровье врага - {EnemyHp}.");
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (PlayerHp > 0 && EnemyHp < 0)
                            {
                                Console.WriteLine($"Ура, победа!");
                                IsFight = false;
                                EnemyDead = true;
                            }
                            else if (PlayerHp < 0 && EnemyHp > 0)
                            {
                                Console.WriteLine("Вы сдохли как собака. Позор вам.");
                                IsFight = false;
                            }
                            else
                            {
<<<<<<< Updated upstream
                                Console.WriteLine("Вы успешно сбежали.");
                                IsFight = false;
                            }
                        }
=======
                                int DoorDmg = rnd.Next(1, 20);
                                Player.Hp = Player.Hp - DoorDmg;
                                Console.WriteLine($"Хоть вы и применили всю свою силу, открыть дверь не удалось. Вы растянули мышцы и получили {DoorDmg} урона.\nВаше нынешнее здоровье - {Player.Hp}.");
                            }
                            break;
                        case ConsoleKey.N:
                            Console.WriteLine("Вы решили не открывать двери.\nНа мгновение вам показалось, что дверь хочет, чтобы вы ее открыли.");
                            break;
                        default:
                            break;
                    }
                }
                if (zone[y, x] == " !")
                {
                    Console.WriteLine("Управление - WASD. Выход - Esc. ");
                }
                if (zone[y, x] == " W")
                {
                    Solid(ref y, ref x, ref yb, ref xb);
                    NPC.Wizard(ref Book, ref SecondQuest, ref WizardMoney, ref WizardReward, ref Money, ref WizardHelp, ref WizardKill, ref NpcKilled);
                }
                if (zone[y, x] == " M")
                {
                    IsTalk = true;
                    NPC.Merchant(ref Book, ref IsTalk, ref BookReject, ref Money, ref ArmorDef, ref LightDef, ref HeavyDef, ref WeaponDef, ref WeaponDmg, ref ShieldDef, ref ShieldDmg, ref BowDef, ref BowDmg, ref SwordDef, ref SwordDmg, ref Potion);
                }
                if (zone[y, x] == " ?")
                {
                    Solid(ref y, ref x, ref yb, ref xb);
            
                    NPC.QuestNPC(ref EnemyDead, ref TalkToNPC, ref TalkTalk, ref RewardNPC, ref Money, ref SecondQuest, ref  WizardMoney, ref  WizardKill, ref  NpcKilled, ref NpcReward, Player.Hp, ref Player.StrengthUp);
                }
                if (zone[y, x] == " X")
                {
                    Solid(ref y, ref x, ref yb, ref xb);
                    NPC.Monster(ref TalkToNPC, ref EnemyDead, ref IsFight, Player.Hp, ref EnemyHp, ref y, ref Potion, ref Heal, 
                        ref EnemyDmg, ref WeaponDef, ref ArmorDef, ref WeaponDmg);
                }
                if (zone[y, x] == " D")
                {
                    Solid(ref y, ref x, ref yb, ref xb);
                    NPC.Doctor(Player.Hp, ref Money);
                }
                if (zone[y, x] == " O")
                {
                    Obj.Trap(Player.Hp);
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
                    Solid(ref y, ref x, ref yb, ref xb);
                    NPC.Dumbbell(ref Player.StrengthUp, ref Player.TalkToTrainer);
                }

                //Твёрдые объекты
                {
                    isSolid = zone[y, x] == " #" || zone[y, x] == " |" || zone[y, x] == "| "
                           || zone[y, x] == "__" || zone[y, x] == "|_" || zone[y, x] == "_|" 
                           || zone[y, x] == " Ш" || zone[y, x] == " W" || zone[y, x] == " %";
                    if (isSolid)
                    {
                        Solid(ref y, ref x, ref yb, ref xb);
>>>>>>> Stashed changes
                    }


                    //Перезапись буфера
                    yb = y;
                    xb = x;

                    //Создание поля / get
                    _proto_zone.RenderPlayer(zone, y, x);

                    //Заполнение поля / set
                    Console.Write($"Здоровье: {PlayerHp} Урон:{WeaponDmg + 5}\nМонет: {Money} Зелий: {Potion}\n");

                    _proto_zone.RenderZone(zone, y, x);

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

<<<<<<< Updated upstream
                            break;
                    }

                    Console.Clear();
=======
                            Console.Write($"Здоровье: {Player.Hp} Урон:{WeaponDmg + 5}\nМонет: {Money} Зелий: {Potion}\n");
                switch (_proto_zone.ZoneId)
                {
                    case 1: Room1(zone, y, x); break;
                    case 2: Room2(zone, y, x); break;
                }
                if (Player.InvtVisible)
                {
                    Player.ShowInvt(ref Player.Invt);
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
                    case ConsoleKey.E:
                        Player.InvtVisible = true;
                        break;
                    default:
>>>>>>> Stashed changes

                }
<<<<<<< Updated upstream
=======
                
                Console.Clear();

>>>>>>> Stashed changes
            }
        } 
    }
}
