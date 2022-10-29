using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject_Crucipuzzle
{

    // TODO: Commentare
    /// <summary>
    /// 
    /// </summary>
    public class Casella
    {
        private char _carattere;
        private bool _impegnata;
        // private ConsoleColor _background;
        // private ConsoleColor _foreground;
        // Altre proprietà...

        // TODO: Commentare
        /// <summary>
        /// 
        /// </summary>
        public Casella()
        {
            _carattere = ' ';
            _impegnata = false;
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
            _impegnata = false;
            // TODO: Aggiungere altro che può servire
        }

        public char Carattere { get; set; }
        public bool Impegnata { get; set; }
    }
}