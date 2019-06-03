using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using sogeti_portfolio_api.Interfaces;

namespace sogeti_portfolio_api.Models
{
    public class JsonSerialize: IJsonSerialization
    {
        private JsonSerializerSettings Settings => new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public string SerializeWithCamelCaseProperties<T>(T value) =>
            JsonConvert.SerializeObject(value, Formatting.Indented, Settings);
            
    }
}