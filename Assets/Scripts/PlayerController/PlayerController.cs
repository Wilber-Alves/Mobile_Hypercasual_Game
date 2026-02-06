using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1.0f;

    public float speed = 1.0f;

    private Vector3 _position;

    void Update()
    {
        _position = transform.position;
        _position.y = transform.position.y;
        _position.z = transform.position.z;


        transform.position = Vector3.Lerp(transform.position, _position, lerpSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
