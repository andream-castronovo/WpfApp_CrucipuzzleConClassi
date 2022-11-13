﻿using System;

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
        private bool _nuova;

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




        /// <summary>
        /// Crea una nuova casella con il carattere all'interno di essa
        /// </summary>
        /// <param name="carattere">Carattere da inserire nella casella</param>
        public Casella(char carattere)
        {

            // 65 = A
            // 90 = Z

            // 97 = a
            // 122 = z

            // Controllo se il carattere inserito è una lettera minuscola
            // Se lo è, la rende maiuscola
            if (carattere >= 97 && carattere <= 122)
                carattere = (char)(carattere - 32);
            // Controllo se il carattere NON è una lettera maiuscola
            else if (!(carattere >= 65 && carattere <= 90))
                throw new Exception("Il carattere non è una lettera (A-Z o a-z)");

            _carattere = carattere;
            _impegnata = false;
        }

        /// <summary>
        /// Carattere all'interno della casella
        /// </summary>
        public char Carattere { get => _carattere; set => _carattere = value; }
        
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


