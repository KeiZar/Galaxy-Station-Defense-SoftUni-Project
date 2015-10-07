using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;



namespace Game
{
     class Game
    {
        #region Global Variables

        private static Random randomGenerator = new Random();
        static Stopwatch stopwatch = new Stopwatch();
        private static List<Towers> towers = new List<Towers>();
        private static List<Enemies> mainEnemies = new List<Enemies>();
        private static int playerStartPossitionX = Console.WindowHeight / 2;
        private static int playerStartPossitionY = Console.WindowWidth / 2;
        private static int playerCurrentPossitionX;
        private static int playerCurrentPossitionY;
        private static bool isRuning = true;
        private static bool startNewGame;
        private static int showMenus; // 0 - main menu, 1 - highscore table, 2 - How to play
        public static int playerMoney = 3000;
        


        #endregion

        #region Functions
        #region RemoveScrollBars()

        private static void RemoveScrollBars() // Sets window size and locks it in place.
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 100;
            Console.BufferHeight = 50;
            Console.BufferWidth = 100;
        }

        #endregion

        #region MenuControl()

        private static void MenuControl(ConsoleKey key) // TODO: Needs adjusting with Menu screens
        {
            /*
            While in Main menu controls are:
            Z - start new game
            X - Highscore Table
            C - How to play
            V - Exit game/back button
            */
            Console.Clear();
            Console.SetCursorPosition(45, 20);
            Console.WriteLine("Press Z - Start New Game");
            Console.SetCursorPosition(45, 22);
            Console.WriteLine("Press X - Highscore Table");
            Console.SetCursorPosition(45, 24);
            Console.WriteLine("Press C - How to play");
            Console.SetCursorPosition(45, 26);
            Console.WriteLine("Press V - Exit game/back button");
            if (key == ConsoleKey.Z)
            {
                startNewGame = true;
                mainEnemies.Clear();
                Enemies.enemiesKilled = 0;
                towers.Clear();
                stopwatch.Reset();
                stopwatch.Stop();
                Console.CursorVisible = true;
                Console.Clear();
            }
            if (key == ConsoleKey.X)
            {
                // TODO: Show highscore table

                if (showMenus == 0 || showMenus == 2)
                {
                    showMenus = 1;
                    Console.Clear();
                    ShowHighscore();
                }
            }
            if (key == ConsoleKey.C)
            {
                // TODO: Show "How to play screen"
                if (showMenus == 0 || showMenus == 1)
                {
                    showMenus = 2;
                    Console.Clear();
                    ShowControls();
                }
            }
            if (key == ConsoleKey.V)
            {
                if (showMenus == 0)
                {

                    isRuning = false; // This kills the console.
                    Environment.Exit(0);
                }
                if (showMenus == 1 || showMenus == 2)
                {
                    showMenus = 0;
                    Console.Clear();
                    Console.SetCursorPosition(45, 20);
                    Console.WriteLine("Press Z - Start New Game");
                    Console.SetCursorPosition(45, 22);
                    Console.WriteLine("Press X - Highscore Table");
                    Console.SetCursorPosition(45, 24);
                    Console.WriteLine("Press C - How to play");
                    Console.SetCursorPosition(45, 26);
                    Console.WriteLine("Press V - Exit game/back button");

                }

            }
        }

        #endregion

        #region ShowHighscore()

        private static void ShowHighscore()
        {
            int writerX = 40;
            int writerY = 20;
            Console.SetCursorPosition(writerX, writerY - 1);
            Console.WriteLine("***HIGHSCORE TABLE***");
            StreamReader highscoreReader = new StreamReader(@"..\..\highscore.txt");
            string reader;


            using (highscoreReader)
            {
                do
                {
                    reader = highscoreReader.ReadLine();
                    Console.SetCursorPosition(writerX, writerY);
                    Console.WriteLine("{0}", reader);
                    writerY++;

                } while (reader != null);
            }
        }

        #endregion

        #region WriteHighscore()

