using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    Transform Ball;
    [SerializeField] float SpeedRotation = 200f;
    [SerializeField] float Speed = 2f;
    [SerializeField] bool dirRight = true;

    private void Start()
    {
        Ball = transform.GetChild(0).GetComponent<Transform>();
    }
    void Update()
    {
        Ball.Rotate(new Vector3( 0f , SpeedRotation * Time.deltaTime , 0f ));
        RollMove();
    }

    private void RollMove()
    {
        if (dirRight)
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector3.right * Speed * Time.deltaTime);
        }

        if (transform.position.x >= 0.784f)
        {
            dirRight = false;
        }
        else if (transform.position.x <= -0.788f)
        {
            dirRight = true;
        }

    }
}
