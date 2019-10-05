using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using H.Types;

namespace HistShardWriter.Controllers
{
    [Route("[controller]")]
    public class FilesController : Controller
    {
        private readonly IFileEvaluator FileEvaluator;
        private readonly ILogger Logger;
        public FilesController(ILogger<FilesController> logger, IFileEvaluator evaluator)
        {
            FileEvaluator = evaluator;
            Logger = logger;
        }

        [HttpPost("evaluation")]
        public async Task<IActionResult> CreateEvaluation()
        {
            Logger.LogInformation("received request to initiate new file evaulation for delivery");
            await FileEvaluator.EvaluateFilesForDelivery();
            return Ok();
        }
    }
}
