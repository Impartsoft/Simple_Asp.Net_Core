using Simple_Asp.Net_Core.Model.DBContext;
using Simple_Asp.Net_Core.Models;
using Simple_Asp.Net_Core.ServiceProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Asp.Net_Core.Data;

public class FTPFileRepo : IFTPFileRepo
{
    private readonly FTPFileContext _context;

    public FTPFileRepo(FTPFileContext context)
    {
        _context = context;
    }

    public void CreateFTPFile(FTPFile ftpFile)
    {
        if (ftpFile == null)
        {
            throw new ArgumentNullException(nameof(ftpFile));
        }

        _context.FTPFiles.Add(ftpFile);
    }

    public void DeleteFTPFile(FTPFile ftpFile)
    {
        if (ftpFile == null)
        {
            throw new ArgumentNullException(nameof(ftpFile));
        }
        _context.FTPFiles.Remove(ftpFile);
    }

    public IEnumerable<FTPFile> GetAllFTPFiles()
    {
        return _context.FTPFiles.ToList();
    }

    public FTPFile GetFTPFileById(int id)
    {
        if (id == 0)
            throw new UserFriendlyException("id不能为0！");

        return _context.FTPFiles.First(p => p.Id == id);
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

}
