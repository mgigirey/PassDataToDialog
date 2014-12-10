using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PassDataToDialog
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Organization> Organizations { get; set; }

        public MainWindowViewModel()
        {
            this.Organizations = new ObservableCollection<Organization>();
            this.Organizations.Add(new Organization { Code = "1", Name = "test", leader = "leader" });
        }

        private ICommand openDialog;

        public ICommand OpenDialog
        {
            get
            {
                if (openDialog == null)
                {
                    openDialog = new RelayCommand(
                        param => ShowOrganizations()
                    );
                }
                return openDialog;
            }
        }

        private void ShowOrganizations()
        {
            OrganizationsViewModel OrganizationsVM = new OrganizationsViewModel(this.Organizations);
            DialogService.Instance.ShowDialog(OrganizationsVM);
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
