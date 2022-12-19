using Newtonsoft.Json;
using PocAPI.WPF.Configuracoes;
using System.IO;

namespace PocAPI.WPF.Utils
{
    public static class JsonUtils
    {
        public static T RetornaObjeto<T>(string caminhoArquivo)
        {
            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return default(T);
            }
        }

        public static void SerializarClass<T>(T Dados, string caminhoArquivo)
        {
            if (!File.Exists(ConstantesWPF.CaminhoPastaConfiguracao))
            {
                Directory.CreateDirectory(ConstantesWPF.CaminhoPastaConfiguracao);
            }

            if (File.Exists(caminhoArquivo))
            {
                File.Delete(caminhoArquivo);
            }

            string json = JsonConvert.SerializeObject(Dados, Formatting.Indented);
            File.AppendAllText(caminhoArquivo, json);
        }
    }
}