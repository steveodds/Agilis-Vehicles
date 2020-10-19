using System;

namespace Agilis_Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var numberOfFiles = args.Length;
                if (numberOfFiles < 1)
                    throw new ArgumentNullException();
            }
            catch (System.ArgumentNullException)
            {
                Console.WriteLine("No file was given.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an error with the provided argument");
                Console.WriteLine(ex.GetBaseException());
            }
            finally
            {
                Console.WriteLine("Boo");
            }
        }
    }
}
