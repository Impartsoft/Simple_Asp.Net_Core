using Simple_Asp.Net_Core.Controllers;
using Simple_Asp.Net_Core.Models;
using System.Collections.Generic;

namespace Simple_Asp.Net_Core.Data
{
    public interface IGoodsRepo
    {
        bool SaveChanges();

        IEnumerable<Goods> GetAllGoods();
        Goods GetGoodsById(Guid id);
        void CreateGoods(Goods goods);
        void UpdateGoods(Goods goods);
        void DeleteGoods(Goods goods);
        Task<IEnumerable<Goods>> SearchForPage(GoodsSearchPageParams searchPageParams);
    }
}
