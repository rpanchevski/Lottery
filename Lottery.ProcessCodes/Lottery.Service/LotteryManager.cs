using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Lottery.Data;
using Lottery.Data.Model;
using OfficeOpenXml;

namespace Lottery.Service
{
    public class LotteryManager : ILotteryManager
    {
        private readonly IRepository<Code> _codeRepository;

        public LotteryManager(IRepository<Code> codeRepository)
        {
            _codeRepository = codeRepository;
        }

        public void ProcessCodes()
        {
            var folderName = @"CodeFiles\";
            var fullPath = $@"{Directory.GetCurrentDirectory()}\{folderName}";

            var directoryInfo = new DirectoryInfo(fullPath);
            var filesInfo = directoryInfo.GetFiles("*.xlsx");

            foreach (var fileInfo in filesInfo)
            {
                using (var package = new ExcelPackage(fileInfo))
                {
                    var worksheet = package.Workbook.Worksheets[1];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 1; row <= rowCount; row++)
                    {
                        var code = new Code
                        {
                            CodeValue = worksheet.Cells[row, 1].Value.ToString(),
                            IsWinning = bool.Parse(worksheet.Cells[row, 2].Value.ToString())
                        };

                        _codeRepository.Insert(code);
                    }
                }

                File.Delete(fileInfo.FullName);
            }
        }
    }
}
