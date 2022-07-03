using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Simple_Asp.Net_Core.Ftp;

namespace Simple_Asp.Net_Core.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class FTPController : ControllerBase
{
    [HttpGet]
    public IActionResult FtpUploadTest()
    {
        UploadFileExample.UploadFile();
        return Ok("文件上传成功！");
    }

    [HttpGet]
    public IActionResult FtpDownLoadTest()
    {
        DownloadFileExample.DownloadFile();
        return Ok("文件上传成功！");
    }
}

