﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IWarehouseUtilization<CLASS, ID>
    {
        List<CLASS> GetUtilizationReport();
        CLASS GetWarehouseUtilization(ID warehouseId);
    }
}
