namespace ScorerApp
{
    public class HeadImgFileNames
    {

        public static List<string> GetImgFileNames()
        {
            List<string> result = new List<string>();

            // 获取wwwroot/img目录的绝对路径
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Img");

            // 检查目录是否存在
            if (Directory.Exists(imagePath))
            {
                // 获取目录下所有文件的文件名并存储
                var files = Directory.GetFiles(imagePath);

                foreach (var item in files)
                {
                    string fileName = Path.GetFileName(item);
                    result.Add(fileName);
                }
            }
            return result;

        }
    }
}
