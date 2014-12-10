using System;
using System.Windows;

namespace PassDataToDialog
{
    // http://stackoverflow.com/a/14198568/3824765
    public class DialogService
    {
        #region Member Variables
        
        private static volatile DialogService instance;
        private static object syncroot = new object();
        
        #endregion

        #region Ctr

        private DialogService()
        {

        }

        #endregion

        #region Public Methods
        
        /*public void ShowDialog(object _callerContentOne, object _callerContentTwo)
        {
            DialogViewModel viewmodel = new DialogViewModel(_callerContentOne, _callerContentTwo);
            DialogView view = new DialogView();
            view.DataContext = viewmodel;

            view.ShowDialog();
        }*/

        public void ShowDialog(OrganizationsViewModel viewModel)
        {
            DialogView dialog = new DialogView() { DataContext = viewModel };
            dialog.Owner = Application.Current.MainWindow;
            dialog.ShowInTaskbar = false;
            dialog.ShowDialog();
        }

        #endregion

        #region Private Methods

        #endregion

        #region Properties
        
        public static DialogService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncroot)
                    {
                        if (instance == null)
                        {
                            instance = new DialogService();
                        }
                    }
                }
                return instance;
            }
        }
        
        #endregion
    }
}
