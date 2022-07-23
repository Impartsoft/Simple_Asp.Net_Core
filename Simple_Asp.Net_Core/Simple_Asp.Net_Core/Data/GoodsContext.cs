﻿using Microsoft.EntityFrameworkCore;
using Simple_Asp.Net_Core.Models;

namespace Simple_Asp.Net_Core.Data;

public class GoodsContext : DbContext
{
    public GoodsContext(DbContextOptions<GoodsContext> opt) : base(opt)
    {
    }

    public DbSet<Goods> Goods { get; set; }
}