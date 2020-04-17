using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using RabbitMQ.Client;
using System.Text;

namespace SeleniumScrapper
{
    public class Sender
    {
      
        public Sender(List<string> messages)
        {

       


        }
        public static void Send(string queue,string data)
        {
     
            
                    var factory = new ConnectionFactory() { HostName = "localhost" };
                    using (var connection = factory.CreateConnection())
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: queue,
                                             durable: false,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);

                        //string message = "Hello World!";
                        var body = Encoding.UTF8.GetBytes(data);

                        channel.BasicPublish(exchange: "",
                                             routingKey: queue,
                                             basicProperties: null,
                                             body: body);
                        Console.WriteLine(" [x] Sent {0}", data);
                    }
                }
            }
        
}
