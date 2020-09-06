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

        int blackNum = 0;
        int whiteNum = 0;

        List<int[]> rowList = new List<int[]>()
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

        //マスのボタンを押したときに走る関数
        private void buttonSquare_Click(object sender, RoutedEventArgs e)
        {
            Button srcButton = (Button)e.Source;
            Image square = (Image)srcButton.Content;

            string btnName = srcButton.Name;
            int btnName2 = int.Parse(btnName.Replace("button", ""));

            int y = (btnName2 / 10) % 10;//btnName2の１０の位の数 = 縦のマス数
            int x = btnName2 % 10;//btnName2の１の位の数 = 横のマス数

            //自分の石を置けるかどうかのチェック
            bool checkOK = CheckTurnUpsideDown(y, x);

            if (square.Source == IMG_GREEN && checkOK)
            {
                int playerColor = 0;
                int opponentColor = 0;
                GetPutStoneColoer(out playerColor, out opponentColor);
                rowList[y][x] = playerColor;
                ChangeTarn();
            }
            ReflectOnBoard();
            CheckOpponentColorExist();
            CheckNoneColorExist();
        }

        //最後に盤面を画面に反映する関数
        private void ReflectOnBoard()
        {
            for (int row = 0; row <= 9; row++)
            {
                int[] rowwww = rowList[row];
                for (int line = 0; line <= 9; line++)
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
            UpdateNumOfStorns();
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

        //プレイヤーの色と相手の色を取得する関数
        private void GetPutStoneColoer(out int playerColor, out int opponentColor)
        {
            if (firstPlayerTarn)
            {
                playerColor = 3; //黒
                opponentColor = 2; //白
            }
            else
            {
                playerColor = 2; //白
                opponentColor = 3; //黒
            }
        }

        //置こうとしたマスがおける場所なのかチェックする関数
        private bool CheckTurnUpsideDown(int y, int x)
        {
            bool right = RightCheck(y, x);
            bool left = LeftCheck(y, x);
            bool up = UpCheck(y, x);
            bool down = DownCheck(y, x);
            bool rightUp = RightUpCheck(y, x);
            bool leftUp = LeftUpCheck(y, x);
            bool rightDown = RightDownCheck(y, x);
            bool leftDown = LeftDownCheck(y, x);

            if (rowList[y][x] == 1)//置きたい場所が緑であるとき
            {
                if (right || left || up || down || rightUp || rightDown || leftUp || leftDown) //ひっくり返せるか判定する
                {
                    //ひっくり返す処理 TODO:分離
                    if (right)
                    {
                        RightReversi(y, x);
                    }
                    if (left)
                    {
                        LeftReversi(y, x);
                    }
                    if (up)
                    {
                        UpReversi(y, x);
                    }
                    if (down)
                    {
                        DownReversi(y, x);
                    }
                    if (rightUp)
                    {
                        RightUpReversi(y, x);
                    }
                    if (leftUp)
                    {
                        LeftUpReversi(y, x);
                    }
                    if (rightDown)
                    {
                        RightDownReversi(y, x);
                    }
                    if (leftDown)
                    {
                        LeftDownReversi(y, x);
                    }
                    return true;
                }
                else
                {
                    //表示：おけない場所です
                    return false;
                }
            }
            else
            {
                //表示：おけない場所です
                return false;
            }
        }

        #region ひっくり返せるか判定する処理

        private bool RightCheck(int y, int x)
        {
            int playerColor = 0;
            int opponentColor = 0;
            GetPutStoneColoer(out playerColor, out opponentColor);
            if (rowList[y][x + 1] == opponentColor)//一つ右が相手の石の時
            {
                for (int i = x + 2; rowList[y][i] != 0; i++)//2つ右以降のチェック　番外になったら抜ける
                {

                    if (rowList[y][i] == playerColor)//自分の色のとき
                    {
                        return true;
                    }
                    else if (rowList[y][i] == 1)//緑のとき抜ける
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        private bool LeftCheck(int y, int x)
        {
            int playerColor = 0;
            int opponentColor = 0;
            GetPutStoneColoer(out playerColor, out opponentColor);
            if (rowList[y][x - 1] == opponentColor)//一つ左が相手の石の時
            {
                for (int i = x - 2; rowList[y][i] > 0; i--)//2つ右以降のチェック　番外になったら抜ける
                {
                    if (rowList[y][i] == playerColor)//自分の色のとき
                    {
                        return true;
                    }
                    else if (rowList[y][i] == 1)//緑のとき抜ける
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        private bool UpCheck(int y, int x)
        {
            int playerColor = 0;
            int opponentColor = 0;
            GetPutStoneColoer(out playerColor, out opponentColor);
            if (rowList[y - 1][x] == opponentColor)//一つ上が相手の石の時
            {
                for (int j = y - 2; rowList[y][x] != 0; j--)//2つ上以降のチェック　番外になったら抜ける
                {
                    if (rowList[j][x] == playerColor)//自分の色のとき
                    {
                        return true;
                    }
                    else if (rowList[j][x] == 1)//緑のとき抜ける
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        private bool DownCheck(int y, int x)
        {
            int playerColor = 0;
            int opponentColor = 0;
            GetPutStoneColoer(out playerColor, out opponentColor);
            if (rowList[y + 1][x] == opponentColor)//一つ上が相手の石の時
            {
                for (int j = y + 2; rowList[y][x] != 0; j++)//2つ上以降のチェック　番外になったら抜ける
                {
                    if (rowList[j][x] == playerColor)//自分の色のとき
                    {
                        return true;
                    }
                    else if (rowList[j][x] == 1)//緑のとき抜ける
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        private bool RightUpCheck(int y, int x)
        {
            int playerColor = 0;
            int opponentColor = 0;
            GetPutStoneColoer(out playerColor, out opponentColor);
            int k = 2;
            if (rowList[y - 1][x + 1] == opponentColor)//一つ右上が相手の石の時
            {
                while (rowList[y - k][x + k] != 0)//2つ右以降のチェック　番外になったら抜ける
                {
                    if (rowList[y - k][x + k] == playerColor)//自分の色のとき
                    {
                        return true;
                    }
                    else if (rowList[y - k][x + k] == 1)//緑のとき抜ける
                    {
                        return false;
                    }
                    else
                    {
                        k++;
                    }
                }
            }
            return false;
        }

        private bool LeftUpCheck(int y, int x)
        {
            int playerColor = 0;
            int opponentColor = 0;
            GetPutStoneColoer(out playerColor, out opponentColor);
            int k = 2;
            if (rowList[y - 1][x - 1] == opponentColor)//一つ左上が相手の石の時
            {
                while (rowList[y - k][x - k] != 0)//2つ左上以降のチェック　番外になったら抜ける
                {
                    if (rowList[y - k][x - k] == playerColor)//自分の色のとき
                    {
                        return true;
                    }
                    else if (rowList[y - k][x - k] == 1)//緑のとき抜ける
                    {
                        return false;
                    }
                    else
                    {
                        k++;
                    }
                }
            }
            return false;
        }

        private bool RightDownCheck(int y, int x)
        {
            int playerColor = 0;
            int opponentColor = 0;
            GetPutStoneColoer(out playerColor, out opponentColor);
            int k = 2;
            if (rowList[y + 1][x + 1] == opponentColor)//一つ右下が相手の石の時
            {
                while (rowList[y + k][x + k] != 0)//2つ右下以降のチェック　番外になったら抜ける
                {
                    if (rowList[y + k][x + k] == playerColor)//自分の色のとき
                    {
                        return true;
                    }
                    else if (rowList[y + k][x + k] == 1)//緑のとき抜ける
                    {
                        return false;
                    }
                    else
                    {
                        k++;
                    }
                }
            }
            return false;
        }

        private bool LeftDownCheck(int y, int x)
        {
            int playerColor = 0;
            int opponentColor = 0;
            GetPutStoneColoer(out playerColor, out opponentColor);
            int k = 2;
            if (rowList[y + 1][x - 1] == opponentColor)//一つ左下が相手の石の時
            {
                while (rowList[y + k][x - k] != 0)//2つ左下以降のチェック　番外になったら抜ける
                {
                    if (rowList[y + k][x - k] == playerColor)//自分の色のとき
                    {
                        return true;
                    }
                    else if (rowList[y + k][x - k] == 1)//緑のとき抜ける
                    {
                        return false;
                    }
                    else
                    {
                        k++;
                    }
                }
            }
            return false;
        }

        #endregion

        #region ひっくり返す処理

        private void Reversi(int y, int x)
        {
            //TODO:ひっくり返す処理を分離
        }

        private void RightReversi(int y, int x)
        {
            int playerColor = 0;
            int opponentColor = 0;
            GetPutStoneColoer(out playerColor, out opponentColor);
            for (int i = x + 1; rowList[y][i] != 0; i++)
            {
                if (rowList[y][i] == opponentColor)//相手の色のときひっくり返す
                {
                    rowList[y][i] = playerColor;

                }
                else//自分の色のとき抜ける
                {
                    return;
                }
            }
        }

        private void LeftReversi(int y, int x)
        {
            int playerColor = 0;
            int opponentColor = 0;
            GetPutStoneColoer(out playerColor, out opponentColor);
            for (int i = x - 1; rowList[y][i] != 0; i--)
            {
                if (rowList[y][i] == opponentColor)//相手の色のときひっくり返す
                {
                    rowList[y][i] = playerColor;

                }
                else//自分の色のとき抜ける
                {
                    return;
                }
            }
        }

        private void UpReversi(int y, int x)
        {
            int playerColor = 0;
            int opponentColor = 0;
            GetPutStoneColoer(out playerColor, out opponentColor);
            for (int i = y - 1; rowList[i][x] != 0; i--)
            {
                if (rowList[i][x] == opponentColor)//相手の色のときひっくり返す
                {
                    rowList[i][x] = playerColor;

                }
                else//自分の色のとき抜ける
                {
                    return;
                }
            }
        }

        private void DownReversi(int y, int x)
        {
            int playerColor = 0;
            int opponentColor = 0;
            GetPutStoneColoer(out playerColor, out opponentColor);
            for (int i = y + 1; rowList[i][x] != 0; i++)
            {
                if (rowList[i][x] == opponentColor)//相手の色のときひっくり返す
                {
                    rowList[i][x] = playerColor;

                }
                else//自分の色のとき抜ける
                {
                    return;
                }
            }
        }

        private void RightUpReversi(int y, int x)
        {
            int playerColor = 0;
            int opponentColor = 0;
            GetPutStoneColoer(out playerColor, out opponentColor);
            int k = 1;
            while (rowList[y - k][x + k] != 0)
            {
                if (rowList[y - k][x + k] == opponentColor)//相手の色のとき
                {
                    rowList[y - k][x + k] = playerColor;
                }
                else if (rowList[y - k][x + k] == playerColor)//自分の色のとき抜ける
                {
                    return;
                }
                k++;
            }
        }

        private void RightDownReversi(int y, int x)
        {
            int playerColor = 0;
            int opponentColor = 0;
            GetPutStoneColoer(out playerColor, out opponentColor);
            int k = 1;
            while (rowList[y + k][x + k] != 0)
            {
                if (rowList[y + k][x + k] == opponentColor)//相手の色のとき
                {
                    rowList[y + k][x + k] = playerColor;
                }
                else if (rowList[y + k][x + k] == playerColor)//自分の色のとき抜ける
                {
                    return;
                }
                k++;
            }
        }
        private void LeftUpReversi(int y, int x)
        {
            int playerColor = 0;
            int opponentColor = 0;
            GetPutStoneColoer(out playerColor, out opponentColor);
            int k = 1;
            while (rowList[y - k][x - k] != 0)
            {
                if (rowList[y - k][x - k] == opponentColor)//相手の色のとき
                {
                    rowList[y - k][x - k] = playerColor;
                }
                else if (rowList[y - k][x - k] == playerColor)//自分の色のとき抜ける
                {
                    return;
                }
                k++;
            }
        }
        private void LeftDownReversi(int y, int x)
        {
            int playerColor = 0;
            int opponentColor = 0;
            GetPutStoneColoer(out playerColor, out opponentColor);
            int k = 1;
            while (rowList[y + k][x - k] != 0)
            {
                if (rowList[y + k][x - k] == opponentColor)//相手の色のとき
                {
                    rowList[y + k][x - k] = playerColor;
                }
                else if (rowList[y + k][x - k] == playerColor)//自分の色のとき抜ける
                {
                    return;
                }
                k++;
            }
        }
        #endregion

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
                    return null;
            }
        }

        //相手の色がないとき、ゲーム終了処理を行う
        private void CheckOpponentColorExist()
        {
            int playerColor = 0;
            int opponentColor = 0;
            GetPutStoneColoer(out playerColor, out opponentColor);
            if (0 == GetNumOfStorn(opponentColor))
            {
                GameEnd();
            }
        }

        //緑のマスがないとき、ゲーム終了処理を行う
        private void CheckNoneColorExist()
        {
            if (0 == GetNumOfStorn(1))
            {
                GameEnd();
            }
        }

        //自分が置ける場所がないとき、パスする
        private bool CheckCanPutStones()
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (rowList[i][j] == 1)//TODO: 統合
                    {
                        if (CheckTurnUpsideDown(i, j))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //指定した色のマスを取得する
        private int GetNumOfStorn(int color)
        {
            int count = 0;

            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (rowList[i][j] == color)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    
        //石の数を更新する
        private void UpdateNumOfStorns()
        {
            blackNum = GetNumOfStorn(2);
            whiteNum = GetNumOfStorn(3);
            textBlockBlack.Text = "黒："+ blackNum;
            textBlockWhite.Text = "白：" + whiteNum;
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
            if (whiteNum == blackNum)
            {
                MessageBox.Show("引き分けです");
            }
        }
    }
}
