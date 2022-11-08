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

        // Altre proprietà...

        // TODO: Commentare
        /// <summary>
        /// 
        /// </summary>
        public Casella()
        {
            _carattere = ' ';
        }




        // TODO: Commentare
        /// <summary>
        /// 
        /// </summary>
        /// <param name="carattere"></param>
        public Casella(char carattere)
        {
            _carattere = carattere;
            // TODO: Aggiungere altro che può servire
        }

        public char Carattere { get => _carattere; set => _carattere = value; }
        public bool Impegnata
        {
            get
            {
                return _carattere == '\u0000' ? false : true;
            }
        }
    }
}


