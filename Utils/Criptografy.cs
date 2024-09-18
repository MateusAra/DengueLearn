using System.Security.Cryptography;
using System.Text;

namespace DengueLearn.Utils
{
    public static class Criptografy
    {
        public static string GenerateHash(this string senha)
        {
            var hash = SHA1.Create();
            var encode = new ASCIIEncoding();
            var array = encode.GetBytes(senha);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}
