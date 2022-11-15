using System;

namespace SharedProject_Crucipuzzle
{
    public class Parola
    {
        // Programmato da: Andrea Maria Castronovo - 4°I - Data Inizio: 5/11/2022

        string _contenuto;
        int _x = -1;
        int _y = -1;
        Direzione _direzione;
        // TODO: Serve altro, implementarlo


        /// <summary>
        /// Crea una parola senza contenuto
        /// </summary>
        public Parola()
        {
            _contenuto = "";
            _direzione = Direzione.NULL;
        }

        /// <summary>
        /// Crea una parola con un contenuto
        /// </summary>
        /// <param name="par"></param>
        public Parola(string par)
        {
            if (par == null)
                par = "";

            _contenuto = par.ToUpper();
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
            if (_x == -1 || _y == -1)
                throw new Exception("La parola non ha coordinate se non è stata prima trovata");


            int stepR = 0; // Verticale
            int stepC = 0; // Orizzontale
            
            // Switch per convertire la direzione
            // in spostamenti di coordinate
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
                    return false; // Se la parola non ha direzione, non è stata trovata
                                  // Anche se c'è il controllo all'inizio del metodo
            }


            // Imposta le coordinate attuali 
            // alle coordinate di inizio della parola
            int r = _x;
            int c = _y;
            
            // Le coordinate attuali girerano per ogni 
            // coordinata che appartiene alla parola

            // Due coorinate (x,y) sono associate ad una casella del tabellone

            for (int n = 0; n < NumCar; n++)
            {
                // Se le coordinate passate come parametro
                // sono uguali ad una coordinata qualsiasi
                // che appartiene alla parola, allora returna true
                if (r == riga && c == colonna) return true;

                // altrimenti imposta come nuove coordinate attuali
                // le coordinate spostate per gli step definiti in base
                // alla direzione della parola trovata
                r = r + stepR;
                c = c + stepC;
            }

            // Qui arriverà solo se non è stata
            // trovata nessuna coordinata appartenente alla parola
            // uguale a quelle richieste

            return false; 
        }


        #region Proprietà

        /// <summary>
        /// Riga d'inizio della parola
        /// </summary>
        public int X { get => _x; set => _x = value; }

        /// <summary>
        /// Colonna d'inizio della parola
        /// </summary>
        public int Y { get => _y; set => _y = value; }

        /// <summary>
        /// Se la parola è stata trovata o no
        /// </summary>
        public bool Trovata
        {
            get
            {
                return _x != -1 && _y != -1;
            }
        }
        
        /// <summary>
        /// Contenuto della parola
        /// </summary>
        public string Contenuto { get => _contenuto; set => _contenuto = value; }

        /// <summary>
        /// Numero di caratteri
        /// </summary>
        public int NumCar { get => _contenuto.Length; }
        
        /// <summary>
        /// Direzione della parola trovata
        /// </summary>
        public Direzione Direzione { get => _direzione; set => _direzione = value; }

        /// <summary>
        /// Simula una stringa, restituendo il carattere relativo all'indice i
        /// </summary>
        /// <param name="i">Posizione nella stringa</param>
        /// <returns>Carattere relativo alla posizione</returns>
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
