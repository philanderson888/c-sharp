using System;

class A
{
    protected int _a;  // AVAILABLE IN CLASS AND DERIVED
    private int _b;    // IN CLASS ONLY; NOT IN CHILDREN
    internal int _c;   // IN WHOLE OF ASSEMBLY
    protected internal int _d;  // IN SUBCLASS AND 
    
}

class B : A
{
    public B()
    {
        // Can access protected int but not private int!
        this._a = 100;
        Console.WriteLine(this._a);
        this._c = 20;
        this._d = 30;
    }
    public B(int a)
    {
        this._a = a;
    }

    public int getA()
    {
        return this._a;
    }
}

class Program
{
    static void Main()
    {
        B b = new B();
        B b2 = new B(10);
        Console.WriteLine(b2.getA());
        
        
    }
}
