using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject_Crucipuzzle
{
    internal class Tabellone
    {

        // Non posso fare un indicizzatore?
        private Casella[,] _caselle; // TODO: Serve altro, implementarlo

        public Casella[,] Caselle { get => _caselle; set => _caselle = value; }

        public Tabellone(int nRighe, int nColonne)
        {

        }

        public Tabellone(string fileTabellone)
        {

        }

        // TODO: Altri costruttori

        /// <summary>
        /// -1 se non esiste la matrice
        /// </summary>
        public int NumeroRighe { get => _caselle != null ? _caselle.GetLength(0) : -1;}

        /// <summary>
        /// -1 se non esiste la matrice
        /// </summary>
        public int NumeroColonne { get => _caselle != null ? _caselle.GetLength(1) : -1; }

        public Parola TrovaParola (Parola par)
        {
            return par;
        }



        // TODO: Sistemare per interazione in classe e incapsulamento
        #region Metodo cerca parola
        ///// <summary>
        ///// Cerca l'iniziale della parola da ricercare nel puzzle
        ///// </summary>
        ///// <param name="parolaDaCercare">Parola da cercare</param>
        ///// <param name="lettere">Matrice che contiene tutte le lettere</param>
        ///// <param name="btns">Matrice con tutti i bottoni da colorare</param>
        ///// <returns>false se nessuna parola è stata trovata; true se anche solo una parola è stata trovata</returns>
        ///// <exception cref="Exception">Nessuna parola da cercare</exception>
        //bool CercaIniziale(string parolaDaCercare, string[,] lettere, Button[,] btns)
        //{
        //    if (parolaDaCercare == "")
        //        throw new Exception("Non hai inserito una parola");

        //    AggiornaColori(btns);

        //    int paroleTrovate = 0;
        //    for (int i = 0; i < lettere.GetLength(0); i++) // Due for per lo scorrere della matrice
        //    {
        //        for (int j = 0; j < lettere.GetLength(1); j++)
        //        {
        //            if (parolaDaCercare[0].ToString() == lettere[i, j]) // Rileva l'iniziale della parola scelta
        //            {
        //                //if (parolaDaCercare.Length != 1)
        //                //{
        //                for (int dX = -1; dX <= 1; dX++) // Due for per girare tutte le direzioni possibili: -1,0,1
        //                {
        //                    for (int dY = -1; dY <= 1; dY++)
        //                    {
        //                        ProvaParola(parolaDaCercare, lettere, btns, dX, dY, i, j, ref paroleTrovate);
        //                    }
        //                }
        //                //}
        //                //else
        //                //{
        //                //    btns[i, j].Background = COLORE_NUOVO;
        //                //}
        //            }
        //        }
        //    }

        //    if (paroleTrovate == 0)
        //        return false;

        //    return true;

        //}



        ///// <summary>
        ///// Metodo per provare a comporre la parola partendo dall'iniziale della parola data
        ///// </summary>
        ///// <param name="parolaDaCercare">Parola da cercare</param>
        ///// <param name="lettere">Matrice contenente le lettere del puzzle</param>
        ///// <param name="orizzontale">Direzione orizzontale. Può essere -1, 0 o 1</param>
        ///// <param name="verticale">Direzione orizzontale. Può essere -1, 0 o 1</param>
        ///// <param name="i">Riga della matrice</param>
        ///// <param name="j">Colonna della matrice</param>
        //void ProvaParola(string parolaDaCercare, string[,] lettere, Button[,] btns, int orizzontale, int verticale, int i, int j, ref int paroleTrovate)
        //{
        //    string parola = "";
        //    // Se la parola è lunga 1 non entra nel for
        //    for (int k = 0; k < parolaDaCercare.Length; k++)
        //    {
        //        if (
        //            j + (k * orizzontale) >= lettere.GetLength(1) // Controllo in caso esco dalla matrice lateralmente
        //            ||
        //            i + (k * verticale) >= lettere.GetLength(0) // Controllo in caso esco dalla matrice verticalmente
        //            ||
        //            j + (k * orizzontale) < 0 // Controllo in caso esco dalla matrice lateralmente da sinistra
        //            ||
        //            i + (k * verticale) < 0 // Controllo in caso esco dalla matrice verticalmente da sinistra
        //            )
        //            return;


        //        // [ righe o colonne + (carattere attuale della parola * la direzione) ]
        //        string check = lettere[i + (k * verticale), j + (k * orizzontale)];
        //        parola += check; // Compongo la parola lettera per lettera

        //        //Console.WriteLine(parolaDaCercare.Substring(0,k+1) + " VS " + parola);

        //        if (parolaDaCercare.Substring(0, k + 1) != parola) // Se una lettera trovata fino ad ora è diversa esci
        //            return;

        //        if (parola == parolaDaCercare) // Se trovi la parola, ricomincia, colora i bottoni e aggiungi 1 alle parole trovate
        //        {
        //            parola = "";

        //            for (int l = 0; l < parolaDaCercare.Length; l++)
        //            {
        //                btns[i + (l * verticale), j + (l * orizzontale)].Background = COLORE_NUOVO;
        //            }
        //            paroleTrovate++;
        //        }
        //    }
        //}
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
