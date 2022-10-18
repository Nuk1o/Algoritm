using System.IO;
using System.Security.Cryptography;
public static class MV_pass_encryption //Шифрование пароля
{
    private const int KEYSIZE = 256;//Размер ключа
    public static byte[] Encrypt(byte[] data, string password, byte[] salt, byte[] iv)//Шифрование
    {
        using var rij = new RijndaelManaged()
        {
            KeySize = KEYSIZE,
            Mode = CipherMode.CBC,
            Padding = PaddingMode.PKCS7
        };

        using var rfc = new Rfc2898DeriveBytes(password,salt);
        rij.Key = rfc.GetBytes(KEYSIZE/8);
        rij.IV = iv;

        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms,rij.CreateEncryptor(),CryptoStreamMode.Write);

        using (var bw = new BinaryWriter(cs))
        {
            bw.Write(data);
        }

        return ms.ToArray();
    }

    public static byte[] Decrypt(byte[] data, string password, byte[] salt, byte[] iv)
    {
        using var rij = new RijndaelManaged()
        {
            KeySize = KEYSIZE,
            Mode = CipherMode.CBC,
            Padding = PaddingMode.PKCS7
        };

        using var rfc = new Rfc2898DeriveBytes(password, salt);
        rij.Key = rfc.GetBytes(KEYSIZE / 8);
        rij.IV = iv;

        using var ms = new MemoryStream(data);
        using var cs = new CryptoStream(ms,rij.CreateDecryptor(),CryptoStreamMode.Read);

        using var br = new BinaryReader(cs);

        return br.ReadBytes(data.Length);
    }
}
