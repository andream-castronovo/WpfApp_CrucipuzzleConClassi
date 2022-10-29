using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject_Crucipuzzle
{
    public class Parola
    {
        string _contenuto;
        int _x;
        int _y;
        Direzione _direzione;

        public Parola(string par)
        {
            _contenuto = par;
            _direzione = Direzione.NULL;
        }

    }

}
