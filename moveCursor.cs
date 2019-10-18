using UnityEngine;

public class moveCursor : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("Move", 0.1f, 0.1f);
    }

    void Move () {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 tpos = transform.position;

        Vector2 pos2 = pos - tpos;
        if(pos2.magnitude > 1)
            transform.position = tpos + pos2.normalized;
        else
            transform.position = tpos + pos2;
    }
}
