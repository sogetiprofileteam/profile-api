namespace sogeti_portfolio_api.Interfaces
{
    public interface IJsonSerialization
    {
         string SerializeWithCamelCaseProperties<T>(T value);
    }
}