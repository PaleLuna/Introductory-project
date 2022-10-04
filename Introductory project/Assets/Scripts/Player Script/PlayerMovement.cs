using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private DirectionLine directionLine;

    private Queue<Vector2> positionsQueue;
    private bool isMoving = false;

    private void Start()
    {
        positionsQueue = new Queue<Vector2>();
    }

    public void PushNewPosition(Vector2 newPosition)
    {
        positionsQueue.Enqueue(newPosition);

        if(!isMoving)
            StartCoroutine(MoveTo());
    }

    public void StopMoving()
    {
        StopAllCoroutines();
    }

    private IEnumerator MoveTo()
    {
        isMoving = true;
        while(positionsQueue.Count > 0)
        {
            Vector3 endPos = positionsQueue.Dequeue();
            Vector2 direction = endPos - transform.position;
            float distance = Vector2.SqrMagnitude(direction); 

            directionLine.SwitchLine(true);

            while(distance != 0)
            {
                distance = Vector3.SqrMagnitude(endPos - transform.position);
                transform.position = Vector3.MoveTowards(transform.position, endPos, velocity * Time.deltaTime);
                directionLine.SetRotation(direction.normalized, distance);

                yield return null;
            }

        }

        isMoving = false;
        directionLine.SwitchLine(false);
    }
}

