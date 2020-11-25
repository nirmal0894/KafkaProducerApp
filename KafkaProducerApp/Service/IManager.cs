using Confluent.Kafka;
using KafkaProducerApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KafkaProducerApp.Service
{
    public interface IManager
    {
        Task<KafkaProcesStatus> ProcessFeedFile();
    }
}
