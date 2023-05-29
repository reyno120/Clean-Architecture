namespace Presentation.Helpers
{
    public static class FormFileExtension
    {
        public static byte[] GetByteArray(this IFormFile formFile)
        {
            var memoryStream = new MemoryStream();
            formFile.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
