using KafkaProducerApp.Config;
using KafkaProducerApp.Model;
using KafkaProducerApp.Service;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace KafkaProducerApp.Job
{
    public class ScheduleJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            //var lastRun = context.PreviousFireTimeUtc?.DateTime.ToString() ?? string.Empty;
            //Log.Warning("Greetings from HelloJob!   Previous run: {lastRun}", lastRun);
            var envConfig = new EnvironmentConfiguration();
            

            var getFileDetails = new GetFileRecords(envConfig);
            var feedFileManager = new FeedFileManager(getFileDetails);
            var result = feedFileManager.ProcessFeedFile();

            if(result.Equals(KafkaProcesStatus.completed))
            {
                File.Delete(envConfig.FeedFileAbsolutePath);
            }
            
            return Task.CompletedTask;
        }
    }
}
