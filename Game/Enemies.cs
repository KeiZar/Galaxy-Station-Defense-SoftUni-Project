using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    class Enemies
    {
        private static int health = 100;
        private static bool isAlive = true;
        private static int enemyType = 0;// 0 - Some Type ; 1 - Some Type; 2-Some Type
        private static double enemyPosX = 0;
        private static double enemyPosY = 0;
        private static double enemySpeed = 1;

       
        public int GetHealth()
        {
            return health;
        }
        public int GetEnemyType()
        {
            return enemyType;
        }
        public double GetEnemyPosX()
        {
            return enemyPosX;
        }
        public double GetEnemyPosY()
        {
            return enemyPosY;
        }
        public bool GetIsAlive()
        {
            return isAlive;
        }
        public double GetEnemySpeed()
        {
            return enemySpeed;
        }
        public void SetHealth(int h)
        {
            health = h;
        }
        public void SetEnemyType(int type)
        {
            enemyType = type;
        }
        public void SetEnemyPosX(int posX)
        {
            enemyPosX = posX;
        }
        public void SetEnemyPosY(int posY)
        {
            enemyPosY = posY;
        }
        public void SetIsAlive(bool alive)
        {
            isAlive = alive;
        }
        public void SetEnemySpeed(double speed)
        {
            enemySpeed = speed;
        }

        public Enemies(int type, int healthP, int posX, int posY, bool isAliveParam)
        {
            enemyType = type;
            enemyPosX = posX;
            enemyPosY = posY;
            isAlive = isAliveParam;
            health = healthP;
        }

        public void EnemyMovement(string direction)
        {
            if (health != 0)
            {
                switch (direction)
                {
                    case "Left":
                        enemyPosX -= enemySpeed;
                        break;
                    case "Right":
                        enemyPosX += enemySpeed;
                        break;
                    case "Up":
                        enemyPosY -= enemySpeed;
                        break;
                    case "Down":
                        enemyPosY += enemySpeed;
                        break;
                    default:
                        enemyPosX -= enemySpeed;
                        break;
                }
            }
        }

        public static void DrawEnemy()
        {
            Console.SetCursorPosition((int)enemyPosX, (int)enemyPosY);
            string enemyImage;
            switch (enemyType)
            {
                case 0:
                    enemyImage = ":(";
                    break;
                case 1:
                    enemyImage = "-_-";
                    break;
                case 2:
                    enemyImage = "X_X";
                    break;
                default:
                    enemyImage = ":(";
                    break;
            }
            Console.Write(enemyImage);
        }
    }
}
