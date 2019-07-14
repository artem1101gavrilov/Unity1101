using UnityEngine;

public class StarMoveBezier : MonoBehaviour {

    Vector2 BezierLerp(Vector2 a, Vector2 b, float t)
    {
        return a + (b - a) * t;
    }

    Vector2 QuadraticBezierLerp(Vector2 a, Vector2 b, Vector2 c, float t)
    {
        var p0 = BezierLerp(a, b, t);
        var p1 = BezierLerp(b, c, t);
        return BezierLerp(p0, p1, t);
    }

    Vector2 CubicBezierLerp(Vector2 a, Vector2 b, Vector2 c, Vector2 d, float t)
    {
        var p0 = QuadraticBezierLerp(a, b, c, t);
        var p1 = QuadraticBezierLerp(b, c, d, t);
        return BezierLerp(p0, p1, t);
    }

    public Transform[] path1;
    public Transform[] path2;
    public Transform[] path3;
    public Transform[] path4;

    float timer = 0;
	
	void Update () {
        timer += Time.deltaTime;

        if (timer < 1)
        {
            transform.position = CubicBezierLerp(path1[0].position, path1[1].position, path1[2].position, path1[3].position, timer);
        }
        else if (timer < 1.5f)
        {
            transform.position = CubicBezierLerp(path2[0].position, path2[1].position, path2[2].position, path2[3].position, (timer - 1.0f) * 2);
        }
        else if (timer < 2)
        {
            transform.position = CubicBezierLerp(path3[0].position, path3[1].position, path3[2].position, path3[3].position, (timer - 1.5f) * 2);
        }
        else if (timer < 3)
        {
            transform.position = CubicBezierLerp(path4[0].position, path4[1].position, path4[2].position, path4[3].position, timer - 2.0f);
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
