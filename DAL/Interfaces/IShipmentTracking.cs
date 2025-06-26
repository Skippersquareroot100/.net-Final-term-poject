using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IShipmentTracking<CLASS, ID>
    {
        List<CLASS> GetByStatus(string status);
        List<CLASS> GetByWarehouse(ID warehouseId);
    }
}
