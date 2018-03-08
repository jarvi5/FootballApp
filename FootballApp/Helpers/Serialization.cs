using Newtonsoft.Json;
namespace FootballApp.Helpers
{
    public static class Serialization<T>
    {
        public static string Serialize(T value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public static T Deserialize(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
