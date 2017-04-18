using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avagnano.marco._5i.briscola
{
  class Mazzo 
    {
        
       public static List<Carta> deck = new List<Carta>();
        //riempimento del mazzo
        public void riempi_mazzo()
        {
            for (int i = 1; i <= 40; i++)
            {
                Carta card = new Carta(i);
                deck.Add(card);
            }
         
         
        }
        //il mazzo viene svuotato per iniziare una nuova partita
        public void svuota_mazzo()
        {
            deck = new List<Carta>();
        }
        //il mazzo viene mischiato
        public void mischiaggio_mazzo()
        {
            deck = deck.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