        private static void WriteHighscore(string playerName, int playerMoney) // Use this when game has finished to write the new highscore.
        {
            /*
            Basic highscore writer to file.
            Will be implemented more function when other things are ready.
            */

            StreamReader highscoreReader = new StreamReader(@"..\..\highscore.txt");

            bool hasPlayerDied = false;
            int counter = 0;

            using (highscoreReader)
            {
                while (highscoreReader.ReadLine() != null)
                {
                    counter++;
                }
            }
            if (counter >= 0)
            {
                counter++;
                File.AppendAllLines(@"..\..\highscore.txt", new[] { string.Format("{0}) {1} - {2}", counter, playerName, playerMoney) });
            }

        }

        #endregion

        #region DrawPlayerMovement

        private static void DrawPlayerMovement()
        {

            Console.SetCursorPosition(playerStartPossitionX, playerStartPossitionY);
        }

        #endregion

        #region PlaceTowers()

        private static void PlaceTowers(List<Towers> towers)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                MovePlayer(key.Key);
                DrawPlayerMovement();


                if (key.Key == ConsoleKey.NumPad1)
                {
                    bool couldAdd = Towers.CouldAddTowerCheck(playerCurrentPossitionX, playerCurrentPossitionY, towers);
                    if (couldAdd)
                    {

                        if (playerMoney >= 100)
                        {
                            towers.Add(new Towers(1, 3, 20, true, 3, false, playerCurrentPossitionX,
                                playerCurrentPossitionY, 100));
                            playerMoney -= 100;
                        }
                    }
                    else
                    {
                        Console.Beep();
                    }
                    Towers.TowerPlacement(towers);
                    playerCurrentPossitionX = Console.CursorLeft;
                    playerCurrentPossitionY = Console.CursorTop;
                }
                if (key.Key == ConsoleKey.NumPad2)
                {
                    bool couldAdd = Towers.CouldAddTowerCheck(playerCurrentPossitionX, playerCurrentPossitionY, towers);
                    if (couldAdd)
                    {
                        if (playerMoney >= 200)
                        {
                            towers.Add(new Towers(2, 7, 20, true, 3, false, playerCurrentPossitionX,
                                playerCurrentPossitionY, 200));
                            playerMoney -= 200;
                        }
                    }
                    else
                    {
                        Console.Beep();
                    }
                    Towers.TowerPlacement(towers);
                    playerCurrentPossitionX = Console.CursorLeft;
                    playerCurrentPossitionY = Console.CursorTop;
                }
                if (key.Key == ConsoleKey.NumPad3)
                {
                    bool couldAdd = Towers.CouldAddTowerCheck(playerCurrentPossitionX, playerCurrentPossitionY, towers);
                    if (couldAdd)
                    {
                        if (playerMoney >= 200)
                        {
                            towers.Add(new Towers(3, 7, 20, true, 3, false, playerCurrentPossitionX,
                                playerCurrentPossitionY, 200));
                            playerMoney -= 200;
                        }
                    }
                    else
                    {
                        Console.Beep();
                    }
                    Towers.TowerPlacement(towers);
                    playerCurrentPossitionX = Console.CursorLeft;
                    playerCurrentPossitionY = Console.CursorTop;
                }
                if (key.Key == ConsoleKey.NumPad4)
                {
                    bool couldAdd = Towers.CouldAddTowerCheck(playerCurrentPossitionX, playerCurrentPossitionY, towers);
                    if (couldAdd)
                    {
                        if (playerMoney >= 300)
                        {
                            towers.Add(new Towers(4, 7, 20, true, 3, false, playerCurrentPossitionX,
                                playerCurrentPossitionY, 300));
                            playerMoney -= 300;
                        }
                    }
                    else
                    {
                        Console.Beep();
                    }
                    Towers.TowerPlacement(towers);
                    playerCurrentPossitionX = Console.CursorLeft;
                    playerCurrentPossitionY = Console.CursorTop;
                }
            }
        }


        #endregion

        #region MovePlayer

        private static void MovePlayer(ConsoleKey key)
        //Player movement - needs adjusting if place size bigger then 1 symbol TODO: Detect collision with station!
        {
            if (key == ConsoleKey.UpArrow)
            {
                if (playerCurrentPossitionY > 3)
                {
                    playerCurrentPossitionY -= 1;
                }

            }
            if (key == ConsoleKey.DownArrow)
            {
                if (playerCurrentPossitionY < Console.WindowHeight - 4)
                {
                    playerCurrentPossitionY += 1;
                }

            }
            if (key == ConsoleKey.LeftArrow)
            {
                if (playerCurrentPossitionX > 2)
                {
                    playerCurrentPossitionX -= 1;
                }
            }
            if (key == ConsoleKey.RightArrow)
            {
                if (playerCurrentPossitionX < Console.WindowWidth - 6)
                {
                    playerCurrentPossitionX += 1;

                }
            }
        }

        #endregion

        #region DisposeTheDeadEnemies

        private static void DisposeTheDeadEnemies(ref List<Enemies> enemies)
        {
            enemies.RemoveAll(p => p.IsAlive == false);
        }

        #endregion

        

        static void ShowControls()
        {

            string controls = @"
            Place towers anywhere on the field to protect the station.
                       
            NumPad 1 - Tower type 1
            NumPad 2 - Tower Type 2
            Numpad 3 - Tower Type 3
            Numpad 4 - Tower Type 4";

            Console.WriteLine("{0}", controls);

        }
        #endregion



        private static void Main()
        {
            RemoveScrollBars();

            while (isRuning)
            {
                //Prevents Console getting stuck on waiting for a key press, it only triggered when a key is pressed.
                if (!startNewGame)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        MenuControl(keyInfo.Key);
                    }
                }
                if (startNewGame)
                {
                    
                    DrawStation();

                    stopwatch.Start();
                 

                    //First phase: Placing the towers
                    while (stopwatch.ElapsedMilliseconds <= 20000)
                    // 20 sec to place the towers before the creeps spawn.
                    {
                        Console.SetCursorPosition(82, 42);
                        Console.WriteLine("Time(20 sec): " + (stopwatch.ElapsedMilliseconds / 1000));
                        Console.SetCursorPosition(2, 44);
                        Console.WriteLine("Money: " + playerMoney);
                        Console.SetCursorPosition(playerCurrentPossitionX, playerCurrentPossitionY);
                        PlaceTowers(towers);
                        
                    }
                    stopwatch.Stop();
                    stopwatch.Reset();
                    stopwatch.Start();
                    Console.Clear();
                    Console.CursorVisible = false;


                    var creepSpawn = new Timer(e => Enemies.WaveInitialization(3 + randomGenerator.Next(0, 3), ref mainEnemies), null,
                            TimeSpan.Zero, TimeSpan.FromSeconds(10)); //Creeps spawn every 10 seconds.
                    bool isInitializedWave = false;

                    //Second phase: fighting with the creeps.
                    while (stopwatch.ElapsedMilliseconds <= 60000)
                    // 60 sec to fight with the creeps before the game end.
                    {
                        DrawStation();
                        Towers.TowerPlacement(towers);
                        if (!isInitializedWave)
                        {
                            Enemies.WaveInitialization(2, ref mainEnemies);
                            //Manual initialization of the wave for the first time.
                            isInitializedWave = true;
                        }


                        //Print WaveDuration,Score and Money
                        Console.SetCursorPosition(75, 42);
                        Console.WriteLine("Wave duration: " + (60 - (stopwatch.ElapsedMilliseconds / 1000)));
                        Console.SetCursorPosition(2, 42);
                        Console.WriteLine("Score: " + Enemies.enemiesKilled * 100);
                        Console.SetCursorPosition(2, 44);
                        Console.WriteLine("Money: " + playerMoney);
                        for (int i = 0; i < mainEnemies.Count; i++)
                        {
                            Enemies.DrawEnemy(mainEnemies[i],ref playerMoney);
                        }
                        Thread.Sleep(500);

                        Towers.TowerRangeCheck(towers, ref mainEnemies);

                        DisposeTheDeadEnemies(ref mainEnemies);
                        //DrawEveryThing(); *Not ready yet ...
                        //Thread.Sleep(500);
                        Console.Clear();


                    }
                    creepSpawn.Dispose();
                    //End of the Game

                    Console.SetCursorPosition(30, 12);
                    Console.WriteLine("Please enter you name:");
                    Console.SetCursorPosition(30, 13);
                    string playerName = Console.ReadLine();
                    Console.SetCursorPosition(30, 16);
                    Console.WriteLine("Congratulations your final score is:" +
                                      (playerMoney + Enemies.enemiesKilled * 100));
                    startNewGame = false;
                    playerMoney += Enemies.enemiesKilled * 100;
                    WriteHighscore(playerName, playerMoney);


                }


            }

            Thread.Sleep(100);
        }


        public static void DrawStation()
        {
            int n = 10;
            Console.SetCursorPosition(0,0);
            Console.WriteLine("{0}{1}{0}",
                new string(' ', n),
                new string('-', n));

            Console.WriteLine("{0}/{2}\\{1}",
                new string(' ', n - 1),
                new string(' ', n - 1),
                new string(' ', n));

            Console.WriteLine("{0}\\{2}/{1}",
                new string(' ', n - 1),
                new string(' ', n - 1),
                new string(' ', n));

            Console.WriteLine("{0}{1}{0}",
                new string(' ', n),
                new string('-', n));

            Console.WriteLine("{0}/{2}\\{1}",
                new string(' ', n + 1),
                new string(' ', n - 1),
                new string(' ', n / 2 + 1));

            for (int i = 0; i < n / 2 - 1; i++)
            {
                Console.WriteLine("{0}|{2}|{1}",
                    new string(' ', n + 1),
                    new string(' ', n + 1),
                    new string(' ', n / 2 + 1));
            }

            Console.WriteLine("{0}\\{2}/{1}",
                new string(' ', n + 1),
                new string(' ', n - 1),
                new string(' ', n / 2 + 1));

            Console.WriteLine("{0}{1}{0}",
                new string(' ', n / n + 1),
                new string('-', n * 3 - 2));

            Console.WriteLine(" /{0}\\",
                new string(' ', n * 3 - 2));

            Console.WriteLine(" \\{0}/",
                new string(' ', n * 3 - 2));

            Console.WriteLine("{0}{1}{0}",
                new string(' ', n / n + 1),
                new string('-', n * 3 - 2));

            Console.WriteLine("{0}/{2}\\{1}",
                new string(' ', n + 1),
                new string(' ', n - 1),
                new string(' ', n / 2 + 1));

            for (int i = 0; i < n / 2 - 1; i++)
            {
                Console.WriteLine("{0}|{2}|{1}",
                    new string(' ', n + 1),
                    new string(' ', n + 1),
                    new string(' ', n / 2 + 1));
            }

            Console.WriteLine("{0}\\{2}/{1}",
                new string(' ', n + 1),
                new string(' ', n - 1),
                new string(' ', n / 2 + 1));

            Console.WriteLine("{0}{1}{0}",
                new string(' ', n / n + 1),
                new string('-', n * 3 - 2));

            Console.WriteLine(" /{0}\\",
                new string(' ', n * 3 - 2));

            Console.WriteLine(" \\{0}/",
                new string(' ', n * 3 - 2));

            Console.WriteLine("{0}{1}{0}",
                new string(' ', n / n + 1),
                new string('-', n * 3 - 2));

            Console.WriteLine("{0}/{2}\\{1}",
                new string(' ', n + 1),
                new string(' ', n - 1),
                new string(' ', n / 2 + 1));

            for (int i = 0; i < n / 2 - 1; i++)
            {
                Console.WriteLine("{0}|{2}|{1}",
                    new string(' ', n + 1),
                    new string(' ', n + 1),
                    new string(' ', n / 2 + 1));
            }

            Console.WriteLine("{0}\\{2}/{1}",
                new string(' ', n + 1),
                new string(' ', n - 1),
                new string(' ', n / 2 + 1));

            Console.WriteLine("{0}{1}{0}",
                new string(' ', n),
                new string('-', n));

            Console.WriteLine("{0}/{2}\\{1}",
                new string(' ', n - 1),
                new string(' ', n - 1),
                new string(' ', n));

            Console.WriteLine("{0}\\{2}/{1}",
                new string(' ', n - 1),
                new string(' ', n - 1),
                new string(' ', n));

            Console.WriteLine("{0}{1}{0}",
                new string(' ', n),
                new string('-', n));
        }
    }
}


