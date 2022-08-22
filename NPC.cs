using System;
using System.Security.Policy;

namespace Dungeons
{
    internal class NPC
    {

        static public void QuestNPC(ref bool EnemyDead, ref bool TalkToNPC, ref bool TalkTalk, ref bool RewardNPC, ref int Money,
            ref bool SecondQuest, ref bool WizardMoney, ref bool WizardKill, ref bool NpcKilled, ref bool NpcReward, ref int PlayerHp, ref bool StrenghtUp)
        {
            {
                if ((!EnemyDead) && (!TalkToNPC))
                {
                    Console.WriteLine("Здравствуй путник! Меня зовут Витя! Что привело тебя в эти темные и непроглядные пучины подземелья?");
                    Console.WriteLine("Помоги мне убить монстра и я тебя вознагражу! Для начала тебе нужно купить оружие. Держи 80 монет для покупки меча.");
                    Money = Money + 80;
                    Console.WriteLine($"У вас теперь {Money} монет.");
                    TalkToNPC = true;
                    TalkTalk = true;
                }
                else if ((EnemyDead) && (!RewardNPC))
                {
                    Console.WriteLine("Ты убил его! Огромное тебе спасибо. Вот, возьми это в качестве платы.");
                    Console.WriteLine("Вы получили 150 золотых монет!");
                    Money = Money + 150;
                    Console.WriteLine($"У вас теперь {Money} монет.");
                    RewardNPC = true;
                }
                else if ((!EnemyDead) && (TalkToNPC))
                {
                    Console.WriteLine("Прошу, поторопись. Не стоит заставлять монстра ждать, он многое может натворить.");
                }
                else if ((EnemyDead == true) && (RewardNPC == true) && SecondQuest == false)
                {

                    Console.WriteLine("О, мой дорогой друг! Я снова нуждаюсь в твоей помощи. \n Нужно забрать долг у одного человека, сможешь?");
                    Console.WriteLine("Y - Принять задание, N - Я таким не занимаюсь.");
                    ConsoleKeyInfo NpcQuest = Console.ReadKey(true);
                    switch (NpcQuest.Key)
                    {
                        case ConsoleKey.Y:
                            SecondQuest = true;
                            Console.WriteLine("Этот человек - маг. Половина от денег твоя. Удачи!");
                            break;
                        case ConsoleKey.N:
                            Console.WriteLine("Как пожелаешь, но лучше бы тебе передумать.");
                            break;
                        default:
                            break;
                    }
                }
                else if ((EnemyDead) && (RewardNPC) && SecondQuest && !WizardMoney && !WizardKill)
                {
                    Console.WriteLine("Верни мне долг мага.");
                }
                else if (WizardMoney && !WizardKill && !NpcKilled && !NpcReward)
                {
                    Console.WriteLine("Молодец! Я в тебе не сомневался! Давай сюда деньги, дам тебе половину.");
                    Console.WriteLine("Y - Дать, N - После того, как убью тебя.");
                    ConsoleKeyInfo WizardMoneyNpc = Console.ReadKey(true);
                    switch (WizardMoneyNpc.Key)
                    {
                        case ConsoleKey.Y:
                            Console.WriteLine("Отлично, вот твои деньги.");
                            Money = Money + 250;
                            Console.WriteLine($"У вас теперь {Money} монет.");
                            NpcReward = true;
                            break;
                        case ConsoleKey.N:
                            Console.WriteLine("Ах ты ж сука! На тебе!");
                            Console.WriteLine("Y - Защитить лицо руками от удара, N - Присесть.");
                            ConsoleKeyInfo Fight = Console.ReadKey(true);
                            switch (Fight.Key)
                            {
                                case ConsoleKey.Y:
                                    Console.WriteLine("Он ударил вам в висок, пока вы судорожно прикрывали лицо. Он нанес вам 20 урона.");
                                    PlayerHp -= 20;
                                    if (PlayerHp <= 0)
                                    {
                                        Console.WriteLine("Вы скончались от яростных ударов Вити.");
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Ваше нынешнее здоровье - {PlayerHp}");
                                        Console.WriteLine("Он открылся перед нападением, находясь в кураже от удара.\n Y - Точный удар, N - Таран");
                                        ConsoleKeyInfo Fight6 = Console.ReadKey(true);
                                        switch (Fight6.Key)
                                        {
                                            case ConsoleKey.Y:
                                                Console.WriteLine("Он схватил вашу руку и заломал ее. Вы проиграли. Вы будете умирать долго и мучительно.");
                                                Environment.Exit(0);
                                                break;
                                            case ConsoleKey.N:
                                                Console.WriteLine("Повалив его, он сильно ударился головой, оставалось только добить его.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                NpcKilled = true;
                                                break;
                                            default:
                                                Console.WriteLine("Вы бездействовали и вас убили.");
                                                Environment.Exit(0);
                                                break;
                                        }
                                    }

                                    break;
                                case ConsoleKey.N:
                                    Console.WriteLine("Вам попался удачный момент для удара, когда Витя раскрылся и замахнулся на вас.\nY - Апперкот, N - Удар по паху.");
                                    ConsoleKeyInfo Fight3 = Console.ReadKey(true);
                                    switch (Fight3.Key)
                                    {
                                        case ConsoleKey.Y:
                                            if (StrenghtUp)
                                            {
                                                Console.WriteLine("Вы сокрушающе ударили Витю, отчего он упал замертво.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                NpcKilled = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Этот удар нанес сильный урон Вите. Он потянул руки к носу и согнулся.\n Y - Добить ударом колена. N - Ударить кулаком по затылку.");
                                                ConsoleKeyInfo Fight5 = Console.ReadKey(true);
                                                switch (Fight5.Key)
                                                {
                                                    case ConsoleKey.Y:
                                                        if (StrenghtUp == true)
                                                        {
                                                            Console.WriteLine("Хоть он и прикрывался руками, вы пробили его защиту.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                            NpcKilled = true;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Вы не смогли пробить его защиту из рук. Он контратаковал, воспользуясь вашим смятением.\nВы умерли.");
                                                            Environment.Exit(0);
                                                        }
                                                        break;
                                                    case ConsoleKey.N:
                                                        Console.WriteLine("Сильный удар прекратил существование Вити.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                        NpcKilled = true;
                                                        break;
                                                    default:
                                                        Console.WriteLine("Вы бездействовали и вас убили.");
                                                        Environment.Exit(0);
                                                        break;
                                                }
                                            }
                                            break;
                                        case ConsoleKey.N:
                                            Console.WriteLine("Витя согнулся и раскрыл лицо для удара.\nY - Добить ударом колена, N - Завершающий апперкот.");
                                            ConsoleKeyInfo Fight4 = Console.ReadKey(true);
                                            switch (Fight4.Key)
                                            {
                                                case ConsoleKey.Y:
                                                    Console.WriteLine("Витя заблокировал ваш удар руками, уже притянутыми к носу. \n Вас повалили на пол. Y - Блокировать удары в голову, N - Резкий хук справа.");
                                                    ConsoleKeyInfo Fight5 = Console.ReadKey(true);
                                                    switch (Fight5.Key)
                                                    {
                                                        case ConsoleKey.Y:
                                                            Console.WriteLine("Вы умерли от бесчисленных ударов по печени.");
                                                            Environment.Exit(0);
                                                            break;
                                                        case ConsoleKey.N:
                                                            Console.WriteLine("Противник не ожидал хука, и подставился. Вы победили.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                            NpcKilled = true;
                                                            break;
                                                        default:
                                                            Console.WriteLine("Вы бездействовали и вас убили.");
                                                            Environment.Exit(0);
                                                            break;
                                                    }
                                                    break;
                                                case ConsoleKey.N:
                                                    Console.WriteLine("Точный и сильный удар не оставил противнику ни одного шанса. \nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                    NpcKilled = true;
                                                    break;
                                                default:
                                                    Console.WriteLine("Вы бездействовали и вас убили.");
                                                    Environment.Exit(0);
                                                    break;
                                            }
                                            break;
                                        default:
                                            Console.WriteLine("Вы бездействовали и вас убили.");
                                            Environment.Exit(0);
                                            break;
                                    }
                                    NpcKilled = true;
                                    break;
                                default:
                                    Console.WriteLine("Вы бездействовали и вас убили.");
                                    Environment.Exit(0);
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else if (WizardKill && !NpcKilled)
                {
                    Console.WriteLine("Ах ты ж сука! Я все слышал! На тебе!");
                    Console.WriteLine("Y - Защитить лицо руками от удара, N - Присесть.");
                    ConsoleKeyInfo Fight = Console.ReadKey(true);
                    switch (Fight.Key)
                    {
                        case ConsoleKey.Y:
                            Console.WriteLine("Он ударил вам в висок, пока вы судорожно прикрывали лицо. Он нанес вам 20 урона.");
                            PlayerHp -= 20;
                            if (PlayerHp <= 0)
                            {
                                Console.WriteLine("Вы скончались от яростных ударов Вити.");
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine($"Ваше нынешнее здоровье - {PlayerHp}");
                                Console.WriteLine("Он открылся перед нападением, находясь в кураже от удара.\n Y - Точный удар, N - Таран");
                                ConsoleKeyInfo Fight6 = Console.ReadKey(true);
                                switch (Fight6.Key)
                                {
                                    case ConsoleKey.Y:
                                        Console.WriteLine("Он схватил вашу руку и заломал ее. Вы проиграли. Вы будете умирать долго и мучительно.");
                                        Environment.Exit(0);
                                        break;
                                    case ConsoleKey.N:
                                        Console.WriteLine("Повалив его, он сильно ударился головой, оставалось только добить его.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                        NpcKilled = true;
                                        break;
                                    default:
                                        Console.WriteLine("Вы бездействовали и вас убили.");
                                        Environment.Exit(0);
                                        break;
                                }
                            }

                            break;
                        case ConsoleKey.N:
                            Console.WriteLine("Вам попался удачный момент для удара, когда Витя раскрылся и замахнулся на вас.\nY - Апперкот, N - Удар по паху.");
                            ConsoleKeyInfo Fight3 = Console.ReadKey(true);
                            switch (Fight3.Key)
                            {
                                case ConsoleKey.Y:
                                    if (StrenghtUp == true)
                                    {
                                        Console.WriteLine("Вы сокрушающе ударили Витю, отчего он упал замертво.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                        NpcKilled = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Этот удар нанес сильный урон Вите. Он потянул руки к носу и согнулся.\n Y - Добить ударом колена. N - Ударить кулаком по затылку.");
                                        ConsoleKeyInfo Fight5 = Console.ReadKey(true);
                                        switch (Fight5.Key)
                                        {
                                            case ConsoleKey.Y:
                                                if (StrenghtUp == true)
                                                {
                                                    Console.WriteLine("Хоть он и прикрывался руками, вы пробили его защиту.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                    NpcKilled = true;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Вы не смогли пробить его защиту из рук. Он контратаковал, воспользуясь вашим смятением.\nВы умерли.");
                                                    Environment.Exit(0);
                                                }
                                                break;
                                            case ConsoleKey.N:
                                                Console.WriteLine("Сильный удар прекратил существование Вити.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                NpcKilled = true;
                                                break;
                                            default:
                                                Console.WriteLine("Вы бездействовали и вас убили.");
                                                Environment.Exit(0);
                                                break;
                                        }
                                    }
                                    break;
                                case ConsoleKey.N:
                                    Console.WriteLine("Витя согнулся и раскрыл лицо для удара.");
                                    Console.WriteLine("Y - Добить ударом колена, N - Завершающий апперкот.");
                                    ConsoleKeyInfo Fight4 = Console.ReadKey(true);
                                    switch (Fight4.Key)
                                    {
                                        case ConsoleKey.Y:
                                            Console.WriteLine("Витя заблокировал ваш удар руками, уже притянутыми к носу. \n Вас повалили на пол. Y - Блокировать удары в голову, N - Резкий хук справа.");
                                            ConsoleKeyInfo Fight5 = Console.ReadKey(true);
                                            switch (Fight5.Key)
                                            {
                                                case ConsoleKey.Y:
                                                    Console.WriteLine("Вы умерли от бесчисленных ударов по печени.");
                                                    Environment.Exit(0);
                                                    break;
                                                case ConsoleKey.N:
                                                    Console.WriteLine("Противник не ожидал хука, и подставился. Вы победили.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                    NpcKilled = true;
                                                    break;
                                                default:
                                                    Console.WriteLine("Вы бездействовали и вас убили.");
                                                    Environment.Exit(0);
                                                    break;
                                            }
                                            break;
                                        case ConsoleKey.N:
                                            Console.WriteLine("Точный и сильный удар не оставил противнику ни одного шанса. \nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                            NpcKilled = true;
                                            break;
                                        default:
                                            Console.WriteLine("Вы бездействовали и вас убили.");
                                            Environment.Exit(0);
                                            break;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Вы бездействовали и вас убили.");
                                    Environment.Exit(0);
                                    break;
                            }
                            NpcKilled = true;
                            break;
                        default:
                            Console.WriteLine("Вы бездействовали и вас убили.");
                            Environment.Exit(0);
                            break;
                    }
                }
                else if (NpcReward == false && NpcKilled == true)
                {
                    Console.WriteLine("Вы смотрите на гниющий труп Вити. Поделом - думаете вы.");
                }
                else
                {
                    Console.WriteLine("Привет!");
                }
            }
        }
        static public void Wizard(ref bool Book, ref bool SecondQuest, ref bool WizardMoney, ref bool WizardReward, ref int Money, ref int WizardHelp,
            ref bool WizardKill, ref bool NpcKilled)
        {
            Console.WriteLine("Приветствую.");
            if (Book == true && SecondQuest == false || Book == true && WizardReward == true)
            {
                Console.WriteLine("Ого. Утопия. Не думал что встречу ее здесь. " +
                    "\nСтавлю свою мантию на то, что торговец пытался выманить ее у тебя, так ведь?" +
                    "\nСлушай, это книга древнего Архивариуса Антонидаса. " +
                    "\nЯ могу изучить ее, чтобы улучшить твои, и разумеется, свои боевые навыки." +
                    "\nНо после этого книга пропадет, на ней стоит заклинание." +
                    "\n Y - Принять N - Отказаться");
                ConsoleKeyInfo WizardDeal = Console.ReadKey(true);
                switch (WizardDeal.Key)
                {
                    case ConsoleKey.Y:
                        WizardHelp = 10;
                        Console.WriteLine("Спасибо, ты поступил правильно. Твои боевые навыки должны были возрасти.");
                        Console.WriteLine("Ваш урон возрос на 10 очков!");
                        break;
                    case ConsoleKey.N:
                        Console.WriteLine("Жаль. Я буду ждать здесь, быть может, передумаешь.");
                        break;
                    default:
                        break;
                }
            }
            else if (SecondQuest == true && WizardKill == false && WizardMoney == false)
            {
                Console.WriteLine("Тебя прислал Витя, так? Мда, плохо получается.\nПослушай, он плохой человек. Он шантажирует меня держа мою семью в заложниках наверху.\nОн не тот, кого за себя выдает. \nУбей его, и я дам тебе в два раза больше чем дал бы он.");
                Console.WriteLine("Y - Хорошо, я сделаю это. N - Долг есть долг. Возвращай.");
                ConsoleKeyInfo NpcKill = Console.ReadKey(true);
                switch (NpcKill.Key)
                {
                    case ConsoleKey.Y:
                        Console.WriteLine("Я рассчитываю на тебя. Сделай всем нам одолжение.");
                        WizardKill = true;
                        break;
                    case ConsoleKey.N:
                        Console.WriteLine("Эх. Держи свои деньги.");
                        WizardMoney = true;
                        break;
                    default:
                        break;
                }
            }
            else if (NpcKilled == true && WizardReward == false)
            {
                Console.WriteLine("Спасибо тебе. Большое тебе спасибо. Вот твои деньги. Моя семья и я будем тебе благодарны всю жизнь.");
                Money = Money + 500;
                Console.WriteLine($"У вас теперь {Money} монет.");
                WizardReward = true;
            }
        }
        static public void Chest(ref bool ChestOpen, ref bool Book, ref Player player)
        {
            if (ChestOpen == false)
            {
                Console.WriteLine("Перед вами сундук. Вы открываете его.");
                Console.WriteLine("Внутри не было ничего кроме старой пыльной книги под названием Утопия. Вы взяли ее с собой.");
                ChestOpen = true;
                Invent.Add(new Item("Книга"), ref player.Inv, ref Invent.BusyCell);
                Book = true;
            }
            else
            {
                Console.WriteLine("Вы уже открывали этот сундук. Теперь он пуст.");
            }
        }
        static public void Merchant(ref bool Book, ref bool IsTalk, ref bool BookReject, ref int Money, ref int ArmorDef,
            ref int LightDef, ref int HeavyDef, ref int WeaponDef, ref int WeaponDmg, ref int ShieldDef, ref int ShieldDmg,
            ref int BowDef, ref int BowDmg, ref int SwordDef, ref int SwordDmg, ref int Potion)
        {
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
                                Invent.PullOut(ref Player.Inv, ref Invent.BusyCell);
                                break;
                            case ConsoleKey.N:
                                Console.WriteLine("Эх, зря вы так, я ведь предложил хорошую цену!");
                                IsTalk = false;
                                BookReject = true;
                                break;
                        }
                        break;
                    default: break;
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
        static public void Monster(ref bool TalkToNPC, ref bool EnemyDead, ref bool IsFight, ref int PlayerHp,
            ref int EnemyHp, ref int y, ref int Potion, ref int Heal, ref int EnemyDmg, ref int WeaponDef, ref int ArmorDef, ref int WeaponDmg)
        {
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
                                PlayerHp = PlayerHp + Heal - EnemyDmg + WeaponDef + ArmorDef;
                                if (PlayerHp > 100)
                                {
                                    PlayerHp = 100;
                                }
                                if (EnemyDmg - WeaponDef - ArmorDef > 0)
                                {
                                    Console.WriteLine($"Вы выпили зелье! Но враг нанёс вам {EnemyDmg - WeaponDef - ArmorDef} урона. Ваше здоровье - {PlayerHp}.");
                                }
                                else
                                {
                                    Console.WriteLine($"Вы выпили зелье! Враг не смог пробить вашу защиту! Ваше здоровье - {PlayerHp}");
                                }
                                Potion--;
                                Console.WriteLine($"У вас осталось {Potion} зелий.");
                            }
                            else
                            {
                                Console.WriteLine("У вас не осталось зелий!");
                            }
                            break;
                        case ConsoleKey.A:
                            PlayerHp = PlayerHp - (EnemyDmg - WeaponDef - ArmorDef);
                            if (PlayerHp > 100)
                            {
                                PlayerHp = 100;
                            }
                            EnemyHp = EnemyHp - WeaponDmg - 5;
                            Console.WriteLine($"Ваше здоровье - {PlayerHp}.");
                            if (EnemyDmg - WeaponDef - ArmorDef > 0)
                            {
                                Console.WriteLine($"Враг нанес вам {EnemyDmg - WeaponDef - ArmorDef} урона!");
                            }
                            else
                            {
                                Console.WriteLine("Враг не смог пробить вашу защиту!");
                            }
                            if (EnemyHp > 0)
                            {
                                Console.WriteLine($"Здоровье врага - {EnemyHp}.");
                            }
                            else
                            {
                                Console.WriteLine("Здоровье врага - 0!");
                            }
                            break;
                        case ConsoleKey.S:
                            if (EnemyDmg - WeaponDef - ArmorDef > 0)
                            {
                                PlayerHp = PlayerHp - (EnemyDmg - WeaponDef - ArmorDef);
                                Console.WriteLine($"Враг нанес вам {EnemyDmg - WeaponDef - ArmorDef} урона!");
                                Console.WriteLine($"Ваше здоровье - {PlayerHp}.");
                            }
                            else
                            {
                                Console.WriteLine("Враг не смог пробить вашу защиту!");
                                Console.WriteLine($"Ваше здоровье - {PlayerHp}.");
                            }
                            Console.WriteLine($"Здоровье врага - {EnemyHp}.");
                            break;
                        default:
                            break;
                    }
                }
                if (PlayerHp >= 0 && EnemyHp <= 0)
                {
                    Console.WriteLine($"Ура, победа!");
                    IsFight = false;
                    EnemyDead = true;
                }
                else if (PlayerHp <= 0 && EnemyHp >= 0)
                {
                    Console.WriteLine("Вы сдохли как собака. Позор вам.");
                    IsFight = false;
                    PlayerHp = 100;
                }
                else
                {
                    Console.WriteLine("Вы успешно сбежали.");
                    IsFight = false;
                }
            }
        }
        static public void Trainer(ref bool StrenghtUpUp, ref bool TalkToTrainer)
        {
            if (StrenghtUpUp == false)
            {
                Console.WriteLine("Привет, салага! Я тренер. Могу стать и твоим. \nЕсли согласен, бери гантели справа от меня и занимайся на здоровье.");
                TalkToTrainer = true;
            }
            else
            {
                Console.WriteLine("Ого, уже виден прогресс! Продолжай в том же духе!");
            }
        }
        static public void Dumbbell(ref bool StrenghtUpUp, ref bool TalkToTrainer)
        {
            if (TalkToTrainer == false)
            {
                Console.WriteLine("Перед вами лежат гантели. Для вас они не имеют никакого значения.");
            }
            else
            {
                Console.WriteLine("Это гантели, о которых говорил Тренер. Вы используете их чтобы повысить свои силовые навыки.");
                StrenghtUpUp = true;
                Console.WriteLine("Вы стали сильнее!");
            }
        }
        static public void Warlock()
        {
            Console.WriteLine("Ты находишься в покоях Короля Чернокнижников. Если у тебя нет дела ко мне - проваливай.");
        }
        static public void Doctor(ref int PlayerHp, ref int Money)
        {
            if (PlayerHp >= 100)
            {
                Console.WriteLine("Здравствуй! Я доктор, если тебе нужна помощь, то я могу вылечить тебя за 20 монет.");
            }
            else if (PlayerHp < 100)
            {
                Console.WriteLine("Здравствуй! Вижу, ты немного ранен. Я могу вылечить тебя за 20 монет.\n Y - принять N - отказать");
                ConsoleKeyInfo HealingDoctor = Console.ReadKey(true);
                switch (HealingDoctor.Key)
                {
                    case ConsoleKey.Y:
                        if (Money >= 20)
                        {
                            Money = Money - 20;
                            PlayerHp = 100;
                            Console.WriteLine("Paratus! Вы полностью излечены.");
                            Console.WriteLine($"У вас теперь {Money} монет.");
                        }
                        else
                        {
                            Console.WriteLine("У вас недостаточно денег.");
                        }
                        break;
                    case ConsoleKey.N:
                        Console.WriteLine("Ut dicis.");
                        break;
                }
            }
        }
    }
}
