using System;
using System.CodeDom;
using System.IO;
using System.Linq;

namespace SharedProject_Crucipuzzle
{
    internal class Tabellone
    {
        // Programmato da: Andrea Maria Castronovo - 4°I - Data Inizio: 5/11/2022

        // Non posso fare un indicizzatore?
        private Casella[,] _caselle; // TODO: Serve altro, implementarlo

        public Casella this[int r, int c]
        {
            get
            {
                return _caselle[r, c];
            }
            set
            {
                _caselle[r, c] = value;
            }
        }


        public Tabellone() { }

        public Tabellone(int nRighe, int nColonne)
        {
            _caselle = new Casella[nRighe, nColonne];
        }

        public Tabellone(string fileTabellone, char separatoreLettere)
        {

            char[,] caratteri;
            
            try
            {
                caratteri = CaricaMatriceDaFile(fileTabellone, separatoreLettere);
            }
            catch (Exception ex)
            {
                throw new Exception("Problema con il file: " + ex.Message);
            }

            _caselle = new Casella[caratteri.GetLength(0), caratteri.GetLength(1)];

            for (int i = 0; i < caratteri.GetLength(0); i++)
            {
                for (int j = 0; j < caratteri.GetLength(1); j++)
                {
                    _caselle[i, j] = new Casella(caratteri[i, j]);
                }
            }
        }

        char[,] CaricaMatriceDaFile(string file, char separatore)
        {
            #region Converto il file in una stringa lunga
            StreamReader sr = new StreamReader(file);
            string strFile = sr.ReadToEnd().Replace("\r", ""); // \r è il carattere che fa muovere il cursore
            sr.Close();
            #endregion


            string[] righe = strFile.Split('\n'); // Qui ho le righe

            if (strFile.IndexOf("\n") == -1) // Se il file ha una riga sola ci aggiungo lo \n per farlo funzionare
                strFile += "\n";

            int nColonne = strFile.Replace(separatore.ToString(), "").IndexOf('\n'); // L'indice di \n è il numero di caratteri, quindi colonne
            int nRighe = righe.Length;


            char[,] caratteri = new char[nRighe, nColonne];

            for (int i = 0; i < nRighe; i++)
            {
                string[] lettere = righe[i].Split(separatore); // Splitto nuovamente per avere le lettere singole 

                for (int j = 0; j < lettere.Length; j++)
                {
                    caratteri[i, j] = lettere[j][0];
                }
            }
            
            return caratteri;
        }

        // TODO: Altri costruttori

        /// <summary>
        /// -1 se non esiste la matrice
        /// </summary>
        public int NumeroRighe { get => _caselle != null ? _caselle.GetLength(0) : -1; }

        /// <summary>
        /// -1 se non esiste la matrice
        /// </summary>
        public int NumeroColonne { get => _caselle != null ? _caselle.GetLength(1) : -1; }

        //public Parola TrovaParola (Parola par)
        //{
        //    return par;
        //}



        // TODO: Sistemare per interazione in classe e incapsulamento
        #region Metodo cerca parola
        /// <summary>
        /// Cerca l'iniziale della parola da ricercare nel puzzle
        /// </summary>
        /// <param name="parolaDaCercare">Parola da cercare</param>
        /// <param name="lettere">Matrice che contiene tutte le lettere</param>
        /// <param name="btns">Matrice con tutti i bottoni da colorare</param>
        /// <returns>false se nessuna parola è stata trovata; true se anche solo una parola è stata trovata</returns>
        /// <exception cref="Exception">Nessuna parola da cercare</exception>
        public Parola[] CercaParola(Parola parolaDaCercare)
        {
            //AggiornaColori(btns);

            Parola[] p = new Parola[100];
            

            for (int i = 0; i < NumeroRighe; i++) // Due for per lo scorrere della matrice
            {
                for (int j = 0; j < NumeroColonne; j++)
                {
                    if (parolaDaCercare[0] == _caselle[i, j].Carattere) // Rileva l'iniziale della parola scelta
                    {
                        int q = 0;
                        foreach (Direzione d in Enum.GetValues(typeof(Direzione)))
                        {

                            p[q] = ProvaParola(parolaDaCercare, d, i, j);
                            q++;

                        }

                    }
                }
            }

            return p;

        }



