using System.Security.Cryptography;
using System.Text;

namespace PocApi.Utils.Utils
{
    public static class SenhaHashUtil
    {
        public static void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {
            using (var hmacsha = new HMACSHA512())
            {
                senhaSalt = hmacsha.Key;
                senhaHash = hmacsha.ComputeHash(Encoding.UTF8.GetBytes(senha));
            }
        }

        public static bool VerificarSenhaHash(string senha, byte[] senhaHash, byte[] senhaSalt)
        {
            using (var hmacsha = new HMACSHA512(senhaSalt))
            {
                var hashCalculado = hmacsha.ComputeHash(Encoding.UTF8.GetBytes(senha));
                for (int i = 0; i < hashCalculado.Length; i++)
                {
                    if (hashCalculado[i] != senhaHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
