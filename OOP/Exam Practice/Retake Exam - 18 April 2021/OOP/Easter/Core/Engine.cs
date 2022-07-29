namespace Easter.Core
{
    using System;

    using Easter.IO;
    using Easter.IO.Contracts;
    using Easter.Core.Contracts;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            //this.controller = new Controller();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;

                    if (input[0] == "AddBunny")
                    {
                        string bunnyType = input[1];
                        string bunnyName = input[2];

                        result = controller.AddBunny(bunnyType, bunnyName);
                    }
                    else if (input[0] == "AddEgg")
                    {
                        string eggName = input[1];
                        int energyRequired = int.Parse(input[2]);

                        result = controller.AddEgg(eggName, energyRequired);
                    }
                    else if (input[0] == "AddDyeToBunny")
                    {
                        string bunnyName = input[1];
                        int power = int.Parse(input[2]);

                        result = controller.AddDyeToBunny(bunnyName, power);
                    }
                    else if (input[0] == "ColorEgg")
                    {
                        string eggName = input[1];

                        result = controller.ColorEgg(eggName);
                    }
                    else if (input[0] == "Report")
                    {
                        result = controller.Report();
                    }

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
