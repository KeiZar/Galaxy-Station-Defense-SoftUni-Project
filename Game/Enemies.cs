using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    class Enemies
    {
        private int health;
        private bool isAlive;
        private int enemyType;
        private double enemyPosX;
        private double enemyPosY;
        private double enemySpeed;
        private int enemyScore;


        
        public Enemies(int type, int health, int posX, int posY, bool isAliveb)
        {
            this.EnemyType = type;
            this.EnemyPosX = posX;
            this.EnemyPosY = posY;
            this.IsAlive = isAliveb;
            this.Health = health;
        }

        public int Health { get; set; }
        public bool IsAlive { get; set; }
        public int EnemyType { get; set; }// 0 - Ground type ; 1 - Air Type;
        public double EnemyPosX { get; set; }
        public double EnemyPosY { get; set; }
        public double EnemySpeed { get; set; }
        public int EnemyScore { get; set; }


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

        public void DrawEnemy()
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
