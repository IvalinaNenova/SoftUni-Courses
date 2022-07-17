using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands
{
    using System;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Environment.Exit(0);
            return null;
        }
    }
}
