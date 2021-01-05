using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversi
{
    class Reverse
    {
        //盤の情報を変更する
        static public void ReverseStorns(int y, int x, List<int[]> boadList, bool right, bool left, bool up, bool down, bool rightUp, bool leftUp, bool rightDown, bool leftDown)
        {
            boadList[y][x] = Info.GetPlayerColoer();//押した場所を自分の色にする

            //ひっくり返すことが可能な方向の石をひっくり返す
            if (right)
            {
                RightReversi(y, x, boadList);
            }
            if (left)
            {
                LeftReversi(y, x, boadList);
            }
            if (up)
            {
                UpReversi(y, x, boadList);
            }
            if (down)
            {
                DownReversi(y, x, boadList);
            }
            if (rightUp)
            {
                RightUpReversi(y, x, boadList);
            }
            if (leftUp)
            {
                LeftUpReversi(y, x, boadList);
            }
            if (rightDown)
            {
                RightDownReversi(y, x, boadList);
            }
            if (leftDown)
            {
                LeftDownReversi(y, x, boadList);
            }
        }

        #region 各方向のひっくり返す処理

        static private void RightReversi(int y, int x, List<int[]> boadList)
        {
            for (int i = x + 1; boadList[y][i] != 0; i++)
            {
                if (boadList[y][i] == Info.GetOpponentColoer())//相手の色のときひっくり返す
                {
                    boadList[y][i] = Info.GetPlayerColoer();

                }
                else//自分の色のとき抜ける
                {
                    return;
                }
            }
        }

        static private void LeftReversi(int y, int x, List<int[]> boadList)
        {
            for (int i = x - 1; boadList[y][i] != 0; i--)
            {
                if (boadList[y][i] == Info.GetOpponentColoer())//相手の色のときひっくり返す
                {
                    boadList[y][i] = Info.GetPlayerColoer();

                }
                else//自分の色のとき抜ける
                {
                    return;
                }
            }
        }

        static private void UpReversi(int y, int x, List<int[]> boadList)
        {
            for (int i = y - 1; boadList[i][x] != 0; i--)
            {
                if (boadList[i][x] == Info.GetOpponentColoer())//相手の色のときひっくり返す
                {
                    boadList[i][x] = Info.GetPlayerColoer();

                }
                else//自分の色のとき抜ける
                {
                    return;
                }
            }
        }

        static private void DownReversi(int y, int x, List<int[]> boadList)
        {
            for (int i = y + 1; boadList[i][x] != 0; i++)
            {
                if (boadList[i][x] == Info.GetOpponentColoer())//相手の色のときひっくり返す
                {
                    boadList[i][x] = Info.GetPlayerColoer();

                }
                else//自分の色のとき抜ける
                {
                    return;
                }
            }
        }

        static private void RightUpReversi(int y, int x, List<int[]> boadList)
        {
            int k = 1;
            while (boadList[y - k][x + k] != 0)
            {
                if (boadList[y - k][x + k] == Info.GetOpponentColoer())//相手の色のとき
                {
                    boadList[y - k][x + k] = Info.GetPlayerColoer();
                }
                else if (boadList[y - k][x + k] == Info.GetPlayerColoer())//自分の色のとき抜ける
                {
                    return;
                }
                k++;
            }
        }

        static private void RightDownReversi(int y, int x, List<int[]> boadList)
        {
            int k = 1;
            while (boadList[y + k][x + k] != 0)
            {
                if (boadList[y + k][x + k] == Info.GetOpponentColoer())//相手の色のとき
                {
                    boadList[y + k][x + k] = Info.GetPlayerColoer();
                }
                else if (boadList[y + k][x + k] == Info.GetPlayerColoer())//自分の色のとき抜ける
                {
                    return;
                }
                k++;
            }
        }

        static private void LeftUpReversi(int y, int x, List<int[]> boadList)
        {
            int k = 1;
            while (boadList[y - k][x - k] != 0)
            {
                if (boadList[y - k][x - k] == Info.GetOpponentColoer())//相手の色のとき
                {
                    boadList[y - k][x - k] = Info.GetPlayerColoer();
                }
                else if (boadList[y - k][x - k] == Info.GetPlayerColoer())//自分の色のとき抜ける
                {
                    return;
                }
                k++;
            }
        }

        static private void LeftDownReversi(int y, int x, List<int[]> boadList)
        {
            int k = 1;
            while (boadList[y + k][x - k] != 0)
            {
                if (boadList[y + k][x - k] == Info.GetOpponentColoer())//相手の色のとき
                {
                    boadList[y + k][x - k] = Info.GetPlayerColoer();
                }
                else if (boadList[y + k][x - k] == Info.GetPlayerColoer())//自分の色のとき抜ける
                {
                    return;
                }
                k++;
            }
        }
        #endregion
    }
}
