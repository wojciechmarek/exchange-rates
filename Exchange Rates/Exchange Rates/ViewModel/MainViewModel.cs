using System;
using System.Collections.Generic;
using System.Windows;
using Exchange_Rates.Model.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Exchange_Rates.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Objects Declarations for Grigs

        //title bar
        public RelayCommand CloseApplicationButton { get; set; }

        private string titleLabel = "Programowanie";
        public string TitleLabel
        {
            get { return titleLabel; }
            set
            {
                Set(ref titleLabel, value);
            }
        }

        //navigation bar
        public RelayCommand<object> NavigationButtons { get; set; }

        //grid visibility
        private bool mainGridVisibility = true;
        public bool MainGridVisibility
        {
            get { return mainGridVisibility; }
            set
            {
                Set(ref mainGridVisibility, value);
            }
        }

        private bool currencyGridVisibility = false;
        public bool CurrencyGridVisibility
        {
            get { return currencyGridVisibility; }
            set
            {
                Set(ref currencyGridVisibility, value);
            }
        }

        private bool converterGridVisibility = false;
        public bool ConverterGridVisibility
        {
            get { return converterGridVisibility; }
            set
            {
                Set(ref converterGridVisibility, value);
            }
        }

        private bool authorGridVisibility = false;
        public bool AuthorGridVisibility
        {
            get { return authorGridVisibility; }
            set
            {
                Set(ref authorGridVisibility, value);
            }
        }

        //main grid
        private string date = "sample";
        public string Date
        {
            get { return date; }
            set
            {
                Set(ref date, value);
            }
        }

        private float usd;
        public float Usd
        {
            get { return usd; }
            set
            {
                Set(ref usd, value);
            }
        }

        private float eur;
        public float Eur
        {
            get { return eur; }
            set
            {
                Set(ref eur, value);
            }
        }

        private float chf;
        public float Chf
        {
            get { return chf; }
            set
            {
                Set(ref chf, value);
            }
        }

        private float cad;
        public float Cad
        {
            get { return cad; }
            set
            {
                Set(ref cad, value);
            }
        }

        private float gbp;
        public float Gbp
        {
            get { return gbp; }
            set
            {
                Set(ref gbp, value);
            }
        }

        private float nzd;
        public float Nzd
        {
            get { return nzd; }
            set
            {
                Set(ref nzd, value);
            }
        }

        private float aud;
        public float Aud
        {
            get { return aud; }
            set
            {
                Set(ref aud, value);
            }
        }

        private float rub;
        public float Rub
        {
            get { return rub; }
            set
            {
                Set(ref rub, value);
            }
        }

        private float jpy;
        public float Jpy
        {
            get { return jpy; }
            set
            {
                Set(ref jpy, value);
            }
        }

        //currency
        public List<string> CurrenciesList { get; set; }

        private string selectedCurrency;
        public string SelectedCurrency // <- tutaj mamy co sie zmienia w combobox
        {
            get { return selectedCurrency; }
            set
            { 
                CurrName = value;  // uihliuhn
                selectedCurrency = value;
                DisplaySepcificInfo();
            }
        }

        private float mainRate;
        public float MainRate
        {
            get { return mainRate; }
            set
            {
                Set(ref mainRate, value);
            }
        }

        private float minRate;
        public float MinRate
        {
            get { return minRate; }
            set
            {
                Set(ref minRate, value);
            }
        }

        private float maxRate;
        public float MaxRate
        {
            get { return maxRate; }
            set
            {
                Set(ref maxRate, value);
            }
        }

        private string currName;
        public string CurrName
        {
            get { return currName; }
            set
            {
                Set(ref currName, value);
            }
        }

        private string currCode;
        public string CurrCode
        {
            get { return currCode; }
            set
            {
                Set(ref currCode, value);
            }
        }


        //converter grid
        private string amountTo = 0.ToString();
        public string AmountTo
        {
            get
            {
                return amountTo;
            }
            set
            {
                amountTo = value;
            }
        } 

        private string currTo = "USD";
        public string CurrTo // <- tutaj mamy co sie zmienia w combobox
        {
            get { return currTo; }
            set
            {
                currTo = value;
                ConvertTo(value);
            }
        }

        

        private string resultTo;
        public string ResultTo
        {
            get { return resultTo; }
            set
            {
                Set(ref resultTo, value);
            }
        }

        private string amountFrom = 0.ToString();
        public string AmountFrom
        {
            get
            {
                return amountFrom;
            }
            set
            {
                amountFrom = value;
            }
        }

        private string currFrom = "USD";
        public string CurrFrom // <- tutaj mamy co sie zmienia w combobox
        {
            get { return currFrom; }
            set
            {
                currFrom = value;
                ConvertFrom(value);
            }
        }

        private string resultFrom;
        public string ResultFrom
        {
            get { return resultFrom; }
            set
            {
                Set(ref resultFrom, value);
            }
        }

        public List<string> CurrCodesList1 { get; set; }
        public List<string> CurrCodesList2 { get; set; }

        //author grid

        private readonly IDataAccessServices dataAccessServices;
        Services services = new Services();

        #endregion

        List<string> codesCurrencies = new List<string>();
        List<string> fullCurrencies = new List<string>();

        public MainViewModel(IDataAccessServices dataAccessServices)
        {
            this.dataAccessServices = dataAccessServices;
            //this.dataAccessServices = dataAccessServices;
            InitEvents();
            ProcessData();

            ConvertFrom("USD");
            ConvertTo("USD");

        }

        private void ProcessData()
        {


            dataAccessServices.GetGeneralCurrencies(
                (item, error) =>
                {
                    if (error != null)
                    {
                        TitleLabel = error.InnerException.Message;
                        return;
                    }
                    else
                    {

                    }

                    Date = item.effectiveDate;
                    Usd = item.rates[1].mid;
                    Eur = item.rates[7].mid;
                    Chf = item.rates[9].mid;
                    Cad = item.rates[4].mid;
                    Gbp = item.rates[10].mid;
                    Nzd = item.rates[5].mid;
                    Aud = item.rates[2].mid;
                    Rub = item.rates[29].mid;
                    Jpy = item.rates[12].mid * 100;
                    

                });

                dataAccessServices.GetSpecificCurrencies(
                 (item, error) =>
                 {
                     if (error != null)
                     {
                         TitleLabel = error.InnerException.Message;
                         return;
                     }
                     else
                     {

                     }

                     
                     for (int i = 0; i < 13; i++)
                     {
                         codesCurrencies.Add(item.rates[i].code);
                         fullCurrencies.Add(item.rates[i].currency);
                     }

                     CurrCodesList1 = codesCurrencies;
                     CurrenciesList = fullCurrencies;
                     CurrCodesList2 = CurrCodesList1;

                 });
        }

        private void InitEvents()
        {
            NavigationButtons = new RelayCommand<object>(ChangeGrid);
            CloseApplicationButton = new RelayCommand(CloseApp);

            
        }

        private void CloseApp()
        {
            Environment.Exit(0);
        }

        private void ChangeGrid(object obj)
        {
            //MessageBox.Show(AmountTo);

            switch (obj.ToString())
            {
                case "main":
                    MainGridVisibility = true;
                    CurrencyGridVisibility = false;
                    ConverterGridVisibility = false;
                    AuthorGridVisibility = false;
                    TitleLabel = "G³ówne kursy walut";
                    break;

                case "currencies":
                    MainGridVisibility = false;
                    CurrencyGridVisibility = true;
                    ConverterGridVisibility = false;
                    AuthorGridVisibility = false;
                    TitleLabel = "Szczegó³owe kursy walut";

                    break;

                case "converter":
                    MainGridVisibility = false;
                    CurrencyGridVisibility = false;
                    ConverterGridVisibility = true;
                    AuthorGridVisibility = false;
                    TitleLabel = "Przelicznik walut";

                    break;

                case "author":
                    MainGridVisibility = false;
                    CurrencyGridVisibility = false;
                    ConverterGridVisibility = false;
                    AuthorGridVisibility = true;
                    TitleLabel = "Autor";

                    break;
            }
        }


        private void ConvertTo(string name)
        {
            float amountTo;
            float.TryParse(AmountTo, out amountTo);

            dataAccessServices.GetSpecificCurrencies(
                   (item, error) =>
                   {
                       if (error != null)
                       {
                           TitleLabel = error.InnerException.Message;
                           return;
                       }
                       else
                       {

                       }

                       for (int i = 0; i < 13; i++)
                       {
                           if (item.rates[i].code == CurrTo)
                           {
                               ResultTo = (amountTo * (float)item.rates[i].bid).ToString();
                           }
                       }



                   });

        }

        private void ConvertFrom(string name)
        {
            float amountFrom;
            float.TryParse(AmountFrom, out amountFrom);

            dataAccessServices.GetSpecificCurrencies(
                  (item, error) =>
                  {
                      if (error != null)
                      {
                          TitleLabel = error.InnerException.Message;
                          return;
                      }
                      else
                      {

                      }

                      for (int i = 0; i < 13; i++)
                      {
                          if (item.rates[i].code == CurrFrom)
                          {
                              ResultFrom = (amountFrom / (float)item.rates[i].ask).ToString();
                          }
                      }



                  });
        }

        private void DisplaySepcificInfo()
        {

            dataAccessServices.GetSpecificCurrencies(
                   (item, error) =>
                   {
                       if (error != null)
                       {
                           TitleLabel = error.InnerException.Message;
                           return;
                       }
                       else
                       {

                       }

                       for (int i = 0; i < 13; i++)
                       {
                           if (item.rates[i].currency == SelectedCurrency)
                           {
                               CurrCode = item.rates[i].code;
                               MainRate = (item.rates[i].ask + item.rates[i].bid)/2;
                               MinRate = (float)item.rates[i].ask;
                               MaxRate = (float)item.rates[i].bid;
                           }
                       }

                       

                   });
        }
    }
}