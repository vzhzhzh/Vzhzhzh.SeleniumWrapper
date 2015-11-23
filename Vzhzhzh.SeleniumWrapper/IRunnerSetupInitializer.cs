using System;

namespace Vzhzhzh.SeleniumWrapper
{
    public interface IRunnerSetupInitializer
    {
        IRunnerTestInitializer SetSetup(Action setup);
    }
}