using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // 确定待生成level的位置、边界
    Vector2 levelP = new Vector2(0.00f, 0.00f);
    float levelW = 8.0f;
    float levelH = 8.0f;

    // platform类型
    enum platformTypes
    {
        breakablePlatform,
        FixedPlatform
    }
    public GameObject breakablePlatform;
    public GameObject fixedPlatform;

    // 指定位置、长宽， 生成level
    GameObject GenerateLevel(Vector2 p, float w, float h)
    {
        GameObject level = new GameObject("Level");
        level = new GameObject("Level");
        level.transform.position = levelP;
        level.transform.localScale = new Vector2(levelW, levelH);

        return level;
    }

    // 传入：所属level、platform类型、位置、宽度，高度  在特定位置生成特点platform
    // ps: p w h是相对值（相对于level），范围-1 -- 1
    void GeneratePlatform(GameObject level, platformTypes pt, Vector2 p, float w, float h)
    {
        GameObject thisPlatform;
        // 把相对参数位置转换为世界空间下的绝对参数
        Vector2 p_world = new Vector2(levelP.x + levelW/2 * p.x, levelP.y + levelH/2 * p.y);
        // 根据platform types及对应参数创建platform
        switch (pt)
        {
            case platformTypes.breakablePlatform:
                thisPlatform = Object.Instantiate(breakablePlatform);
                thisPlatform.transform.SetParent(level.transform);
                thisPlatform.transform.localScale = new Vector2(w, h);
                thisPlatform.transform.position = p_world;
                break;
        }
    }

    // 销毁Level
    void DestructLevel(GameObject level)
    { }

    void Start()
    {
        // 生成level and platforms
        GameObject level = GenerateLevel(levelP, levelW, levelH);
        GeneratePlatform(level, platformTypes.breakablePlatform, new Vector2(0.3f, 0.3f), 0.3f, 0.03f);
    }
}

// Questiones and Matters

// Matters
//1. 如何限制GeneratePlatform()参数的取值范围(0-1)?
//2. 应该把GeneratePlatform设为Level对象的方法的
//3. Object.Instantiate的parent问题
//4. 我应该把level和platform定义为类的
