using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversi
{
    class ReverseCheck
    {
        //置こうとしたマスがおける場所なのかチェックする関数
        static public bool CheckTurnUpsideDown(int y, int x, List<int[]> boadList, ref bool right, ref bool left, ref bool up, ref bool down, ref bool rightUp, ref bool leftUp, ref bool rightDown, ref bool leftDown)
        {
            if (boadList[y][x] == 1)//置きたい場所が緑であるとき
            {
                right = RightCheck(y, x, boadList);
                left = LeftCheck(y, x, boadList);
                up = UpCheck(y, x, boadList);
                down = DownCheck(y, x, boadList);
                rightUp = RightUpCheck(y, x, boadList);
                leftUp = LeftUpCheck(y, x, boadList);
                rightDown = RightDownCheck(y, x, boadList);
                leftDown = LeftDownCheck(y, x, boadList);

                if (right || left || up || down || rightUp || rightDown || leftUp || leftDown) //ひっくり返せるか判定する
                {
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

        //置こうとしたマスがおける場所なのかチェックする関数
        static public bool CheckTurnUpsideDown(int y, int x, List<int[]> boadList)
        {
            if (boadList[y][x] == 1)//置きたい場所が緑であるとき
            {
                bool right = RightCheck(y, x, boadList);
                bool left = LeftCheck(y, x, boadList);
                bool up = UpCheck(y, x, boadList);
                bool down = DownCheck(y, x, boadList);
                bool rightUp = RightUpCheck(y, x, boadList);
                bool leftUp = LeftUpCheck(y, x, boadList);
                bool rightDown = RightDownCheck(y, x, boadList);
                bool leftDown = LeftDownCheck(y, x, boadList);

                if (right || left || up || down || rightUp || rightDown || leftUp || leftDown) //ひっくり返せるか判定する
                {
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

        static private bool RightCheck(int y, int x, List<int[]> boadList)
        {
            if (boadList[y][x + 1] == Info.GetOpponentColoer())//一つ右が相手の石の時
            {
                for (int i = x + 2; boadList[y][i] != 0; i++)//2つ右以降のチェック　番外になったら抜ける
                {
                    if (boadList[y][i] == Info.GetPlayerColoer())//自分の色のとき
                    {
                        return true;
                    }
                    else if (boadList[y][i] == 1)//緑のとき抜ける
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        static private bool LeftCheck(int y, int x, List<int[]> boadList)
        {
            if (boadList[y][x - 1] == Info.GetOpponentColoer())//一つ左が相手の石の時
            {
                for (int i = x - 2; boadList[y][i] != 0; i--)//2つ右以降のチェック　番外になったら抜ける
                {
                    if (boadList[y][i] == Info.GetPlayerColoer())//自分の色のとき
                    {
                        return true;
                    }
                    else if (boadList[y][i] == 1)//緑のとき抜ける
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        static private bool UpCheck(int y, int x, List<int[]> boadList)
        {
            if (boadList[y - 1][x] == Info.GetOpponentColoer())//一つ上が相手の石の時
            {
                for (int j = y - 2; boadList[j][x] != 0; j--)//2つ上以降のチェック　番外になったら抜ける
                {
                    if (boadList[j][x] == Info.GetPlayerColoer())//自分の色のとき
                    {
                        return true;
                    }
                    else if (boadList[j][x] == 1)//緑のとき抜ける
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        static private bool DownCheck(int y, int x, List<int[]> boadList)
        {
            if (boadList[y + 1][x] == Info.GetOpponentColoer())//一つ下が相手の石の時
            {
                for (int j = y + 2; boadList[j][x] != 0; j++)//2つ下以降のチェック　番外になったら抜ける
                {
                    if (boadList[j][x] == Info.GetPlayerColoer())//自分の色のとき
                    {
                        return true;
                    }
                    else if (boadList[j][x] == 1)//緑のとき抜ける
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        static private bool RightUpCheck(int y, int x, List<int[]> boadList)
        {
            int k = 2;
            if (boadList[y - 1][x + 1] == Info.GetOpponentColoer())//一つ右上が相手の石の時
            {
                while (boadList[y - k][x + k] != 0)//2つ右以降のチェック　番外になったら抜ける
                {
                    if (boadList[y - k][x + k] == Info.GetPlayerColoer())//自分の色のとき
                    {
                        return true;
                    }
                    else if (boadList[y - k][x + k] == 1)//緑のとき抜ける
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

        static private bool LeftUpCheck(int y, int x, List<int[]> boadList)
        {
            int k = 2;
            if (boadList[y - 1][x - 1] == Info.GetOpponentColoer())//一つ左上が相手の石の時
            {
                while (boadList[y - k][x - k] != 0)//2つ左上以降のチェック　番外になったら抜ける
                {
                    if (boadList[y - k][x - k] == Info.GetPlayerColoer())//自分の色のとき
                    {
                        return true;
                    }
                    else if (boadList[y - k][x - k] == 1)//緑のとき抜ける
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

        static private bool RightDownCheck(int y, int x, List<int[]> boadList)
        {
            int k = 2;
            if (boadList[y + 1][x + 1] == Info.GetOpponentColoer())//一つ右下が相手の石の時
            {
                while (boadList[y + k][x + k] != 0)//2つ右下以降のチェック　番外になったら抜ける
                {
                    if (boadList[y + k][x + k] == Info.GetPlayerColoer())//自分の色のとき
                    {
                        return true;
                    }
                    else if (boadList[y + k][x + k] == 1)//緑のとき抜ける
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

        static private bool LeftDownCheck(int y, int x, List<int[]> boadList)
        {
            int k = 2;
            if (boadList[y + 1][x - 1] == Info.GetOpponentColoer())//一つ左下が相手の石の時
            {
                while (boadList[y + k][x - k] != 0)//2つ左下以降のチェック　番外になったら抜ける
                {
                    if (boadList[y + k][x - k] == Info.GetPlayerColoer())//自分の色のとき
                    {
                        return true;
                    }
                    else if (boadList[y + k][x - k] == 1)//緑のとき抜ける
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
    }
}
