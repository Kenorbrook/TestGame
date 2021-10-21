using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMap
{
    public IEnumerator MoveBackGround(GameObject gm, float speed, SpawnBlock sb)
    {
        while (true) {
            gm.transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
            if (gm.transform.position.x <= -3)
            {
                gm.transform.position = new Vector2(0, gm.transform.position.y);
                sb.Spawn();
            }
            yield return new WaitForEndOfFrame();
        } 
    }
}
