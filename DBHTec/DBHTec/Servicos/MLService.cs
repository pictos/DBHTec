using DBHTec.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DBHTec.Servicos
{
    public class MLService
    {
        private static Lazy<MLService> LazyClient = new Lazy<MLService>(() => new MLService());
        public static MLService Current { get => LazyClient.Value; }
        private MLService()
        {
            Cliente = new HttpClient();

            Cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Const.apiKey);

            Cliente.BaseAddress = new Uri(Const.baseUrl);
        }
        private readonly HttpClient Cliente;

        public async Task<RespostaTest> AcessarML(Diabete diabete)
        {
            try
            {

                string json = JsonConvert.SerializeObject(diabete);

                using (var contentString = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    var resposta = await Cliente.PostAsync(string.Empty, contentString).ConfigureAwait(false);
                    var content = await resposta.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return JsonConvert.DeserializeObject<RespostaTest>(content);
                }
              
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}