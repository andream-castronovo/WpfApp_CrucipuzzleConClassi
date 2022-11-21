using System;
using System.IO;


namespace SharedProject_Crucipuzzle
{
    internal class Tabellone
    {
        // Programmato da: Andrea Maria Castronovo - 4°I - Data Inizio: 5/11/2022

        private Casella[,] _caselle; 

        /// <summary>
        /// Ad una posizione r e c nel tabellone corrisponde una casella
        /// </summary>
        /// <param name="r">Riga</param>
        /// <param name="c">Colonna</param>
        /// <returns>Casella relativa alla posizione</returns>
        public Casella this[int r, int c]
        {
            get
            {
                return _caselle[r, c];
            }
            set
            {
                _caselle[r, c] = value;
            }
        }

        /// <summary>
        /// Costruttore vuoto per permettere dinamicità nelle inizializzazioni fuori la classe
        /// </summary>
        public Tabellone() { }

        /// <summary>
        /// Crezione di un tabellone con definite righe e colonne
        /// </summary>
        /// <param name="nRighe">Numero di righe</param>
        /// <param name="nColonne">Numero di colonne</param>
        public Tabellone(int nRighe, int nColonne)
        {
            _caselle = new Casella[nRighe, nColonne];

            // Devo inizializzare ogni casella a mano
            // perché la matrice di oggetti sarà riempita
            // di "null" di default
            for (int i = 0; i < nRighe; i++)
            {
                for (int j = 0; j < nColonne; j++)
                {
                    _caselle[i, j] = new Casella(); // Caselle vuote con valori di default
                }
            }
        }

        /// <summary>
        /// Creazione di un tabellone da un file
        /// </summary>
        /// <param name="fileTabellone">Percorso al file contenente i caratteri da mettere in ogni casella</param>
        /// <param name="separatoreLettere">Separatore che nel file separa le lettere</param>
        /// <exception cref="Exception">Problema con il file</exception>
        public Tabellone(string fileTabellone, char separatoreLettere = ' ')
        {

            char[,] caratteri;

            try
            {
                caratteri = CaricaMatriceDaFile(fileTabellone, separatoreLettere);
            }
            catch (Exception ex)
            {
                throw new Exception("Problema con il file, assicurati di aver caricato un file contenente una tabella di caratteri");
            }

            _caselle = new Casella[caratteri.GetLength(0), caratteri.GetLength(1)];

            for (int i = 0; i < caratteri.GetLength(0); i++)
            {
                for (int j = 0; j < caratteri.GetLength(1); j++)
                {
                    _caselle[i, j] = new Casella(caratteri[i, j]);
                }
            }
        }

        /// <summary>
        /// Carica una matrice di lettere da un file
        /// </summary>
        /// <param name="file">Percorso del file</param>
        /// <param name="separatore">Separatore che separa le lettere nel file</param>
        /// <returns>Matrice di char</returns>
        char[,] CaricaMatriceDaFile(string file, char separatore)
        {
            #region Converto il file in una stringa lunga
            StreamReader sr = new StreamReader(file);
            string strFile = sr.ReadToEnd().Replace("\r", ""); // \r è il carattere che fa muovere il cursore
            sr.Close();
            #endregion

            string[] righe = strFile.Split('\n'); // Qui ho le righe

            if (strFile.IndexOf("\n") == -1) // Se il file ha una riga sola ci aggiungo lo \n per farlo funzionare
                strFile += "\n";

            int nColonne = strFile.Replace(separatore.ToString(), "").IndexOf('\n'); // L'indice di \n è il numero di caratteri, quindi colonne
            int nRighe = righe.Length;

            // Matrice in cui metterò i caratteri
            char[,] caratteri = new char[nRighe, nColonne];

            for (int i = 0; i < nRighe; i++)
            {
                string[] lettere = righe[i].Split(separatore); // Splitto nuovamente per avere le lettere singole 

                for (int j = 0; j < lettere.Length; j++)
                {
                    caratteri[i, j] = lettere[j][0];
                }
            }

            return caratteri;
        }


        /// <summary>
        /// Controlla se ci sono caselle non inizializzate
        /// </summary>
        /// <exception cref="Exception"></exception>
        void ControllaCaselle()
        {
            for (int i = 0; i < NumeroRighe; i++)
            {
                for (int j = 0; j < NumeroColonne; j++)
                {
                    if (this[i, j] == null)
                        throw new Exception($"Le caselle devono essere tutte occupate (casella non occupata: Riga {i}, Colonna {j}.");
                }
            }
        }

        public string Soluzione()
        {
            string parola = "";
            for (int i = 0; i < NumeroRighe; i++)
            {
                for (int j = 0; j < NumeroColonne; j++)
                {
                    if (!this[i,j].Impegnata)
                    {
                        parola += this[i, j].Carattere;
                    }
                }
            }
            return parola;
        }

        /// <summary>
        /// Matrice di caselle contenute nel Tabellone
        /// </summary>
        public Casella[,] Caselle
        {
            get => _caselle;
            set 
            {
                _caselle = value;

                for (int i = 0; i < _caselle.GetLength(0); i++)
                {
                    for (int j = 0; j < _caselle.GetLength(1); j++)
                    {
                        _caselle[i,j] = new Casella();
                    }
                }
                 
            }
        }



