﻿using Microsoft.EntityFrameworkCore;
using Simple_Asp.Net_Core.Models;

namespace Simple_Asp.Net_Core.Data;

public class FTPFileContext : DbContext
{
    public FTPFileContext(DbContextOptions<FTPFileContext> opt) : base(opt)
    {
    }

    public DbSet<FTPFile> FTPFiles { get; set; }
}
