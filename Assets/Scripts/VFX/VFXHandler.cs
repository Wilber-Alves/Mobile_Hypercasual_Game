using UnityEngine;

public class VFXHandler : MonoBehaviour
{

    [SerializeField, Tooltip("Prefab to spawn when hit and destroyed.")]
    GameObject _mainExplosionChunk;
     [SerializeField, Tooltip("Min explosion chunks to spawn.")]
    int _minChunks = 5;
    [SerializeField, Tooltip("Max explosion chunks to spawn.")]
    int _maxChunks = 10;
    [SerializeField, Tooltip("Force of explosion.")]
    float _explosionForce = 1500.0f;

    public void SpawnExplosion()
    {
        // spawn a random number of the main chunks
        int rand = Random.Range(_minChunks, _maxChunks);
        if (_mainExplosionChunk)
        {
            for (int i = 0; i < rand; i++)
            {
                SpawnSubObject(_mainExplosionChunk);

            }
        }
    }

    public void OnBreak()
    {
        SpawnExplosion();
        Destroy(gameObject);
    }
    public void SpawnSubObject(GameObject prefab)
    {
        Vector3 pos = transform.position + Random.onUnitSphere * 0.8f;
        GameObject newObj = Instantiate(prefab, pos, Quaternion.identity);

        Rigidbody rb = newObj.GetComponent<Rigidbody>();
        if (rb != null) rb.AddExplosionForce(_explosionForce, transform.position, 1.0f);

        Destroy(newObj, 2.0f);
    }
}