        /// <summary>
        /// -1 se non esiste la matrice
        /// </summary>
        public int NumeroRighe { get => _caselle != null ? _caselle.GetLength(0) : -1; }

        /// <summary>
        /// -1 se non esiste la matrice
        /// </summary>
        public int NumeroColonne { get => _caselle != null ? _caselle.GetLength(1) : -1; }

        #region Metodo cerca parola
        /// <summary>
        /// Cerca l'iniziale della parola da ricercare nel puzzle
        /// </summary>
        /// <param name="parolaDaCercare">Parola da cercare</param>
        /// <returns>Parola se la parola è stata trovata, null se non è stata trovata</returns>
        /// <exception cref="Exception">Nessuna parola da cercare</exception>
        public Parola CercaParola(Parola parolaDaCercare)
        {
            //AggiornaColori(btns);
            ControllaCaselle();

            for (int i = 0; i < NumeroRighe; i++) // Due for per lo scorrere della matrice
            {
                for (int j = 0; j < NumeroColonne; j++)
                {
                    if (parolaDaCercare[0] == _caselle[i, j].Carattere) // Rileva l'iniziale della parola scelta
                    {
                        foreach (Direzione d in Enum.GetValues(typeof(Direzione)))
                        {
                            ProvaParola(parolaDaCercare, d, i, j);
                        }

                    }
                }
            }
            return parolaDaCercare;
        }

        /// <summary>
        /// Prende la direzione la trasforma in movimento orizzontale e verticale
        /// </summary>
        /// <param name="d">Direzione da trasformare</param>
        /// <param name="orizzontale">Movimento orizzontale</param>
        /// <param name="verticale">Movimento verticale</param>
        public void ProcessaDirezione(Direzione d, out int orizzontale, out int verticale)
        {
            orizzontale = 0; // Sinistra Destra di default
            verticale = 1;

            switch (d)
            {
                //case Direzione.Sx_Dx: // Sinistra Destra di default
                //    orizzontale = 0;
                //    verticale = 1;
                //    break;

                case Direzione.Dx_Sx:
                    orizzontale = 0;
                    verticale = -1;
                    break;
                case Direzione.Up_Down:
                    orizzontale = 1;
                    verticale = 0;
                    break;
                case Direzione.Down_Up:
                    orizzontale = -1;
                    verticale = 0;
                    break;
                case Direzione.UpSx_DownDx:
                    orizzontale = 1;
                    verticale = 1;
                    break;
                case Direzione.DownDx_UpSx:
                    orizzontale = -1;
                    verticale = -1;
                    break;
                case Direzione.DownSx_UpDx:
                    orizzontale = -1;
                    verticale = 1;
                    break;
                case Direzione.UpDx_DownSx:
                    orizzontale = 1;
                    verticale = -1;
                    break;
            }
        }

        /// <summary>
        /// Prova a comporre la parola verso la direzione data
        /// </summary>
        /// <param name="parolaDaCercare">Parola da cercare</param>
        /// <param name="d">Direzione verso cui cercare la parola</param>
        /// <param name="i">Riga di partenza della ricerca</param>
        /// <param name="j">Colonna di partenza della ricerca</param>
        void ProvaParola(Parola parolaDaCercare, Direzione d, int i, int j)
        {
            int orizzontale;
            int verticale;

            ProcessaDirezione(d, out orizzontale, out verticale);

            string parola = "";

            // Se la parola è lunga 1 non entra nel for
            for (int k = 0; k < parolaDaCercare.NumCar; k++)
            {
                if (
                    j + (k * orizzontale) >= NumeroColonne // Controllo in caso esco dalla matrice lateralmente
                    ||
                    i + (k * verticale) >= NumeroRighe // Controllo in caso esco dalla matrice verticalmente
                    ||
                    j + (k * orizzontale) < 0 // Controllo in caso esco dalla matrice lateralmente da sinistra
                    ||
                    i + (k * verticale) < 0 // Controllo in caso esco dalla matrice verticalmente da sinistra
                    )
                    return;


                // [ righe o colonne + (carattere attuale della parola * la direzione) ]
                char check = _caselle[i + (k * verticale), j + (k * orizzontale)].Carattere;

                parola += check; // Compongo la parola lettera per lettera

                //Console.WriteLine(parolaDaCercare.Substring(0,k+1) + " VS " + parola);

                if (parolaDaCercare.Contenuto.Substring(0, k + 1) != parola) // Se una lettera trovata fino ad ora è diversa esci
                    return;

                if (parola == parolaDaCercare.Contenuto) // Se trovi la parola, ricomincia
                {
                    parolaDaCercare.X = i;
                    parolaDaCercare.Y = j;
                    parolaDaCercare.Direzione = d;

                    for (int l = 0; l < parolaDaCercare.NumCar; l++)
                    {
                        this[i + (l * verticale), j + (l * orizzontale)].Impegnata = true;
                        this[i + (l * verticale), j + (l * orizzontale)].Nuova = true;
                    }

                }
            }
        }
        #endregion
    }
}
