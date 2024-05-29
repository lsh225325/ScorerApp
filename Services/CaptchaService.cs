using System.Text;

namespace ScorerApp;

public class CaptchaService
{
    const string chars = "abcdefghijkmnpqrstuvwxyz";
    const string chars2 = "0123456789";

    public string GenerateCodeAsync(int length = 5)
    {
        StringBuilder captchaBuilder = new StringBuilder();
        Random random = new Random();
        for (int i = 0; i < 2; i++)
        {
            int index = random.Next(chars.Length);
            captchaBuilder.Append(chars[index]);
        }
        
        for (int i = 0; i < length; i++)
        {
            int index = random.Next(chars2.Length);
            captchaBuilder.Append(chars2[index]);
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
