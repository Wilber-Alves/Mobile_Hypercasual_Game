using UnityEngine;

public class TouchController : MonoBehaviour
{

    public Vector2 mousePositionPrev;
    public float velocity = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            // mousePosition NOW - mousePosition PREV = delta

            Move(Input.mousePosition.x - mousePositionPrev.x);
        }

        mousePositionPrev = Input.mousePosition;
    }

    public void Move(float speed)
    {
        transform.position += Vector3.right * Time.deltaTime * speed * velocity;   
    }
}
