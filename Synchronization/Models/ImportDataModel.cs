using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronization.Models
{
    public class ImportDataModel<T>
        where T: BaseEntity
    {
        public List<T> Data { get; set; }
        public int Total { get; set; }
    }
}
