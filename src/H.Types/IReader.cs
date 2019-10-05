using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H.Types
{
    public interface IReader
    {
        Task<IDictionary<Guid, IEnumerable<Point>>> ReadData(IEnumerable<Guid> tags, long startInclusive, long endExclusive);
    }
}
