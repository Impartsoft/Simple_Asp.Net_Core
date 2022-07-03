using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentFTP;
using Simple_Asp.Net_Core.ServiceProvider;

namespace Simple_Asp.Net_Core.Ftp
{
    public static class UploadFileExample
    {
        public const string FTP_DEFAULT_PATH = "/root/";
        public static void UploadFile()
        {
            using (var ftp = new FtpClient("39.98.125.164", 21, "root", "123456"))
            {
                ftp.Connect();

                var localfile = AppDomain.CurrentDomain.BaseDirectory + "files/README.md";
                // upload a file to an existing FTP directory
                ftp.UploadFile(localfile, "/root/README2.md");

                //// upload a file and ensure the FTP directory is created on the server
                //ftp.UploadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, true);

                //// upload a file and ensure the FTP directory is created on the server, verify the file after upload
                //ftp.UploadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, true, FtpVerify.Retry);

            }
        }

        public static async Task UploadFileAsync(string tempFileName, string localTempFilePath, string remoteFilePath = FTP_DEFAULT_PATH)
        {
            //  Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "files", tempFileName);
            var token = new CancellationToken();
            using (var ftp = new FtpClient("39.98.125.164", 21, "root", "123456"))
            {
                await ftp.ConnectAsync(token);

                // upload a file to an existing FTP directory
                var ftpStatus = await ftp.UploadFileAsync(localTempFilePath, Path.Combine(remoteFilePath, tempFileName), token: token);

                if (ftpStatus != FtpStatus.Success)
                {
                    throw new UserFriendlyException($"文件上传失败{ftpStatus.ToString()}！");
                }

                // upload a file and ensure the FTP directory is created on the server
                //await ftp.UploadFileAsync(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, true, token: token);

                //// upload a file and ensure the FTP directory is created on the server, verify the file after upload
                //await ftp.UploadFileAsync(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, true, FtpVerify.Retry, token: token);

            }
        }

        public static async Task UploadFileAsync2(Stream fileStream, string tempFileName,  string remoteFilePath = FTP_DEFAULT_PATH)
        {
            var token = new CancellationToken();
            using (var ftp = new FtpClient("39.98.125.164", 21, "root", "123456"))
            {
                 ftp.Connect();

                // upload a file to an existing FTP directory
                 var ftpStatus = await ftp.UploadAsync(fileStream, Path.Combine(remoteFilePath, tempFileName), token: token);
                if (ftpStatus != FtpStatus.Success)
                {
                    throw new UserFriendlyException($"文件上传失败{ftpStatus.ToString()}！");
                }
            }
        }

    }
}