using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace avagnano.marco._5i.briscola
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string player)
        {
            InitializeComponent();
            Partita(player);

        }
        Gioco match = new Gioco();
        BitmapImage retro = new BitmapImage(new Uri("/Image/retro.png", UriKind.Relative));
        string s_rimaste = "Carte rimaste";
        

        private void Partita(string player)
        {

            im1.Source = Utente.carte_mano[0].path;
            im2.Source = Utente.carte_mano[1].path;
            im3.Source = Utente.carte_mano[2].path;
            im4.Source = null;
            im5.Source = null;
            im6.Source = match.b_path;
            im7.Source = retro;
            im8.Source = retro;
            im9.Source = retro;
            im10.Source = retro;
            c_remained.Content = s_rimaste + "\n" + Mazzo.deck.Count;
            lblname.Content = player;
            p1.Content = Utente.punteggio;
            p2.Content = CPU.punteggio;

        }

        private void Giocata(object sender, MouseButtonEventArgs e)
        {
            im1.Source = null;
            b1.Background = null;
            b2.Background = null;
            b3.Background = null;
            b4.Background = null;
            b5.Background = null;
            b6.Background = null;
            im1.IsEnabled = false;
            im2.IsEnabled = false;
            im3.IsEnabled = false;
            turno(0);
        }

        private void Giocata2(object sender, MouseButtonEventArgs e)
        {
            im2.Source = null;
            b1.Background = null;
            b2.Background = null;
            b3.Background = null;
            b4.Background = null;
            b5.Background = null;
            b6.Background = null;
            im1.IsEnabled = false;
            im2.IsEnabled = false;
            im3.IsEnabled = false;
            turno(1);
        }

        private void Giocata3(object sender, MouseButtonEventArgs e)
        {
            im3.Source = null;
            b1.Background = null;
            b2.Background = null;
            b3.Background = null;
            b4.Background = null;
            b5.Background = null;
            b6.Background = null;
            im1.IsEnabled = false;
            im2.IsEnabled = false;
            im3.IsEnabled = false;
            turno(2);
        }
        private async void turno(int index1)
        {
            match.turno(index1);
            im4.Source = match.g_utente.path;
            if (CPU.mio_turno == false)
            {
                //attende 800 ms per la giocata della carta al centro del tavolo per la CPU, se non è il suo turno
                await Task.Delay(800);
                im5.Source = match.g_CPU.path;
            }
            match.assegna_turno(match.return_vincitore);
            clean_CPU();
            if (CPU.mio_turno)
            {
                match.turno_CPU();
            }
            //attende 1 secondo per la pulizia delle carte dal centro 
            await Task.Delay(1000);
            im4.Source = null;
            im5.Source = null;
            if (Mazzo.deck.Count == 0)
            {
                im6.Source = null;
                im10.Source = null;
            }
            assegna_carta();
            p1.Content = Utente.punteggio;
            p2.Content = CPU.punteggio;


            if (CPU.mio_turno)
            {
                //attende 800 ms per la giocata della CPU se è il suo turno
                await Task.Delay(800);
                im5.Source = match.g_CPU.path;
                clean_CPU();
            }
            im1.IsEnabled = true;
            im2.IsEnabled = true;
            im3.IsEnabled = true;
            c_remained.Content = s_rimaste + "\n" + Mazzo.deck.Count;
            if (Utente.carte_mano[0].sem == null && Utente.carte_mano[1].sem == null && Utente.carte_mano[2].sem == null)
            {
                decreta_vincitore();
            }
        }

        public void assegna_carta()
        {

            if (im1.Source == null)
            {
                im1.Source = Utente.carte_mano[0].path;
            }
            else
                if (im2.Source == null)
                {
                    im2.Source = Utente.carte_mano[1].path;
                }
                else
                    if (im3.Source == null)
                    {
                        im3.Source = Utente.carte_mano[2].path;
                    }
            if (CPU.carte_mano[0].sem != null && CPU.carte_mano[1].sem != null && CPU.carte_mano[2].sem != null)
            {
                if (im7.Source == null)
                {
                    im7.Source = retro;
                }
                if (im8.Source == null)
                {
                    im8.Source = retro;
                }
                if (im9.Source == null)
                {
                    im9.Source = retro;
                }
            }
        }
        public void clean_CPU()
        {
            if (match.g_CPU.index == 0)
            {
                im7.Source = null;
            }
            if (match.g_CPU.index == 1)
            {
                im8.Source = null;
            }
            if (match.g_CPU.index == 2)
            {
                im9.Source = null;
            }
        }
        public void ricomincia_partita()
        {
            match = new Gioco();
            Partita(lblname.Content.ToString());
        }
        public void decreta_vincitore()
        {
            im4.Source = null;
            im5.Source = null;
            if (Utente.punteggio > CPU.punteggio)
            {
                MessageBox.Show("Hai vinto!");
            }
            else
                if (Utente.punteggio < CPU.punteggio)
                {
                    MessageBox.Show("Ha vinto la CPU");
                }
                else
                    if (Utente.punteggio == CPU.punteggio)
                    {
                        MessageBox.Show("Avete pareggiato!");
                    }
            if (MessageBox.Show("Vuoi iniziare una nuova partita?", "Inizia partita", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                Close();
            }
            else
            {
                ricomincia_partita();
            }
        }

        private void restart(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Sei sicuro di voler avviare una nuova partita?", "Inizia partita", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                ricomincia_partita();
            }
        }
        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Border)sender).Background = Brushes.SkyBlue;

        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Border)sender).Background = null;
        }

        private void Border2_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Border)sender).Background = Brushes.Red;
        }

        private void Border2_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Border)sender).Background = null;
        }
    }
}
