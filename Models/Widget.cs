using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace DatabaseForMango.Models
{
    [Table(Name = "Widgets")]
    public class Widget : TableObject
    {
        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;

        // WidgetId
        private int _WidgetId;

        [Column(
            CanBeNull = false,
            IsPrimaryKey = true,
            IsDbGenerated = true,
            //DbType = "INT NOT NULL Identity",
            AutoSync = AutoSync.OnInsert)]
        public int WidgetId
        {
            get { return _WidgetId; }
            set
            {
                if (_WidgetId == value)
                    return;
                NotifyPropertyChanging("WidgetId");
                _WidgetId = value;
                NotifyPropertyChanged("WidgetId");
            }
        }

        // WidgetName
        private string _WidgetName;

        [Column]
        public string WidgetName
        {
            get { return _WidgetName; }
            set
            {
                if (_WidgetName == value)
                    return;
                NotifyPropertyChanging("WidgetName");
                _WidgetName = value;
                NotifyPropertyChanged("WidgetName");
            }
        }

        // Category
        [Column]
        internal int _categoryId;

        private EntityRef<Category> _category;

        [Association(
            Storage = "_category",
            ThisKey = "_categoryId",
            OtherKey = "CategoryId",
            IsForeignKey = true)]
        public Category WidgetCategory
        {
            get { return _category.Entity; }
            set
            {
                NotifyPropertyChanging("WidgetCategory");
                _category.Entity = value;
                if (value != null)
                {
                    _categoryId = value.CategoryId;
                }
                NotifyPropertyChanged("WidgetCategory");
            }
        }

        //private DateTime _creationDate = DateTime.Now;

        //[Column]
        //public DateTime? CreationDate
        //{
        //    get { return _creationDate; }
        //    set
        //    {
        //        NotifyPropertyChanging("CreationDate");
        //        _creationDate = value;
        //        NotifyPropertyChanged("CreationDate");
        //    }
        //}
    }
}