using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PassDataToDialog
{
    public class OrganizationsViewModel : INotifyPropertyChanged
    {
        public OrganizationsViewModel(ObservableCollection<Organization> orgs)
        {
            // _organizations = new ObservableCollection<Organization>();
            // this.Organizations.Add(new Organization { Code = "1", Name = "test", leader = "leader" });
            this.Organizations = orgs;
        }

        ObservableCollection<Organization> _organizations;

        public ObservableCollection<Organization> Organizations
        {
            get
            {
                if (_organizations == null)
                {
                    _organizations = new ObservableCollection<Organization>();
                    //this._organizations.Add(new Organization { Code = "1", Name = "test", leader = "leader" }); 

                }
                return _organizations;
            }

            set
            {
                _organizations = value;
                this.OnPropertyChanged("Organizations");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged(string changedProperty)
        {
            if (PropertyChanged != null)
            {

                PropertyChanged(this, new PropertyChangedEventArgs(changedProperty));
            }
        }
    }
}
