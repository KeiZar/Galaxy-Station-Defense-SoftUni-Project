﻿using System;
using System.Collections.Generic;


namespace Game
{
    class Towers
    {
        /* Tower parameters
           !!!!!!!!!!!!!!!!! Range => 3 - short, 5 - medium, 7 - long
           !!!!!!!!!!!!!!!!! Power => 20 - low, 40 - medium, 60 high
           !!!!!!!!!!!!!!!!! Fire rate = 3 - slow, 5 - medium, 7 - high
            Tower type = 1 - short Range, 2 - long range, 3 - long range, 4 - Air only type
        */
        private static int towerType = 0;
        private static int towerRange = 0;
        private static int towerPower = 0;
        private static bool isGround = true;
        private static int fireRate = 0;
        private static bool crowdControl = false;
        private static int towerPosX;
        private static int towerPosY;
        private static int towerPrice = 0;


        public Towers(int towerType, int towerRange, int towerPower, bool isGround, int fireRate, bool crowdControl,int posX, int posY,int towerPrice)
        {
            // TODO
            TowerType = towerType;
            TowerRange = towerRange;
            TowerPower = towerPower;
            IsGround = isGround;
            FireRate = fireRate;
            CrowdControl = crowdControl;
            TowerPosX = posX;
            TowerPosY = posY;
            TowerPrice = towerPrice;

        }

        public Towers()
        {
        }

        public int TowerType { get; set; }
        public int TowerRange { get; set; }
        public int TowerPower { get; set; }
        public bool IsGround { get; set; }
        public int FireRate { get; set; }
        public bool CrowdControl { get; set; }
        public int TowerPosX { get; set; }
        public int TowerPosY { get; set; }
        public int TowerPrice { get; set; }

        #region TowerRangeCheck()
        public static void TowerRangeCheck(List<Towers> towers,ref List<Enemies> enemies)
        {
            for (int i = 0; i < towers.Count; i++)
            {
                for (int j = 0; j < enemies.Count; j++)
                {
                    if (Math.Pow(enemies[j].EnemyPosX - towers[i].TowerPosX, 2) +
                        Math.Pow(enemies[j].EnemyPosY - towers[i].TowerPosY, 2) <=
                        Math.Pow(towers[i].TowerRange, 2))
                    {
                        enemies[j].Health -= 5;
                        switch (enemies[j].EnemyType)
                        {
                            case 0:
                                enemies[j].EnemyImage = " @- ";
                                break;
                            case 1:
                                enemies[j].EnemyImage = " $- ";
                                break;
                            case 2:
                                enemies[j].EnemyImage = " ()- ";
                                break;
                            default:
                                enemies[j].EnemyImage = " !- ";
                                break;
                        }
                    }
                    else
                    {
                        enemies[j].EnemyImage = enemies[j].EnemyImage.Replace('-', ' ');
                    }
                }
            }
        }
        #endregion

        #region CouldAddTowerCheck()
        public static bool CouldAddTowerCheck(int playerCurrentPossitionX, int playerCurrentPossitionY,List<Towers> towers)
        {
            foreach (var tower in towers)
            {
                if ((playerCurrentPossitionX >= tower.TowerPosX - 5 && playerCurrentPossitionX <= tower.TowerPosX + 5) &&
                    (playerCurrentPossitionY >= tower.TowerPosY - 2 && playerCurrentPossitionY <= tower.TowerPosY + 3))
                {
                    return false;
                }
            }
            
            return true;
            
        }
        #endregion

        #region TowerPlacement()
        public static void TowerPlacement(List<Towers> towers)
        {
                 // TowerPattern:
                 //  6 chars width , 3 chars height;
                 // If you want to change it, you should change the CouldAddTowerCheck function accordingly.
            foreach (var tower in towers)
            {
                
                switch (tower.TowerType)
                {
                    case 1:
                        Console.SetCursorPosition(tower.TowerPosX, tower.TowerPosY);
                        Console.Write("  -.- ");
                        Console.SetCursorPosition(tower.TowerPosX, tower.TowerPosY + 1);
                        Console.Write("  (.) ");
                        Console.SetCursorPosition(tower.TowerPosX, tower.TowerPosY + 2);
                        Console.Write("++++++");
                        Console.SetCursorPosition(tower.TowerPosX,tower.TowerPosY);
                        break;

                    case 2:
                        Console.SetCursorPosition(tower.TowerPosX, tower.TowerPosY);
                        Console.Write("  <|> ");
                        Console.SetCursorPosition(tower.TowerPosX, tower.TowerPosY + 1);
                        Console.Write(" <(*)>");
                        Console.SetCursorPosition(tower.TowerPosX, tower.TowerPosY + 2);
                        Console.Write("======");
                        Console.SetCursorPosition(tower.TowerPosX,tower.TowerPosY);
                        break;

                    case 3:
                      Console.SetCursorPosition(tower.TowerPosX, tower.TowerPosY);
                        Console.Write("  - - ");
                        Console.SetCursorPosition(tower.TowerPosX, tower.TowerPosY + 1);
                        Console.Write("  ( ) ");
                        Console.SetCursorPosition(tower.TowerPosX, tower.TowerPosY + 2);
                        Console.Write("++  ++");
                        Console.SetCursorPosition(tower.TowerPosX,tower.TowerPosY);
                        break;
                    case 4:
                        Console.SetCursorPosition(tower.TowerPosX, tower.TowerPosY);
                        Console.Write("   *  ");
                        Console.SetCursorPosition(tower.TowerPosX, tower.TowerPosY + 1);
                        Console.Write("  *** ");
                        Console.SetCursorPosition(tower.TowerPosX, tower.TowerPosY + 2);
                        Console.Write("******");
                        Console.SetCursorPosition(tower.TowerPosX,tower.TowerPosY);
                        break;
                }
            }

        }
        #endregion

    }
}
