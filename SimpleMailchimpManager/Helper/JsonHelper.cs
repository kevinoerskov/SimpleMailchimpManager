using Newtonsoft.Json;
using System.Text;

namespace SimpleMailchimpManager.Helper
{
    internal static class JsonHelper
    {
        internal static T DeserializeTo<T>(byte[] serializedData)
        {
            var dataString = Encoding.UTF8.GetString(serializedData);
            var deserializedObject = JsonConvert.DeserializeObject<T>(dataString);

            return deserializedObject;
        }

        internal static byte[] Serialize(object objectToSerialize)
        {
            var serializedData = JsonConvert.SerializeObject(objectToSerialize);
            var byteArrayData = Encoding.UTF8.GetBytes(serializedData);

            return byteArrayData;
        }
    }
}