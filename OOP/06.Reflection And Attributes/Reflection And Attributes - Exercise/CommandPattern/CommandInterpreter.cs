using CommandPattern.Core.Contracts;
using System.Linq;
using System.Reflection;

namespace CommandPattern
{
    using System;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputInfo = args.Split(' ');

            string commandName = inputInfo[0] + "Command";
            string[] parameters = inputInfo.Skip(1).ToArray();

            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandName);

            ICommand command = Activator.CreateInstance(type) as ICommand;

            string result = command.Execute(parameters);

            return result;
        }
    }
}
