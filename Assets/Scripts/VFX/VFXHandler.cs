using UnityEngine;

public class VFXHandler : MonoBehaviour
{
    [SerializeField] GameObject _mainExplosionChunk;
    [SerializeField] int _minChunks = 8;
    [SerializeField] int _maxChunks = 12;
    [SerializeField] float _explosionForce = 500.0f;

    // now, when the Player collides with the obstacle, we call this method to spawn the chunks and destroy the obstacle
    public void OnBreak(Vector3 impactPoint)
    {
        if (_mainExplosionChunk != null)
        {
            int rand = Random.Range(_minChunks, _maxChunks);
            for (int i = 0; i < rand; i++)
            {
                SpawnChunk(impactPoint);
            }
        }

        // destroy the original object after spawning the chunks
        Destroy(gameObject);
    }

    private void SpawnChunk(Vector3 center)
    {
        // create a random position around the impact point to spawn the chunk
        Vector3 spawnPos = center + (Vector3.forward * 0.5f) + Random.insideUnitSphere * 0.5f;
        GameObject newObj = Instantiate(_mainExplosionChunk, spawnPos, Random.rotation);

        Rigidbody rb = newObj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // the force is applied from the center of the explosion to the chunk, so it will fly away from the explosion
            rb.AddExplosionForce(_explosionForce, center, 3.0f);
        }

        Destroy(newObj, 2.0f);
    }
}