using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{

    public float speed = 10.0f;
    public float moveThreshold = 50.0f;
    public float smoothTime = 0.1f;

    private Vector2 touchStart;
    private bool isDragging = false;
    private float horizontalMove = 0.0f;
    private float velocity = 0.0f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isDragging = true;
                    touchStart = touch.position;
                    break;

                case TouchPhase.Moved:
                    float deltaX = touch.position.x - touchStart.x;
                    if (isDragging)
                    {
                        float moveDir = Mathf.Sign(deltaX);
                        if (Mathf.Abs(horizontalMove) < moveThreshold || Mathf.Sign(horizontalMove) == moveDir)
                        {
                            horizontalMove += deltaX;
                            velocity = Mathf.SmoothDamp(velocity, moveDir * speed, ref velocity, smoothTime);
                            transform.position += Vector3.right * velocity * Time.deltaTime;
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    horizontalMove = 0.0f;
                    break;
            }
        }
    }
}
