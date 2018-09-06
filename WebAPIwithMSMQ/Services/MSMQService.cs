using System.Messaging;
using Newtonsoft.Json;

namespace WebAPIwithMSMQ.Services
{
    /// <summary>
    /// MSMQ Service
    /// </summary>
    public class MSMQService : IQueueService
    {
        private MessageQueue _microsoftQueue;

        private ISettingService _settingService;

        public MSMQService(ISettingService settingService)
        {
            this._settingService = settingService;

            this.InitMSMQ();
        }

        /// <summary>
        /// Send data to Queue
        /// </summary>
        /// <param name="data">data send to queue</param>
        public void Send(object data)
        {
            var result = JsonConvert.SerializeObject(data);

            Message demoMessage = new Message()
            {
                Formatter = new XmlMessageFormatter(),
                Body = result,
                Priority = MessagePriority.Low
            };
            
            this._microsoftQueue.Send(demoMessage);
        }

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