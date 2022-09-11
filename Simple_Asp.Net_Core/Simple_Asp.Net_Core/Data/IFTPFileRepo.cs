using Simple_Asp.Net_Core.Models;
using System.Collections.Generic;

namespace Simple_Asp.Net_Core.Data
{
    public interface IFTPFileRepo
    {
        bool SaveChanges();

        IEnumerable<FTPFile> GetAllFTPFiles();
        FTPFile GetFTPFileById(Guid id);
        void CreateFTPFile(FTPFile file);
        void DeleteFTPFile(FTPFile file);
    }
}
