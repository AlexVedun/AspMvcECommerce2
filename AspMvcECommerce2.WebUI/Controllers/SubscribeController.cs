using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspMvcECommerce2.WebUI.Controllers
{
    public class SubscribeController : ApiController
    {
        private static ConcurrentBag<StreamWriter> mClients;

        static SubscribeController()
        {
            mClients = new ConcurrentBag<StreamWriter>();
        }

        //Действие добавления нового подписчика
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            HttpResponseMessage response = request.CreateResponse();
            response.Content = new PushStreamContent(
                (stream, content, contex) => OnStreamAvailable(stream, content, contex)
                , "text/event-stream"
            );
            return response;
        }

        [NonAction]
        public void OnStreamAvailable(Stream stream, HttpContent content, TransportContext context)
        {
            StreamWriter client = new StreamWriter(stream);
            mClients.Add(client);
        }

        public async static void SendMessage(string _name)
        {
            //Перебираем потоки вывода всех подписчиков
            foreach (var client in mClients)
            {
                try
                {
                    //!!! Специальное форматирование строки данных для ее передачи клиенту
                    //через WebSocket
                    var data = string.Format("data: {0}\n\n", JsonConvert.SerializeObject(_name));
                    await client.WriteAsync(data);
                    await client.FlushAsync();
                }
                catch (Exception)
                {
                    StreamWriter ignore;
                    mClients.TryTake(out ignore);
                }
            }
        }
    }
}
