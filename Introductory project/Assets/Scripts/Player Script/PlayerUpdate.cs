using UnityEngine;

[RequireComponent(typeof(PlayerControl))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerUpdate : MonoBehaviour
{
    private Camera cam;

    private PlayerControl _playerControl;
    private PlayerMovement _playerMovement;
    private void Awake()
    {
        CollisionDetector.CollidedWithSpike.AddListener(GameOver);
        CoinCounter.CoinsRanOut.AddListener(GameOver);
    }

    private void Start()
    {
        cam = Camera.main;

        _playerControl = GetComponent<PlayerControl>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (_playerControl.CatchTheTouch())
            _playerMovement.PushNewPosition(GetMouseClickPosition());
    }

    private Vector2 GetMouseClickPosition()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void GameOver()
    {
        _playerMovement.StopMoving();
        this.enabled = false;
    }
}
