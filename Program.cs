using System;
using System.Diagnostics;
using System.IO;

namespace funkcje_klasy
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Dodaj(2, 4, "IMIE");
        //    Console.ReadKey();

        //}
        //static void Dodaj(int a, int b, string tekst)
        //{
        //    int wynik = a + b;
        //    Console.WriteLine("Wynik: " + wynik + " " + tekst);
        //}


        //static void Main(string[] args)
        //{
        //    Console.WriteLine(Dodaj(2, 3));
        //}
        //static int Dodaj(int a, int b)
        //{
        //    int wynik = a + b;

        //    return wynik;
        //}


        // CALCULATOR


        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Write first value");
        //    double a = double.Parse(Console.ReadLine());          
        //    Console.WriteLine("Write first value");
        //    double c = double.Parse(Console.ReadLine());
        //    Console.WriteLine(Calculator(a,c));

        //}
        //static double Calculator(double a, double c)
        //{
        //    Console.WriteLine("Write sing to operation");
        //    char b = char.Parse(Console.ReadLine());
        //    double bad = 0;
        //    switch(b)
        //    {
        //        case '+':
        //            {
        //                return a + c;
        //            }
        //        case '-':
        //            {
        //                return a - c;
        //            }
        //        case '/':
        //            {
        //                return a / c;
        //            }
        //        case '*':
        //            {
        //                return a * c;
        //            }
        //        default:
        //            {
        //                return bad;
        //            }
        //    }           
        //}


        //static void Main(string[] args)
        //{
        //    int a = 5;
        //    Console.WriteLine("Before: " + a);
        //    Test(a);
        //    Console.WriteLine("After: " + a);

        //}
        //static void Test(int a)
        //{
        //    a += 5;
        //    Console.WriteLine("In function: " + a);

        //}

        //static void Main(string[] args)
        //{
        //    int a = 5;
        //    Console.WriteLine("Before: " + a);
        //    Test(ref a);
        //    Console.WriteLine("After: " + a);
        //}
        //static void Test(ref int a)
        //{
        //    a += 5;
        //    Console.WriteLine("In function: " + a);
        //}



        //static void Main(string[] args)
        //{
        //    int a; 
        //    Test(out a);
        //    Console.WriteLine("After: " + a);
        //}
        //static void Test(out int b)
        //{
        //    b = 5;
        //    b += 5;
        //    Console.WriteLine("In function: " + b);

        //}


        //static void Main(string[] args)
        //{
        //    int[] tab = new int[2];
        //    tab[0] = 5;
        //    tab[1] = 2;
        //    Console.WriteLine("Before: " + tab[0] + " , " + tab[1]);
        //    Test(tab);
        //    Console.WriteLine("After: " + tab[0] + " , " + tab[1]);
        //}
        //static void Test(int[] tab) //// <-- THE CAME TAB AS ABOVE
        //{
        //    tab[0] = 555;
        //    tab[1] = 222;
        //    Console.WriteLine("In function: " + tab[0] + " , " + tab[1]);

        //}



        //static void Main(string[] args)
        //{
        //    int[] tab = new int[2];
        //    tab[0] = 5;
        //    tab[1] = 2;
        //    Console.WriteLine("Before: " + tab[0] + " , " + tab[1]);
        //    Test(tab);
        //    Console.WriteLine("After: " + tab[0] + " , " + tab[1]);
        //}
        //static void Test(int[] tab) //// <-- JUST ADRESS TO TAB 
        //{
        //    tab = new int[2]; //// <-- NEW TAB 
        //    tab[0] = 555;
        //    tab[1] = 222;
        //    Console.WriteLine("In function: " + tab[0] + " , " + tab[1]);

        //}

        // GAME:
        static void Main(string[] args)
        {
            bool game = true;
            int level = 0;
            int level1;
            string name;
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Write your name");
            name = Console.ReadLine();

            
            
            do
            {
                level1 = StartIPoziom(level, level);

                char[,] tab = new char[20, 20];
                int position1 = 0;
                int position2 = 0;
                int[,] tabOfobstacles = new int[20, 20];
                Random random = new Random();
                Random random2 = new Random();
                stopwatch.Start();

                tab = UzupełnienieTablicy(tab, random, random2, level1);
                ZapisaniePrzeszkód(tab,tabOfobstacles);
                
                do
                {
                    Console.WriteLine("Move the 'O' whit use 'W,A,S,D' = ' ^,<,v,>'");
                    
                    char[,] tab1 = (char[,])tab.Clone();
                    tab1[19, 19] = 'X';
                    tab1[position1, position2] = 'O';

                    Wypisanie(tab1); 
                    Sing(ref position1, ref position2);
                    
                    Console.Clear();
                    
                    for (int i = 0; i <20; i++)
                    {                        
                        if (tabOfobstacles[position1,position2] == 1)
                        {
                            Console.WriteLine(name + ", YOU HIT THE MINE, YOU LOST\n");
                            game = false;
                            stopwatch.Stop();
                            Console.WriteLine("your time is: " + stopwatch.Elapsed.Seconds.ToString() + " seconds");
                            stopwatch.Reset();
                            break;
                        }
                    }
                    if (position1 == 19 && position2 == 19)
                    {
                        Console.WriteLine("CONGRATULATIONS " + name + ", YOU WIN THE GAME\n");
                        stopwatch.Stop();
                        Console.WriteLine("your time is: " + stopwatch.Elapsed.Seconds.ToString() + " seconds");
                        stopwatch.Reset();
                        AddHighScore(name, DateTime.Now.ToString(), stopwatch.Elapsed.Seconds.ToString(), level1.ToString());
                        break;
                    }
                } while (game == true);
                
                game = Zakończenie(game);

            } while (game == true);





            static int StartIPoziom(int level, int level1)
            {
                Console.WriteLine("This is test game");
                Console.WriteLine("You have got five levels of hard to choose {1,2,3,4,5}");
                Console.WriteLine("Choose oneand and entre");
                level = int.Parse(Console.ReadLine());
                switch (level)
                {
                    case 1:
                        {
                            level1 = 20;
                            break;
                        }
                    case 2:
                        {
                            level1 = 40;
                            break;
                        }
                    case 3:
                        {
                            level1 = 60;
                            break;
                        }
                    case 4:
                        {
                            level1 = 80;
                            break;
                        }
                    case 5:
                        {
                            level1 = 100;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                Console.Clear();
                return level1;
                
            }

            static char[,] UzupełnienieTablicy(char[,] tab, Random random, Random random2,int level1)
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        tab[i, j] = ' ';
                    }
                }
                for (int i = 0; i < level1; i++)
                {
                    tab[random.Next(0, 19), random2.Next(0, 19)] = '+';
                }
                return tab;
            }
            static void ZapisaniePrzeszkód(char[,] tab, int[,] tabOfobstacles)
            {
                for(int i = 0; i < 20; i ++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        char c = tab[i, j];
                        if (c == '+')
                        {
                            tabOfobstacles[i, j] = 1;
                        }
                    }
                }
            }

            static void Wypisanie(char[,] tab1)
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        Console.Write(tab1[i, j]);
                    }
                    Console.WriteLine();
                }
            }

            static void Sing(ref int position1, ref int position2)
            {
                var odp = Console.ReadLine();
                char sign = odp[0];
                if (sign != 'a' && sign != 's' && sign != 'd' && sign != 'w')
                {
                    Console.Clear();
                }

                switch (sign)
                {
                    case 'a':
                        {
                            position2--;
                            break;
                        }
                    case 's':
                        {
                            position1++;
                            break;
                        }
                    case 'd':
                        {
                            position2++;
                            break;
                        }
                    case 'w':
                        {
                            position1--;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                if (position1 == -1) { position1 = 0; }
                if (position1 == 20) { position1 = 19; }
                if (position2 == -1) { position2 = 0; }
                if (position2 == 20) { position2 = 19; }
            }
            static bool Zakończenie(bool game)
            {
                Console.WriteLine("If you want to play again - press 'y'");
                Console.WriteLine("If you don't want to play again - press 'n'");
                string s = Console.ReadLine();
                if (s == "y") { game = true; }
                else { game = false; }
                Console.Clear();
                return game;
            }
            static void AddHighScore(string name, string date, string Time, string level1)
            {
                using (StreamWriter streamWriter = File.AppendText("high_scores.txt"))
                {
                    streamWriter.WriteLine(name + " | " + date + " | " + Time + " | " + level1);
                }
            }
        }

        private static void AddHighScore(string name, Func<string> toString1, string v, Func<string> toString2)
        {
            throw new NotImplementedException();
        }
    }
}


