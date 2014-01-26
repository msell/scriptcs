using System;
using Moq;

using ScriptCs.Contracts;

using Should;

using Xunit;

namespace ScriptCs.Tests
{
    public class ScriptHostTests
    {
        public class TheGetMethod
        {
            private Mock<IScriptPackContext> _mockContext = new Mock<IScriptPackContext>();
            private Mock<IScriptPackManager> _mockScriptPackManager = new Mock<IScriptPackManager>();
            private IFileSystem _mockFileSystem = Mock.Of<IFileSystem>();
            private ScriptHost _scriptHost; 

            public TheGetMethod()
            {
                _scriptHost = new ScriptHost(_mockScriptPackManager.Object, new ScriptEnvironment(new string[0], _mockFileSystem));
                _mockScriptPackManager.Setup(s => s.Get<IScriptPackContext>()).Returns(_mockContext.Object);
            }

            [Fact]
            public void ShoulGetScriptPackFromScriptPackManagerWhenInvoked()
            {
                var result = _scriptHost.Require<IScriptPackContext>();
                _mockScriptPackManager.Verify(s => s.Get<IScriptPackContext>());
            }
        }

        public class TheConstructor
        {
            private IFileSystem _mockFileSystem = Mock.Of<IFileSystem>();
            [Fact]
            public void ShouldSetScriptEnvironment()
            {
                Mock.Get(_mockFileSystem).Setup(x => x.CurrentDirectory).Returns(Environment.CurrentDirectory);

                var environment = new ScriptEnvironment(new string[0], _mockFileSystem);
                var scriptHost = new ScriptHost(null, environment);

                scriptHost.Env.ShouldEqual(environment);
            }
        }
    }
}
