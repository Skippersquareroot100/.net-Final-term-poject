using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class FileUploadRepo : Repo, IRepo<FileUpload, int, FileUpload>, IFileUploadService<FileUpload, int, bool>
    {
        public FileUpload Add(FileUpload obj)
        {
            db.FileUploads.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.FileUploads.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<FileUpload> Get()
        {
            return db.FileUploads.ToList();
        }

        public FileUpload Get(int id)
        {
            return db.FileUploads.Find(id);
        }

        public FileUpload Update(FileUpload obj)
        {
            var dbobj = Get(obj.FileId);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Upload(FileUpload file)
        {
            db.FileUploads.Add(file);
            return db.SaveChanges() > 0;
        }

        public List<FileUpload> GetUploads()
        {
            return db.FileUploads.ToList();
        }

        public FileUpload GetUpload(int id)
        {
            return db.FileUploads.Find(id);
        }
    }
}