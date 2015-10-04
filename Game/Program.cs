using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static int playerStartPossitionX = 0;
        static int playerStartPossitionY = 0;
        static int playerCurrentPossitionX = 0;
        static int playerCurrentPossitionY = 0;
        static bool isRuning = true;
        static bool startNewGame = false;
        static int showMenus = 0; // 0 - main menu, 1 - highscore table, 2 - How to play
        private static string playerScore = "Highscore! YAAA!";

        static void RemoveScrollBars() // Sets window size and locks it in place.
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 100;
            Console.BufferHeight = 50;
            Console.BufferWidth = 100;
        }

        private static void MenuControl(ConsoleKey key) // TODO: Needs adjusting with Menu screens
        {
            /*
            While in Main menu controls are:
            Z - start new game
            X - Highscore Table
            C - How to play
            V - Exit game/back button
            */
            if (key == ConsoleKey.Z)
            {
                startNewGame = true;
            }
            if (key == ConsoleKey.X)
            {
                // TODO: Show highscore table

                if (showMenus == 0 || showMenus == 2)
                {
                    showMenus = 1;
                    ShowHighscore();
                }
            }
            if (key == ConsoleKey.C)
            {
                // TODO: Show "How to play screen"
                if (showMenus == 0 || showMenus == 1)
                {
                    showMenus = 2;
                }
            }
            if (key == ConsoleKey.V)
            {
                if (showMenus == 0)
                {
                    isRuning = false; // This kills the console.
                }
                if (showMenus == 1 || showMenus == 2)
                {
                    showMenus = 0; 
                }
                
            }
        }

        private static void ShowHighscore()
        {

            Console.WriteLine("**HIGHSCORE TABLE**");
            StreamReader highscoreReader = new StreamReader(@"..\..\highscore.txt");
            string reader;
            Console.WriteLine(showMenus);
            using (highscoreReader)
            {
                do
                {
                    reader = highscoreReader.ReadLine();

                    Console.WriteLine("{0}", reader);

                } while (reader != null);
            }
            Thread.Sleep(1000); // TODO: REMOVE THIS AT SOME POINT!!!


        }

        static void WriteHighscore() // Use this when game has finished to write the new highscore.
        {
            /*
            Basic highscore writer to file.
            Will be implemented more function when other things are ready.
            */
            
            StreamWriter highscoreWriter = new StreamWriter(@"..\..\highscore.txt");
            bool hasPlayerDied = true;
            using (highscoreWriter)
            {
                do
                {
                    highscoreWriter.WriteLine(playerScore);

                } while (hasPlayerDied);
            }
        } 

        private static void PlaceTowers(ConsoleKey key, Towers tower)
        {
            int towerType;
            if (key == ConsoleKey.NumPad1)
            {
                towerType = 1;
                tower.TowerPlacement(playerCurrentPossitionX, playerCurrentPossitionY, towerType);
            }
            if (key == ConsoleKey.NumPad2)
            {
                towerType = 2;
                tower.TowerPlacement(playerCurrentPossitionX, playerCurrentPossitionY, towerType);
            }
            if (key == ConsoleKey.NumPad3)
            {
                towerType = 3;
                tower.TowerPlacement(playerCurrentPossitionX, playerCurrentPossitionY, towerType);
            }
            if (key == ConsoleKey.NumPad4)
            {
                towerType = 4;
                tower.TowerPlacement(playerCurrentPossitionX, playerCurrentPossitionY, towerType);
            }
        }

        private static void MovePlayer(ConsoleKey key) //Player movement - needs adjusting if station size bigger then 1 symbol TODO: Detect collision with station!
        {
            if (key == ConsoleKey.UpArrow)
            {
                if (playerCurrentPossitionX > Console.WindowHeight)
                {
                    playerCurrentPossitionX--;
                }

            }
            if (key == ConsoleKey.DownArrow)
            {
                if (playerCurrentPossitionX < Console.WindowHeight)
                {
                    playerCurrentPossitionX++;
                }

            }
            if (key == ConsoleKey.LeftArrow)
            {
                if (playerCurrentPossitionY > Console.WindowWidth)
                {
                    playerCurrentPossitionY--;
                }
            }
            if (key == ConsoleKey.RightArrow)
            {
                if (playerCurrentPossitionY < Console.WindowWidth)
                {
                    playerCurrentPossitionY++;

                }
            }
        }
      
        static void WaveInitialization(List<Enemies> enemies)//Initialize the Wave of Enemies(Top Left)
        {
            Random randGen = new Random();

            for (int i = 0; i < enemies.Count; i++)
            {
                int randPosX = randGen.Next(1, 49);
                int randType = randGen.Next(0, 2);
                enemies.Add(new Enemies(randType, 100, randPosX, 1, true));

            }
        }

        static void WaveMovement(List<Enemies> enemies, string direction) //Moves the enemies in the wave // Move direction should be random!
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].IsAlive)
                {
                    enemies[i].EnemyMovement(direction);
                }
                if (enemies[i].Health <= 0)
                {
                    enemies[i].IsAlive = false;
                }
            }
        }

        static void Main(string[] args)
        {
            RemoveScrollBars();

            // PLACEHOLDERS!!!
            List<Enemies> mainEnemies = new List<Enemies>();
            Towers tower = new Towers();
            string someDirection = "Down";
            // PLACEHOLDERS!!!
            


            while (isRuning)
            {

                /*
                Everything is more or less a lot of if-else checks and a lot of Console.Writeline();
                Be mindful of the other parts of the code and ask questions on Skype or if you need help!
                We will make a lot of static methods and we will only write them in this file. No OOP elements!
                */

                
                //Prevents Console getting stuck on waiting for a key press, it only triggered when a key is pressed.
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (startNewGame)
                    {
                        MovePlayer(keyInfo.Key);
                        PlaceTowers(keyInfo.Key, tower); // Implement towers!
                     }
                    else
                    {
                        MenuControl(keyInfo.Key);
                    }


                }
                /*
                TODO: Towers
                TODO: Implement 4 different towers [See Trello for more details]
                */

                Console.Clear();
                // TODO: Implement "DrawMenu();" else Console.Clear(); just wipes the console entirely

                /*
                CHECK MENU CONTROL METHOD ABOVE!!!
                TODO: Menu
                TODO: Implement "Start new game"
                TODO: Implement "Highscore" option
                TODO: Implement "How to play" option
                TODO: Implement stop function [Use "Environment.Exit(-1);" in menu]
                */



                /*
                TODO: Enemy movement
                TODO: Implement enemy spawn and movement
                TODO: Implement enemy HP, Points and gold drop                
                TODO: Implement ground and air only enemies
                */
                WaveInitialization(mainEnemies);
                WaveMovement(mainEnemies, someDirection); // Enemies go down on console when spawned - temporary - change someDirection for anther direction

                /*
                TODO: Map
                TODO: Implement Station possition on console + HP of station
                TODO: Player start possition + player collision with station - see player movement method.
                */

                /*
                TODO: At game end, show on screen score and first 3 high score possitions!
                TODO: If new score is > from current highscores, add and move possitions!
                TODO: Write to file the highscores!
                */

                Thread.Sleep(60);
            }
        }
    }
}
