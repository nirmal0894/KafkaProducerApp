using KafkaProducerApp.Config;
using KafkaProducerApp.Job;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Specialized;

namespace KafkaProducerApp.Service
{
    public class FeedFileProcessor : IScheduleFeedFile
    {
        private readonly IScheduler scheduler;
        public FeedFileProcessor()
        {
            NameValueCollection props = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" },
                { "quartz.scheduler.instanceName", "MyScheduler" },
                { "quartz.jobStore.type", "Quartz.Simpl.RAMJobStore, Quartz" },
                { "quartz.threadPool.threadCount", "3" }
            };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);
            scheduler = factory.GetScheduler().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public void Start()
        {

            scheduler.Start().ConfigureAwait(false).GetAwaiter().GetResult();

            ScheduleJobs();
            //var envConfig = new EnvironmentConfiguration();
            ////var kafkaApiClient  = new KafkaApiClient(envConfig);

            //var getFileDetails = new GetFileRecords(envConfig);
            //var feedFileManager = new FeedFileManager(getFileDetails);
            //feedFileManager.ProcessFeedFile();
        }

        public void ScheduleJobs()
        {
            IJobDetail job = JobBuilder.Create<ScheduleJob>()
                .WithIdentity("job1", "group1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
                .Build();

            // Tell quartz to schedule the job using our trigger
            var test = scheduler.ScheduleJob(job, trigger).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        public void Stop()
        {
            //throw new NotImplementedException();
            scheduler.Shutdown().ConfigureAwait(false).GetAwaiter().GetResult();
            Console.WriteLine("Service Stopped");
        }
    }
}
