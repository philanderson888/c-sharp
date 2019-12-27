using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Metronome m = new Metronome();
        //    Listener l = new Listener();
        //    l.Subscribe(m);
        //    m.Subscribe2();
            m.Start();
        }
    }

    public class Metronome
    {
        public delegate void TickHandler();        // method restrictor
        public event TickHandler Tick;              // event
        public void Start()
        {
            Tick += DoThis2;

            if (Tick != null)
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(1000);
                    Tick();
                }
            }
            else
            {
                Console.WriteLine("Event is null");
            }
        }

        public void DoThis2()
        {
            Console.WriteLine("Metronome has ticked");
            System.Media.SystemSounds.Beep.Play();
        }
    }

    public class Listener
    {
        public void Subscribe(Metronome m)
        {
            m.Tick += DoThis;
        }

        private void DoThis()
        {
            Console.WriteLine("The event has happened and a method has executed the event");
        }
    }
}
