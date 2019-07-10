using System.Collections;
using UnityEngine;

public class FocusCamera : MonoBehaviour {
    SpriteRenderer spriteRenderer;
    Transform camTransform;
    Animator animator;

    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        camTransform = Camera.main.transform;
        StartCoroutine(CameraFocus());
    }
	
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            animator.Play("run");
            transform.Translate(new Vector3(-1 * Time.deltaTime, 0, 0));
            if (spriteRenderer.flipX)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                StopAllCoroutines();
                StartCoroutine(CameraFocus());
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.Play("run");
            transform.Translate(new Vector3(1 * Time.deltaTime, 0, 0));
            if (!spriteRenderer.flipX)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                StopAllCoroutines();
                StartCoroutine(CameraFocus());
            }
        }
        else
        {
            animator.Play("idle");
        }
    }

    //Вызывать эту корутину, если камера не является ребенком главного героя.
    IEnumerator CameraFocus()
    {
        Vector3 StartPosition = camTransform.position;
        Vector3 targetPosition = new Vector3(transform.position.x, StartPosition.y, StartPosition.z);
        targetPosition.x = spriteRenderer.flipX ? transform.position.x + 1 : transform.position.x - 1;
        float timeMove = 1.0f;
        float startTime = Time.realtimeSinceStartup;
        float fraction = 0;
        while (fraction < 1f)
        {
            targetPosition.x = spriteRenderer.flipX ? transform.position.x + 1 : transform.position.x - 1;
            fraction = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / timeMove);
            camTransform.position = Vector3.Lerp(StartPosition, targetPosition, fraction);
            yield return null;
        }
        float speedCam = spriteRenderer.flipX ? 1 : -1;
        while (true)
        {
            if(Mathf.Abs(camTransform.position.x - transform.position.x) < 0.98f)
            {
                camTransform.Translate(new Vector3(speedCam * Time.deltaTime, 0, 0));
            }
            yield return null;
        }
    }

    //Вызывать эту корутину, если камера является ребенком главного героя.
    IEnumerator LocalCameraFocus()
    {
        Vector3 StartPosition = camTransform.position;
        Vector3 targetPosition = new Vector3(transform.position.x, StartPosition.y, StartPosition.z);
        targetPosition.x = spriteRenderer.flipX ? transform.position.x + 1 : transform.position.x - 1;
        float timeMove = 1.0f;
        float startTime = Time.realtimeSinceStartup;
        float fraction = 0;
        while (fraction < 1f)
        {
            targetPosition.x = spriteRenderer.flipX ? transform.position.x + 1 : transform.position.x - 1;
            fraction = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / timeMove);
            camTransform.position = Vector3.Lerp(StartPosition, targetPosition, fraction);
            yield return null;
        }
    }
}
