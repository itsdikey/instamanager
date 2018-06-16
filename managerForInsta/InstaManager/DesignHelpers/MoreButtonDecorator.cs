using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace InstaManager.DesignHelpers
{
    public class MoreButtonDecorator
    {
        private Path _contentPath;
        private SolidColorBrush _changeTo;
        private Brush _defaultBrush;
        public MoreButtonDecorator(Button button, SolidColorBrush changeTo)
        {
            button.MouseEnter += Button_MouseEnter;
            button.MouseLeave += Button_MouseLeave;
            _contentPath = ((button.Content as Viewbox).Child as Canvas).Children[0] as Path;
            _defaultBrush = _contentPath.Fill;
            _changeTo = changeTo;
        }
       

        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _contentPath.Fill = _defaultBrush;
        }

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _contentPath.Fill = _changeTo;
        }
    }
}
