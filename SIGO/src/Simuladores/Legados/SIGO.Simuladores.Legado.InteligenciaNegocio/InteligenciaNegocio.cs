using SIGO.Bus.EventBus.Events.SIGO;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SIGO.Simuladores.Legado.InteligenciaNegocio
{
    public class InteligenciaNegocio
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

                    DateTime dataInicio = DateTime.Now;
                    dataInicio.AddDays(random.Next(1, 15));
                    var indicativoInteligenciaNegocioIntegrationEvent = new IndicativoInteligenciaNegocioIntegrationEvent()
                    {
                        PrevisaoVendas = random.Next(1000000, int.MaxValue),
                        DataInicio = dataInicio,
                        DataFim = dataInicio.AddDays(15)
                    };

                    var jsonString = JsonSerializer.Serialize(indicativoInteligenciaNegocioIntegrationEvent);

                    var data = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    await client.PostAsync("/api/Mule/PublicarEvento/InteligenciaNegocio", data);
                }

                Thread.Sleep(TimeSpan.FromHours(1));
            }
        }
    }
}
