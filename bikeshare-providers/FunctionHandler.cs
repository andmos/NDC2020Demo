using System;
using System.Text;

using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.IO;
using Newtonsoft.Json;
using System.Globalization;

namespace Function
{
    public class FunctionHandler
    {
        private readonly Uri _bikeshareProvidersFile = new Uri(@"https://raw.githubusercontent.com/NABSA/gbfs/master/systems.csv");
        private readonly HttpClient _httpClient;
        public FunctionHandler()
        {
            _httpClient = new HttpClient();
        }
        public async Task<string> Handle(string input) 
        {
            
            List<BikeshareProvider> bikeshareSystems = new List<BikeshareProvider>();
            using(var reader = new StreamReader(await _httpClient.GetStreamAsync(_bikeshareProvidersFile)))
            {
                using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    bikeshareSystems = csv.GetRecords<BikeshareProvider>().ToList();
                }
            }
            return JsonConvert.SerializeObject(bikeshareSystems);
            
        }
        public class BikeshareProvider
        {
            [Name("Country Code")]
            public string CountryCode {get; set;} 
            [Name("Name")]
            public string Name {get; set;}
            [Name("Location")]
            public string Location {get; set;}
            [Name("System ID")]
            public string Id {get; set;}
            [Name("URL")]
            public string Url {get; set;}
            [Name("Auto-Discovery URL")]
            public string GBFSFileUrl {get; set;}  
        }
    }
}
