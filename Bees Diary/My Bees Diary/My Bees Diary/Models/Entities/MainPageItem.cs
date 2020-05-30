using System;
using System.Collections.Generic;
using System.Text;

namespace My_Bees_Diary.Models.Entities
{
    /// <summary>
    /// This entity is used for the startPage.
    /// </summary>
    /// <remarks>
    /// We use this in order for the pages to be displayed in the sidebar of the startPage.
    /// </remarks>
    public class MainPageItem
    {
        /// <summary>
        /// Title of the item.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The item's icon source.
        /// </summary
        public string IconSource { get; set; }
        /// <summary>
        /// Type of the item (in this case, page.)
        /// </summary>
        public Type TargetType { get; set; }
        /// <summary>
        /// This is for additional arguments if the page needs such.
        /// </summary>
        public object[] args { get; set; }
    }

}
