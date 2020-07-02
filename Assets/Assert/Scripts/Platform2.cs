using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform2 : MonoBehaviour
{
    public Map map; // platform所属的map
    int platformWidth;
    int platformHeight = 2;
    Vector2 position; // 在所属map中的位置

    public int getWidth() {
        return this.platformWidth;
    }
    public int getHeight() {
        return this.platformHeight;
    }
    public Vector2 getPos(){
        return this.position;
    }
    public void setPos(Vector2 pos) {
        this.position = pos;
    }

    public Platform2(int pw, int ph, Vector2 pos, Map m) {
        this.platformHeight = ph;
        this.map = m;
        this.position = pos;
        // platform的宽度只能是map宽度的一半
        if (pw > m.getMap().Length / 2)
            this.platformWidth = m.getMap().Length / 2;
        else
            this.platformWidth = pw;
    }
    public Platform2(int pw, int ph, Map m) {
        this.platformHeight = ph;
        this.map = m;
        // platform的宽度只能是map宽度的一半
        if (pw > m.getMap().Length / 2)
            this.platformWidth = m.getMap().Length / 2;
        else
            this.platformWidth = pw;
    }
}
