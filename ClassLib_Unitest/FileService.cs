namespace ClassLib_Unitest
{
    public class FileService
    {
        public async Task WriteToFileAsync(string fileName, string content)
        {
            await File.WriteAllTextAsync(fileName, content);
        }

        public async Task<string> ReadFromFileAsync(string fileName)
        {
            return await File.ReadAllTextAsync(fileName);
        }
    }
}
