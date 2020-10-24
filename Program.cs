using System;

namespace Agilis_Vehicles
{
    class Program
    {
        private static string _result;
        static void Main(string[] args)
        {
            try
            {
                var numberOfFiles = args.Length;
                if (numberOfFiles > 1)
                    throw new ArgumentException("Too many arguments.");
                if (numberOfFiles <= 0)
                    throw new ArgumentException("No argument or an invalid argument was given.");
                if (string.IsNullOrWhiteSpace(args[0]))
                    throw new ArgumentException("The argument was empty.");
                if (args[0].Length < 3)
                    throw new ArgumentException("No reliable matches can be made for arguments with less than 3 characters.");
                if (args[0].Contains("xlsx") || args[0].Contains("xls"))
                {
                    throw new NotImplementedException("This feature is currently disabled.");
                    // var excelProcessor = new ExcelProcessor(@"C:\Users\user\Documents\sample\Motor Data.xlsx");
                    // excelProcessor.GetGenesysData();
                    // var names = excelProcessor.RawMotorData;
                    // var levCompute = new NearestCorrectSpelling(names, "placeholder");
                    // var results = levCompute.ProcessModels();
                }
                else
                {
                    var original = args[0];
                    var check = new NearestCorrectSpelling(null, String.Empty);
                    var result = check.GetWord(original, out int lev);
                    if (lev == 1000 || lev < 0)
                        throw new Exception("No match was found.");
                    if (args[0].Length == 3 && lev > 1)
                        throw new Exception("No match was found.");
                    _result = result;
                }
            }
            catch (System.ArgumentNullException ex)
            {
                var message = "No file or argument was given: " + ex.Message;
            }
            catch (System.IO.IOException ex)
            {
                var message = "Cannot access file. Check if it's open in Excel: " + ex.Message;
            }
            catch (Exception ex)
            {
                var message = "There was an error with the provided argument: " + ex.Message;
            }
            //TODO: Log messages and implement a proper finally
            // finally
            // {
            //     Console.WriteLine("Boo");
            // }
        }
    }
}
