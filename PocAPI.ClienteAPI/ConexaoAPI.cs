using Newtonsoft.Json;
using PocApi.Compartilhado.DTOs;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PocAPI.ClienteAPI
{
    public class ConexaoAPI
    {
        private HttpClient _httpClient;
        private string _token;
        private string _enconding = "application/json";

        public ConexaoAPI(string token)
        {
            _token = token;
            _httpClient = new HttpClient();
        }

        public async Task<RespostaServicoDTO<T>> GetAsync<T>(string url)
        {
            RespostaServicoDTO<T> respostaServicoDTO = new RespostaServicoDTO<T>();
            try
            {
                HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(url);
                using (HttpContent httpContentRequest = httpResponseMessage.Content)
                {
                    respostaServicoDTO = await TratarRetorno<T>(httpResponseMessage);
                }
            }
            catch (Exception ex)
            {
                respostaServicoDTO.Sucesso = false;
                respostaServicoDTO.Mensagem = ex.Message;
            }
            return respostaServicoDTO;
        }

        private async Task<RespostaServicoDTO<T>> TratarRetorno<T>(HttpResponseMessage httpResponseMessage)
        {
            RespostaServicoDTO<T> respostaServicoDTO = new RespostaServicoDTO<T>();

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using (HttpContent httpContentRetorno = httpResponseMessage.Content)
                {
                    string retorno = await httpContentRetorno.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(retorno))
                    {
                        respostaServicoDTO = JsonConvert.DeserializeObject<RespostaServicoDTO<T>>(retorno);
                    }
                }
            }
            else
            {
                respostaServicoDTO.Sucesso = false;
                respostaServicoDTO.Mensagem = httpResponseMessage.ReasonPhrase;
            }

            return respostaServicoDTO;
        }
    }
}