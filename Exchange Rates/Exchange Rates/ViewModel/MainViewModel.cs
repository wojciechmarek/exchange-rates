using System;
using System.Collections.Generic;
using System.Windows;
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
        private bool mainGridVisibility = false;
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

        private bool converterGridVisibility = true;
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
        public string AmountTo { get; set; }

        private string currTo;
        public string CurrTo // <- tutaj mamy co sie zmienia w combobox
        {
            get { return currTo; }
            set
            { 
                currTo = value;
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

        public string AmountFron { get; set; }

        private string currFrom;
        public string CurrFrom // <- tutaj mamy co sie zmienia w combobox
        {
            get { return currFrom; }
            set
            {
                currFrom = value;
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

        public List<string> CurrCodesList { get; set; }

        //author grid


        #endregion
        public MainViewModel()
        {
            InitEvents();
            CurrenciesList = new List<string> { "test1", "tesdfst1", "tessdft1" };
            CurrCodesList = new List<string> { "pln", "usd", "jpy", "cad", "eur" };

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
    }
}