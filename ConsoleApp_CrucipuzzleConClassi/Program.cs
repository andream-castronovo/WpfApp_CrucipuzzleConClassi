using System;
using System.IO;
using SharedProject_Crucipuzzle;

namespace ConsoleApp_CrucipuzzleConClassi
{
    internal class Program
    {
        static void ScriviColorato(string s, ConsoleColor c)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(s);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void Main(string[] args)
        {
            // Programmato da: Andrea Maria Castronovo - 4°I - Data Inizio: 5/11/2022

            const string DEFAULT_PATH = @"..\..\Crucipuzzle.txt";

            //Console.WriteLine("Hello world");

            //Tabellone t = new Tabellone(DEFAULT_PATH, ' ');

            Tabellone t = new Tabellone(10, 13);

            char[] alfabeto = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            Random random = new Random();
            for (int i = 0; i < t.NumeroRighe; i++)
            {
                for (int j = 0; j < t.NumeroColonne; j++)
                {
                    t[i, j].Carattere = alfabeto[random.Next(0, 26)];
                }
            }



            for (int iR = 0; iR < t.NumeroRighe; iR++)
            {
                for (int iC = 0; iC < t.NumeroColonne; iC++)
                {
                    Console.Write($"{t[iR, iC].Carattere}" + (iC != t.NumeroColonne - 1 ? " " : ""));
                }
                Console.Write($"\n");
            }

            bool repeat = true;

            Console.WriteLine("\nScrivi \"quit\" per uscire");
            while (repeat)
            {
                int xCursor = Console.CursorLeft;
                int yCursor = Console.CursorTop;
                Console.Write("Che parola vuoi cercare? --> ");

                string input = Console.ReadLine();

                if (input != "quit")
                {
                    Parola p = t.CercaParola(new Parola(input));

                    if (p.Trovata)
                    {

                        for (int i = 0; i < t.NumeroRighe; i++)
                        {
                            for (int j = 0; j < t.NumeroColonne; j++)
                            {
                                if (t[i, j].Impegnata)
                                {
                                    Console.SetCursorPosition(j * 2, i);
                                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                                    Console.Write(t[i, j].Carattere);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                }
                            }
                        }



                        t.ProcessaDirezione(p.Direzione, out int orizzontale, out int verticale);


                        for (int i = 0; i < p.NumCar; i++)
                        {
                            Console.SetCursorPosition((p.Y + (orizzontale * i)) * 2, p.X + (verticale * i));
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(p.Contenuto[i]);
                        }

                        Console.SetCursorPosition(0, yCursor + 1);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Parola trovata!");
                        Console.SetCursorPosition(xCursor, yCursor);
                        for (int i = 0; i < Console.WindowWidth; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.SetCursorPosition(xCursor, yCursor);
                    }
                    else
                    {
                        Console.WriteLine("Parola non trovata");
                        
                        Console.SetCursorPosition(xCursor, yCursor);
                        for (int i = 0; i < Console.WindowWidth; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.SetCursorPosition(xCursor, yCursor);

                    }
                }
                else
                {
                    repeat = false;
                }

            }





            Console.WriteLine("\n\tProgramma terminato.");
            Console.ReadKey(true);
        }
    }


}
