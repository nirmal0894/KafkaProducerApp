using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaProducerApp.Ioc
{
    interface IScheduleFeedFileMonitoring
    {
        void Start();

        void Stop();
    }
}
