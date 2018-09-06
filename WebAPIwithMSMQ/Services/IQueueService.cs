using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIwithMSMQ.Services
{
    /// <summary>
    /// Provide Queue Service
    /// </summary>
    public interface IQueueService
    {
        /// <summary>
        /// Put data into queue
        /// </summary>
        /// <param name="data"></param>
        void Put<T>(T data);
    }
}