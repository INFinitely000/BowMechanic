using System;
using System.Reflection;

namespace RuntimeConsole
{
    public struct CommandData
    {
        public string description;
        public MethodInfo method;
        public Type[] parameters;
        
        public CommandData(string description, MethodInfo method, Type[] parameters)
        {
            this.method = method;
            this.parameters = parameters;
            this.description = description;
        }
    }
}