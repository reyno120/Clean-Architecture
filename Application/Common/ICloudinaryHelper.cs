
using Newtonsoft.Json.Linq;

namespace Application.Common
{
    public interface ICloudinaryHelper
    {
        public JToken UploadImage(string fileName, string folderName, byte[] filebytes);
    }
}
