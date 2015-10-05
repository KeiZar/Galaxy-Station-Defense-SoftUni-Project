using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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


        public Towers(int towerType, int towerRange, int towerPower, bool isGround, int fireRate, bool crowdControl,int posX, int posY)
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

        //Write some other methods to be used for fire and stuff.

        //Write usable method for proper attack after range check(including if enemy is ground or air)
        static void TowerRangeCheck(int towerPosX, int towerPosY, List<Enemies> enemy )
        {
            // TODO: Check current tower possition with enemy current posstion.
        }

        public static bool CouldAddTowerCheck(int playerCurrentPossitionX, int playerCurrentPossitionY,List<Towers> towers)
        {
            foreach (var tower in towers)
            {
                if (playerCurrentPossitionX >= tower.TowerPosX - 5 && playerCurrentPossitionX <= tower.TowerPosX + 5 &&
                    playerCurrentPossitionY >= tower.TowerPosY - 2 && playerCurrentPossitionY <= tower.TowerPosY + 3)
                {
                    return false;
                }
            }
            return true;
        }
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

    }
}
