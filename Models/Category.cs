using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace DatabaseForMango.Models
{
    [Table(Name = "Categories")]
    public class Category : TableObject
    {
        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;

        // CategoryId
        private int _CategoryId;

        [Column(
            IsPrimaryKey = true,
            IsDbGenerated = true,
            DbType = "INT NOT NULL Identity",
            CanBeNull = false,
            AutoSync = AutoSync.OnInsert)]
        public int CategoryId
        {
            get { return _CategoryId; }
            set
            {
                if (_CategoryId == value)
                    return;
                NotifyPropertyChanging("CategoryId");
                _CategoryId = value;
                NotifyPropertyChanging("CategoryId");
            }
        }

        // CategoryName

        private string _CategoryName;

        [Column]
        public string CategoryName
        {
            get { return _CategoryName; }
            set
            {
                if (_CategoryName == value)
                    return;
                NotifyPropertyChanging("CategoryName");
                _CategoryName = value;
                NotifyPropertyChanging("CategoryName");
            }
        }

        // Widgets
        private EntitySet<Widget> _Widgets;

        [Association(
            Storage = "_Widgets",
            ThisKey = "CategoryId",
            OtherKey = "_categoryId")]
        public EntitySet<Widget> Widgets
        {
            get { return _Widgets; }
            set { _Widgets.Assign(value); }
        }

        // Assign handlers for the add and remove operations, respectively.
        public Category()
        {
            _Widgets = new EntitySet<Widget>(
                new Action<Widget>(this.attach_Widget),
                new Action<Widget>(this.detach_Widget)
                );
        }

        // Called during an add operation
        private void attach_Widget(Widget w)
        {
            NotifyPropertyChanging("WidgetCategory");
            w.WidgetCategory = this;
        }

        // Called during a remove operation
        private void detach_Widget(Widget w)
        {
            NotifyPropertyChanging("WidgetCategory");
            w.WidgetCategory = null;
        }
    }
}