using RabbitMQ.Client;
namespace StoreApi.MessageHandler
{
    public class MessageBrokerHandler
    {
        private readonly IConfiguration _configuration;
        internal MessageBrokerHandler(IConfiguration iconfig) => _configuration = iconfig;

     

        internal IConnection ConnectMq() {

            var ip = _configuration["RabbitMQ:ip"];
            var port = _configuration["RabbitMQ:port"];
            var username = _configuration["RabbitMQ:username"];
            var password = _configuration["RabbitMQ:password"];
            var factory = new ConnectionFactory { HostName =ip,Port=int.Parse(port), UserName= username,Password=password};
          
                return factory.CreateConnection(); 
           
        }

    }
}
