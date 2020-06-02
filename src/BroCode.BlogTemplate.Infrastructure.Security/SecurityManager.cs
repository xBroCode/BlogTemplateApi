using System.Security.Cryptography;
using System.Text;

namespace BroCode.BlogTemplate.Infrastructure.Security
{
    public static class SecurityManager
    {
        public static string GenerateMD5Hash(string value)
        {
            var md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString();
        }
    }
}
