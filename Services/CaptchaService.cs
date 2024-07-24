using System.Text;

namespace ScorerApp;

public class CaptchaService
{
    const string chars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
    const string chars2 = "0123456789";

    public string GenerateCodeAsync(int length = 6)
    {
        StringBuilder captchaBuilder = new StringBuilder();
        Random random = new Random();

        // Append a letter
        int index = random.Next(chars.Length);
        captchaBuilder.Append(chars[index]);

        // Append numbers length - 1
        for (int i = 0; i < length - 1; i++)
        {
            int index2 = random.Next(chars2.Length);
            captchaBuilder.Append(chars2[index2]);
        }

        return captchaBuilder.ToString();
    }

    public string GenerateNuberCodeAsync(int length = 8)
    {
        StringBuilder captchaBuilder = new StringBuilder();
        Random random = new Random();
        for (int i = 0; i < length; i++)
        {
            int index = random.Next(chars2.Length);
            captchaBuilder.Append(chars2[index]);
        }

        return captchaBuilder.ToString();
    }

}
