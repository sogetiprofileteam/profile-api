using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using sogeti_portfolio_api.Interfaces;

namespace sogeti_portfolio_api.Models
{
    public class JsonSerialize: IJsonSerialization
    {
        public JsonSerializerSettings settings = new JsonSerializerSettings() {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public string Serialize(object value) {
            var serialized = JsonConvert.SerializeObject(value, Formatting.Indented, settings);
            return serialized;
        }
    }
}