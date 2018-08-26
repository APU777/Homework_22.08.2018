using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework_22._08._2018
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private byte _ASize;
        private byte _BSize;
        private byte _FontASize;
        private byte _FontBSize;
        private SettingsPB S_PB = new SettingsPB(); 

        bool _CheckWindowSize = false;
        bool _CheckSexMouseOVer = true;

        public MainWindow()
        {
            InitializeComponent();


            this.CountryBox.AutoSuggestionList.Add("Kiev");
            this.CountryBox.AutoSuggestionList.Add("Rivne");
            this.CountryBox.AutoSuggestionList.Add("Kostopil");
            this.CountryBox.AutoSuggestionList.Add("Odessa");
          

          
        }
        private void SetSizeControls()
        {
            S_PB.DefaultSettings(LastNameBlock, BSMan, out _ASize, out _BSize, out _FontASize, out _FontBSize, _CheckWindowSize);//Add

            S_PB.SetSizeNameBlock(_FirstName: FirstNameBlock, _SurName: SurnameBlock, _Size: LastNameBlock.FontSize); //Add
            S_PB.SetSizeAddressBlock(_Country: CountryBlock, _City: CityBlock, _Address: AddressBlock, _PhoneNumber: PhoneNumberBlock, _Size: LastNameBlock.FontSize);//Add
            S_PB.SetSizeLOWData(DatePr, DateBlock, BSManBlock, BSWomanBlock, LastNameBlock.FontSize);// Add
            S_PB.SetSizeBorderSex(BSMan, BSWoman, BSMan.Height);//Add
            S_PB.CheckSexSize(BSMan, BSWoman, BSManBlock, BSWomanBlock, _ASize, _BSize, _FontASize, _FontBSize);//Add


            _CheckWindowSize = S_PB.DefaultSettings(ShowLastNameBlock, ShowBSMan, out _ASize, out _BSize, out _FontASize, out _FontBSize, _CheckWindowSize);//Show

            S_PB.SetSizeNameBlock(_FirstName: ShowFirstNameBlock, _SurName: ShowSurnameBlock, _Size: ShowLastNameBlock.FontSize); //Show
            S_PB.SetSizeAddressBlock(_Country: ShowCountryBlock, _City: ShowCityBlock, _Address: ShowAddressBlock, _PhoneNumber: ShowPhoneNumberBlock, _Size: ShowLastNameBlock.FontSize);//Show
            S_PB.SetSizeLOWData(ShowDatePr, ShowDateBlock, ShowBSManBlock, ShowBSWomanBlock, ShowLastNameBlock.FontSize);//Show
            S_PB.SetSizeBorderSex(ShowBSMan, ShowBSWoman, ShowBSMan.Height);//Show

            S_PB.CheckSexSize(ShowBSMan, ShowBSWoman, ShowBSManBlock, ShowBSWomanBlock, _ASize, _BSize, _FontASize, _FontBSize);//Show
        }


        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetSizeControls();

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

        private void ShowLastnameBox_KeyUp(object sender, KeyEventArgs e)
        {
            MessageBox.Show(ShowLastnameBox.Text);

        }

        private void DataGRID_Loaded(object sender, RoutedEventArgs e)
        {
            List<DTablePB> result = new List<DTablePB>(3);
            result.Add(new DTablePB("Prystupa", "Vitaly", "Aleksandrovich", 'M', "31-08-1996", "Ukraine", "Rivne", "Street", "380673339482"));
            result.Add(new DTablePB("Prystupa", "Vitaly", "Aleksandrovich", 'M', "31-08-1996", "Ukraine", "Rivne", "Street", "380673339482"));
            result.Add(new DTablePB("Prystupa", "Vitaly", "Aleksandrovich", 'M', "31-08-1996", "Ukraine", "Rivne", "Street", "380673339482"));

            DataGRID.ItemsSource = result;
             
        }
    }
}