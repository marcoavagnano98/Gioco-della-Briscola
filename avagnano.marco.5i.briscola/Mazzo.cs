using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avagnano.marco._5i.briscola
{
  class Mazzo 
    {
        
       public List<Carta> deck = new List<Carta>();
        public void riempi_mazzo()
        {
            for (int i = 1; i <= 40; i++)
            {
                Carta card = new Carta(i);
                deck.Add(card);
            }
         
         
        }
        public void mischiaggio_mazzo()
        {
            deck = deck.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
