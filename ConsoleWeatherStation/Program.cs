using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WeatherStationNamespace;

namespace ConsoleWeatherStation
{
    internal class Program
    {
        /// <summary>
        /// Die Wetterdaten werden aus der Datei Messwerte.csv eingelesen
        /// und ausgewertet
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            string[] measures = File.ReadAllLines("./Messwerte.csv");
            string[] dataLine;
            WeatherStation weatherStation = new WeatherStation();

            for (int i = 1; i < measures.Length; i++)
            {
                dataLine = measures[i].Split(';');
                weatherStation.SetMeasurementAtPeriod(Convert.ToInt32(dataLine[0]), Convert.ToDouble(dataLine[1]), Convert.ToDouble(dataLine[2]));
            }

            Console.WriteLine("Auswertung der Wetterstationsdaten\n");
            Console.Write("Anzahl gültiger Viertelstundenwerte: ");
            Console.WriteLine(weatherStation.Count);
            weatherStation.GetAverageAllDay(out double temperature, out double humidity);
            Console.WriteLine($"Durchschnittstemperatur: {temperature:f2} und Durchschnittsfeuchte: {humidity:f2}");
            Console.Write("Zum Beenden Eingabetaste ...");
            Console.ReadLine();
        }
    }
}