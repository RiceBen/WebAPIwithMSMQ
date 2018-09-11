using System;

namespace WebAPIwithMSMQ.Services
{
    /// <summary>
    /// Setting Service
    /// </summary>
    public interface ISettingService
    {
        /// <summary>
        /// Get Value in Setting
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        string GetValue(String key);
    }
}