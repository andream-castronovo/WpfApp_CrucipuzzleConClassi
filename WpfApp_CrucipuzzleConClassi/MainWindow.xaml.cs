﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;
using SharedProject_Crucipuzzle;


namespace WpfApp_CrucipuzzleConClassi
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Programmato da: Andrea Maria Castronovo - 4°I - Data Inizio: 5/11/2022

        public MainWindow()
        {
            InitializeComponent();

            //MessageBox.Show("La grafica e il controllo errori nell'ambito dell'UI non è curato come le classi in quanto l'esercitazione prevedeva solo il funzionamento di queste", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            btnCerca.IsEnabled = false;
            btnSolz.IsEnabled = false;
            btnConferma.Visibility = Visibility.Collapsed;

        }

        Tabellone _t;
        Button[,] _btns;
        TextBox[,] _txts;


        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                _t = new Tabellone(CercaFile(), ' ');

            }
            catch(Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
                return;
            }
            _btns = new Button[_t.NumeroRighe, _t.NumeroColonne];

            GeneraBottoni(_btns);

            for (int iR = 0; iR < _t.NumeroRighe; iR++)
            {
                for (int iC = 0; iC < _t.NumeroColonne; iC++)
                {
                    _btns[iR,iC].Content = _t[iR, iC].Carattere;
                }
            }

            btnCerca.IsEnabled = true;
            btnSolz.IsEnabled = true;
            btnConferma.Visibility = Visibility.Collapsed;
            btnConferma.IsEnabled = false;
            
        }

        private void btnCerca_Click(object sender, RoutedEventArgs e)
        {
            Parola p = _t.CercaParola(new Parola(txtParola.Text));


            for (int i = 0; i < _btns.GetLength(0); i++)
            {
                for (int j = 0; j < _btns.GetLength(1); j++)
                {
                    if (_t[i, j].Impegnata)
                    {
                        if (_t[i, j].Nuova)
                        {
                            _btns[i, j].Background = Brushes.Green;
                            _t[i, j].Nuova = false;
                        }
                        else
                        {
                            _btns[i, j].Background = Brushes.Magenta;
                        }
                    }
                    
                }
            }
            

        }

        /// <summary>
        /// Genera i bottoni che conterranno le caselle
        /// </summary>
        /// <param name="btns">Matrice di bottoni</param>
        void GeneraBottoni(Button[,] btns)
        {
            // Dimensione griglia in base a quanti bottoni ci sono
            grdTabellone.Width = 25 * btns.GetLength(1);
            grdTabellone.Height = 25 * btns.GetLength(0);

            for (int i = 0; i < btns.GetLength(0); i++)
            {
                for (int j = 0; j < btns.GetLength(1); j++)
                {
                    Button btn = new Button()
                    {
                        Width = grdTabellone.Width / btns.GetLength(1),
                        Height = grdTabellone.Height / btns.GetLength(0),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        FontSize = 18,
                    };

                    btn.Margin = new Thickness(btn.Width * j, btn.Height * i, 0, 0);

                    btns[i, j] = btn;

                    grdTabellone.Children.Add(btn);

                }
            }
        }
        /// <summary>
        /// Genera le TextBox per il compilamento del tabellone manuale
        /// </summary>
        /// <param name="txts">Array textbox</param>
        void GeneraTextox(TextBox[,] txts)
        {
            // Dimensione griglia in base a quanti bottoni ci sono
            grdTabellone.Width = 25 * txts.GetLength(1);
            grdTabellone.Height = 25 * txts.GetLength(0);

            for (int i = 0; i < txts.GetLength(0); i++)
            {
                for (int j = 0; j < txts.GetLength(1); j++)
                {
                    TextBox txt = new TextBox()
                    {
                        Width = grdTabellone.Width / txts.GetLength(1),
                        Height = grdTabellone.Height / txts.GetLength(0),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        FontSize = 18,
                    };

                    txt.Margin = new Thickness(txt.Width * j, txt.Height * i, 0, 0);
                    txt.Name = $"txt{i}_{j}";

                    txts[i, j] = txt;

                    grdTabellone.Children.Add(txt);
                }
            }
        }

        /// <summary>
        /// Usa OpenFileDialog per trovare il file
        /// </summary>
        /// <returns>Stringa con percorso del file</returns>
        string CercaFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if ((bool)ofd.ShowDialog())
                return ofd.FileName;

            return @"..\..\Crucipuzzle.txt";
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            int r;
            int c;
            try
            {
                r = int.Parse(txtRow.Text);
                c = int.Parse(txtCol.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore: {ex.Message}");
                return;
            }

            _t = new Tabellone(r,c);


            _btns = new Button[r, c];

            _txts = new TextBox[r, c];
            GeneraTextox(_txts);

            btnConferma.Visibility = Visibility.Visible;
            btnConferma.IsEnabled = true;
            btnCerca.IsEnabled = false;
            btnSolz.IsEnabled = false;

            MessageBox.Show("Riempi tutte le txtbox, dopo conferma");
            
            
        }

        /// <summary>
        /// Riempie i bottoni con il content del Tabellone
        /// </summary>
        /// <param name="btns">Matrice di bottoni</param>
        /// <param name="t">Tabellone</param>
        void RiempiBottoni(Button[,] btns, Tabellone t)
        {
            for (int i = 0; i < t.NumeroRighe; i++)
            {
                for (int j = 0; j < t.NumeroColonne; j++)
                {
                    btns[i, j].Content = t[i, j].Carattere;
                }
            }
        }

        private void btnConferma_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {

                for (int i = 0; i < _txts.GetLength(0); i++)
                {
                    for (int c = 0; c < _txts.GetLength(1); c++)
                    {
                        if (_txts[i,c].Text.Length != 1)
                        {
                            throw new Exception($"Assicurati di aver messo solo un carattere nella casella r{i} c{c}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
                return;
            }

            GeneraBottoni(_btns);
            for (int i = 0; i < _txts.GetLength(0); i++)
            {
                for (int c = 0; c < _txts.GetLength(1); c++)
                {
                    _t[i, c].Carattere = _txts[i, c].Text.ToUpper()[0];
                    _txts[i, c].Visibility = Visibility.Collapsed;
                }
            }


            RiempiBottoni(_btns, _t);

            btnConferma.IsEnabled = false;
            btnConferma.Visibility = Visibility.Collapsed;
            btnCerca.IsEnabled = true;
            btnSolz.IsEnabled = true;


        }

        private void btnSolz_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_t.Soluzione(),"Soluzione");
        }
    }
}
