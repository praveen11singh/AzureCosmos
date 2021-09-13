using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
namespace ConsoleApp7
{
    class JsonData
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
             const string EndpointUrl = @"https://pkcosmosaccount.documents.azure.com:443/";
             const string PrimaryKey = @"BTqe4xYQulPLMOVmZjl71L5gM3jwgO2ykSuewT1LjYIMKuyqL6tJbiPdmvyl39oMVlraUToXjggIfGn8GteU3A==";
             DocumentClient client;
             client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            IQueryable<JsonData> familyQuery = client.CreateDocumentQuery<JsonData>(
                    UriFactory.CreateDocumentCollectionUri("praveen", "container1"), queryOptions);
            foreach (var x in familyQuery)
            {
                Console.WriteLine("\tRead {0}", x.id + "  " + x.name);
            }
            Console.Read();
        }
    }
}
