using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    class Enemies
    {
        private  int health;
        public  int Health { get; set; }
                
        private  bool isAlive;
        public  bool IsAlive{ get; set; }
                
        private  int enemyType;
        public  int EnemyType { get; set; }// 0 - Some Type ; 1 - Some Type; 2-Some Type
                
        private  double enemyPosX;
        public  double EnemyPosX{ get; set; }
                
        private  double enemyPosY;
        public  double EnemyPosY{ get; set; }
                
        private  double enemySpeed;
        public  double EnemySpeed{ get; set; }

       
        //public int GetHealth()
        //{
        //    return health;
        //}
        //public int GetEnemyType()
        //{
        //    return enemyType;
        //}
        //public double GetEnemyPosX()
        //{
        //    return enemyPosX;
        //}
        //public double GetEnemyPosY()
        //{
        //    return enemyPosY;
        //}
        //public bool GetIsAlive()
        //{
        //    return isAlive;
        //}
        //public double GetEnemySpeed()
        //{
        //    return enemySpeed;
        //}
        //public void SetHealth(int h)
        //{
        //    health = h;
        //}
        //public void SetEnemyType(int type)
        //{
        //    enemyType = type;
        //}
        //public void SetEnemyPosX(int posX)
        //{
        //    enemyPosX = posX;
        //}
        //public void SetEnemyPosY(int posY)
        //{
        //    enemyPosY = posY;
        //}
        //public void SetIsAlive(bool alive)
        //{
        //    isAlive = alive;
        //}
        //public void SetEnemySpeed(double speed)
        //{
        //    enemySpeed = speed;
        //}

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

        public  void DrawEnemy()
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
