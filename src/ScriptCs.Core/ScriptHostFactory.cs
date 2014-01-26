using ScriptCs.Contracts;

namespace ScriptCs
{
    public class ScriptHostFactory : IScriptHostFactory
    {
        public IScriptHost CreateScriptHost(IScriptPackManager scriptPackManager, string[] scriptArgs, IFileSystem fileSystem)
        {
            return new ScriptHost(scriptPackManager, new ScriptEnvironment(scriptArgs, fileSystem));
        }
    }
}