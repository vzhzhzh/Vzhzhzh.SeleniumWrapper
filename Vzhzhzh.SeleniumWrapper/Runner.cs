using System;
using NUnit.Framework;

namespace Vzhzhzh.SeleniumWrapper
{
    public class Runner : IRunnerSetupInitializer, IRunnerTestInitializer, IRunnerExecutor, IRunnerConditionsInitializer
    {
        private readonly DriverHolder _driver;
        private Action _setup;
        private Action _test;
        private int _minSuccessfulAttempts;
        private int _maxAttempts;

        private int _attempts;
        private int _successfulAttempts;
        private bool _needToPerformSetup = true;

        public static IRunnerSetupInitializer Create(DriverHolder driver)
        {
            return new Runner(driver);
        }

        private Runner(DriverHolder driver)
        {
            _driver = driver;
        }

        public IRunnerTestInitializer SetSetup(Action setup = null)
        {
            _setup = setup ?? (() => { });
            return this;
        }

        public IRunnerConditionsInitializer SetTest(Action test)
        {
            _test = test;
            return this;
        }

        public IRunnerExecutor SetConditions(int minSuccessCount = 2, int maxAttempts = 5)
        {
            if (minSuccessCount > maxAttempts)
            {
                throw new InvalidOperationException("u fuckin wot mate");
            }
            _minSuccessfulAttempts = minSuccessCount;
            _maxAttempts = maxAttempts;
            return this;
        }

        public void Execute()
        {
            while (NeedMoreSuccessfulRuns() && CheckIfTestPossiblyCanBeSuccessful())
            {
                try
                {
                    _attempts++;
                    if (_needToPerformSetup)
                    {
                        _setup();
                    }
                    _test();
                    _successfulAttempts++;
                    _needToPerformSetup = false;
                }
                catch (Exception)
                {
                    CleanUp();
                    _maxAttempts--;
                    _needToPerformSetup = true;
                }
            }

            if (_successfulAttempts < _minSuccessfulAttempts)
            {
                throw new AssertionException("test failed");
            }
        }

        private void CleanUp()
        {
            _driver.TearDown();
        }

        private bool NeedMoreSuccessfulRuns()
        {
            return _successfulAttempts < _minSuccessfulAttempts;
        }

        private bool CheckIfTestPossiblyCanBeSuccessful()
        {
            return _maxAttempts - _attempts >= _minSuccessfulAttempts - _successfulAttempts;
        }
    }
}