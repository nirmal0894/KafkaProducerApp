namespace KafkaProducerApp
{
    using Confluent.Kafka;
    using System;
    using System.Threading;
    public class ConsumerWrapper
    {
        private string _topicName;
        private ConsumerConfig _consumerConfig;
        private ConsumerBuilder<string,string> _consumer;
        private static readonly Random rand = new Random();
        public ConsumerWrapper(ConsumerConfig config,string topicName)
        {
            this._topicName = topicName;
            this._consumerConfig = config;
            this._consumer = new ConsumerBuilder<string,string>(this._consumerConfig);
            this._consumer.Build().Subscribe(topicName);
        }
        public string readMessage(){
            var consumeResult = this._consumer.Build().Consume();
            return consumeResult.Value;// Value;
        }
    }
}