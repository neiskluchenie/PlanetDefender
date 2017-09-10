using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetDefender
{
    class Attacker
    {
        Point[,] square = new Point[4, 2];          //массив координат врага
        Point[,] oldSquare = new Point[4, 2];       //массив для записи координат на стирание

        int shiftX;                                 //сдвиг, должен быть кратен 4

        public Attacker(int _shiftX)                //конструктор, в который мы передаем смещение этого экземпляра по Х
        {
            shiftX = _shiftX;

            for (int y = 0; y < 2; y++)             //задаем координаты для врага
            {
                for (int x = 0; x < 4; x++)
                {
                    square[x, y] = new Point(x+shiftX, y+4);
                }
            }

            for (int y = 0; y < 2; y++)             // инициализируем массив координат для стирания нулями
            {
                for (int x = 0; x < 4; x++)
                {
                    oldSquare[x, y] = new Point(0, 0);
                }
            }
        }

        public void Draw()
        {
            foreach (Point p in square)             //отрисовываем врага по заданным координатам
            {
                if (p.y<35)
                {
                    Console.SetCursorPosition(p.x, p.y);
                    Console.Write("#");
                }
                
            }
        }

        public void InitOldCoord()
        {
            for (int y = 0; y < 2; y++)             //записываем координаты для стирания
            {
                for (int x = 0; x < 4; x++)
                {
                    oldSquare[x, y].x = square[x, y].x;
                    oldSquare[x, y].y = square[x, y].y;
                }
            }
        }

        public void Move()
        {
            foreach (Point p in square)             //даем врагу новые координаты

                if (p.y < 37)
                {
                    { p.y = p.y + 2; }
                }

            
        }

        public void EraseOldCoord()
        {
            foreach (Point p in oldSquare)          //затираем по координатам для стирания
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(" ");
            }
        }
    }
}
