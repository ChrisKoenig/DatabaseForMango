using System.Collections.ObjectModel;
using System.Linq;
using DatabaseForMango.Models;
using GalaSoft.MvvmLight;

namespace DatabaseForMango.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        WidgetDataContext db;

        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                db = new WidgetDataContext();
                Refresh();
            }
        }

        Category _category1;
        Category _category2;
        int counter = 6;

        public void Refresh()
        {
            // ensure that data exists - just for this test app
            if (db.Categories.Count() == 0 || db.Widgets.Count() == 0)
            {
                RecreateDatabase();
            }

            Widgets = null;
            Widgets = new ObservableCollection<Widget>(db.Widgets);
            _category1 = db.Categories.First();
            _category2 = db.Categories.Skip(1).Take(1).First();
        }

        public void Add()
        {
            var widget = new Widget()
            {
                WidgetName = "Widget " + counter,
                WidgetCategory = counter % 2 == 0 ? _category1 : _category2,
            };

            db.Widgets.InsertOnSubmit(widget);
            db.SubmitChanges();
            counter += 1;
            Refresh();
        }

        public void Delete()
        {
            if (SelectedWidget == null)
                return;
            db.Widgets.DeleteOnSubmit(SelectedWidget);
            db.SubmitChanges();
            Refresh();
        }

        public void Update()
        {
            if (SelectedWidget == null)
                return;
            SelectedWidget.WidgetName += " UPDATED!";
            db.SubmitChanges();
            Refresh();
        }

        private ObservableCollection<Widget> _widgets = new ObservableCollection<Widget>();

        public ObservableCollection<Widget> Widgets
        {
            get { return _widgets; }

            set
            {
                if (_widgets != value)
                {
                    _widgets = value;

                    RaisePropertyChanged(() => Widgets);
                }
            }
        }

        private Widget _SelectedWidget = new Widget();

        public Widget SelectedWidget
        {
            get { return _SelectedWidget; }
            set
            {
                if (_SelectedWidget == value)
                {
                    return;
                }
                _SelectedWidget = value;
                RaisePropertyChanged(() => SelectedWidget);
            }
        }

        internal void RecreateDatabase()
        {
            // purge
            db.Categories.DeleteAllOnSubmit(db.Categories);
            db.Widgets.DeleteAllOnSubmit(db.Widgets);
            db.SubmitChanges();

            // create new
            _category1 = new Category() { CategoryName = "Category 1" };
            _category2 = new Category() { CategoryName = "Category 2" };

            db.Categories.InsertOnSubmit(_category1);
            db.Categories.InsertOnSubmit(_category2);

            db.Widgets.InsertOnSubmit(new Widget() { WidgetName = "Widget 1", WidgetCategory = _category1 });
            db.Widgets.InsertOnSubmit(new Widget() { WidgetName = "Widget 2", WidgetCategory = _category2 });
            db.Widgets.InsertOnSubmit(new Widget() { WidgetName = "Widget 3", WidgetCategory = _category1 });
            db.Widgets.InsertOnSubmit(new Widget() { WidgetName = "Widget 4", WidgetCategory = _category2 });
            db.Widgets.InsertOnSubmit(new Widget() { WidgetName = "Widget 5", WidgetCategory = _category1 });

            db.SubmitChanges();
            Refresh();
        }

        private int _databaseSchemaVersion = 0;

        public int DatabaseSchemaVersion
        {
            get
            {
                return _databaseSchemaVersion;
            }
            set
            {
                if (_databaseSchemaVersion != value)
                {
                    _databaseSchemaVersion = value;
                    RaisePropertyChanged(() => DatabaseSchemaVersion);
                }
            }
        }
    }
}