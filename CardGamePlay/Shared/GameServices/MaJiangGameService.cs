using System;
using System.Linq;
using CardGamePlay.Shared.Interfaces;

namespace CardGamePlay.Shared.GameServices
{
    public class MaJiangGameService : IGameplay
    {
        public static readonly int[] Cards = new int[144]
        {
            // 萬
            01,02,03,04,05,06,07,08,09,
            01,02,03,04,05,06,07,08,09,
            01,02,03,04,05,06,07,08,09,
            01,02,03,04,05,06,07,08,09,

            // 筒
            11,12,13,14,15,16,17,18,19,
            11,12,13,14,15,16,17,18,19,
            11,12,13,14,15,16,17,18,19,
            11,12,13,14,15,16,17,18,19,

            // 條
            21,22,23,24,25,26,27,28,29,
            21,22,23,24,25,26,27,28,29,
            21,22,23,24,25,26,27,28,29,
            21,22,23,24,25,26,27,28,29,

            // 東南西北中發白
            31,32,33,34,35,36,37,
            31,32,33,34,35,36,37,
            31,32,33,34,35,36,37,
            31,32,33,34,35,36,37,

            // 梅蘭菊竹及春夏秋冬
            41,42,43,44,45,46,47,48
        };

        public int[] Shuffle(int times = 1)
        {
            var random = new Random();
            var randomCards = new int[144];

            Array.Copy(Cards, randomCards, 144);

            for (int i = 0; i < times; i++)
            {
                randomCards = randomCards.OrderBy(x => random.Next()).ToArray();
            }

            return randomCards;
        }

        public int[][] Draw(int[] cards, int user)
        {
            var drawCards = new int[user][];

            for (int i = 0; i < user; i++)
            {
                drawCards[i] = new int[16];

                for (int j = 0; j < 16; j++)
                {
                    // [0 1 2 3], [16 17 18 19], [32 33 34 35]
                    // [4 5 6 7], [20 21 22 23]
                    // [8 9 10 11], [24 25 26 27]
                    // [12 13 14 15], [28 29 30 31]
                    var index = (j / 4);
                    drawCards[i][j] = cards[(user * i) + (4 * (user - 1) * index) + j];
                }
            }

            return drawCards;
        }
    }
}
