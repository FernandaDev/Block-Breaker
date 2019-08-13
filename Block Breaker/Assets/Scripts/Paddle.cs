using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    void Start()
    {
        
    }

    void Update()
    {
        float xInput = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        Vector2 newPos = new Vector2(xInput, transform.position.y);

        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);

        transform.position = newPos;
    }
}
