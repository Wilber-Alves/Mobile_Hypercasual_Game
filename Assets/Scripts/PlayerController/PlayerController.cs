using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    // publics
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1.0f;

    public float speed = 1.0f;

    public string tagToCheckObstacle = "Obstacle";

    // privates
    private bool _canrun;
    private Vector3 _position;
    private void Start()
    {
        _canrun = true;
    }
    void Update()
    {
        if (!_canrun) return;

        _position = transform.position;
        _position.y = transform.position.y;
        _position.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _position, lerpSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            _canrun = false;
            Debug.Log("Game Over!");

        }
    }

}
