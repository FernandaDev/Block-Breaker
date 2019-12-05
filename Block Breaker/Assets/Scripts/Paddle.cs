using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    Ball ball;

    private void Awake()
    {
        ball = FindObjectOfType<Ball>();
    }


    void Update()
    {
        Vector2 newPos = new Vector2(transform.position.x, transform.position.y);

        newPos.x = Mathf.Clamp(GetXPos(), minX, maxX);

        transform.position = newPos;
    }

    private float GetXPos()
    {
        if(GameManager.instance.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
