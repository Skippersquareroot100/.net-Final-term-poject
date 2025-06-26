using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ILowStockAlert<CLASS, ID, RET>
    {
        List<CLASS> CheckStockLevels(ID warehouseId, int threshold);
        RET GenerateNotification(ID warehouseId, string message);
    }
}
