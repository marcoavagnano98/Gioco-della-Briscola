using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace avagnano.marco._5i.briscola
{
    class Carta
    {

        public int num { get; set; }
        public string sem { get; set; }
        public BitmapImage path { get; set; }
      
        int valore;
        string seme;

        public Carta()
        {

        }
        public Carta(int index)
        {
            BitmapImage card = new BitmapImage();
            card.BeginInit();
            if (index <= 10)
            {
                valore = index;
                seme = "bas";
            }
            else
                if (index > 10 && index <= 20)
            {
                valore = index - 10;
                seme = "cop";

            }
            else
                if (index > 20 && index <= 30)
            {
                valore = index - 20;
                seme = "den";
            }
            else
                if (index > 30 && index <= 40)
            {
                valore = index - 30;
                seme = "spa"; 
            }

            num = valore;
            sem = seme;
            path = new BitmapImage(new Uri("/Image/" + valore + "_" + seme + ".png", UriKind.Relative));
           
        }

    }
}
