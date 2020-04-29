using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace rummqListener
{
    class Listener
    {
        static void Main(string[] args)
        {

            Console.WriteLine(" Listener has been started");
            string message = "";

            MongoConnector m = new MongoConnector();
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "check",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    message = Encoding.UTF8.GetString(body);
                    if (message.Length > 0)
                    {
                        m.InsertDataToDB(message);
                    }


                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "check",
                                             autoAck: true,
                                             consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
