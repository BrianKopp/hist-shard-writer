using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using H.Types;

namespace HistShardWriter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : Controller
    {
        private readonly ILogger Logger;
        private readonly IWriter Writer;
        private readonly IReader Reader;
        public DataController(ILogger<DataController> lgr, IWriter writer, IReader reader)
        {
            Logger = lgr;
            Writer = writer;
            Reader = reader;
        }
        [HttpPost]
        public async Task<IActionResult> PostData([FromBody] IDictionary<Guid, IEnumerable<Point>> data)
        {
            Logger.LogDebug($"posting data with {data.Keys.Count}");
            try
            {
                await Writer.WriteData(data);
                return Ok();
            }
            catch (Exception e)
            {
                Logger.LogError(e, "error writing data");
                throw e;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetData([FromQuery] IEnumerable<Guid> tags, long start, long end)
        {
            Logger.LogDebug($"getting data for {tags.Count()} tags between {start} and {end}");
            try
            {
                var data = await Reader.ReadData(tags, start, end);
                return Ok(data);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "error fetching data");
                throw ex;
            }
        }
    }
}
