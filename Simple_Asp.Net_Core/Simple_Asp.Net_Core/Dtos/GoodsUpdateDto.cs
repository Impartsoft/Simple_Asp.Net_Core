using System.ComponentModel.DataAnnotations;

namespace Simple_Asp.Net_Core.Dtos
{
    public class GoodsUpdateDto
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// 商品代码
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string? Code { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string? Name { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
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
        /// 保存图片列表
        /// </summary>
        public string? DBImageIds { get { return string.Join(',', Images); } }

        /// <summary>
        /// 图片列表
        /// </summary>
        public List<string> Images { get; set; } = new List<string>();
    }
}
