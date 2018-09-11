using System;
using System.Messaging;
using WebAPIwithMSMQ.Utilities;

namespace WebAPIwithMSMQ.Services
{
    /// <summary>
    /// MSMQ Service
    /// </summary>
    public class MSMQService : IQueueService
    {
        private MessageQueue _microsoftQueue;

        private ISettingService _settingService;

        private bool disposed = false;

        /// <summary>
        /// Contructor of MSMQService
        /// </summary>
        /// <param name="settingService">ISettingService</param>
        public MSMQService(ISettingService settingService)
        {
            this._settingService = settingService;

            this.InitMSMQ();
        }

        /// <summary>
        /// Release the resource
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            // avoid redundant function call
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                if (this._microsoftQueue != null)
                {
                    this._microsoftQueue.Dispose();
                }
            }

            this.disposed = true;
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~MSMQService()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Send data to Queue
        /// </summary>
        /// <param name="data">data send to queue</param>
        public void Send<T>(T data)
        {
            var result = XmlHelper.SerializeToMSMQMailFormat(data);
            using (Message demoMessage = new Message())
            {
                demoMessage.BodyStream = new System.IO.MemoryStream(System.Text.Encoding.Unicode.GetBytes(result.ToCharArray()));
                demoMessage.BodyType = 8;
                demoMessage.Recoverable = false;
                demoMessage.UseAuthentication = false;
                demoMessage.UseDeadLetterQueue = false;
                demoMessage.UseEncryption = false;
                demoMessage.Priority = MessagePriority.Normal;
                demoMessage.Formatter = new XmlMessageFormatter(new Type[1]
                {
                        typeof(string)
                });

                this._microsoftQueue.Send(demoMessage, MessageQueueTransactionType.Single);
            }
        }

        /// <summary>
        /// Send data to Queue
        /// </summary>
        /// <param name="data">data send to queue</param>
        public void Send(string data)
        {
            using (Message demoMessage = new Message(data))
            {
                demoMessage.BodyType = 8;
                demoMessage.Recoverable = false;
                demoMessage.UseAuthentication = false;
                demoMessage.UseDeadLetterQueue = false;
                demoMessage.UseEncryption = false;
                demoMessage.Priority = MessagePriority.Normal;
                demoMessage.Formatter = new XmlMessageFormatter(new Type[1]
                {
                        typeof(string)
                });

                this._microsoftQueue.Send(demoMessage, MessageQueueTransactionType.Single);
            }
        }

        /// <summary>
        /// Initionalize MSMQ Service class
        /// </summary>
        private void InitMSMQ()
        {
            var path = this._settingService.GetValue("MSMQPath");

            // represent local path
            if (path.StartsWith(@".\"))
            {
                if (MessageQueue.Exists(path))
                {
                    this._microsoftQueue = new MessageQueue(path);
                }
                else
                {
                    this._microsoftQueue = MessageQueue.Create(path);
                }
            }
            else
            {
                this._microsoftQueue = new MessageQueue(path);
            }
        }
    }
}