using HomeApi.Infrastructure.Jobs;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace HomeApi.Infrastructure.Extensions;

public static class QuartzExtensions
{
    public static IServiceCollection AddQuartz(this IServiceCollection services)
    {
        // Add job that repeats forever
        services.AddQuartzJob<CheckerJob>(WithSimpleSchedule(TimeSpan.FromMinutes(1)));

        services.AddQuartzHostedService();

        return services;
    }

    public static IServiceCollection AddQuartzJob<T>(this IServiceCollection services, IScheduleBuilder scheduleConfiguration) where T : class, IJob
    {
        services.AddQuartz(configure =>
        {
            var jobKey = new JobKey(nameof(T));
            
            configure.AddJob<T>(jobKey)
                .AddTrigger(trigger => trigger.ForJob(jobKey)
                    .WithSchedule(scheduleConfiguration));
        });
        
        return services;
    }

    public static IScheduleBuilder WithSimpleSchedule(TimeSpan timespan, bool repeat = true, int? repeatCount = null)
    {
        var scheduler = SimpleScheduleBuilder.Create();
        
        scheduler.WithInterval(timespan);
        
        if (repeat && repeatCount.HasValue)
        {
            scheduler.WithRepeatCount(repeatCount.Value);
        }
        else if (repeat && (repeatCount is null))
        {
            scheduler.RepeatForever();
        }

        return scheduler;
    }
}
