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
using System.Windows.Shapes;

namespace avagnano.marco._5i.briscola
{
    /// <summary>
    /// Logica di interazione per StartGame.xaml
    /// </summary>
    public partial class StartGame : Window
    {
        public StartGame()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string player = "";
            if(pl.Text.Trim()=="")
            {
                player = "Player1";
            }
            else
            {
                player = pl.Text;
            }
            MainWindow finestra = new MainWindow(player);
            Hide();
            finestra.ShowDialog();
            Close();
        }
    }
}
