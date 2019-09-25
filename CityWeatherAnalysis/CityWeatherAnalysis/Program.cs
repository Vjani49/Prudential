using System;
using System.IO;
using System.Net;

namespace CityWeatherAnalysis
{
    class Program
    {
        static private string cityNamesData = @"E:\Prudential\InputFolder\City\Data.txt";
        private static readonly string URL = "http://api.openweathermap.org/data/2.5/group";
        private static readonly string appID = "aa69195559bd4f88d79f9aadeb77a8f6";
        private static readonly string queryParameterID = "?id=";
        private static readonly string queryParameterAppID = "&units=metric&appid=";
        static private string outputFilePath = @"E:\Prudential\OutputFolder\";
        static private string currentDate;

        static void Main(string[] args)
        {
            try
            {
                // Read a text file line by line.
                string[] cityLineItem = File.ReadAllLines(cityNamesData);
                currentDate = DateTime.Now.ToString("M/d/yyyy");
                currentDate = currentDate.Replace('/', '-');

                // Get Count of Cities
                int cityCount = cityLineItem.Length;

                // Create an array to store city details
                string[] cityDetails = new string[2];

                // Iterate for each city line item from file
                foreach (string city in cityLineItem)
                {
                    cityDetails = city.Split('=');

                    // Make HTTP request
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + queryParameterID + cityDetails[0] + queryParameterAppID + appID);
                    try
                    {
                        WebResponse response = request.GetResponse();
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);

                            // Create directory if it does not exist
                            if (!Directory.Exists(outputFilePath + @"\" + cityDetails[1]))
                            {
                                Directory.CreateDirectory(outputFilePath + @"\" + cityDetails[1]);
                            }

                            // Write the ouput in json file
                            File.WriteAllText(outputFilePath + @"\" + cityDetails[1] + @"\" + cityDetails[1] + "_" + currentDate + ".json", reader.ReadToEnd());

                        }
                    }
                    catch (WebException ex)
                    {
                        WebResponse errorResponse = ex.Response;
                        using (Stream responseStream = errorResponse.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                            String errorText = reader.ReadToEnd();
                            // log errorText
                            Console.WriteLine(errorText);
                        }
                        throw;
                    }

                }
                Console.WriteLine("Execution completed successfully. Press any key to continue.");
                char c = Console.ReadKey().KeyChar;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                char c = Console.ReadKey().KeyChar;
            }
        }
    }
}
