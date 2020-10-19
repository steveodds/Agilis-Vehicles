using System.IO;
using System.Linq;
using Npoi.Mapper;
using Npoi.Mapper.Attributes;
using NPOI.SS.UserModel;

class ExcelProcessor
{
    private string excelFile;
    public ExcelProcessor(string filepath)
    {
        excelFile = filepath;
    }

    private void GetExcelData()
    {
        IWorkbook workbook;
        using (FileStream file = new FileStream(excelFile, FileMode.Open, FileAccess.Read))
        {
            workbook = WorkbookFactory.Create(file);
        }

        // var importer = new Mapper(workbook);
        // var items = importer.Take<MurphyExcelFormat>(1);
        // foreach (var item in items)
        // {
        //     var row = item.Value;
        //     if (string.IsNullOrEmpty(row.EmailAddress))
        //         continue;

        //     UpdateUser(row);
        // }

    }
}