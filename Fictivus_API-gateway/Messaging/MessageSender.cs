using Fictivus_API_gateway.DTO;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fictivus_API_gateway.Messaging
{
    public class MessageSender
    {
        //moet DTO kunnen zenden
        public static void SendMessage(string methodRequested, string dto)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "write",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(methodRequested + dto);

                channel.BasicPublish(exchange: "",
                                     routingKey: "write",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", dto);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
