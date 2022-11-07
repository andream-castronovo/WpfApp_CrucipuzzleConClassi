using System;
using System.IO;
using SharedProject_Crucipuzzle;

namespace ConsoleApp_CrucipuzzleConClassi
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            const string DEFAULT_PATH = @"..\..\Crucipuzzle.txt";

            Console.WriteLine("Hello world");

            Tabellone t = new Tabellone(DEFAULT_PATH, ' ');


            for (int iR = 0; iR < t.NumeroRighe; iR++)
            {
                for (int iC = 0; iC < t.NumeroColonne; iC++)
                {
                    Console.Write($"{t[iR,iC].Carattere}" + (iC != t.NumeroColonne-1 ? " " : ""));
                }
                Console.Write($"\n");
            }



            Console.WriteLine("\n\tProgramma terminato.");
            Console.ReadKey(true);
        }
    }
}
