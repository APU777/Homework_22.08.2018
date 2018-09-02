using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Homework_22._08._2018
{
    internal class SettingsPB
    {
        public bool DefaultSettings(TextBlock _LN, Border _Sex, out byte _A, out byte _B, out byte _FA, out byte _FB, bool _CheckWSize)
        {
            if (_CheckWSize)
            {
                _LN.FontSize = 50;
                _Sex.Height = 80;
                _A = 80;
                _B = 155;
                _FA = 50;
                _FB = 120;
                return false;
            }
            else
            {
                _LN.FontSize = 30;
                _Sex.Height = 50;
                _A = 50;
                _B = 70;
                _FA = 30;
                _FB = 50;
                return true;
            }
        }
        public void SetSizeNameBlock(TextBlock _FirstName, TextBlock _SurName, double _Size)
        {
            _FirstName.FontSize = _Size;
            _SurName.FontSize = _Size;
        }
        public void SetSizeAddressBlock(TextBlock _Country, TextBlock _City, TextBlock _Address, TextBlock _PhoneNumber, double _Size)
        {
            _Country.FontSize = _Size;
            _City.FontSize = _Size;
            _Address.FontSize = _Size;
            _PhoneNumber.FontSize = _Size;
        }
        public void SetSizeLOWData(DatePicker _DP, TextBlock _Date, TextBlock S_M, TextBlock S_W, double _Size)
        {
            _DP.FontSize = _Size - 10;
            _Date.FontSize = _Size - 3.5;
            S_M.FontSize = _Size;
            S_W.FontSize =_Size;
        }
        public void SetSizeBorderSex(Border B_M, Border B_W, double _Size)
        {
            B_M.Width = _Size;
            B_W.Width = _Size;
            B_W.Height = _Size;
        }
        public void CheckSexSize(Border _M, Border _W, TextBlock _FM, TextBlock _FW, byte _A, byte _B, byte _FA, byte _FB)
        { 
            VisualActionPB.BeginAnimation(_M, _B, _A);
            VisualActionPB.BeginAnimation(_W, _B, _A);
            VisualActionPB.BeginFontAnimation(_FM, _FB, _FA);
            VisualActionPB.BeginFontAnimation(_FW, _FB, _FA);
        }

    }
}
