/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Exchange_Rates"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using Exchange_Rates.Model.Services;
using GalaSoft.MvvmLight.Ioc;

namespace Exchange_Rates.ViewModel
{
    /// <summary>
    /// Klasa zawiera wszystkie statyczne odniesienia do ModelView
    /// w aplikacji i dostarcza punkt wejscia do bindowania
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        ///Inicjuje klasê ViewModelLocator class.
        ///</summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
                SimpleIoc.Default.Register<IDataAccessServices, DataAccessServices>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}