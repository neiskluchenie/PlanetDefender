using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetDefender
{
    class Player
    {
        public int locationX;
        public int locationY;
        public int oldLocation;

        public Player(int _x, int _y) //конструктор
        {
            locationX = _x;
            locationY = _y;
        }

        public void MoveLeft()
        {
            if (locationX > 5)           // если мы не выходим за границу экрана
            {
                oldLocation = locationX + 4;
                locationX--;            // двигаемся влево
            }
        }

        public void MoveRight()
        {
            if (locationX < 111)         // если мы не выходим за границу экрана
            {
                oldLocation = locationX;
                locationX++;            //двигаемся вправо
            }
        }

        public void DrawPlayer()
        {
            Console.SetCursorPosition(oldLocation, locationY); //мы затираем старую позицию
            Console.Write(" ");
            Console.SetCursorPosition(locationX, locationY); // и рисуем на новых координатах
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("{=^=}");
        }
    }
}
