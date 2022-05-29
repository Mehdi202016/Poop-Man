using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] float SmothSpeed;
    public Vector3 Offset;
    public static CameraFollow instace;

    private void Awake()
    {
        if (instace == null)
        { instace = this; }
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = Player.position + Offset;
        Vector3 SmoththePosition = Vector3.Lerp(transform.position, desiredPosition, SmothSpeed);
        transform.position = SmoththePosition;
    }
}
