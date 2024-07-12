using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float moveDistance = 5f;

    private bool shouldMove = false;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (shouldMove)
        {
            transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
            if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
            {
                shouldMove = false;
            }
        }
    }

    public void StartMoving()
    {
        shouldMove = true;
    }
}
