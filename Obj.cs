using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons
{
    internal class Obj
    {
        static public void Door(ref Player Player, ref int PlayerHp, ref int x, Random rnd)
        {
            Console.WriteLine("Вы стоите перед огромными дверьми Короля Чернокнижников. Чтобы открыть их, нужна немалая сила.\nПопытаться открыть их? Y - Да N - Нет");
            ConsoleKeyInfo WarlockDoor = Console.ReadKey(true);
            switch (WarlockDoor.Key)
            {
                case ConsoleKey.Y:
                    if (Player.StrengthUp)
                    {
                        Console.WriteLine("Вы успешно открыли дверь, приложив немалую силу, которая, благо, у вас имеется!");
                        if (x == 11)
                        {
                            x = x - 2;
                        }
                        else if (x == 9)
                        {
                            x = x + 2;
                        }
                    }
                    else
                    {
                        int DoorDmg = rnd.Next(1, 20);
                        PlayerHp = PlayerHp - DoorDmg;
                        Console.WriteLine($"Хоть вы и применили всю свою силу, открыть дверь не удалось. Вы растянули мышцы и получили {DoorDmg} урона.\nВаше нынешнее здоровье - {PlayerHp}.");
                    }
                    break;
                case ConsoleKey.N:
                    Console.WriteLine("Вы решили не открывать двери.\nНа мгновение вам показалось, что дверь хочет, чтобы вы ее открыли.");
                    break;
                default:
                    break;
            }
        }
        static public void Trap(ref int PlayerHp)
        {
            Random random = new Random();
            int TrapDamage = random.Next(5, 15);
            PlayerHp = PlayerHp - TrapDamage;
            if (PlayerHp > 0)
            {
                Console.WriteLine($"Вы попали в ловушку и получили {TrapDamage} урона! Ваше нынешнее здоровье - {PlayerHp}");
            }
            else
            {
                PlayerHp = 0;
                Console.WriteLine("Увы и ах, вы умерли от попадания в ловушку! Впредь будьте осторожнее...");
                Environment.Exit(0);
            }
        }
    }
}
