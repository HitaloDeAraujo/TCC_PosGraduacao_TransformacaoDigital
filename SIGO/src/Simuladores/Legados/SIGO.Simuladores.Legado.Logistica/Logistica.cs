using SIGO.Bus.EventBus.Events.SIGO;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SIGO.Simuladores.Legado.Logistica
{
    public class Logistica
    {
        private static string URL = "https://localhost:5009";

        public static async Task Simular()
        {
            Random random = new Random();
            while (true)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(URL);

                    int quantidade = random.Next(1, 200 - 1);
                    var estoqueMinimoIntegrationEvent = new EstoqueMinimoIntegrationEvent()
                    {
                        ProdutoID = random.Next(0, 200),
                        Quantidade = quantidade,
                        EstoqueMinimo = quantidade + 1
                    };

                    var jsonString = JsonSerializer.Serialize(estoqueMinimoIntegrationEvent);

                    var data = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    await client.PostAsync("/api/Mule/EstoqueMinimo/PublicarEvento", data);
                }

                Thread.Sleep(TimeSpan.FromMinutes(2));
            }
        }
    }
}