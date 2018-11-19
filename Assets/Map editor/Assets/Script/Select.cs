using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Select {

    public static Vector2 pos;


    public static Vector2 get_pos()
    {
        Vector2 pos = new Vector2(Select.pos.x, Select.pos.y);

        Select.pos = new Vector2(-1.25f, -1.25f);


        return pos;
    }
}
