using System;
using EShop.Shipping.Core.Contract;
using EShop.Shipping.Infrastructure;
using Microsoft.Azure.WebJobs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EShop.Core.Domain.RequestModel;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EShop.Shipping
{
    public class ShippingFunction
    {
        private readonly IServiceManager _serviceManager;
        private readonly IConfiguration _configuration;

        public ShippingFunction(IServiceManager serviceManager, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _configuration = configuration;
        }
        [FunctionName("ShippingFunction")]
        public async Task Run([ServiceBusTrigger(ServiceBusConstant.ShippingTopic, ServiceBusConstant.ShippingSubscription,
                Connection = "ServiceBusConnection", IsSessionsEnabled = true)]
            string mySbMsg, IDictionary<string, object> userProperties)
        {
            try
            {
                //Thread.Sleep(20000);
                await _serviceManager.Order.ShipOrder(JsonConvert.DeserializeObject<ShippingRequest>(mySbMsg));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
