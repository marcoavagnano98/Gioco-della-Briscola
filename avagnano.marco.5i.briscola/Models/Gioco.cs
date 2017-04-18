using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace avagnano.marco._5i.briscola
{
    class Gioco
    {
        public bool start_partita = true;
        public static string briscola;
        public Carta g_utente = new Carta();
        public Carta g_CPU = new Carta();
        public int return_vincitore { get; set; }
        Mazzo nuovo_mazzo = new Mazzo();

        public BitmapImage b_path { get; set; }
        public Gioco()
        {
            //caso in cui una nuova partita sia iniziata
            if (start_partita)
            {
                //si svuotano le liste delle carte in mano e si azzerano i punteggi
                Utente.carte_mano = new List<Carta>();
                CPU.carte_mano = new List<Carta>();
                Utente.punteggio = 0;
                CPU.punteggio = 0;
                //prima si svuota il mazzo poi viene riempito e mischiato
                nuovo_mazzo.svuota_mazzo();
                nuovo_mazzo.riempi_mazzo();
                nuovo_mazzo.mischiaggio_mazzo();

                for (int i = 0; i < 3; i++)
                {
                    assegna_carta(0, 0);
                }
                assegna_turno(0);
                //si salvano il valore del seme della briscola e il percorso della sua immagine
                briscola = Mazzo.deck[0].sem;
                b_path = Mazzo.deck[0].path;
                //si pone la Carta briscola alla fine del mazzo
                Carta appoggio = new Carta();
                appoggio = Mazzo.deck[0];
                Mazzo.deck.RemoveAt(0);
                Mazzo.deck.Add(appoggio);
                start_partita = false;
            }

        }
        //metodo che assegna le carte alla fine di ogni giocata ai giocatori
        public void assegna_carta(int index, int index1)
        {
            if (start_partita)
            {
                Utente.carte_mano.Add(Mazzo.deck[0]);
                CPU.carte_mano.Add(Mazzo.deck[1]);
                Carta giocata = Mazzo.deck[0];
            }
            else
            {
                //caso in cui il mazzo abbia ancora carte
                if (Mazzo.deck.Count != 0)
                {
                    //caso in cui l'utente abbia vinto il turno
                    if (Utente.mio_turno)
                    {
                        Utente.carte_mano[index] = Mazzo.deck[0];
                        CPU.carte_mano[index1] = Mazzo.deck[1];
                    }
                    //caso in cui la CPU abbia vinto il turno
                    else
                    {
                        Utente.carte_mano[index] = Mazzo.deck[1];
                        CPU.carte_mano[index1] = Mazzo.deck[0];
                    }
                }
                else
                {
                    return;
                }
            }
            Mazzo.deck.RemoveAt(0);
            Mazzo.deck.RemoveAt(0);
        }
        //metodo che stabilisce chi vince la giocata
        public int carta_vincente(Carta p1, Carta p2)
        {
            //caso in cui le due carte giocate abbiano lo stesso seme
            if (p1.sem == p2.sem)
            {
                //si prende la carta con il valore maggiore
                if (p1.value > p2.value)
                {
                    return 1;
                }

                if (p1.value < p2.value)
                {
                    return 2;
                }
                //se i due valori sono uguali(ovvero uguale a 0), si prende quella con il numero maggiore
                if (p1.value == p2.value)
                {
                    if (p1.num > p2.num)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
            }
            else
            {
                //caso in cui l'utente gioca una briscola e la CPU un acarta diversa da briscola
                if (p1.sem == briscola && p2.sem != briscola)
                {
                    return 1;
                }
                //caso in cui la CPU gioca una briscola e l'utente una carta diversa da briscola
                else
                    if (p1.sem != briscola && p2.sem == briscola)
                    {
                        return 2;
                    }
                //se non si entra in nessuno dei casi precedenti vince chi ha tirato per prima
                if (Utente.mio_turno)
                {
                    return 1;
                }

            }
            return 2;
        }
        //metodo che incrementa il punteggio dei giocatori alla fine di ogni giocata
        public void incrementa_punteggio(Carta carta_player, Carta carta_cpu, int win)
        {
            if (win == 1)
            {
                Utente.punteggio = Utente.punteggio + carta_player.value + carta_cpu.value;

            }
            else
            {
                CPU.punteggio = CPU.punteggio + carta_player.value + carta_cpu.value;
            }
        }
        //assegna il turno al vincitore della giocata
        public void assegna_turno(int win)
        {
            if (start_partita)
            {
                CPU.mio_turno = false;
                Utente.mio_turno = true;
            }
            else
            {
                if (win == 1)
                {
                    Utente.mio_turno = true;
                    CPU.mio_turno = false;
                }
                else
                {
                    CPU.mio_turno = true;
                    Utente.mio_turno = false;
                }
            }
        }
        //metodo che comprende tutte le azioni da effettuare in un turno
        public void turno(int index1)
        {

            CPU giocata = new CPU();
            // viene preso l'indice corrispondente alla posizione della carta nella lista di carte mano
            g_utente = Utente.carte_mano[index1];
            g_utente.index = index1;
            int index2 = 0;
            //se è il turno dell'utente la CPU gioca per seconda
            if (Utente.mio_turno)
            {
                index2 = giocata.scelta(g_utente);
                g_CPU = CPU.carte_mano[index2];
                g_CPU.index = index2;
            }
            return_vincitore = carta_vincente(g_utente, g_CPU);
            incrementa_punteggio(g_utente, g_CPU, return_vincitore);
            //se il mazzo non è vuoto utente e CPU pescano
            if (Mazzo.deck.Count != 0)
            {
                assegna_carta(g_utente.index, g_CPU.index);
            }
            //altrimenti vengono svuotate le carte in mano
            else
            {
                Utente.carte_mano[g_utente.index] = new Carta();
                CPU.carte_mano[g_CPU.index] = new Carta();
            }
        }
        //giocata della CPU
        public void turno_CPU()
        {
            CPU giocata = new CPU();
            //si prende l'indice corrispondente alla posizione della carta nella lista delle carte in mano
            int i = giocata.giocata_CPU();
            g_CPU = CPU.carte_mano[i];
            g_CPU.index = i;
        }


    }
}
