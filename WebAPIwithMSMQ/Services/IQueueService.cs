using System;

namespace WebAPIwithMSMQ.Services
{
    /// <summary>
    /// Provide Queue Service
    /// </summary>
    public interface IQueueService : IDisposable
    {
        /// <summary>
        /// Send data to Queue
        /// </summary>
        /// <param name="data">data send to queue</param>
        void Send<T>(T data);

        /// <summary>
        /// Send data to Queue
        /// </summary>
        /// <param name="data">data send to queue</param>
        void Send(string data);
    }
}