using System.Threading.Tasks;

namespace H.Types
{
    public interface IFileEvaluator
    {
        Task<bool> EvaluateFilesForDelivery();
    }
}
