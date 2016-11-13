using Core.Models;
using System.Collections.Generic;

namespace Synchronization.Models
{
    public class ImportDataModel<T>
        where T: BaseEntity
    {
        public List<T> Data { get; set; }
        public int Total { get; set; }
    }
}
