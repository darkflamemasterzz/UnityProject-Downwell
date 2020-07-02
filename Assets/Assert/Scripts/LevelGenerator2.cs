using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator2 : MonoBehaviour
{
    public Map map;

    public int minDistanceX = 4; // platform间的最小横向距离
    public int minDistanceY = 4; // platform间的最小纵向距离

    public string seed;
    public bool useRandomSeed;

    [Range(0, 100)]
    public int randomPercent;

    private void Start()
    {
        // 实例化map
        Vector2 cameraPos = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Transform>().position;
        map = new Map(30, 30, cameraPos);
        // 给map填充platform
        DrawPlatformRandomly();
    }

    void DrawPlatformRandomly() {
        
    }

    Platform2 MakeAPlatformRandomly() {
        if (useRandomSeed)
        {
            seed = Time.time.ToString();
        }
        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        int mapW = this.map.getWidth(); // 该map的宽度
        int platformW; // 该platform的宽度

        // 70%机会得 mapW/4 30%... 10%...
        platformW = mapW / 2;
        if (pseudoRandom.Next(0, 100) < 70)
            platformW = mapW / 4;
        if (pseudoRandom.Next(0, 100) < 30)
            platformW = mapW / 6;

        return new Platform2(platformW, 2, this.map);
    }
}
