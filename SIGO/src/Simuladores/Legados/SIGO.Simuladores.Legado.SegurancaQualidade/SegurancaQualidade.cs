using SIGO.Bus.EventBus.Events.SIGO;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SIGO.Simuladores.Legado.SegurancaQualidade
{
    public class SegurancaQualidade
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
                    var materialInconsistenteIntegrationEvent = new MaterialInconsistenteIntegrationEvent()
                    {
                        MaterialID = random.Next(1, 500),
                        Descricao = "Material com elasticidade mais alta que o comum"
                    };

                    var jsonString = JsonSerializer.Serialize(materialInconsistenteIntegrationEvent);

                    var data = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    await client.PostAsync("/api/Mule/MaterialInconsistente/PublicarEvento", data);
                }

                Thread.Sleep(TimeSpan.FromMinutes(2));
            }
        }
    }
}
