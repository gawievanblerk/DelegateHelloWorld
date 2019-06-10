using System;
using System.Threading;

namespace DelegateHelloWorld
{
    class Program
    {
        static bool isAuth;

        private static void Authorize() {
            Console.WriteLine("Authorizing ...");
            isAuth = true;
        }

        delegate void SayHelloDelegate(string name);
        public static void SayHello(string name)
        {
            if (!isAuth)
            {
                Console.WriteLine("Not Authorized.");
                Authorize();
                SayHelloDelegate del = new SayHelloDelegate(SayHello);
                del(name);
            }
            else
            {
                Console.WriteLine("SayHello is Authorized.");
                Console.WriteLine("Hello {0}", name);
            }
        }

        static void Main(string[] args)
        {
            SayHello("World");
            SayHello("Authorized World");
        }
    }
}
