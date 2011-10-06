using System;
using System.Data.Linq;

namespace DatabaseForMango.Models
{
    public class WidgetDataContext : DataContext
    {
        public WidgetDataContext()
            : base("Data Source=isostore:/WidgetDb.sdf")
        {
        }

        public Table<Widget> Widgets;
        public Table<Category> Categories;
    }
}