﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class GalaxyStation
    {
        static void Main()
        {
            int n = 10;

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

