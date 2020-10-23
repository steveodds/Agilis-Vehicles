using System;
using System.Collections.Generic;
using Fastenshtein;

class NearestCorrectSpelling
{
    private string _excelFile;
    private List<MotorModel> _misspeltModels;
    private List<MotorModel> _filteredModels;
    public NearestCorrectSpelling(List<MotorModel> misspeltModels, string excelFile)
    {
        _misspeltModels = misspeltModels;
        _excelFile = excelFile;
    }

    private string ProcessRawModels(string model)
    {
        if(model.Contains(@"/"))
            model = model.Substring(model.IndexOf(@"/") + 1);

        //TODO Add more constraints
        
        return model;
    }

    private string GetClosestWord(string original, out bool exactmatch)
    {
        if(original is null)
            throw new ArgumentNullException("Cannot compare null values");
        string word = String.Empty;
        var models = GetList();
        var levenshtein = new Levenshtein(original);
        var levDistance = 1000;
        exactmatch = false;
        foreach (var model in models)
        {
            int distanceTemp = levenshtein.DistanceFrom(model.Model);
            if(distanceTemp < levDistance)
            {
                levDistance = distanceTemp;
                word = model.Model;
            }
            if(levDistance == 0)
            {
                exactmatch = true;
                break;
            }
        }
        return word;
    }


    private List<MakeModel> GetList()
    {
        var processor = new ExcelProcessor(_excelFile);
        var models = processor.GetRefData();
        return models;
    }

    public List<MotorModel> ProcessModels()
    {
        foreach (var model in _misspeltModels)
        {
            // bool exactmatch = false;
            var fixedModel = ProcessRawModels(model.Make);
            var modelMatch = GetClosestWord(fixedModel, out bool exactmatch);
            if (exactmatch is false || !String.IsNullOrEmpty(modelMatch))
            {
                _filteredModels.Add(new MotorModel{
                    Make = modelMatch,
                    ExcelLocation = model.ExcelLocation
                });
            }
        }

        return _filteredModels;
    }
}