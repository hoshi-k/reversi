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

namespace reversi
{
    /// <summary>
    /// Page2.xaml の相互作用ロジック
    /// </summary>
    public partial class Page2 : Page
    {
        ImageSource IMG_GREEN;
        ImageSource IMG_WHITE;
        ImageSource IMG_BLACK;
        static public bool firstPlayerTarn = true;

        int blackNum = 0;
        int whiteNum = 0;

        List<int[]> boadList = new List<int[]>()
        {
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
        new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
        new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
        new int[] { 0, 1, 1, 1, 2, 3, 1, 1, 1, 0 },
        new int[] { 0, 1, 1, 1, 3, 2, 1, 1, 1, 0 },
        new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
        new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
        new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        public Page2()
        {
            InitializeComponent();
            IMG_WHITE = btn44.Source;
            IMG_BLACK = btn45.Source;
            IMG_GREEN = btn11.Source;
            ReflectOnBoard();
        }

        private Image GetSorce(string strCoodinate)
        {
            switch (strCoodinate)
            {
                //Dictionary にしようとしたがbtn〇〇が動的なため使えないと言われた
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
                    return null;
            }
        }

        //マスのボタンを押したときの処理
        private void buttonSquare_Click(object sender, RoutedEventArgs e)
        {
            Button srcButton = (Button)e.Source;
            Image square = (Image)srcButton.Content;

            string btnName = srcButton.Name;
            int boardCoordinates = int.Parse(btnName.Replace("button", ""));

            int y = (boardCoordinates / 10) % 10;//boardCoordinatesの１０の位の数 = 縦のマス数
            int x = boardCoordinates % 10;//boardCoordinatesの１の位の数 = 横のマス数

            bool right = false;
            bool left = false;
            bool up = false;
            bool down = false;
            bool rightUp = false;
            bool leftUp = false;
            bool rightDown = false;
            bool leftDown = false;

            //自分の石を置けるかどうかのチェック
            if (ReverseCheck.CheckTurnUpsideDown(y, x, boadList, ref right, ref left, ref up, ref down, ref rightUp, ref leftUp, ref rightDown, ref leftDown))
            {
                //盤の情報を変更する
                Reverse.ReverseStorns(y, x, boadList, right, left, up, down, rightUp, leftUp, rightDown, leftDown);
                //盤面を画面に反映する
                ReflectOnBoard();

                //相手の色がないとき、ゲーム終了処理を行う
                CheckOpponentColorExist();
                //緑のマスがないとき、ゲーム終了処理を行う
                CheckNoneColorExist();
                //ターンプレイヤーを交代する(相手のターンになる)
                ChangeTarn();
                //相手が置ける場所がないとき、パスする(次を自分のターンにする)
                if (!CheckCanPutStones())
                {
                    MessageBox.Show("置ける場所がありません。パスします。");
                    ChangeTarn();
                    //自分も置ける場所がないとき、ゲームを終了する
                    if (!CheckCanPutStones())
                    {
                        MessageBox.Show("両者置ける場所がありません。ゲーム終了です。");
                        GameEnd();
                    }
                }
            }
        }

        //最後に盤面を画面に反映する
        private void ReflectOnBoard()
        {
            for (int row = 0; row <= 9; row++)
            {
                int[] rowList = boadList[row];
                for (int line = 0; line <= 9; line++)
                {
                    string rowstr = row.ToString();
                    string linestr = line.ToString();
                    string strCoodinate = rowstr + linestr;
                    Image sorce = GetSorce(strCoodinate);
                    if (rowList[line] == 1)
                    {
                        sorce.Source = IMG_GREEN;
                    }
                    if (rowList[line] == 2)
                    {
                        sorce.Source = IMG_WHITE;
                    }
                    if (rowList[line] == 3)
                    {
                        sorce.Source = IMG_BLACK;
                    }
                }
            }
            UpdateNumOfStorns();
        }
        
        //石の数を更新する
        private void UpdateNumOfStorns()
        {
            whiteNum = Info.GetNumOfStorn(boadList, 2);
            blackNum = Info.GetNumOfStorn(boadList, 3);
            textBlockBlack.Text = "黒：" + blackNum;
            textBlockWhite.Text = "白：" + whiteNum;
        }

        //プレイヤーを交代する
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

        //自分が置ける場所がないかどうかを確認する
        private bool CheckCanPutStones()
        {
            for (int y = 1; y <= 8; y++)
            {
                for (int x = 1; x <= 8; x++)
                {
                    if (boadList[y][x] == 1)//TODO: 統合
                    {
                        if (ReverseCheck.CheckTurnUpsideDown(y, x, boadList))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //相手の色がないとき、ゲーム終了処理を行う
        private void CheckOpponentColorExist()
        {
            if (0 == Info.GetNumOfStorn(boadList, Info.GetOpponentColoer()))
            {
                GameEnd();
            }
        }

        //緑のマスがないとき、ゲーム終了処理を行う
        private void CheckNoneColorExist()
        {
            if (0 == Info.GetNumOfStorn(boadList, 1))
            {
                GameEnd();
            }
        }

        //ゲーム終了処理　石の数を比べて勝敗を判定する
        private void GameEnd()
        {
            if (blackNum > whiteNum)
            {
                MessageBox.Show("黒プレイヤーの勝利です");
            }
            else if (whiteNum > blackNum)
            {
                MessageBox.Show("白プレイヤーの勝利です");
            }
            else if (whiteNum == blackNum)
            {
                MessageBox.Show("引き分けです");
            }
        }
    }
}