using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Homework_22._08._2018
{
    internal static class VisualActionPB
    {
        public static void BeginAnimation(Border _BS, byte _Size, byte _TOSize)
        {
            
            DoubleAnimation _DABorder = new DoubleAnimation 
            {
                From = _Size,
                To = _TOSize,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            _BS.Dispatcher.Invoke(new Action(delegate
            {
                _BS.BeginAnimation(Border.WidthProperty, _DABorder);
                _BS.BeginAnimation(Border.HeightProperty, _DABorder);
             }));
        }
       
        public static void BeginFontAnimation(TextBlock _TB, byte _Size, byte _TOSize)
        {
            DoubleAnimation _DATextBlock = new DoubleAnimation {
                From = _Size,
                To = _TOSize,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            _TB.Dispatcher.Invoke(new Action(delegate {
                _TB.BeginAnimation(TextBlock.FontSizeProperty, _DATextBlock);
            }));
        }
    }
}
