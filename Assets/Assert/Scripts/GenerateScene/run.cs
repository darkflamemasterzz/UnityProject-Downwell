using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Level level = new Level("1", new Vector2(0, 0), 8f, 8f);
        level.addPlatform(new Platform("1", 0.4f, 0.08f, new Vector2(0.3f, 0.3f)));
        level.DecorateLevel();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
