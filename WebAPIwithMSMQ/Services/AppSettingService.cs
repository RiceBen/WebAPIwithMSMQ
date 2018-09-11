using System.Collections.Specialized;
using System.Configuration;

namespace WebAPIwithMSMQ.Services
{
    public class AppSettingService : ISettingService
    {
        private NameValueCollection collection;

        public AppSettingService()
        {
            collection = ConfigurationManager.AppSettings;
        }

        /// <summary>
        /// Get Value in Setting
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        public string GetValue(string key)
        {
            var value = collection.Get(key);

            return value;
        }
    }
}