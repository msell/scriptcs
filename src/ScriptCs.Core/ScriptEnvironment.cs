using System.Collections.Generic;
using ScriptCs.Contracts;

namespace ScriptCs
{
    public class ScriptEnvironment
    {
        public ScriptEnvironment(string[] scriptArgs, IFileSystem fileSystem)
        {
            ScriptArgs = scriptArgs;
            WorkingDirectory = fileSystem.CurrentDirectory;
        }

        public IReadOnlyList<string> ScriptArgs { get; private set; }
        public static string WorkingDirectory { get; private set; }
    }
}