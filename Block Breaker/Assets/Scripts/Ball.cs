using UnityEngine;

public class Ball : MonoBehaviour
{
    Paddle paddle;
    [SerializeField] Vector2 startVelocity;

    Vector2 paddleDistance;
    Rigidbody2D rb2D;
    bool hasStarted = false;
    AudioSource audioSource;
    [SerializeField] AudioClip[] ballSoundFXs;
    [SerializeField] float randomFactor = 0.2f;

    private void Awake()
    {
        paddle = FindObjectOfType<Paddle>();
        rb2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
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
        if (GameManager.instance.IsAutoPlayEnabled())
        {
            rb2D.velocity = startVelocity;
            hasStarted = true;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2D.velocity = startVelocity;
                hasStarted = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0,  randomFactor ), Random.Range(0, randomFactor));

        if (hasStarted)
        {
            int randSound = Random.Range(0, ballSoundFXs.Length);
            audioSource.PlayOneShot(ballSoundFXs[randSound]);
            rb2D.velocity += velocityTweak;
        }
    }
}
