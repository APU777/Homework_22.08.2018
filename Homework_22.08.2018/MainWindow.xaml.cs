using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Homework_22._08._2018
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static double _ScreenWidth = SystemParameters.PrimaryScreenWidth;
        private static double _ScreenHeight = SystemParameters.PrimaryScreenHeight;
        private byte _ASize;
        private byte _BSize;
        private byte _FontASize;
        private byte _FontBSize;
        private bool? _BufferSex = null;

        private SettingsPB S_PB = new SettingsPB(); 

        bool _CheckWindowSize = false;
        bool _CheckSexMouseOVer = true;
        bool _CheckColor = false;

        public MainWindow()
        {
            InitializeComponent();

            SetAuxiliaryData();

            for (int i = 15; i < 17; ++i)
                ((CSWPFAutoCompleteTextBox.UserControls.AutoCompleteTextBox)((StackPanel)Grid_AddType.Children[i]).Children[0]).Text = null;
        }
        private void SetAuxiliaryData()
        {

            String[] _Country = System.IO.File.ReadAllLines(@"../../TEXTData/Countries.txt");
            foreach (var C in _Country)
                this.CountryBox.AutoSuggestionList.Add(C);
        }

        private void SetSizeControls()
        {
            if (ActualWidth >= ((_ScreenWidth * 94) / 100) && ActualHeight  >= ((_ScreenHeight * 85) / 100) || _CheckWindowSize == false)
            {
                S_PB.DefaultSettings(LastNameBlock, BSMan, out _ASize, out _BSize, out _FontASize, out _FontBSize, _CheckWindowSize);//Add
                _CheckWindowSize = S_PB.DefaultSettings(ShowLastNameBlock, ShowBSMan, out _ASize, out _BSize, out _FontASize, out _FontBSize, _CheckWindowSize);//Show
            }
               

            S_PB.SetSizeNameBlock(_FirstName: FirstNameBlock, _SurName: SurnameBlock, _Size: LastNameBlock.FontSize); //Add
            S_PB.SetSizeAddressBlock(_Country: CountryBlock, _City: CityBlock, _Address: AddressBlock, _PhoneNumber: PhoneNumberBlock, _Size: LastNameBlock.FontSize);//Add
            S_PB.SetSizeLOWData(DatePr, DateBlock, BSManBlock, BSWomanBlock, LastNameBlock.FontSize);// Add
            S_PB.SetSizeBorderSex(BSMan, BSWoman, BSMan.Height);//Add

            S_PB.CheckSexSize(BSMan, BSWoman, BSManBlock, BSWomanBlock, _ASize, _BSize, _FontASize, _FontBSize);//Add


            S_PB.SetSizeNameBlock(_FirstName: ShowFirstNameBlock, _SurName: ShowSurnameBlock, _Size: ShowLastNameBlock.FontSize); //Show
            S_PB.SetSizeAddressBlock(_Country: ShowCountryBlock, _City: ShowCityBlock, _Address: ShowAddressBlock, _PhoneNumber: ShowPhoneNumberBlock, _Size: ShowLastNameBlock.FontSize);//Show
            S_PB.SetSizeLOWData(ShowDatePr, ShowDateBlock, ShowBSManBlock, ShowBSWomanBlock, ShowLastNameBlock.FontSize);//Show
            S_PB.SetSizeBorderSex(ShowBSMan, ShowBSWoman, ShowBSMan.Height);//Show

            S_PB.CheckSexSize(ShowBSMan, ShowBSWoman, ShowBSManBlock, ShowBSWomanBlock, _ASize, _BSize, _FontASize, _FontBSize);//Show
        }

        private bool CheckText_in_Box()
        {
            Dictionary<TextBlock, bool> TBForeground = new Dictionary<TextBlock, bool>();
            if (LastnameBox.Text.Length == 0)
                TBForeground.Add(LastNameBlock, false);
            else
                TBForeground.Add(LastNameBlock, true);

            if (FirstnameBox.Text.Length == 0)
                TBForeground.Add(FirstNameBlock, false);
            else
                TBForeground.Add(FirstNameBlock, true);

            if (SurnameBox.Text.Length == 0)
                TBForeground.Add(SurnameBlock, false);
            else
                TBForeground.Add(SurnameBlock, true);

            if (CountryBox.Text.Length == 0)
                TBForeground.Add(CountryBlock, false);
            else
                TBForeground.Add(CountryBlock, true);

            if (PhoneNumberBox.Text.Length == 0)
                TBForeground.Add(PhoneNumberBlock, false);
            else
                TBForeground.Add(PhoneNumberBlock, true);

            return WorkShopPB.ALERT<TextBlock, bool>(TBForeground);
        }

        private void CheckLengthTextBox()
        {
            if (CheckB.IsChecked == false)
                DatePr.Text = null;

            if (String.IsNullOrWhiteSpace(CityBox.Text))
                CityBox.Text = null;
            if (String.IsNullOrWhiteSpace(AddressBox.Text))
                AddressBox.Text = null;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetSizeControls();
            Title = ActualWidth.ToString();
        }

        private void BSManBlock_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsMouseOver && _CheckSexMouseOVer)
            {
                WorkShopPB.BAnimationFAnimation(BSMan, BSManBlock, _ASize, _BSize, _FontASize, _FontBSize);
                _CheckSexMouseOVer = false;
            }
            else
            {
                WorkShopPB.BAnimationFAnimation(BSMan, BSManBlock, _BSize, _ASize, _FontBSize, _FontASize);
                _CheckSexMouseOVer = true;
            }
        }

        private void BSWomanBlock_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsMouseOver && _CheckSexMouseOVer)
            {
                WorkShopPB.BAnimationFAnimation(BSWoman, BSWomanBlock, _ASize, _BSize, _FontASize, _FontBSize);
                _CheckSexMouseOVer = false;
            }
            else
            {
                WorkShopPB.BAnimationFAnimation(BSWoman, BSWomanBlock, _BSize, _ASize, _FontBSize, _FontASize);
                _CheckSexMouseOVer = true;
            }
        }

        private void ShowBSManBlock_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsMouseOver && _CheckSexMouseOVer)
            {
                WorkShopPB.BAnimationFAnimation(ShowBSMan, ShowBSManBlock, _ASize, _BSize, _FontASize, _FontBSize);
                _CheckSexMouseOVer = false;
            }
            else
            {
                WorkShopPB.BAnimationFAnimation(ShowBSMan, ShowBSManBlock, _BSize, _ASize, _FontBSize, _FontASize);
                _CheckSexMouseOVer = true;
            }
        }

        private void ShowBSWomanBlock_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsMouseOver && _CheckSexMouseOVer)
            {
                WorkShopPB.BAnimationFAnimation(ShowBSWoman, ShowBSWomanBlock, _ASize, _BSize, _FontASize, _FontBSize);
                _CheckSexMouseOVer = false;
            }
            else
            {
                WorkShopPB.BAnimationFAnimation(ShowBSWoman, ShowBSWomanBlock, _BSize, _ASize, _FontBSize, _FontASize);
                _CheckSexMouseOVer = true;
            }
        }
       
        private void DataGRID_Loaded(object sender, RoutedEventArgs e)
        {
            List<DTablePB> result = new List<DTablePB>();
            DataGRID.ItemsSource = DataBaseCommon.AllDataSearch(result);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _CheckColor =  CheckText_in_Box();

            if (_CheckColor)
            {
                try
                {
                    CheckLengthTextBox();
                    DataBaseCommon.AddData(Grid_AddType, _BufferSex, DatePr.Text);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    DatePr.Text = null;
                    BSMan.Background = null;
                    BSWoman.Background= null;
                    _BufferSex = null;
                    DatePr.IsEnabled = false;
                    CheckB.IsChecked = false;
                }
            }
        }

        private void CheckB_Click(object sender, RoutedEventArgs e)
        {
            if (!DatePr.IsEnabled)
                DatePr.IsEnabled = true;
            else
            {
                DatePr.IsEnabled = false;
                DatePr.Text = null;
            }
        }

        private void BSMan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BSWoman.Background = null;
            BSMan.Background = Brushes.Red;
            _BufferSex = true;
        }

        private void BSWoman_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BSMan.Background = null;
            BSWoman.Background = Brushes.Red;
            _BufferSex = false;
        }

        ////////////////////////////////////////////////////////////////////////
        private int _LName = 0;
        private bool _LNameText = true;
        private int _IndxLName = -1000;

        private void ShowLastnameBox_KeyUp(object sender, KeyEventArgs e)
        {
            List<DTablePB> result = new List<DTablePB>();

            if(DataBaseCommon.FieldName.Contains("LastName") == false)
                DataBaseCommon.FieldName.Add("LastName");
            
            if (_LNameText)
            {
                if (_LName == 0)
                {
                    DataBaseCommon.FieldInfo.Add(ShowLastnameBox.Text);
                    ++_LName;
                }
                _LNameText = false;
            }

            if (_IndxLName == -3)
            {
                if (ShowLastnameBox.Text.Length > 0)
                {
                    _IndxLName = DataBaseCommon.FieldInfo.Count - 1;
                    DataBaseCommon.FieldInfo[_IndxLName] = ShowLastnameBox.Text;
                    _IndxLName = DataBaseCommon.FieldInfo.IndexOf(ShowLastnameBox.Text);
                }
            }

            if (_IndxLName > -1)
                DataBaseCommon.FieldInfo[_IndxLName] = ShowLastnameBox.Text;

            _IndxLName = DataBaseCommon.FieldInfo.IndexOf(ShowLastnameBox.Text);

            if (ShowLastnameBox.Text.Length == 0)
            {
                DataBaseCommon.FieldName.Remove("LastName");
                _IndxLName  = -3;
                _LNameText = true;
            }

            if (DataBaseCommon.FieldName.Count > 0)
            {
                DataGRID.IsReadOnly = true;
                DataGRID.ItemsSource = DataBaseCommon.ShowData(result, ShowLastnameBox.Text);
            }
        }
        ///////////////////////////////////////////////////////////////////////
        private int _FName = 0;
        private bool _FNameText = true;
        private int _IndxFName = -1000;
        private void ShowFirstnameBox_KeyUp(object sender, KeyEventArgs e)
        {
            List<DTablePB> result = new List<DTablePB>();

            if (DataBaseCommon.FieldName.Contains("FirstName") == false)
                DataBaseCommon.FieldName.Add("FirstName");

            if (_FNameText)
            {
                if (_FName == 0)
                {
                    DataBaseCommon.FieldInfo.Add(ShowFirstnameBox.Text);
                    ++_FName;
                }
                _FNameText = false;
            }

            if (_IndxFName == -3)
            {
                if (ShowFirstnameBox.Text.Length > 0)
                {
                    if (DataBaseCommon.FieldInfo.Count == 1)
                        _IndxFName = 0;
                    else
                        _IndxFName = DataBaseCommon.FieldInfo.Count - 1;         //LOOK AT INDEX!!!  
                    
                    DataBaseCommon.FieldInfo[_IndxFName] = ShowFirstnameBox.Text;
                    _IndxFName = DataBaseCommon.FieldInfo.IndexOf(ShowFirstnameBox.Text);
                }
            }

            if (_IndxFName > -1)
                DataBaseCommon.FieldInfo[_IndxFName] = ShowFirstnameBox.Text;

            _IndxFName = DataBaseCommon.FieldInfo.IndexOf(ShowFirstnameBox.Text);

            if (ShowFirstnameBox.Text.Length == 0)
            {
                DataBaseCommon.FieldName.Remove("FirstName");
                _IndxFName  = -3;
                _FNameText = true;
            }

            if (DataBaseCommon.FieldName.Count > 0)
            {
                DataGRID.IsReadOnly = true;
                DataGRID.ItemsSource = DataBaseCommon.ShowData(result, ShowFirstnameBox.Text);
            }
        }
        ///////////////////////////////////////////////////////////////////////
        private void ShowSurnameBox_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}