using System.Collections.Generic;
using System.IO;
using System.Linq;
using Npoi.Mapper;
using Npoi.Mapper.Attributes;
using NPOI.SS.UserModel;

class ExcelProcessor
{
    private string _excelFile;
    public List<MotorModel> RawMotorData {get; set;}
    public ExcelProcessor(string filepath)
    {
        _excelFile = filepath;
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

    public void GetGenesysData()
    {
        IWorkbook workbook;
        var names = new List<MotorModel>();
        using (var file = new FileStream(_excelFile, FileMode.Open, FileAccess.Read))
        {
            workbook = WorkbookFactory.Create(file);
        }

        var sheet = workbook.GetSheetAt(0);
        var row = 1;
        while (sheet.GetRow(row) != null)
        {
            var makeCell = sheet.GetRow(row).GetCell(19);
            names.Add(new MotorModel{
                Make = makeCell.StringCellValue,
                ExcelLocation = makeCell.Address.ToString()
            });
            row++;
        }
        RawMotorData = names;
    }

    public void WriteFixedData(List<MotorModel> fixedModels)
    {
        //TODO
    }
}