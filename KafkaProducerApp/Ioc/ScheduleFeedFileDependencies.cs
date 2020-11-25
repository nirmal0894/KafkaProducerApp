using System;
using System.Collections.Generic;
using System.Text;
using Unity.Extension;

namespace KafkaProducerApp.Ioc
{
    public class ScheduleFeedFileDependencies : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IScheduleFeedFileMonitoring, FeedFileJobScheduler>();
        }
        
    }
}
