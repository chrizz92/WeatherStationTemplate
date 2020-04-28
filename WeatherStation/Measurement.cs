using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherStationNamespace
{
    public class Measurement
    {
        private double _temperature;
        private double _humidity;

        public Measurement(double temp, double hum)
        {
            _temperature = temp;
            _humidity = hum;
        }

        public double Temperature
        {
            set
            {
                _temperature = value;
            }
            get
            {
                return _temperature;
            }
        }

        public double Humidity
        {
            set
            {
                _humidity = value;
            }
            get
            {
                return _humidity;
            }
        }

        public bool IsComfortable
        {
            get
            {
                if (_temperature >= 21 && _temperature <= 24 && _humidity >= 40 && _humidity <= 60)
                {
                    return true;
                }
                return false;
            }
        }
    }
}