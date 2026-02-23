using UnityEngine;

public class ItemCollectableAnimator2 : MonoBehaviour
{

    [Tooltip("The speed at which the coin move.")]
    public float slideSpeed = 2.0f;

    [Tooltip("The total height of the bobbing motion.")]
    public float slideAmount = 0.5f;
    
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        Slide();
    }

    private void Slide()
    {
        float xOffset = Mathf.Sin(Time.time * slideSpeed) * slideAmount;
        transform.position = new Vector3(startPosition.x + xOffset, startPosition.y, startPosition.z);
    }

}
