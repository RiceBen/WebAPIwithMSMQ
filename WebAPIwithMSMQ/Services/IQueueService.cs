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
        /// Send data to Queue
        /// </summary>
        /// <param name="data">data send to queue</param>
        void Send(object data);
    }
}