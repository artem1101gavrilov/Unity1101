using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour {

    float timer = 0;
    Vector2 startCircle = new Vector2();

	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer < 1)
        {
            var x = Mathf.Lerp(4.0f, -0.2f, timer);
            var y = 0.134f * x * x - 0.475f * x - 0.485f;
            Vector2 pos = new Vector2(x, y);
            transform.position = pos;
            startCircle = pos;
            startCircle.y += 0.5f;
        }
        else if(timer < 2)
        {
            var angle = Mathf.Lerp(270, -90, timer - 1) * Mathf.PI / 180.0f ;
            var x = 0.5f * Mathf.Cos(angle);
            var y = 0.5f * Mathf.Sin(angle);
            var pos = startCircle;
            pos.x += x;
            pos.y += y;
            transform.position = pos;
        }
        else if(timer < 3)
        {
            var x = Mathf.Lerp(-0.2f, -2.6f, (timer - 2));
            var y = 0.136f * x * x + 0.022f * x - 0.39f;
            Vector2 pos = new Vector2(x, y);
            transform.position = pos;
        }
        else
        {
            timer = 0;
            var pos = Camera.main.transform.position;
            pos.x += 4;
            pos.y = 0;
            pos.z = -2;
            transform.position = pos;
        }
    }
}
