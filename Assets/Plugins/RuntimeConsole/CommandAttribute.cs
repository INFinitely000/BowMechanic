using System;

namespace RuntimeConsole
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class CommandAttribute : Attribute
    {
        public string Command { get; private set; }
        public string Description { get; private set; }

        public CommandAttribute() {}

        public CommandAttribute(string command, string description)
        {
            Command = command;
            Description = description;
        }
    }
}