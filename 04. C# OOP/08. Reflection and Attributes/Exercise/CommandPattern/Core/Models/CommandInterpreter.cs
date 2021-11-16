using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Models.Commands;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        //---------------------------Constants---------------------------
        private const string commandSuffix = "Command";

        //---------------------------Methods---------------------------
        public string Read(string args)
        {
            string[] tokens = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = tokens[0];
            string[] commandArgs = tokens[1..];


            // REFLECTION
            Type commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == $"{commandName}{commandSuffix}");

            // ANOTHER WAY WITH REFLECTION
            //ICommand instance = (ICommand)Activator
            //    .CreateInstance("CommandPattern", $"CommandPattern.Core.Models.Commands.{commandName}Command")
            //    .Unwrap();

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command.");
            }

            ICommand command = (ICommand)Activator.CreateInstance(commandType); //as ICommand;

            // WORKING WITHOUT REFLECTION (BUT WILL NEED FACTORY)
            //ICommand command = default;

            //if (commandName == "Hello")
            //{
            //    command = new HelloCommand();
            //}
            //else if (commandName == "Exit")
            //{
            //    command = new ExitCommand();
            //}

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
