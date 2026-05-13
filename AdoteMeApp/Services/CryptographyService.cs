using System.Security.Cryptography;
using System.Text;

namespace AdoteMeApp.Services;

public class CryptographyService
{
    public string GerarHash(
        string texto)
    {
        using SHA256 sha256 =
            SHA256.Create();

        byte[] bytes =
            sha256.ComputeHash(
                Encoding.UTF8.GetBytes(texto));

        StringBuilder builder =
            new();

        foreach (byte b in bytes)
        {
            builder.Append(
                b.ToString("x2"));
        }

        return builder.ToString();
    }
}