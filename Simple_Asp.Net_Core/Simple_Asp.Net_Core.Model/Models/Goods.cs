using System.ComponentModel.DataAnnotations;

namespace Simple_Asp.Net_Core.Models;

public class Goods : EntityBase
{
    /// <summary>
    /// 商品代码
    /// </summary>
    [MaxLength(250)]
    public string? Code { get; set; }

    /// <summary>
    /// 商品名称
    /// </summary>
    [Required]
    [MaxLength(250)]
    public string? Name { get; set; }

    /// <summary>
    /// 商品描述
    /// </summary>
    [Required]
    [MaxLength(500)]
    public string? Desc { get; set; }

    /// <summary>
    /// 商品类型
    /// </summary>
    [MaxLength(500)]
    public string? Type { get; set; }

    /// <summary>
    /// 主要图片Id
    /// </summary>
    [MaxLength(500)]
    public string? MainImageId { get; set; }

    /// <summary>
    /// 图片列表Ids
    /// </summary>
    [MaxLength(2000)]
    public string? DBImageIds { get; set; }
}