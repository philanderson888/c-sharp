using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle();
            r.Changed += Method01;  // fire method01 when Changed event occurs
            r.Changed += r.Method02; // fire this method also which is internal to class
            r.Length = 10;
            r.Width = 20;
        }

        static void Method01(object sender, EventArgs e)
        {
            Rectangle r = (Rectangle)sender;  // Obtain the rectangle object passed in
            Console.WriteLine("Dimensions changed : Length is now {0} and Width is now {1}",r.Length,r.Width);
        }
    }

    public delegate void EventHandler(Object sender, EventArgs e);  // Defines the types of methods which can run when an event is fired in C# ie must be void but have 2 input parameters

    class Rectangle
    {
        public event EventHandler Changed;  // Event is the 'changed' event (ie fires when a rectangle dimensions are changed).  The types of methods which can run when this event fires are restricted by the delegate ie will be void and accept object sender and eventargs as the two arguments input

        private double length;
        private double width;
        public double Length
        {
            get { return length; }
            set {
                length = value;
                Changed(this, EventArgs.Empty);  // fire this event when new value set
            }
        }
        public double Width
        {
            get { return width; }
            set
            {
                width = value;
                Changed(this, EventArgs.Empty);
            }
        }

        public void Method02(object sender, EventArgs e)
        {
            Console.WriteLine("In Method 02 also");
            Console.WriteLine("Length is {0} and width is {1}",this.length,this.width);
        }
    }
}
