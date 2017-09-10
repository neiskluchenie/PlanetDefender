using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;// для таймера

namespace PlanetDefender
{
    class Program
    {
        static void Gamefield() // настраиваем ширину/высоту/название окна
        {
            Console.Title = "Планетозащитник 2017";
            Console.WindowWidth = 120;
            Console.BufferWidth = 120;
            Console.WindowHeight = 40;
            Console.BufferHeight = 40;
            Console.CursorVisible = false; // скрываем противную мигающую каретку
        }

        static void Main()
        {
            Gamefield(); //отрисовка игрового поля

            //Attacker enemy = new Attacker(32); //задаем координаты для врага

            List<Attacker> aList = new List<Attacker>();
            int attackerCount = 0;

            Stopwatch spawnTimer = new Stopwatch(); // таймер для задержки перед появлением звездочек
            spawnTimer.Start();
            int elapsedTime = 0;

            int shiftX = 4;

            while (true)
            {
                if (attackerCount < 5)                                     //всего звезд на экране
                {
                    elapsedTime = (int)spawnTimer.ElapsedMilliseconds;  //записываем время со старта
                    int spawn = 500;               //задаем случайный интервал
                    if (elapsedTime > spawn)                            // через который будет появляться звездочка
                    {
                        //int random = r.Next(5, 75);                     // в случайной координате по х

                        Attacker enemy = new Attacker(shiftX);        //создаем звездочку с заданными координатами и скоростью

                        shiftX = shiftX + 4;
                        aList.Add(enemy);                                   //добавляем звездочку в список
                       attackerCount++;                                    // увеличиваем отслеживаемое количество звезд на экране
                        spawnTimer.Restart();                           //сбрасываем таймер
                    }
                }

                foreach (Attacker enemy in aList)
                {
                    enemy.Draw(); //отрисовываем врага по заданным координатам

                    enemy.InitOldCoord(); //записываем координаты для стирания

                    enemy.Move(); // даем врагу новые координаты
                } 
               
                System.Threading.Thread.Sleep(1000); // задержка

                foreach (Attacker enemy in aList)
                {
                    enemy.EraseOldCoord(); //затираем по координатам для стирания
                }
               
                                
            }
         
        }
    }
}
