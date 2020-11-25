using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaProducerApp.Service
{
    interface IScheduleFeedFile
    {
        void Start();

        void Stop();
    }
}
