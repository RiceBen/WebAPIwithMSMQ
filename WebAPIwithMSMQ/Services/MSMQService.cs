using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIwithMSMQ.Services
{
    /// <summary>
    /// MSMQ Service
    /// </summary>
    public class MSMQService : IQueueService
    {
        /// <summary>
        /// Put data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        public void Put<T>(T data)
        {
            
        }
    }
}