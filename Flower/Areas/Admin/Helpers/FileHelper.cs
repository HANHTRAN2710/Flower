namespace Flower.Areas.Admin.Helpers
{
    public class FileHelper
    {
        public static string generateFileName(string fileName)
        {
            var lastIndex = fileName.LastIndexOf('.');
            var ext = fileName.Substring(lastIndex);
            var name = Guid.NewGuid().ToString().Replace("-", "");
            return name + ext;

        }
    }
}
