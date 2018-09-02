using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Homework_22._08._2018
{
   static class WorkShopPB
    {
        public static void  BAnimationFAnimation(Border _Sex, TextBlock _FSex, byte _A, byte _B, byte _FA, byte _FB)
        {
            VisualActionPB.BeginAnimation(_Sex, _A, _B);
            VisualActionPB.BeginFontAnimation(_FSex, _FA, _FB);
        }
        public static bool ALERT<T, V>(Dictionary<T, V> _Cycle)
        {
            bool? _CheckFalse = null;

            if (_Cycle.Count > 0)
            {
                foreach (KeyValuePair<T, V> _T in _Cycle)
                {
                    VisualActionPB.ColorChangeForBlock((TextBlock)(object)_T.Key, (bool)(object)_T.Value);

                    if ((bool)(object)_T.Value == false)
                        _CheckFalse = false;
                }
            }
            if (_CheckFalse == false)
                return false;
            else
                return true;
        }
    }

}
