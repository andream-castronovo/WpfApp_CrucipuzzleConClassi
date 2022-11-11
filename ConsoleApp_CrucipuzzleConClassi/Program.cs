using System;
using System.IO;
using SharedProject_Crucipuzzle;

namespace ConsoleApp_CrucipuzzleConClassi
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            // Programmato da: Andrea Maria Castronovo - 4°I - Data Inizio: 5/11/2022

            const string DEFAULT_PATH = @"..\..\Crucipuzzle.txt";

            //Console.WriteLine("Hello world");

            //Tabellone t = new Tabellone(DEFAULT_PATH, ' ');
            
            Tabellone t = new Tabellone(2,3);

            for (int iR = 0; iR < t.NumeroRighe; iR++)
            {
                for (int iC = 0; iC < t.NumeroColonne; iC++)
                {
                    Console.Write($"{t[iR,iC].Carattere}" + (iC != t.NumeroColonne-1 ? " " : ""));
                }
                Console.Write($"\n");
            }

            bool repeat = true;

            Console.Write("Scrivi \"quit\" per uscire");
            while(repeat)
            {
                Console.Write("Che parola vuoi cercare? --> ");
                
                string input = Console.ReadLine();
                if (input != "quit")
                {
                    Parola p = t.CercaParola(new Parola(input));

                    if (p != null)
                    {

                        for (int i = 0; i < t.NumeroRighe; i++)
                        {
                            for (int j = 0; j < t.NumeroColonne; j++)
                            {
                                if (t[i, j].Impegnata)
                                {
                                    Console.SetCursorPosition(j * 2, i);
                                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                                    Console.Write(t[i,j].Carattere);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                }
                            }
                        }


                        Console.WriteLine("Parola trovata!");

                        t.ProcessaDirezione(p.Direzione, out int orizzontale, out int verticale);

                        int xCursor = Console.CursorLeft;
                        int yCursor = Console.CursorTop;

                        for (int i = 0; i < p.NumCar; i++)
                        {
                            Console.SetCursorPosition((p.Y + (orizzontale * i)) * 2, p.X + (verticale * i));
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(p.Contenuto[i]);
                        }

                        Console.SetCursorPosition(xCursor, yCursor);
                        Console.BackgroundColor = ConsoleColor.Black;
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
