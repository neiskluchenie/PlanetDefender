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
            Console.WindowHeight = 45;
            Console.BufferHeight = 45;
            Console.CursorVisible = false; // скрываем противную мигающую каретку
        }

        static void DrawBorder() // рисуем границы игрового поля
        {
            for (int y = 3; y < 42; y++)
            {
                Console.SetCursorPosition(4, y);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write('[');
            }
            for (int y = 3; y < 42; y++)
            {
                Console.SetCursorPosition(116, y);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(']');
            }
        }

        static void Main()
        {
            Gamefield(); //отрисовка 
            DrawBorder(); //отрисовка границ 

            List<Attacker> aList = new List<Attacker>();    //список, содержащий массивы врагов
            int attackerCount = 0;                          //количество врагов на экране
            int shiftX = 5;                                 // сдвиг врага на координату по х
            Random enemyX = new Random();                   //случайный множитель сдвига

            // таймер для задержки перед появлением врага
            Stopwatch spawnTimer = new Stopwatch(); spawnTimer.Start(); int elapsedTime = 0;

            //таймер для задержки падения врага
            Stopwatch dropTimer = new Stopwatch(); int elapsedTime1=0; dropTimer.Start();
            int tick = 1000; //скорость падения

            Player p = new Player(35, 40); //создаем игрока
            ConsoleKeyInfo userKey; //отслеживаемая нажатая клавиша

            while (true)
            {
                if (attackerCount < 5)                                     //всего звезд на экране
                {
                    elapsedTime = (int)spawnTimer.ElapsedMilliseconds;  //записываем время со старта
                    int spawn = 2000;               //задаем случайный интервал
                    if (elapsedTime > spawn)                            // через который будет появляться звездочка
                    {
                       Attacker enemy = new Attacker(shiftX*enemyX.Next(1,22));        //создаем врага в одном из специально выбранных случайных мест
                       
                        aList.Add(enemy);                                   //добавляем звездочку в список
                        attackerCount++;                                    // увеличиваем отслеживаемое количество звезд на экране
                        spawnTimer.Restart();                           //сбрасываем таймер
                    }
                }

                if (Console.KeyAvailable)               // Если клавиша нажата
                {
                    userKey = Console.ReadKey(true);    // мы передаем информацию о нажатой клавише в нашу переменную

                    switch (userKey.Key)                // и в зависимости от того, какая клавиша нажата
                    {
                        case ConsoleKey.LeftArrow:      //движемся налево
                            p.MoveLeft();
                            break;

                        case ConsoleKey.RightArrow:     //движемся направо
                            p.MoveRight();
                            break;

                        //case ConsoleKey.Escape:         // Если жмем выход
                        //    gameRunning = false;
                        //    break;
                    }
                }

                p.DrawPlayer(); //рисуем игрока

                elapsedTime1 = (int)dropTimer.ElapsedMilliseconds; //записываем прошедшее время в переменную
                if (elapsedTime1 > tick)            // если времени прошло достаточно
                {
                    foreach (Attacker enemy in aList)
                    {
                        enemy.EraseOldCoord(); //затираем по координатам для стирания
                        enemy.Draw(); //отрисовываем врага по заданным координатам
                        enemy.InitOldCoord(); //записываем координаты для стирания
                        enemy.Move(); // даем врагу новые координаты
                    }
                    dropTimer.Restart();

                }
                     
                                
            }
         
        }
    }
}
