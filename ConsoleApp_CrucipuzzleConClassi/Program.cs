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
            Console.Write(s);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Tipico codice del controllo di input e conversione in Console
        /// </summary>
        /// <param name="n">Risultato controllato e convertito</param>
        /// <param name="messaggio">Messaggio da ripetere in caso di input errato</param>
        /// <param name="min">Valore minimo COMPRESO che il numero deve avere</param>
        /// <param name="max">Valore massimo COMPRESO che il numero deve avere</param>
        static void ControlloInput(out int n, string messaggio, int min, int max)
        {
            bool inOk;
            do
            {
                Console.Write(messaggio);
                inOk = int.TryParse(Console.ReadLine(), out n);

                if (!inOk)
                    ScriviColorato("Input non valido, deve essere un numero intero\n\n", ConsoleColor.Red);
                
                else if (n < min)
                {
                    ScriviColorato($"Il numero non deve essere più picclo di {min}\n\n", ConsoleColor.Red);
                    inOk = false;
                }
                
                else if (n > max)
                {
                    ScriviColorato($"Il numero non deve essere più grande di {max}\n\n" +
                        $"", ConsoleColor.Red);
                    inOk = false;
                }

            } while (!inOk);
        }

        static void ControlloInput(out char s, string messaggio)
        {
            bool inOk;
            do
            {
                Console.Write(messaggio);
                inOk = char.TryParse(Console.ReadLine(), out s);

                if (!inOk)
                    ScriviColorato("Input non valido, deve essere un carattere\n\n", ConsoleColor.Red);

            } while (!inOk);
        }

        static void ComponiTabellone(Tabellone t)
        {
            for (int iR = 0; iR < t.NumeroRighe; iR++)
            {
                for (int iC = 0; iC < t.NumeroColonne; iC++)
                {
                    if (t[iR, iC].Carattere == '-')
                    {
                        bool inOk = false;
                        do
                        {
                            ControlloInput(out char c, $"Inserisci carattere per posizione r{iR} c{iC}: ");
                            try
                            {
                                t[iR, iC].Carattere = c;
                                inOk = true;
                            }
                            catch (Exception ex)
                            {
                                ScriviColorato($"Errore: {ex.Message}\n", ConsoleColor.Red);
                            }
                        } while (!inOk);
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            // Programmato da: Andrea Maria Castronovo - 4°I - Data Inizio: 5/11/2022

            const string DEFAULT_PATH = @"..\..\Crucipuzzle.txt";

            Console.WriteLine("Con quale costruttore vuoi comporre il tabellone: ");
            Console.WriteLine("\t1) Con file");
            Console.WriteLine("\t2) Con righe e colonne");
            Console.WriteLine("\t3) Da zero");

            ControlloInput(out int n, "Risposta (1-3): ", 1, 3);
            Tabellone t = null;
            int r;
            int c;
            switch (n)
            {
                case 1:
                    t = new Tabellone(DEFAULT_PATH, ' ');
                    break;
                case 2:
                    ControlloInput(out r, "Inserisci numero righe: ", 1, 30);
                    ControlloInput(out c, "Inserisci numero colonne: ", 1, 30);

                    t = new Tabellone(r, c);

                    ComponiTabellone(t);
                    break;
                case 3:
                    t = new Tabellone();

                    if (t.NumeroRighe == -1)
                    {
                        ControlloInput(out r, "Inserisci numero righe: ", 1, 30);
                        ControlloInput(out c, "Inserisci numero colonne: ", 1, 30);

                        t.Caselle = new Casella[r, c];
                        ComponiTabellone(t);

                    }
                    
                    break;
            }


            //Console.Clear();
            // Scrittura tabellone a schermo

            Console.Write("\n");

            int xInizioTabellone = Console.CursorLeft;
            int yInizioTabellone = Console.CursorTop;

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



                Console.SetCursorPosition(xCursor, yCursor);

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
                                    Console.SetCursorPosition(j * 2 + xInizioTabellone, i + yInizioTabellone);
                                    if (t[i, j].Nuova)
                                    {
                                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                                        t[i, j].Nuova = false;
                                    }
                                    else
                                    {
                                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                    }
                                    Console.Write(t[i, j].Carattere);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                }
                            }
                        }

                        Console.SetCursorPosition(0, yCursor + 1);
                        Console.BackgroundColor = ConsoleColor.Black;
                        ScriviColorato("Parola trovata!                                                                        ", ConsoleColor.Green);
                        Console.SetCursorPosition(xCursor, yCursor);
                        for (int i = 0; i < Console.WindowWidth; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.SetCursorPosition(xCursor, yCursor);
                    }
                    else
                    {

                        Console.SetCursorPosition(xCursor, yCursor);
                        for (int i = 0; i < Console.WindowWidth; i++)
                        {
                            Console.Write(" ");
                        }
                        ScriviColorato("Parola non trovata                                                ", ConsoleColor.Red);
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
