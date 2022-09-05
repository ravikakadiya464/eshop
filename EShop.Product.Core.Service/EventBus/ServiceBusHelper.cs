using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;

namespace EShop.Product.Core.Service.EventBus
{
    public class ServiceBusHelper
    {
        private readonly IConfiguration _configuration;

        public ServiceBusHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendTopicMessageAsync(string topicName, string payload,
            string partitionKey = "", string sessionKey = "", IDictionary<string, object> additionalProperties = null)
        {

            var topicClient = new TopicClient(_configuration.GetConnectionString("SbConnectionString"), topicName);

            var message = new Message(Encoding.UTF8.GetBytes(payload));
            if (!string.IsNullOrEmpty(partitionKey))
            {
                message.PartitionKey = partitionKey;
            }

            if (!string.IsNullOrEmpty(sessionKey))
            {
                message.SessionId = sessionKey;
            }

            if (additionalProperties != null)
            {
                foreach (var (key, value) in additionalProperties)
                {
                    message.UserProperties.Add(key, value);
                }
            }

            await topicClient.SendAsync(message);
            return true;
        }
    }
}
