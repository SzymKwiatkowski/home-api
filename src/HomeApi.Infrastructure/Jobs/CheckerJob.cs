using Quartz;

namespace HomeApi.Infrastructure.Jobs;

public class CheckerJob : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        return Task.CompletedTask;
    }
}
