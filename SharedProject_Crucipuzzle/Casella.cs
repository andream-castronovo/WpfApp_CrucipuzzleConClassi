using System;

namespace SharedProject_Crucipuzzle
{

    // TODO: Commentare
    /// <summary>
    /// 
    /// </summary>
    public class Casella
    {
        // Programmato da: Andrea Maria Castronovo - 4°I - Data Inizio: 5/11/2022

        private char _carattere;
        private bool _impegnata;

        // Altre proprietà...

        // TODO: Commentare
        /// <summary>
        /// 
        /// </summary>
        public Casella()
        {
            _carattere = '-';
            _impegnata = false; 
        }




        // TODO: Commentare
        /// <summary>
        /// 
        /// </summary>
        /// <param name="carattere"></param>
        public Casella(char carattere)
        {

            // 65 = A
            // 90 = Z

            // 97 = a
            // 122 = z

            if (carattere >= 97 && carattere <= 122)
                carattere = (char)(carattere - 32);
            else if (!(carattere >= 65 && carattere <= 90))
                throw new Exception("Il carattere non è una lettera (A-Z o a-z)");

            _carattere = carattere;
            _impegnata = false;
        }

        public char Carattere { get => _carattere; set => _carattere = value; }
        public bool Impegnata { get => _impegnata; set => _impegnata = value; }
    }
}


