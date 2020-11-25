using KafkaProducerApp.Config;
using KafkaProducerApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KafkaProducerApp.Service
{
    public class GetFileRecords :IGetFileRecords
    {
        private readonly EnvironmentConfiguration config;
        public GetFileRecords(EnvironmentConfiguration _config)
        {
            this.config = _config;
        }
        public IEnumerable<Profile> GetFileDetails()
        {
            if (File.Exists(config.FeedFileAbsolutePath))
            {
                var fileDetails = ProcessRecords();
                return fileDetails;
            }
            else
            {
                return null;
            }
        }

        public void FeedFileRemove()
        {
            File.Delete(config.FeedFileAbsolutePath);
        }

        private IEnumerable<Profile> ProcessRecords()
        {
            var allRows = new List<string>();
            try
            {
                var text = File.ReadAllText(config.FeedFileAbsolutePath);
                //To do : Read the encrypted file and call decryption service and use the response to call the api 
                byte[] byteArray = Encoding.UTF8.GetBytes(text);
                var sourceStream = new MemoryStream(byteArray);
                // var result = gpgService.DecryptAndReturnStream(this.decryptionConfiguration.GpgHomePath, this.decryptionConfiguration.BinaryPath, this.decryptionConfiguration.Passphrase, byteArray);
                string result = string.Empty;
                using (var streamReader = new StreamReader(sourceStream))
                {
                    string line = String.Empty;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        allRows.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            var profile = new List<Profile>();
            var header = "id~productname~quantity";
            var separator = '~';
            var headerColumns = header.Split(separator);
            foreach (var row in allRows.Skip(1).Where(row => !string.IsNullOrWhiteSpace(row)))
            {
                var rowColumns = row.Split(separator);
                var id = Array.IndexOf(headerColumns, "id");
                var productname = Array.IndexOf(headerColumns, "productname");
                var quantity = Array.IndexOf(headerColumns, "quantity");
                //yield return new Profile
                //{
                //    Id = Convert.ToInt32(rowColumns[id]),
                //    Productname = rowColumns[productname],
                //    Quantity = Convert.ToInt32(rowColumns[quantity])
                //};

                profile.Add(new Profile()
                {
                    Id = Convert.ToInt32(rowColumns[id]),
                    Productname = rowColumns[productname],
                    Quantity = Convert.ToInt32(rowColumns[quantity])
                });
                //return profile;
            }
            return profile;
        }

        private bool FileIsNotBeingWrittenTo()
        {
            FileStream stream = null;

            try
            {
                stream = File.Open(config.FeedFileAbsolutePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return false;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            return true;
        }
    }
}
