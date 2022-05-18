using System;
using Xunit;
using CommandAPI.Models;

namespace CommandAPI.Tests
{
    public class CommandTests : IDisposable
    {
        Command testCommand;
        public CommandTests()
        {
             testCommand = new Command
            {
                HowTo = "Do something ",
                Platform = "Some platform",
                CommandLine = "Some commandLine"
            };
        }
        public void Dispose()
        {
            testCommand = null;
        }
        [Fact]
        public void CanChangeHowTo()
        {
            testCommand.HowTo = "Execute Unit Tests";
            Assert.Equal("Execute Unit Tests", testCommand.HowTo);
        }
        [Fact]
        public void CanChangePlatform()
        {
            testCommand.Platform = "xUnit";
            Assert.Equal("xUnit", testCommand.Platform);
        }
        [Fact]
        public void CanChangeCommandLine()
        {
            testCommand.CommandLine = "dotnet test";
            Assert.Equal("dotnet test", testCommand.CommandLine);
        }
    }
}