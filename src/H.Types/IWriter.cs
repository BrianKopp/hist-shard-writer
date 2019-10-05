using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace H.Types
{
    public interface IWriter
    {
        Task WriteData(IDictionary<Guid, IEnumerable<Point>> dataToWrite);
    }
}
