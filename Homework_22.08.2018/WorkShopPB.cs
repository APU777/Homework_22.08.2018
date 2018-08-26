using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
