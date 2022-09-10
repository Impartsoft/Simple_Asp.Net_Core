using System.ComponentModel.DataAnnotations;

namespace Simple_Asp.Net_Core.Models;

public class Goods : EntityBase
{
    /// <summary>
    /// 商品代码
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// 商品名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 商品描述
    /// </summary>
    public string? Desc { get; set; }

    /// <summary>
    /// 商品类型
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// 主要图片Id
    /// </summary>
    public string? MainImageId { get; set; }

    /// <summary>
    /// 图片列表Ids
    /// </summary>
    public string? DBImageIds { get; set; }
}