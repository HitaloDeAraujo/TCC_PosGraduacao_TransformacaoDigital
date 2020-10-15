using SIGO.Bus.EventBus.Events.SIGO;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SIGO.Simuladores.Legado.MonitoramentoVendas
{
    public class MonitoramentoVendas
    {
        public static async Task Simular(string URL)
        {
            Random random = new Random();
            while (true)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(URL);

                    int orcamentos = random.Next(3000, 5000);
                    var relacaoOrcamentoVendasIntegrationEvent = new RelacaoOrcamentoVendasIntegrationEvent()
                    {
                        Orcamentos = orcamentos,
                        Vendas = random.Next(1, orcamentos)
                    };

                    var jsonString = JsonSerializer.Serialize(relacaoOrcamentoVendasIntegrationEvent);

                    var data = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    await client.PostAsync("/api/Mule/PublicarEvento/RelacaoOrcamentoVendas", data);
                }

                Thread.Sleep(TimeSpan.FromMinutes(2));
            }
        }
    }
}
