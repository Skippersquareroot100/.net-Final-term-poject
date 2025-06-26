using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISearchInventory<CLASS, RET, ID>
    {
        List<CLASS> SearchByProductNameOrSKU(string query);
        RET UpdateInventoryLocation(ID inventoryId, ID locationId);
    }
}
