using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObserverSample
{
    abstract class DynamicObserver : INotifyPropertyChanged
    {
        Dictionary<string, Action<object>> UpdateExpressions = new Dictionary<string, Action<object>>();

        DynamicObservable dataSource = null;
        public DynamicObservable DataSource
        {
            private get
            {
                return dataSource;
            }
            set
            {
                dataSource = value;
                value.Update += Update;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void AddUpdateAction(string propertyName, Action<object> updateAction)
        {
            UpdateExpressions[propertyName] = updateAction;
        }

        void Update(string propertyName)
        {
            Action<object> updateAction;
            if (UpdateExpressions.TryGetValue(propertyName, out updateAction))
            {
                updateAction(DataSource.GetPropertyValue(propertyName));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
