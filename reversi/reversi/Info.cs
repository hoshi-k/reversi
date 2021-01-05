using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversi
{
    class Info
    {
        //プレイヤーの色を取得する関数
        static public int GetPlayerColoer()
        {
            if (Page2.firstPlayerTarn)
            {
                return 3; //黒
            }
            else
            {
                return  2; //白
            }
        }

        //相手の色を取得する関数
        static public int GetOpponentColoer()
        {
            if (Page2.firstPlayerTarn)
            {
                return 2; //白
            }
            else
            {
                return 3; //黒
            }
        }

        //指定した色のマスを取得する
        static public int GetNumOfStorn(List<int[]> boadList, int color)
        {
            int count = 0;

            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (boadList[i][j] == color)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
