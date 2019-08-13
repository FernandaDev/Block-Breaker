using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] Vector2 startVelocity;

    Vector2 paddleDistance;
    Rigidbody2D rb2D;
    bool hasStarted = false;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        paddleDistance = transform.position - paddle.transform.position;
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBall();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 newPos = new Vector2(paddle.transform.position.x,
                                             paddle.transform.position.y) + paddleDistance;

        transform.position = newPos;
    }

    void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb2D.velocity = startVelocity;
            hasStarted = true;
        }
    }
}
