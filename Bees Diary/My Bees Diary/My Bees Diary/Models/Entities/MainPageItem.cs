using System;
using System.Collections.Generic;
using System.Text;

namespace My_Bees_Diary.Models.Entities
{
   public class MainPageItem
{
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Type TargetType { get; set; }
        public object[] args { get; set; }
    }
}
