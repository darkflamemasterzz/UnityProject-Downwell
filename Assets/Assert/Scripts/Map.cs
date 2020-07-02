using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    int width;
    int height;
    Vector2 pos;

    int[,] map;

    public Platform2 platform;

    public Map(int width, int height, Vector2 p) {
        this.width = width;
        this.height = height;
        this.pos = p;

        for (int x = 0; x < width; x++) { //! 这可太耗费计算资源了
            for (int y = 0; y < height; y++) {
                map[x, y] = 0;
            }
        }
    }

    public int[,] getMap() {
        return this.map;
    }
    public int getWidth() {
        return this.width;
    }
    public int getHeight() {
        return this.height;
    }
    public Vector2 getPos() {
        return this.pos;
    }
    // 写入platform
    public void DrawPlatform(Platform2 p) {
        int pWidth = p.getWidth();
        int pHeight = p.getHeight();
        Vector2 pPos = p.getPos();

        // 计算出从第几行开始画platform
        int startX = (int)pPos.x - pWidth / 2;
        // 计算出从第几列开始画platform
        int startY = (int)pPos.y - pHeight / 2;
        // 遍历map，draw platform
        for (int x = startX; x < startX + pWidth - 1; x++) {
            if (x > this.width)
                break;
            for (int y = startY; y < startY + pHeight - 1; y++) {
                if (y > this.width)
                    break;
                map[x, y] = 1;
            }
        }
    }
}
