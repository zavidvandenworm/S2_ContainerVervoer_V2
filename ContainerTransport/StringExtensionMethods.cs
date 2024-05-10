using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ContainerTransport
{
    public static class StringExtensionMethods
    {
        public static bool ValidateJson(this string s)
        {
            try
            {
                JToken.Parse(s);
                return true;
            }
            catch (JsonReaderException ex)
            {
                return false;
            }
        }
    }
}
