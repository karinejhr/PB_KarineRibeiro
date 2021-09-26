using System.IO;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IChefBlobService
    {
        Task<string> UploadAsync(Stream stream);

        Task DeleteAsync(string BlobName);
    }
}
