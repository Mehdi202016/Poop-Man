using UnityEngine;

public class SwipeControl : MonoBehaviour
{
    [SerializeField] private float SpeedSwipe=0.5f;
    [SerializeField] private float MaxAmount=1f;
    Move PlayerMove;

    void Start()
    {
        PlayerMove = GetComponent<Move>();
    }
    void Update()
    {
        float amount = Time.deltaTime * SpeedSwipe * PlayerMove.FactorMove;
        Mathf.Clamp(amount,-MaxAmount,MaxAmount);
        transform.Translate(amount, 0, 0);
    }
}
