using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avagnano.marco._5i.briscola
{
    class CPU
    {
        public static List<Carta> carte_mano = new List<Carta>();
        public static bool mio_turno = false;
        public static int punteggio = 0;

        //la CPU in base alla Carta giocata dall'Utente fa la sua mossa
        public int scelta(Carta giocata)
        {
            //siamo nel caso in cui la carta giocata dall'utente è una briscola
            if (giocata.sem == Gioco.briscola)
            {
                //controlliamo che la carta dell'utente abbia un valore
                if (giocata.value != 0)
                {
                    //in caso una delle tre carte della CPU sia briscola e abbia un valore maggiore di quella dell'utente viene giocata
                    if (carte_mano[0].sem == Gioco.briscola && carte_mano[0].value > giocata.value && carte_mano[0].sem != null)
                    {
                        return 0;
                    }
                    if (carte_mano[1].sem == Gioco.briscola && carte_mano[1].value > giocata.value && carte_mano[1].sem != null)
                    {
                        return 1;
                    }
                    if (carte_mano[2].sem == Gioco.briscola && carte_mano[2].value > giocata.value && carte_mano[2].sem != null)
                    {
                        return 2;
                    }
                }
                else
                {
                    //in questo caso se la briscola dell'utente non ha valore la CPU va liscio
                    if (carte_mano[0].value == 0 && carte_mano[0].sem != Gioco.briscola && carte_mano[0].sem != null)
                    {
                        return 0;
                    }
                    if (carte_mano[1].value == 0 && carte_mano[1].sem != Gioco.briscola && carte_mano[1].sem != null)
                    {
                        return 1;
                    }
                    if (carte_mano[2].value == 0 && carte_mano[2].sem != Gioco.briscola && carte_mano[2].sem != null)
                    {
                        return 2;
                    }
                }

            }
            //siamo nel caso in cui la carta giocata dall'utente non è una briscola
            if (giocata.sem != Gioco.briscola)
            {
                //controlliamo che il valore della carta giocata dall'utente sia maggiore di 0
                if (giocata.value != 0)
                {
                    //se la carta giocata dall'utente ha un valore alto allora la CPU cerca di buttare una briscola
                    if (giocata.value == 11 || giocata.value == 10 || giocata.value == 4)
                    {
                        if (carte_mano[0].sem == Gioco.briscola && carte_mano[0].sem != null)
                        {
                            return 0;
                        }
                        if (carte_mano[1].sem == Gioco.briscola && carte_mano[1].sem != null)
                        {
                            return 1;
                        }
                        if (carte_mano[2].sem == Gioco.briscola && carte_mano[2].sem != null)
                        {
                            return 2;
                        }
                    }
                    //la CPU controlla se ha una carta con lo stesso seme di quella giocata dall'utente con un maggior valore
                    if (giocata.sem == carte_mano[0].sem && carte_mano[0].value > giocata.value && carte_mano[0].sem != null)
                    {
                        return 0;
                    }
                    if (giocata.sem == carte_mano[1].sem && carte_mano[1].value > giocata.value && carte_mano[1].sem != null)
                    {
                        return 1;
                    }
                    if (giocata.sem == carte_mano[2].sem && carte_mano[2].value > giocata.value && carte_mano[2].sem != null)
                    {
                        return 2;
                    }
                }
                else
                {
                    //se la carta dell'utente non ha valore la CPU va liscio
                    if (carte_mano[0].value == 0 && carte_mano[0].sem != null)
                    {
                        return 0;
                    }
                    if (carte_mano[1].value == 0 && carte_mano[1].sem != null)
                    {
                        return 1;
                    }
                    if (carte_mano[2].value == 0 && carte_mano[2].sem != null)
                    {
                        return 2;
                    }
                }
            }
            if (carte_mano[0].sem != null)
            {
                return 0;
            }
            if (carte_mano[1].sem != null)
            {
                return 1;
            }
            if (carte_mano[2].sem != null)
            {
                return 2;
            }
            return 0;
        }
        //metodo utilizzato quando la CPU gioca per prima
        public int giocata_CPU()
        {
            //la CPU cerca di usare sempre liscio o di buttare la carta con il valore minore
            if(carte_mano[0].sem != null && carte_mano[0].value==0)
            {
                return 0;
            }
            if (carte_mano[1].sem != null && carte_mano[1].value == 0)
            {
                return 1;
            }
            if (carte_mano[2].sem != null && carte_mano[2].value == 0)
            {
                return 2;
            }
            if(carte_mano[0].sem != null  && carte_mano[0].value <= carte_mano[1].value && carte_mano[0].value <= carte_mano[1].value)
            {
                return 0;
            }
            if(carte_mano[1].sem != null  && carte_mano[1].value <= carte_mano[0].value && carte_mano[1].value <= carte_mano[2].value)
            {
                return 1;
            }
            if (carte_mano[2].sem != null  && carte_mano[2].value <= carte_mano[0].value && carte_mano[2].value <= carte_mano[1].value)
            {
                return 2;
            }
            if (carte_mano[0].sem != null )
            {
                return 0;
            }
            if (carte_mano[1].sem != null)
            {
                return 1;
            }
            if (carte_mano[2].sem != null)
            {
                return 2;
            }
            return 0;
        }

    }
}
