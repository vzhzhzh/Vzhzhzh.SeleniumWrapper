namespace Vzhzhzh.SeleniumWrapper
{
    public interface IRunnerConditionsInitializer
    {
        IRunnerExecutor SetConditions(int minSuccessCount = 2, int maxAttempts = 5);
    }
}