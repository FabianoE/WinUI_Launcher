using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WinUI_Launcher.Classes;

public class Utils
{
    public static string HexToString(string hex)
    {
        var result = new StringBuilder();

        for (var i = 0; i < hex.Length; i += 2)
        {
            var hexPair = hex.Substring(i, 2);
            var byteValue = Convert.ToByte(hexPair, 16);
            result.Append((char)byteValue);
        }

        return result.ToString();
    }
    public static async Task<bool> VerifyFileHash(string filePath, string hash)
    {
        using (var md5 = MD5.Create())
        {
            var fileBytes = await File.ReadAllBytesAsync("." + filePath);
            var hashBytes = md5.ComputeHash(fileBytes);
            var hashString = BitConverter.ToString(hashBytes).Replace("-", "");

            return hashString == hash;
        }
    }
}