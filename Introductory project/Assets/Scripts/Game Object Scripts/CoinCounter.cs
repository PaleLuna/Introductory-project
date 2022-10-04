using UnityEngine;
using UnityEngine.Events;

public class CoinCounter : MonoBehaviour
{
    public static UnityEvent CoinsRanOut = new();

    private int coinsLeft;

    private void Awake()
    {
        CollisionDetector.PickedUpCoin.AddListener(CoisIsMatched);

        coinsLeft = GameObject.FindGameObjectWithTag("CoinSpawner").GetComponent<ObjectSpawner>().NumberSpawns;
    }

    private void CoisIsMatched(GameObject coin)
    {
        Destroy(coin);

        coinsLeft--;
        if (coinsLeft <= 0)
            CoinsRanOut.Invoke();
    }
}
