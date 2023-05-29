using Application.Common;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;
using Newtonsoft.Json.Linq;

namespace Infrastructure
{
    public class CloudinaryHelper : ICloudinaryHelper
    {
        public JToken UploadImage(string fileName, string folderName, byte[] fileBytes)
        {
            DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
            var test = Environment.GetEnvironmentVariable("CLOUDINARY_URL");
            Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
            cloudinary.Api.Secure = true;

            MemoryStream stream = new MemoryStream(fileBytes);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, stream),
                UseFilename = true,
                UniqueFilename = false,
                Overwrite = true,
                Folder = folderName
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            return uploadResult.JsonObj;
        }
    }
}