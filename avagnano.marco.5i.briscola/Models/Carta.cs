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
        public int value { get; set; }
        public int index { get; set; }
        public BitmapImage path { get; set; }

        int numero;
        int valore;
        string seme;

        public Carta()
        {
        }
        //costruttore utilizzato solo all'inizio di una partita
        public Carta(int index)
        {

            //viene assegnato numero e seme ad ogni carta
            if (index <= 10)
            {

                numero = index;
                seme = "bas";
            }
            else
                if (index > 10 && index <= 20)
            {
                numero = index - 10;
                seme = "cop";

            }
            else
                if (index > 20 && index <= 30)
            {
                numero = index - 20;
                seme = "den";
            }
            else
                if (index > 30 && index <= 40)
            {
                numero = index - 30;
                seme = "spa";
            }
            //vengono assegnati tutti i valori alle carte in base al numero che una carta ha
            switch (numero)
            {
                case 1:
                    valore = 11;
                    break;
                case 3:
                    valore = 10;
                    break;
                case 8:
                    valore = 2;
                    break;
                case 9:
                    valore = 3;
                    break;
                case 10:
                    valore = 4;
                    break;
                default:
                    valore = 0;
                    break;
            }
            num = numero;
            sem = seme;
            value = valore;
            //percorso dell'immagine di una Carta
            path = new BitmapImage(new Uri("/Image/" + numero + "_" + seme + ".png", UriKind.Relative));
        }

    }
}
