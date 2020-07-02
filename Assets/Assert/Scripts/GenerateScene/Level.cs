using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    // Level属性：level游戏对象、平台s 位置 宽度 高度
    GameObject level;
    List<Platform> platforms = new List<Platform>(); // platform列表：保护该Level中的所有platform对象

    string name;

    Vector2 levelP;
    float levelW;
    float levelH;

    // Level构造函数
    public Level(string name, Vector2 lp, float lw, float lh)
    {
        this.name = name;
        this.levelP = lp;
        this.levelW = lw;
        this.levelH = lh;

        // initate level object
        initiateLevel(lp, lw, lh);
    }

    // Initiate level object
    void initiateLevel(Vector2 lp, float lw, float lh)
    {
        this.level = new GameObject("level_" + name);

        BoxCollider2D levelCollider = this.level.AddComponent<BoxCollider2D>();
        levelCollider.size = new Vector2(lw, lh);
    }

    // 向Level对象传入platforms
    public void addPlatform(Platform platform)
    {
        platforms.Add(platform);
    }

    // 布置platform绘制level
    public void DecorateLevel()
    {
        // Instantiate platforms and put them to the right place
        platforms.ForEach(p => {
            p.platform.transform.SetParent(level.transform);
            p.platform.transform.position = new Vector2(p.pos.x + this.levelW/2 * p.pos.x, p.pos.y + this.levelH/2 * p.pos.y);
        });
    }
}
