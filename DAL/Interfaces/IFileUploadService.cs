using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFileUploadService<CLASS, ID, RET>
    {
        RET Upload(CLASS file);
        List<CLASS> GetUploads();
        CLASS GetUpload(ID id);
    }
}
