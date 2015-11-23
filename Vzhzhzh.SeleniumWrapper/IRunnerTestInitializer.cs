using System;

namespace Vzhzhzh.SeleniumWrapper
{
    public interface IRunnerTestInitializer
    {
        IRunnerConditionsInitializer SetTest(Action test);
    }
}