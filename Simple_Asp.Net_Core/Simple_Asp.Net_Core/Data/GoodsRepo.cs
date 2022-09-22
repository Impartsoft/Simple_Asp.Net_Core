using Microsoft.EntityFrameworkCore;
using Simple_Asp.Net_Core.Model.DBContext;
using Simple_Asp.Net_Core.Models;
using Simple_Asp.Net_Core.ServiceProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Asp.Net_Core.Data;

public class GoodsRepo : IGoodsRepo
{
    private readonly CommanderContext _context;

    public GoodsRepo(CommanderContext context)
    {
        _context = context;
    }

    public void CreateGoods(Goods user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        _context.Goods.Add(user);
    }

    public void DeleteGoods(Goods user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        _context.Goods.Remove(user);
    }

    public IEnumerable<Goods> GetAllGoods()
    {
        return _context.Goods.ToList();
    }

    public async Task<IEnumerable<Goods>> SearchForPage(GoodsSearchPageParams searchPageParams)
    {
        if (!string.IsNullOrWhiteSpace(searchPageParams.Query))
            return await _context.Goods.Where(v => !string.IsNullOrWhiteSpace(v.Name) && v.Name.StartsWith(searchPageParams.Query)).Skip(searchPageParams.PageSkip).Take(searchPageParams.PageSize).ToListAsync();
        else if (!string.IsNullOrWhiteSpace(searchPageParams.Type))
            return await _context.Goods.Where(v => !string.IsNullOrWhiteSpace(v.Type) && v.Type.StartsWith(searchPageParams.Type)).Skip(searchPageParams.PageSkip).Take(searchPageParams.PageSize).ToListAsync();
        else
            return await _context.Goods.Skip(searchPageParams.PageSkip).Take(searchPageParams.PageSize).ToListAsync();
    }

    public Goods GetGoodsById(Guid id)
    {
        return _context.Goods.FirstOrDefault(p => p.Id == id);
    }

    public void UpdateGoods(Goods goods)
    {
        //Nothing
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

}
