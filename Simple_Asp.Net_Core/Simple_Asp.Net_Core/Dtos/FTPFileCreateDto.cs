using System.ComponentModel.DataAnnotations;

namespace Simple_Asp.Net_Core.Dtos
{
    public class FTPFileCreateDto
    {
        public FTPFileCreateDto(string fileName, string fileContentType, string ftpFileName, string ftpPath)
        {
            FileName = fileName;
            FileContentType = fileContentType;
            FTPFileName = ftpFileName;
            FTPPath = ftpPath;
        }

        [Required]
        [MaxLength(250)]
        public string FileName { get; set; }

        [Required]
        [MaxLength(250)]
        public string FileContentType { get; set; }

        [Required]
        [MaxLength(250)]
        public string FTPFileName { get; set; }

        [Required]
        [MaxLength(250)]
        public string FTPPath { get; set; }
    }
}
