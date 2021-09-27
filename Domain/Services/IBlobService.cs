using System.IO;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IBlobService
    {
        Task<string> UploadAsync(Stream stream);

        Task DeleteAsync(string blobName);

    }
}
