using UnityEngine;

public class DirectionLine : MonoBehaviour
{
    [SerializeField] private float rotationVelocity;
    [SerializeField] private GameObject line;

    public void SetRotation(Vector2 direction, float distance)
    {
        Quaternion toRotation = Quaternion.LookRotation(transform.forward, direction);
        float multiplier = Mathf.Clamp(distance, 0, 1);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime / multiplier);
    }

    public void SwitchLine(bool isActive)
    {
        line.SetActive(isActive);
    }
}
