using Farabeh.MyBuilding.Api.Framework.Configurations;
using Microsoft.AspNetCore.Http;

namespace Farabeh.MyBuilding.Api.Framework.ManageFiles
{
    public class ManageImage
    {
        public async Task<string> Upload(IFormFile image, string path)
        {
            var fileNameWithoutExtention = Path.GetFileNameWithoutExtension(image.FileName);
            var fileExtention = Path.GetFileName(image.FileName).Replace(fileNameWithoutExtention, "");
            var fileName = Guid.NewGuid().ToString();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{path}", fileName + fileExtention);

            using (var fileSrteam = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileSrteam);
            }

            return $"{new AppSettings().BaseDomainName}/{path}/{fileName}{fileExtention}";
        }

        public string UploadPath(string path)
        {
            var fileExtention = ".test";
            var fileName = "file";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{path}", fileName + fileExtention);

            return filePath + "<br/><br/>" + $"{new AppSettings().BaseDomainName}/{path}/{fileName}{fileExtention}";
        }
    }
}
