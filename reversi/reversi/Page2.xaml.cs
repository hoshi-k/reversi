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
        //int[] row0 = { 0, 0, 0, 0, 0, 0, 0, 0 };
        //int[] row1 = { 0, 0, 0, 0, 0, 0, 0, 0 };
        //int[] row2 = { 0, 0, 0, 0, 0, 0, 0, 0 };
        //int[] row3 = { 0, 0, 0, 1, 2, 0, 0, 0 };
        //int[] row4 = { 0, 0, 0, 2, 1, 0, 0, 0 };
        //int[] row5 = { 0, 0, 0, 0, 0, 0, 0, 0 };
        //int[] row6 = { 0, 0, 0, 0, 0, 0, 0, 0 };
        //int[] row7 = { 0, 0, 0, 0, 0, 0, 0, 0 };

        int[] row0 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] row1 = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
        int[] row2 = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
        int[] row3 = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
        int[] row4 = { 0, 1, 1, 1, 3, 2, 1, 1, 1, 0 };
        int[] row5 = { 0, 1, 1, 1, 2, 3, 1, 1, 1, 0 };
        int[] row6 = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
        int[] row7 = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
        int[] row8 = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
        int[] row9 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public Page2()
        {
            InitializeComponent();
            IMG_WHITE = btn44.Source;
            IMG_BLACK = btn45.Source;
            IMG_GREEN = btn11.Source;
            ReflectOnBoard();
        }

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

        //置こうとしたマスがおける場所なのかチェックする関数
        private void CheckTurnUpsideDown(int btnName2)
        {
            int tens = (btnName2 / 10) % 10; // (n % 100) / 10
            int ones = btnName2 % 10;
            int[] row = GetRow(tens);
            if (row[ones] == 0)
            {
                //TODO:配列の範囲外になってしまいチェックできない　配列の端一列ずつ追加する？
            }
        }

        private int[] GetRow(int row)
        {
            switch (row)
            {
                case 0:
                    return row0;
                case 1:
                    return row1;
                case 2:
                    return row2;
                case 3:
                    return row3;
                case 4:
                    return row4;
                case 5:
                    return row5;
                case 6:
                    return row6;
                case 7:
                    return row7;
                case 8:
                    return row8;
                case 9:
                    return row9;
                default:
                    return row0;
            }
        }

        //最後に盤面を画面に反映する関数
        private void ReflectOnBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                int[] rowwww = GetRow(row);
                for (int line = 0; line < 8; line++)
                {
                    string rowstr = row.ToString();
                    string linestr = line.ToString();
                    string aaa = rowstr + linestr;
                    Image sorce = GetSorce(aaa);
                    if (rowwww[line] == 1)
                    {
                        sorce.Source = IMG_GREEN;
                    }
                    if (rowwww[line] == 2)
                    {
                        sorce.Source = IMG_WHITE;
                    }
                    if (rowwww[line] == 3)
                    {
                        sorce.Source = IMG_BLACK;
                    }
                }
            }
        }

        //マスのボタンを押したときに走る関数
        private void buttonSquare_Click(object sender, RoutedEventArgs e)
        {
            Button srcButton = (Button)e.Source;
            Image square = (Image)srcButton.Content;

            string btnName = srcButton.Name;
            int btnName2 = int.Parse(btnName.Replace("button", ""));
            CheckTurnUpsideDown(btnName2);

            if (square.Source == IMG_GREEN)
            {
                square.Source = GetPutStoneImage();
                ChangeTarn();
            }
            ReflectOnBoard();
        }

        private Image GetSorce(string aaa)
        {
            switch (aaa)
            {
                case "11":
                    return btn11;
                case "12":
                    return btn12;
                case "13":
                    return btn13;
                case "14":
                    return btn14;
                case "15":
                    return btn15;
                case "16":
                    return btn16;
                case "17":
                    return btn17;
                case "18":
                    return btn18;
                case "21":
                    return btn21;
                case "22":
                    return btn22;
                case "23":
                    return btn23;
                case "24":
                    return btn24;
                case "25":
                    return btn25;
                case "26":
                    return btn26;
                case "27":
                    return btn27;
                case "28":
                    return btn28;
                case "31":
                    return btn31;
                case "32":
                    return btn32;
                case "33":
                    return btn33;
                case "34":
                    return btn34;
                case "35":
                    return btn35;
                case "36":
                    return btn36;
                case "37":
                    return btn37;
                case "38":
                    return btn38;
                case "41":
                    return btn41;
                case "42":
                    return btn42;
                case "43":
                    return btn43;
                case "44":
                    return btn44;
                case "45":
                    return btn45;
                case "46":
                    return btn46;
                case "47":
                    return btn47;
                case "48":
                    return btn48;
                case "51":
                    return btn51;
                case "52":
                    return btn52;
                case "53":
                    return btn53;
                case "54":
                    return btn54;
                case "55":
                    return btn55;
                case "56":
                    return btn56;
                case "57":
                    return btn57;
                case "58":
                    return btn58;
                case "61":
                    return btn61;
                case "62":
                    return btn62;
                case "63":
                    return btn63;
                case "64":
                    return btn64;
                case "65":
                    return btn65;
                case "66":
                    return btn66;
                case "67":
                    return btn67;
                case "68":
                    return btn68;
                case "71":
                    return btn71;
                case "72":
                    return btn72;
                case "73":
                    return btn73;
                case "74":
                    return btn74;
                case "75":
                    return btn75;
                case "76":
                    return btn76;
                case "77":
                    return btn77;
                case "78":
                    return btn78;
                case "81":
                    return btn81;
                case "82":
                    return btn82;
                case "83":
                    return btn83;
                case "84":
                    return btn84;
                case "85":
                    return btn85;
                case "86":
                    return btn86;
                case "87":
                    return btn87;
                case "88":
                    return btn88;
                default:
                    return btn11;
            }
        }
    }
}
