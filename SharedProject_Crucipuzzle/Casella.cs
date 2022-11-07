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
        
        private ConsoleColor _background;

        public string ToWpf()
        {
            return "";
        }

        // Altre proprietà...

        // TODO: Commentare
        /// <summary>
        /// 
        /// </summary>
        public Casella()
        {
            _carattere = ' ';
            // _background = ConsoleColor.Black
            // _foreground = ConsoleColor.White
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
                return _carattere == null ? false : true;
            }
        }
    }
}


