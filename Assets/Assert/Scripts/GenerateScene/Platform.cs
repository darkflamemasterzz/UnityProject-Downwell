using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform
{
    // Platform属性：platform游戏对象 宽度 高度 位置
    public GameObject platform;

    public string name;

    float width; // "0~1"
    float height;
    public Vector2 pos;

    // 构造函数
    public Platform(string name, float width, float height, Vector2 pos)
    {
        this.name = name;

        this.width = width;
        this.height = height;
        this.pos = pos;

        // Initiate platform对象
        initiatePlatform(name, width, height);
    }

    // Initiate platform对象
    void initiatePlatform(string name, float width, float height)
    {
        this.platform = new GameObject("platform_" + name);
        this.platform.transform.localScale = new Vector2(width, height);
        SpriteRenderer spr = this.platform.AddComponent<SpriteRenderer>();
        Texture2D texture = (Texture2D)Resources.Load("../Sprites/breakablePlatform");
        Rect spriteRect = new Rect(0, 0, this.width, this.height);
        Vector2 privot = new Vector2(0.5f, 0.5f);
        Sprite sp = Sprite.Create(texture, spriteRect, privot, 4);
        //spr.sprite = sp;
        this.platform.GetComponent<SpriteRenderer>().sprite = sp;
        this.platform.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.4f, 0.6f, 1.0f);
    }

    // 销毁该platform对象
    void destroyPlatform()
    {
        GameObject.Destroy(this.platform);
    }
}



// Questiones and Matters

// Matters
//1. 如何限制Width Height pos参数的取值范围(0-1)?
//2. 如何动态添加sprite对象（带Texture的）
