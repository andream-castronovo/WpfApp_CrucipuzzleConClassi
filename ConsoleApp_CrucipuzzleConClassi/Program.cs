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

            Tabellone t = new Tabellone(DEFAULT_PATH, ' ');


            for (int iR = 0; iR < t.NumeroRighe; iR++)
            {
                for (int iC = 0; iC < t.NumeroColonne; iC++)
                {
                    Console.Write($"{t[iR,iC].Carattere}" + (iC != t.NumeroColonne-1 ? " " : ""));
                }
                Console.Write($"\n");
            }

            t.CercaParola(new Parola("NOTE"));




            Console.WriteLine("\n\tProgramma terminato.");
            Console.ReadKey(true);
        }
    }
}
