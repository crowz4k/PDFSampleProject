using System.Threading.Tasks;

namespace PDFSampleProject.API.Abstraction
{
    public interface IPDFService
    {
        Task<byte[]> Create();
    }
}
