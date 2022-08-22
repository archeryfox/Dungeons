using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons
{
    internal class Item
    {
        public Item(string Type)
        {
            this.Type = Type;
        }
        public Item()
        {
            
        }
        public string Type;
        public int Lvl = 0;
    }
    internal class Empty 
    {
        public Empty(string Type)
        {
            this.Type = Type;
        }
        public Empty()
        {

        }
        public string Type = "Пусто";
        public const int Lvl = -1;
    }

    internal class Invent
    {
        /// <summary>
        /// Количество занятых клеток в инвентаре
        /// </summary>
        static public int BusyCell = 1;
        /// <summary>
        /// Инвентарь максимально заполнен/не заполнен
        /// </summary>
        static public bool Full = false;
        static private bool CheckFull(ref int BusyCell)
        {
            if( BusyCell == 6)
            {
                Full = true;
                Console.WriteLine("Ваш инвентарь полон!");
            }
            return Full;
        }
        /// <summary>
        /// Добавляет выбранный предмет в инветарь(в конце всегда указывается 
        /// количество занятых карманов!)
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Inv"></param>
        /// <param name="BusyCell"></param>
        static public void Add(dynamic item, ref dynamic [] Inv, ref int BusyCell)
        {
            CheckFull(ref BusyCell);
            if (BusyCell < Inv.Length && BusyCell != 0 && !Full)
            {
                Inv[BusyCell] = item;
                BusyCell++;
            }
        }
        /// <summary>
        /// Выбрасывает последний предмет из камрана
        /// </summary>
        /// <param name="Inv"></param>
        /// <param name="BusyCell"></param>
        static public void PullOut(ref dynamic[] Inv, ref int BusyCell)
        {
            if (BusyCell > 1)
            {
                BusyCell--;
            }
            if (BusyCell < Inv.Length && BusyCell >= 1)
            {
                Inv[BusyCell] = new Item();
            }
        }
        /// <summary>
        /// Начисляет денег на ваш счёт
        /// </summary>
        /// <param name="cheсk"></param>
        public void GoldUp(int cheсk, Player player)
        {
            player.Inv[0] += cheсk;
        }
        /// <summary>
        /// Снимает деньги со счёта
        /// </summary>
        /// <param name="cheсk"></param>
        public void GoldDown(int cheсk, Player player)
        {
            player.Inv[0] -= cheсk;
        }
    }
}
