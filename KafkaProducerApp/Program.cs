using KafkaProducerApp.Service;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Quartz;
using System;
using System.Diagnostics;
using System.IO;
using Topshelf;

namespace KafkaProducerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // var scheduler = new SchedulerBuilder();
            //var p = scheduler.ScheduleJob();

            HostFactory.Run(x =>
            {
                x.Service<FeedFileProcessor>(service =>
                {
                    service.ConstructUsing(s => new FeedFileProcessor());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                // Service log on as
                x.RunAsLocalSystem()
                  .StartAutomatically()
                  .EnableServiceRecovery(rc => rc.RestartService(5));

                x.SetServiceName("FeedFileProcessorService");
                x.SetDisplayName("FeedFileProcessor");
                x.SetDescription("Process the files , decryptes and calls the API to push to kafka");
            });

        }
    }
}
