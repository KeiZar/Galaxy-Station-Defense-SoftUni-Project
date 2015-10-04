using System;
using System.Collections.Generic;
using System.Linq;
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


        public Towers(int towerType, int towerRange, int towerPower, bool isGround, int fireRate, bool crowdControl)
        {
            // TODO
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

        public void TowerPlacement(int possitionX, int possitionY, int towerType)
        {
            // TODO: JUST DO IT! ITS IN THE NAME!
        }

    }
}
