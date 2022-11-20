using System;

namespace SharedProject_Crucipuzzle
{

    /// <summary>
    /// Contiene una lettera che insieme ad altre caselle potrebbe formare una parola
    /// </summary>
    public class Casella
    {
        // Programmato da: Andrea Maria Castronovo - 4°I - Data Inizio: 5/11/2022

        private char _carattere;
        private bool _impegnata;
        private bool _nuova;

        /// <summary>
        /// Crea una nuova casella con il carattere "-" di default
        /// </summary>
        public Casella()
        {
            _carattere = '-';
            _impegnata = false; 
        }

        /// <summary>
        /// Crea una nuova casella con il carattere all'interno di essa
        /// </summary>
        /// <param name="carattere">Carattere nella casella</param>
        public Casella(char carattere)
        {
            Carattere = carattere;
            _impegnata = false;
        }

        /// <summary>
        /// Carattere
        /// </summary>
        public char Carattere 
        {
            get => _carattere;
            set
            {
                // ASCII values
                // 65 = A
                // 90 = Z

                // 97 = a
                // 122 = z

                // Controllo se il carattere inserito è una lettera minuscola
                // Se lo è, la rende maiuscola
                if (value >= 97 && value <= 122)
                    value = (char)(value - 32);
                
                // Controllo se il carattere NON è una lettera maiuscola
                else if (!(value >= 65 && value <= 90))
                    throw new Exception("Il carattere non è una lettera (A-Z o a-z)");

                _carattere = value;

            }
        }
        
        /// <summary>
        /// Se il carattere all'interno della casella fa parte di una parola trovata
        /// </summary>
        public bool Impegnata { get => _impegnata; set => _impegnata = value; }
        
        /// <summary>
        /// Se il carattere all'interno della casella fa parte di una NUOVA parola trovata
        /// </summary>
        public bool Nuova { get => _nuova; set => _nuova = value; }
    }
}


