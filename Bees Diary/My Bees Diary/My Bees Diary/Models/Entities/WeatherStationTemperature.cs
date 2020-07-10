using System;
using System.Collections.Generic;
using System.Text;

namespace My_Bees_Diary.Models.Entities
{
    public class WeatherStationTemperature
{
        public int id;
        public int apiary_id;
        public string current_date_and_time;
        public double temperature;

        public WeatherStationTemperature()
        {

        }

        public override string ToString()
        {
            return string.Format("{0:0.00}", this.temperature);
        }
    }
}
