﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

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

        #region Version 2

        //public Table<Log> Log;

        //public List<Widget> GetWidgetsByFirstLetter(string firstLetter)
        //{
        //    var query = from w in Widgets
        //                where w.WidgetName.StartsWith(firstLetter)
        //                select w;
        //    return query.ToList();
        //}

        #endregion Version 2
    }
}