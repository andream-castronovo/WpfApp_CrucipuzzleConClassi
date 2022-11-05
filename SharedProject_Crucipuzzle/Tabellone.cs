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

        private void CercaSinistraDestra(Parola par)
        {
            bool trovata;
            for (int iR = 0; iR < NumeroRighe; iR++)
            {
                for (int iC = 0; iC <= (NumeroColonne - par.NumCar); iC++)
                {
                    trovata = true;
                    for (int x = 0; x < par.NumCar && trovata; x++)
                    {
                        if (_caselle[iR, iC + x].Carattere != par[x]) // par[x] equivale a par.Carattere(x) del prof,
                                                                      // io ho usato un indicizzatore e per questo lo
                                                                      // uso così
                        {
                            trovata = false;
                        }
                    }
                    if (trovata)
                    {
                        for (int x = 0; x < par.NumCar && trovata; x++)
                        {
                            _caselle[iR, x + iC].Impegnata = true;
                        }
                        par.Direzione = Direzione.Sx_Dx;
                        par.X = iR;
                        par.Y = iC;
                        return;
                    }
                }
            }
        }

        private void CercaBassoDestra_AltoSinistra (Parola par)
        {
            bool trovata;
            for (int iR = par.NumCar - 1; iR < NumeroRighe; iR++)
            {
                for (int iC = par.NumCar - 1; iC < NumeroColonne; iC++)
                {
                    trovata = true;
                    for (int x = 0; x < par.NumCar && trovata; x++)
                    {
                        if (_caselle[iR - x, iC - x].Carattere != par[x]) // par[x] equivale a par.Carattere(x) del prof,
                                                                      // io ho usato un indicizzatore e per questo lo
                                                                      // uso così
                        {
                            trovata = false;
                        }
                    }
                    if (trovata)
                    {
                        for (int x = 0; x < par.NumCar && trovata; x++)
                        {
                            _caselle[iR - x, iC - x].Impegnata = true;
                        }
                        par.Direzione = Direzione.DownDx_UpSx;
                        par.X = iR;
                        par.Y = iC;
                        return;
                    }
                }
            }
        }
    }
}
