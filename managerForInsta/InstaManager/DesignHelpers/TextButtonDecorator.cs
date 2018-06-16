using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using InstaManager.Extensions;

namespace InstaManager.DesignHelpers
{
    public class TextButtonDecorator
    {
        private TextBlock _content;
        private SolidColorBrush _changeTo;
        private Brush _defaultBrush;
        public TextButtonDecorator(Button button, SolidColorBrush changeTo)
        {
            button.MouseEnter += Button_MouseEnter;
            button.MouseLeave += Button_MouseLeave;
            _content = (button as DependencyObject).GetFirstChildOfType<TextBlock>();//(button.Content as TextBlock);
            _defaultBrush = _content?.Foreground;
            _changeTo = changeTo;
        }


        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if(_content!=null)
            _content.Foreground = _defaultBrush;
        }

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_content != null)
                _content.Foreground = _changeTo;
        }
    }
}
