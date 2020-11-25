using KafkaProducerApp.Model;
using System.Collections.Generic;

namespace KafkaProducerApp.Service
{
    public interface IGetFileRecords
    {
        IEnumerable<Profile> GetFileDetails();
        void FeedFileRemove();
    }
}
