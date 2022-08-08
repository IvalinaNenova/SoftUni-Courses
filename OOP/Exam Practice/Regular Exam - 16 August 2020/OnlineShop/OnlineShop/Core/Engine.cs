using System;
using OnlineShop.IO;

namespace OnlineShop.Core
{
    public class Engine : IEngine
    {
        private const string Separator = " ";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IController controller;

        public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter, IController controller)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;
            this.controller = controller;
        }

        public void Run()
        {
            while (true)
            {
                string[] data = this.reader.CustomReadLine().Split(Separator);
                string msg;

                try
                {
                    msg = this.commandInterpreter.ExecuteCommand(data, this.controller);
                }
                catch (ArgumentException e)
                {
                    msg = e.Message;
                }
                catch (InvalidOperationException e)
                {
                    msg = e.Message;
                }

                this.writer.CustomWriteLine(msg);
            }
        }
    }
}