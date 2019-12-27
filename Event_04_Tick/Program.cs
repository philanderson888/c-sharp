/*https://www.codeproject.com/Articles/11541/The-Simplest-C-Events-Example-Imaginable*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_04_Tick
{
    class Program
    {
        static void Main(string[] args)
        {
            Metronome m = new Metronome();
            Listener l = new Listener();
            l.Subscribe(m);
            m.Start();

        }
    }





    public class Metronome
    {
        public event TickHandler Tick;                 // new event called TICK which has restrictions on methods that
                                                       // can run, restricted by delegate TICKHANDLER

        public EventArgs e = null;                      // null ARGUMENTS PASSED INTO THIS EVENT

        public delegate void TickHandler(Metronome m, EventArgs e);
                                                        // DELEGATE TICKHANDLER RESTRICTING THE TYPE OF METHODS THAT
                                                        // CAN RESPOND TO THE TICK EVENT

        public void Start()
        {

            if (Tick != null)                           // VALIDATE TICK EVENT EXISTS
            {
                Tick(this, e);                           // MAKE THE TICK EVENT HAPPEN FROM (THIS INSTANCE OF A METRONOME 
                                                         // OBJECT AND PASSING IN EVENT ARGUMENTS E (IN THIS CASE, NULL))
            }

        }
    }




    public class Listener
    {
        public void Subscribe(Metronome m)
        {
            m.Tick += new Metronome.TickHandler(HeardIt);
            m.Tick += HeardIt;
            m.Tick += HeardItHereToo;
                                                // TO THE METRONOME TICK EVENT ADD A NEW METHOD 
        }


        private void HeardIt(Metronome m, EventArgs e)
        {
            System.Console.WriteLine("HEARD IT ");
        }

        private void HeardItHereToo(Metronome m, EventArgs e)
        {
            Console.WriteLine("Heard it here too");
        }

    }



}
