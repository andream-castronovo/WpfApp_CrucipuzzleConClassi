using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            MessageBox.Show("La grafica e il controllo errori nell'ambito dell'UI non è curato come le classi in quanto l'esercitazione prevedeva solo il funzionamento di queste", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        Tabellone _t;
        Button[,] _btns;
        TextBox[,] _txts;

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            _t = new Tabellone(CercaFile(), ' ');
            _btns = new Button[_t.NumeroRighe, _t.NumeroColonne];

            GeneraBottoni(_btns);

            for (int iR = 0; iR < _t.NumeroRighe; iR++)
            {
                for (int iC = 0; iC < _t.NumeroColonne; iC++)
                {
                    _btns[iR,iC].Content = _t[iR, iC].Carattere;
                }
            }
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
            btnConferma.IsEnabled = true;
            MessageBox.Show("Riempi tutte le txtbox, dopo conferma");
            
            
        }

        private void btnConferma_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {

                for (int i = 0; i < _txts.GetLength(0); i++)
                {
                    for (int c = 0; c < _txts.GetLength(1); c++)
                    {
                        if (_txts[i, c].Text == "" || _txts.Length == 1)
                        {
                            throw new Exception("Problem");
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
                    _btns[i, c].Content = _txts[i, c].Text;
                    _txts[i, c].Visibility = Visibility.Collapsed;
                }
            }





        }
    }
}
