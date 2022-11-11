using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject_Crucipuzzle
{
    public class Parola
    {
        // Programmato da: Andrea Maria Castronovo - 4°I - Data Inizio: 5/11/2022

        string _contenuto;
        int _x;
        int _y;
        Direzione _direzione;
        // TODO: Serve altro, implementarlo


        // TODO: Commentare
        /// <summary>
        /// 
        /// </summary>
        public Parola()
        {
            _contenuto = "";
            _direzione = Direzione.NULL;
        }

        // TODO: Commentare
        /// <summary>
        /// 
        /// </summary>
        /// <param name="par"></param>
        public Parola(string par)
        {
            _contenuto = par;
            _direzione = Direzione.NULL;
        }

        // TODO: Altri overload di "public Parola"

        /// <summary>
        /// Verifica se una casella appartiene alla parola
        /// </summary>
        /// <param name="riga"></param>
        /// <param name="colonna"></param>
        /// <returns>
        /// "true"  quando il carattere di coordinata (riga, colonna) appartiene alla parola
        /// "false" quando il carattere di coordinata (riga,colonna) non appartiene alla parola
        ///         oppure la parola non è stata ancora trovata nel tabellone
        /// </returns>
        public bool CoordinataAppartiene(int riga, int colonna)
        {
            int stepR = 0; // Verticale
            int stepC = 0; // Orizzontale
            // TODO: Commentare
            switch (_direzione)
            {
                case Direzione.Sx_Dx:
                    stepR = 0;
                    stepC = 1;
                    break;
                case Direzione.Dx_Sx:
                    stepR = 0;
                    stepC = -1;
                    break;
                case Direzione.Up_Down:
                    stepR = 1;
                    stepC = 0;
                    break;
                case Direzione.Down_Up:
                    stepR = -1;
                    stepC = 0;
                    break;
                case Direzione.UpSx_DownDx:
                    stepR = 1;
                    stepC = 1;
                    break;
                case Direzione.DownDx_UpSx:
                    stepR = -1;
                    stepC = -1;
                    break;
                case Direzione.DownSx_UpDx:
                    stepR = -1;
                    stepC = 1;
                    break;
                case Direzione.UpDx_DownSx:
                    stepR = 1;
                    stepC = -1;
                    break;
                case Direzione.NULL:
                    return false;
            }


            int r = _x;
            int c = _y;

            for (int n = 0; n < NumCar; n++)
            {
                if (r == riga && c == colonna) return true;

                r = r + stepR;
                c = c + stepC;
            }


            return false;
        }


        #region Proprietà

        public int X { get => _x; set => _x = value; }

        public int Y { get => _y; set => _y = value; }

        public string Contenuto { get => _contenuto; set => _contenuto = value; }

        public int NumCar { get => _contenuto.Length; }

        public Direzione Direzione { get => _direzione; set => _direzione = value; }

        public char this[int i] 
        {
            get
            {
                if (_contenuto != "")
                    return _contenuto[i];
                else
                    return '\u0000';
            }
        }


        #endregion

    }

}
