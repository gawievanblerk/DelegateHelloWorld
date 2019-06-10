using System;

namespace DelegateHelloWorld
{
    class Program
    {
        static bool isAuth;

        private static void Authorize()
        {

            Console.WriteLine("Authorizing ...");
            isAuth = true;

        }

        delegate void SayHelloDelegate(string name, int retries = 0);
        public static void SayHello(string name, int retries = 0)
        {
            if (!isAuth && retries < 3)
            {
                Console.WriteLine("Not Authorized.");
                Authorize();
                retries++;
                SayHelloDelegate del = new SayHelloDelegate(SayHello);
                del(name, retries);
            }
            else if (!isAuth)
            {
                Console.WriteLine("Failed to Authorize");
            }
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