        /// <summary>
        /// Metodo per provare a comporre la parola partendo dall'iniziale della parola data
        /// </summary>
        /// <param name="parolaDaCercare">Parola da cercare</param>
        /// <param name="lettere">Matrice contenente le lettere del puzzle</param>
        /// <param name="orizzontale">Direzione orizzontale. Può essere -1, 0 o 1</param>
        /// <param name="verticale">Direzione orizzontale. Può essere -1, 0 o 1</param>
        /// <param name="i">Riga della matrice</param>
        /// <param name="j">Colonna della matrice</param>
        Parola[] ProvaParola(Parola parolaDaCercare, Direzione d, int i, int j)
        {

            int orizzontale = 0; // Sinistra Destra di default
            int verticale = 1;

            Parola[] p = new Parola[100];

            switch (d)
            {
                //case Direzione.Sx_Dx: // Sinistra Destra di default
                //    orizzontale = 0;
                //    verticale = 1;
                //    break;

                case Direzione.Dx_Sx:
                    orizzontale = 0;
                    verticale = -1;
                    break;
                case Direzione.Up_Down:
                    orizzontale = 1;
                    verticale = 0;
                    break;
                case Direzione.Down_Up:
                    orizzontale = -1;
                    verticale = 0;
                    break;
                case Direzione.UpSx_DownDx:
                    orizzontale = 1;
                    verticale = 1;
                    break;
                case Direzione.DownDx_UpSx:
                    orizzontale = -1;
                    verticale = -1;
                    break;
                case Direzione.DownSx_UpDx:
                    orizzontale = -1;
                    verticale = 1;
                    break;
                case Direzione.UpDx_DownSx:
                    orizzontale = 1;
                    verticale = -1;
                    break;
            }


            string parola = "";

            // Se la parola è lunga 1 non entra nel for
            for (int k = 0; k < parolaDaCercare.NumCar; k++)
            {
                if (
                    j + (k * orizzontale) >= NumeroColonne // Controllo in caso esco dalla matrice lateralmente
                    ||
                    i + (k * verticale) >= NumeroRighe // Controllo in caso esco dalla matrice verticalmente
                    ||
                    j + (k * orizzontale) < 0 // Controllo in caso esco dalla matrice lateralmente da sinistra
                    ||
                    i + (k * verticale) < 0 // Controllo in caso esco dalla matrice verticalmente da sinistra
                    )
                    return null;


                // [ righe o colonne + (carattere attuale della parola * la direzione) ]
                char check = _caselle[i + (k * verticale), j + (k * orizzontale)].Carattere;
                
                parola += check; // Compongo la parola lettera per lettera

                //Console.WriteLine(parolaDaCercare.Substring(0,k+1) + " VS " + parola);

                if (parolaDaCercare.Contenuto.Substring(0, k + 1) != parola) // Se una lettera trovata fino ad ora è diversa esci
                    return null;

                if (parola == parolaDaCercare.Contenuto) // Se trovi la parola, ricomincia, colora i bottoni e aggiungi 1 alle parole trovate
                {
                    parolaDaCercare.X = i;
                    parolaDaCercare.Y = j;
                    parolaDaCercare.Direzione = d;
                    return parolaDaCercare;

                }
            }

            return null;

        }
        /// <summary>
        /// L'esistenza di questo metodo dipende dal fatto che non abbiamo studiato le Liste
        /// </summary>
        void SistemaArray<T>(T[] arr)
        {
            int newArrSize = 0;
            int i = 0;
            while (i < arr.Length)
            {

                if (arr[i] == null)
                {
                    newArrSize = i;
                    i = arr.Length;
                }

                i++;
            }

            T[] newArr = new T[newArrSize];

            for (i = 0; i < newArr.Length; i++)
            {

            }

        }
        ///// <summary>
        ///// Aggiorna i bottoni dal colore nuovo a quello vecchio
        ///// </summary>
        ///// <param name="btns"></param>
        //void AggiornaColori(Button[,] btns)
        //{
        //    for (int i = 0; i < btns.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < btns.GetLength(1); j++)
        //        {
        //            if (btns[i, j].Background == COLORE_NUOVO)
        //                btns[i, j].Background = COLORE;
        //        }
        //    }
        //}


        #endregion


    }
}
