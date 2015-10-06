using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Game
{
    class Enemies
    {
        private static int health;
        private bool isAlive;
        private int enemyType;
        private static double enemyPosX;
        private static double enemyPosY;
        private double enemySpeed;
        private int enemyScore;
        private string enemyImage;
        public static int enemiesKilled = 0;


        public void CheckAlive(object o)
        {
            if (IsAlive)
            {
                EnemyPosX--;
            }
            else
            {
                IsAlive = false;
            }

        }
        public Enemies(int type, int health, int posX, int posY, bool isAlive)
        {
            EnemyType = type;
            switch (EnemyType)
            {
                case 0:
                    EnemyImage = " @ ";
                    break;
                case 1:
                    EnemyImage = " $ ";
                    break;
                case 2:
                    EnemyImage = " () ";
                    break;
                default:
                    EnemyImage = " ! ";
                    break;
            }

            EnemyPosX = posX;
            EnemyPosY = posY;
            IsAlive = isAlive;
            Health = health;
            Timer move = new Timer(CheckAlive, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));//Creeps move every 2 seconds.
        }



        public int Health { get; set; }
        public bool IsAlive { get; set; }
        public int EnemyType { get; set; }// 0 - Ground type ; 1 - Air Type;
        public double EnemyPosX { get; set; }
        public double EnemyPosY { get; set; }
        public double EnemySpeed { get; set; }
        public int EnemyScore { get; set; }
        public string EnemyImage { get; set; }

        #region DrawEnemy()
        public static void DrawEnemy(Enemies enemyObj)
        {

            Console.SetCursorPosition(Math.Min(90, (int)enemyObj.EnemyPosX), Math.Min(45, (int)enemyObj.EnemyPosY));
            if (enemyObj.Health <= 0)
            {
                enemyObj.EnemyImage = "DEAD";
                enemyObj.IsAlive = false;
                enemiesKilled++;
            }
            Console.Write(enemyObj.EnemyImage);

        }
        #endregion




        //public static void DrawEnemies(ref List<Enemies> enemies)
        //{
        //    for (int i = 0; i < enemies.Count; i++)
        //    {


        //        Console.SetCursorPosition(Math.Min(90,(int)enemies[i].EnemyPosX), Math.Min(45,(int)enemies[i].EnemyPosY));
        //        switch (enemies[i].EnemyType)
        //        {
        //            case 0:
        //                enemies[i].EnemyImage = " @ ";
        //                break;
        //            case 1:
        //                enemies[i].EnemyImage = " $ ";
        //                break;
        //            case 2:
        //                enemies[i].EnemyImage = " () ";
        //                break;
        //            default:
        //                enemies[i].EnemyImage = " ! ";
        //                break;
        //        }
        //        Console.Write(enemies[i].EnemyImage);
        //        Thread.Sleep(100);
        //    }


        //}

        #region WaveInitialization()
        public static void WaveInitialization(int enemiesAmount, ref List<Enemies> enemies)//Initialize the Wave of Enemies(Top Left)
        {
            Random randGen = new Random();


            int randPosY = randGen.Next(5, 31);
            int randType = randGen.Next(0, 3);
            if (enemies.Count == 0)
            {
                enemies.Add(new Enemies(randType, 100, Console.WindowWidth - 5, randPosY, true));
            }

            {
                int counter = 0;
                while (counter < enemiesAmount)
                {
                    for (int j = 0; j < enemies.Count; j++)
                    {
                        randPosY = randGen.Next(5, 31);
                        randType = randGen.Next(0, 2);
                        if (randPosY < enemies[j].EnemyPosY || randPosY > enemies[j].EnemyPosY + 3)
                        {
                            enemies.Add(new Enemies(randType, 100, Console.WindowWidth - 5, randPosY, true));
                            counter++;
                            break;
                        }
                    }

                }
            }

        }
        #endregion
    }
}
