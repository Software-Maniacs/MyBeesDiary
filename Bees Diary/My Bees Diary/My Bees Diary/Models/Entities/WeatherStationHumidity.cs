using System;
using System.Collections.Generic;
using System.Text;

namespace My_Bees_Diary.Models.Entities
{
    public class WeatherStationHumidity
{
        public int id;
        public int apiary_id;
        public string current_data_and_time;
        public decimal humidity;

        public WeatherStationHumidity()
        {

        }

        public override string ToString()
        {
            return string.Format("{0:0.00}", this.humidity);
        }
    }
}
