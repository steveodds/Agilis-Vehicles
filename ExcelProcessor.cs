using System.Collections.Generic;
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

    public List<MakeModel> GetRefData()
    {
        //var refFile = $@"{Directory.GetCurrentDirectory()}\Agilis LIVE Make & Models.xlsx";
        var refFile = @"C:\Users\user\Documents\sample\Agilis LIVE Make & Models.xlsx";
        var vehicles = new List<MakeModel>();
        IWorkbook workbook;
        using (FileStream file = new FileStream(refFile, FileMode.Open, FileAccess.Read))
        {
            workbook = WorkbookFactory.Create(file);
        }

        var importer = new Mapper(workbook);
        var items = importer.Take<MakeModel>(0);
        foreach (var item in items)
        {
            var row = item.Value;
            if (string.IsNullOrEmpty(row.Make))
                continue;

            vehicles.Add(row);
        }
        return vehicles;
    }

    public List<MotorModel> GetGenesysData()
    {
        IWorkbook workbook;
        var names = new List<MotorModel>();
        
        return names;
    }

}