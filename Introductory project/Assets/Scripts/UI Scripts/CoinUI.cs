using TMPro;
using UnityEngine;

public class CoinUI: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textLabel;

    private int count = 0;

    private void Awake()
    {
        CollisionDetector.CollideWithCoin.AddListener(IncreaseValue);
    }

    private void IncreaseValue()
    {
        count++;
        textLabel.text = count.ToString();
    }
}
