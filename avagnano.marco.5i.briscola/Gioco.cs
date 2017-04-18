using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avagnano.marco._5i.briscola
{
    class Gioco : Mazzo 
    {
        public bool end_partita = false;
        public Gioco()
        {
            riempi_mazzo();
            mischiaggio_mazzo();

        }
        public Carta assegna_carta()
        {
            Utente player = new Utente();
            Carta giocata = deck[0];
            player.carte_mano.Add(deck[0]);
            deck.RemoveAt(0);
            return giocata;
          
        }
    }
}
