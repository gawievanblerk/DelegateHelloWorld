using System;
using System.Threading;

namespace DelegateHelloWorld
{
    class Program
    {
        static bool isAuth;

        delegate void SayHelloDelegate(string name);
        public static void SayHello(string name)
        {
            if (!isAuth)
            {
                Console.WriteLine("Not Authorized.");
                isAuth = true;
                SayHelloDelegate del = new SayHelloDelegate(SayHello);
                del(name);
            }
            else
            {
                Console.WriteLine("SayHello is now Authorized.");
                Console.WriteLine("Hello {0}", name);
            }
        }

        static void Main(string[] args)
        {
            SayHello("World");
            Console.ReadLine();
        }
    }
}
