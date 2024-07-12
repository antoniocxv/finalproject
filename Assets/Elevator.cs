using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Vector2 startPosition;
    public Vector2 endPosition;
    public float speed = 1.0f;

    private float t = 0.0f;
    private bool movingUp = true;

    void Update()
    {
        // Mover la plataforma hacia arriba y hacia abajo
        if (movingUp)
        {
            if (t < 1.0f)
            {
                t += Time.deltaTime * speed;
            }
            else
            {
                movingUp = false;
                t = 1.0f;
            }
        }
        else
        {
            if (t > 0.0f)
            {
                t -= Time.deltaTime * speed;
            }
            else
            {
                movingUp = true;
                t = 0.0f;
            }
        }
        transform.position = Vector2.Lerp(startPosition, endPosition, t);
    }
}
