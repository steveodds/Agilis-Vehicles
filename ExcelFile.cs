using System;
using System.Collections.Generic;

class ExcelFile
{
    public string ExcelFilePath {get; set;}
    public List<string> Makes;
    public ExcelFile(string path)
    {
        ExcelFilePath = path;
        Makes = new List<string>();
    }

    private List<string> GetMakesFromDoc()
    {
        throw new NotImplementedException();
    }
}