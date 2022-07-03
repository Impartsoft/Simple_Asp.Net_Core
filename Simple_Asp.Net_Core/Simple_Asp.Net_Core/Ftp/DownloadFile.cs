using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentFTP;

namespace Simple_Asp.Net_Core.Ftp
{

    public static class DownloadFileExample
    {

        public static void DownloadFile()
        {

            //using (var ftp = new FtpClient("39.98.125.164", 21, "root", "123456"))
            //{
            //	ftp.Connect();

            //	// upload a file to an existing FTP directory
            //	ftp.UploadFile(@"D:\README.md", "/root/README.md");

            //	//// upload a file and ensure the FTP directory is created on the server
            //	//ftp.UploadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, true);

            //	//// upload a file and ensure the FTP directory is created on the server, verify the file after upload
            //	//ftp.UploadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, true, FtpVerify.Retry);

            //}

            using (var ftp = new FtpClient("39.98.125.164", 21, "root", "123456"))
            {
                ftp.Connect();

                var localfile = AppDomain.CurrentDomain.BaseDirectory + "files/README111.md";

                // download a file and ensure the local directory is created
                ftp.DownloadFile(localfile, "/root/README.md");
            }
        }

        public static async Task DownloadFileAsync(string fileName, string ftpPath, string ftpName)
        {
            var token = new CancellationToken();
            using (var ftp = new FtpClient("39.98.125.164", 21, "root", "123456"))
            {
                await ftp.ConnectAsync(token);

                var localfile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "files", fileName);
                // download a file and ensure the local directory is created
                await ftp.DownloadFileAsync(localfile, Path.Combine(ftpPath, ftpName), token: token);

                // download a file and ensure the local directory is created, verify the file after download
                //await ftp.DownloadFileAsync(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpLocalExists.Overwrite, FtpVerify.Retry, token: token);
            }
        }

        public static byte[] DownloadFileAsync2(string ftpPath, string ftpName)
        {
            using (var ftp = new FtpClient("39.98.125.164", 21, "root", "123456"))
            {
                ftp.Connect();

                ftp.Download(out byte[] outBytes, Path.Combine(ftpPath, ftpName));

                return outBytes;
            }
        }



        //Download(out byte[] outBytes, string remotePath, long restartPosition = 0, Action<FtpProgress> progress = null)
    }
}