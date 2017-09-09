using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetDefender
{
    class Program
    {
        static void Main(string[] args)
        {
            Point[,] square = new Point[4, 2]; //создаем массив из объектов типо точка

            for (int y = 0; y < 2; y++) //инициализируем каждый элемент массива координатами
            {
                for (int x = 0; x < 4; x++)
                {
                    square[x, y] = new Point(x, y);
                }
            }

            foreach (Point p in square) //выводим каждую точку массива на экран
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write("#");
            }

            Console.ReadLine();
        }
    }
}
