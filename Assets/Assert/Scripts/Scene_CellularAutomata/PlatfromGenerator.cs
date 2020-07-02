using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromGenerator : MonoBehaviour
{
    // map..
    public int width = 20;
    public int height = 20;

    // platform...
    public int platformMaxWidth = 10;
    public int platformMinWidth = 5;
    public int platformHeight = 2;

    public int minDistanceX = 4; // platform间的最小横向距离
    public int minDistanceY = 4; // platform间的最小纵向距离

    // random seed...
    public string seed;
    public bool useRandomSeed;

    [Range(0, 100)]
    public int randomFillPercentX;
    public int randomFillPercentY;

    int[,] map;

    void RandomDrawPlatform() {
        //if (useRandomSeed)
        //{
        //    seed = Time.time.ToString();
        //}

        //System.Random pseudoRandom = new System.Random(seed.GetHashCode()); //?

        //int currH = 0; // 记录上面和左边platform的位置信息
        //int currW = 0;
        //// 遍历生成map，标记待生成的platform
        //for (int y = 0; y < height; y++) {
        //    // 判断该行于上一行platform的距离,并通过pseudoRandom与randomFillPercent绝对是否要在该行生成platform
        //    if ((y == 0 || y - currH > minDistanceY) && pseudoRandom.Next(0, 100) < randomFillPercentX) {
        //        currH = y;
        //        for (int x = 0; x < height; x++)
        //        {
        //            // 判断该格与左边platform的距离，并通过randomSeed绝对是否要在该格生成platform
        //            if ((x == 0 ||x - currW > minDistanceX) && pseudoRandom.Next(0, 100) < randomFillPercentY) {
        //                currW = x;
        //            }

        //        }
        //    }
        //}
    }
}
