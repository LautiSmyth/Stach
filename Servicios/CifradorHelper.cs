using System.IO;
using System.Security.Cryptography;

namespace Servicios
{
    public static class CifradorHelper
    {
        private static readonly byte[] Salt = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };

        public static void CifrarArchivo(string rutaOrigen, string rutaDestino, string password)
        {
            using (Aes aes = Aes.Create())
            {
                var derive = new Rfc2898DeriveBytes(password, Salt, 10000);
                aes.Key = derive.GetBytes(32);
                aes.IV = derive.GetBytes(16);

                using (FileStream fsOut = new FileStream(rutaDestino, FileMode.Create, FileAccess.Write))
                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                using (CryptoStream cs = new CryptoStream(fsOut, encryptor, CryptoStreamMode.Write))
                using (FileStream fsIn = new FileStream(rutaOrigen, FileMode.Open, FileAccess.Read))
                {
                    fsIn.CopyTo(cs);
                }
            }
        }

        public static void DescifrarArchivo(string rutaOrigen, string rutaDestino, string password)
        {
            using (Aes aes = Aes.Create())
            {
                var derive = new Rfc2898DeriveBytes(password, Salt, 10000);
                aes.Key = derive.GetBytes(32);
                aes.IV = derive.GetBytes(16);

                using (FileStream fsIn = new FileStream(rutaOrigen, FileMode.Open, FileAccess.Read))
                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                using (CryptoStream cs = new CryptoStream(fsIn, decryptor, CryptoStreamMode.Read))
                using (FileStream fsOut = new FileStream(rutaDestino, FileMode.Create, FileAccess.Write))
                {
                    cs.CopyTo(fsOut);
                }
            }
        }
    }
}
