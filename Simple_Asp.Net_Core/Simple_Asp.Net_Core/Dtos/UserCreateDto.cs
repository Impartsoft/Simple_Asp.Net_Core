namespace Simple_Asp.Net_Core.Dtos;

public class UserCreateDto
{
    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 展示名称
    /// </summary>
    public string NickName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// 电子邮箱
    /// </summary>
    public string Mail { get; set; }
}
