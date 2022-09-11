using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Simple_Asp.Net_Core.Data;
using Simple_Asp.Net_Core.Dtos;
using Simple_Asp.Net_Core.Ftp;
using Simple_Asp.Net_Core.Models;
using Simple_Asp.Net_Core.ServiceProviders;

namespace Simple_Asp.Net_Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFTPFileRepo _repository;
        private readonly IMapper _mapper;
        public FileController(IFTPFileRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> FtpUpload(List<IFormFile> files)
        {
            var ids = new List<Guid>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var ftpFileName = Path.GetRandomFileName();
                    await UploadFileExample.UploadFileAsync2(formFile.OpenReadStream(), ftpFileName, UploadFileExample.FTP_DEFAULT_PATH);

                    Guid id = SaveFileInfo(formFile.FileName, formFile.ContentType, ftpFileName, UploadFileExample.FTP_DEFAULT_PATH);
                    ids.Add(id);
                }
            }

            return Ok(SysMsg.Success("图片上传成功！", ids));
        }
         
        [HttpGet]
        public IActionResult FtpDownLoad(Guid id)
        {
            var ftpFile = _repository.GetFTPFileById(id);
            if (ftpFile == null)
                throw new UserFriendlyException("无法获取该文件！");

            return File(DownloadFileExample.DownloadFileAsync2(ftpFile.FTPPath, ftpFile.FTPFileName), ftpFile.FileContentType);
        }

        private Guid SaveFileInfo(string fileName, string fileContentType, string ftpFileName, string ftpPath)
        {
            var fileCreateDto = new FTPFileCreateDto(fileName, fileContentType, ftpFileName, ftpPath);

            var file = _mapper.Map<FTPFile>(fileCreateDto);

            _repository.CreateFTPFile(file);
            _repository.SaveChanges();

            return file.Id;
        }

        /*

         通过保存方式完成文件上传
         // 保存临时文件
         var localFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "files", ftpFileName);
         using (var stream = System.IO.File.Create(localFilePath))
         {
             await formFile.CopyToAsync(stream);
         }
         // 上传至FTP
         await UploadFileExample.UploadFileAsync(ftpFileName, localFilePath, UploadFileExample.FTP_DEFAULT_PATH);
         // 将文件信息保存至数据库

         // 删除本地临时文件
         System.IO.File.Delete(localFilePath);


          下载文件
         await DownloadFileExample.DownloadFileAsync(ftpFile.FileName, ftpFile.FTPPath, ftpFile.FTPFileName);
          将文件信息保存至数据库
         var bytes = System.IO.File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "files", ftpFile.FileName));
          删除本地临时文件
         System.IO.File.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "files", ftpFile.FileName));
      */
    }
}
