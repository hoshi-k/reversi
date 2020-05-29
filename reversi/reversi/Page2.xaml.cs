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
using System.Windows.Resources;

namespace オセロ
{
    /// <summary>
    /// Page2.xaml の相互作用ロジック
    /// </summary>
    public partial class Page2 : Page
    {
        ImageSource IMG_GREEN;
        ImageSource IMG_WHITE;
        ImageSource IMG_BLACK;
        bool firstPlayerTarn = true;

        public Page2()
        {
            InitializeComponent();
            IMG_WHITE = btn43.Source;
            IMG_BLACK = btn44.Source;
            IMG_GREEN = btn00.Source;
            btn01.Source = IMG_GREEN;
            btn02.Source = IMG_GREEN;
            //button1.BackgroundColor = Color.Red;
        }

        //Image myImage3 = new Image();
        //BitmapImage bi3 = new BitmapImage();
        //bi3.BeginInit();
        //bi3.UriSource = new Uri("smiley_stackpanel.PNG", UriKind.Relative);
        //bi3.EndInit();
        //myImage3.Stretch = Stretch.Fill;
        //myImage3.Source = bi3;

        private void ChangeTarn()
        {
            if (firstPlayerTarn)
            {
                firstPlayerTarn = false;
            }
            else
            {
                firstPlayerTarn = true;
            }
        }

        private ImageSource GetPutStoneImage()
        {
            if (firstPlayerTarn)
            {
                return IMG_BLACK;
            }
            else
            {
                return IMG_WHITE;
            }
        }

        private void button00_Click(object sender, RoutedEventArgs e)
        {
            //source.BeginInit();
            //source.UriSource = new Uri("file://Images\\Black.png");
            //source.EndInit();

            //btn00.Source = IMG_BLACK;
            //PutStone(btn00.Source);
            if (btn00.Source == IMG_GREEN)
            {
                btn00.Source = GetPutStoneImage();
                ChangeTarn();
            }
        }

        private void button01_Click(object sender, RoutedEventArgs e)
        {
            //btn01.Source = IMG_WHITE;
            //PutStone(btn01.Source);
            if (btn01.Source == IMG_GREEN)
            {
                btn01.Source = GetPutStoneImage();
                ChangeTarn();
            }
        }

        private void button02_Click(object sender, RoutedEventArgs e)
        {
            //btn02.Source = IMG_BLACK;
            //PutStone(btn02.Source);
            if (btn02.Source == IMG_GREEN)
            {
                btn02.Source = GetPutStoneImage();
                ChangeTarn();
            }
            ChangeTarn();
        }

        private void button03_Click(object sender, RoutedEventArgs e)
        {
            btn03.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button04_Click(object sender, RoutedEventArgs e)
        {
            btn04.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button05_Click(object sender, RoutedEventArgs e)
        {
            btn05.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button06_Click(object sender, RoutedEventArgs e)
        {
            btn06.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button07_Click(object sender, RoutedEventArgs e)
        {
            btn07.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            btn10.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            btn11.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            btn12.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            btn13.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {
            btn14.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {
            btn15.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button16_Click(object sender, RoutedEventArgs e)
        {
            btn16.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button17_Click(object sender, RoutedEventArgs e)
        {
            btn17.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button20_Click(object sender, RoutedEventArgs e)
        {
            btn20.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button21_Click(object sender, RoutedEventArgs e)
        {
            btn21.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button22_Click(object sender, RoutedEventArgs e)
        {
            btn22.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button23_Click(object sender, RoutedEventArgs e)
        {
            btn23.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button24_Click(object sender, RoutedEventArgs e)
        {
            btn24.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button25_Click(object sender, RoutedEventArgs e)
        {
            btn25.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button26_Click(object sender, RoutedEventArgs e)
        {
            btn26.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button27_Click(object sender, RoutedEventArgs e)
        {
            btn27.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button30_Click(object sender, RoutedEventArgs e)
        {
            btn30.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button31_Click(object sender, RoutedEventArgs e)
        {
            btn31.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button32_Click(object sender, RoutedEventArgs e)
        {
            btn32.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button33_Click(object sender, RoutedEventArgs e)
        {
            btn33.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button34_Click(object sender, RoutedEventArgs e)
        {
            btn34.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button35_Click(object sender, RoutedEventArgs e)
        {
            btn35.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button36_Click(object sender, RoutedEventArgs e)
        {
            btn36.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button37_Click(object sender, RoutedEventArgs e)
        {
            btn37.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button40_Click(object sender, RoutedEventArgs e)
        {
            btn40.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button41_Click(object sender, RoutedEventArgs e)
        {
            btn41.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button42_Click(object sender, RoutedEventArgs e)
        {
            btn42.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button43_Click(object sender, RoutedEventArgs e)
        {
            btn43.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button44_Click(object sender, RoutedEventArgs e)
        {
            btn44.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button45_Click(object sender, RoutedEventArgs e)
        {
            btn45.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button46_Click(object sender, RoutedEventArgs e)
        {
            btn46.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button47_Click(object sender, RoutedEventArgs e)
        {
            btn47.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button50_Click(object sender, RoutedEventArgs e)
        {
            btn50.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button51_Click(object sender, RoutedEventArgs e)
        {
            btn51.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button52_Click(object sender, RoutedEventArgs e)
        {
            btn52.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button53_Click(object sender, RoutedEventArgs e)
        {
            btn53.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button54_Click(object sender, RoutedEventArgs e)
        {
            btn54.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button55_Click(object sender, RoutedEventArgs e)
        {
            btn55.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button56_Click(object sender, RoutedEventArgs e)
        {
            btn56.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button57_Click(object sender, RoutedEventArgs e)
        {
            btn57.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button60_Click(object sender, RoutedEventArgs e)
        {
            btn60.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button61_Click(object sender, RoutedEventArgs e)
        {
            btn61.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button62_Click(object sender, RoutedEventArgs e)
        {
            btn62.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button63_Click(object sender, RoutedEventArgs e)
        {
            btn63.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button64_Click(object sender, RoutedEventArgs e)
        {
            btn64.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button65_Click(object sender, RoutedEventArgs e)
        {
            btn65.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button66_Click(object sender, RoutedEventArgs e)
        {
            btn66.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button67_Click(object sender, RoutedEventArgs e)
        {
            btn67.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button70_Click(object sender, RoutedEventArgs e)
        {
            btn70.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button71_Click(object sender, RoutedEventArgs e)
        {
            btn71.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button72_Click(object sender, RoutedEventArgs e)
        {
            btn72.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button73_Click(object sender, RoutedEventArgs e)
        {
            btn73.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button74_Click(object sender, RoutedEventArgs e)
        {
            btn74.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button75_Click(object sender, RoutedEventArgs e)
        {
            btn75.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button76_Click(object sender, RoutedEventArgs e)
        {
            btn76.Source = GetPutStoneImage();
            ChangeTarn();
        }

        private void button77_Click(object sender, RoutedEventArgs e)
        {
            btn77.Source = GetPutStoneImage();
            ChangeTarn();
        }
    }
}
