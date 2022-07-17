using System.Security.Cryptography.X509Certificates;

namespace AuthorProblem
{
    using System;
    public class StartUp
    {
        [Author("Marina")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();

            tracker.PrintMethodsByAuthor();
        }

        [Author("Vanya")]
        public void BlahBlah()
        {

        }
        [Author("Ivalina")]
        public static void Something()
        {

        }
    }
}
