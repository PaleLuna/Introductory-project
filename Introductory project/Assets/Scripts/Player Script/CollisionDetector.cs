using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    public static UnityEvent CollidedWithSpike = new();
    public static UnityEvent CollideWithCoin = new();
    public static UnityEvent<GameObject> PickedUpCoin = new UnityEvent<GameObject>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gObj = collision.gameObject;

        if (gObj.GetComponent<Spike>())
        {
            CollidedWithSpike.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gObj = collision.gameObject;

        if (gObj.GetComponent<Coin>())
        {
            CollideWithCoin.Invoke();
            PickedUpCoin.Invoke(gObj);
        }
    }
}
