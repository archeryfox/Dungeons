using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons
{
    internal class Obj
    {
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
