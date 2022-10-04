using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FinishingGame : MonoBehaviour
{
    [SerializeField] private GameObject menuItem;
    [SerializeField] private GameObject gObjWithText;

    private TMP_Text textLabel;


    private void Awake()
    {
        CollisionDetector.CollidedWithSpike.AddListener(LoseGame);
        CoinCounter.CoinsRanOut.AddListener(WinGame);
    }

    private void Start()
    {
        textLabel = gObjWithText.GetComponent<TextMeshProUGUI>();
    }

    private void LoseGame()
    {
        menuItem.SetActive(true);
        textLabel.text = "Вы проиграли!";
    }

    private void WinGame()
    {
        menuItem.SetActive(true);
        textLabel.text = "Вы выиграли!";
    }
}
