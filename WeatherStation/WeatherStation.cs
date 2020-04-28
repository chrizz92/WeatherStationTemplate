using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherStationNamespace
{
    public class WeatherStation
    {
        private Measurement[] _measures;

        public WeatherStation()
        {
            _measures = new Measurement[96];
        }

        public int Count
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < _measures.Length; i++)
                {
                    if (_measures[i] != null)
                    {
                        sum++;
                    }
                }
                return sum;
            }
        }

        public static int ParseTimeString(string timeString)
        {
            int returnValue = -1;
            timeString = timeString.Trim();

            if (timeString.Length == 5 && timeString[2] == ':' && (timeString[0] >= '0' && timeString[0] <= '9') && (timeString[1] >= '0' && timeString[1] <= '9') && (timeString[3] >= '0' && timeString[3] <= '9') && (timeString[4] >= '0' && timeString[4] <= '9'))
            {
                int hours = Convert.ToInt32(timeString.Substring(0, 2));
                int minutes = Convert.ToInt32(timeString.Substring(3, 2));
                if (hours <= 23 && minutes < 60 && minutes % 15 == 0)
                {
                    returnValue = (hours * 4) + (minutes / 15);
                }
            }

            return returnValue;
        }

        public bool SetMeasurementAtPeriod(int period, double temp, double hum)
        {
            bool returnValue = false;

            if (period >= 0 && period < _measures.Length)
            {
                _measures[period] = new Measurement(temp, hum);
                returnValue = true;
            }

            return returnValue;
        }

        public bool SetMeasurementAtTime(string time, double temp, double hum)
        {
            bool success = SetMeasurementAtPeriod(ParseTimeString(time), temp, hum);
            return success;
        }

        public int CountInInterval(string startTime, string endTime)
        {
            int startingTime = ParseTimeString(startTime);
            int endingTime = ParseTimeString(endTime);
            int returnValue = -1;

            if (startingTime >= 0 && startingTime < _measures.Length && endingTime >= 0 && endingTime < _measures.Length && startingTime < endingTime)
            {
                returnValue = 0;
                for (int i = startingTime; i <= endingTime; i++)
                {
                    if (_measures[i] != null)
                    {
                        returnValue++;
                    }
                }
            }
            return returnValue;
        }

        public void GetAverageAllDay(out double temp, out double hum)
        {
            hum = 0.0;
            temp = 0.0;

            if (Count > 0)
            {
                for (int i = 0; i < _measures.Length; i++)
                {
                    if (_measures[i] != null)
                    {
                        temp += _measures[i].Temperature;
                        hum += _measures[i].Humidity;
                    }
                }
                temp = temp / Count;
                hum = hum / Count;
            }
        }
    }
}