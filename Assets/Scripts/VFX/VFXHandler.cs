using DG.Tweening;
using UnityEngine;

public class VFXHandler : MonoBehaviour
{
    [Header("Explosion Settings")]
    [SerializeField] GameObject _mainExplosionChunk;
    [SerializeField] float _explosionForce = 500.0f;
    [SerializeField] MeshRenderer _meshRenderer;


    [Header("Animation Timings")]
    [Tooltip("How long the obstacle takes to expand and fade away.")]
    public float breakDuration = 0.2f;

    [Tooltip("The delay before spawning chunks (0 = immediate). Should be shorter than Break Duration.")]
    public float particleSpawnDelay = 0.05f;

    [Header("Visual Effects")]
    [Tooltip("Scale multiplier for the expansion effect (e.g., 1.5 = 50% larger).")]
    public float expandMultiplier = 1.5f;

    [Tooltip("The color the block flashes before disappearing (usually White).")]
    public Color flashColor = Color.blue;

    private bool _isBreaking = false;

    public void OnBreak(Vector3 impactPoint)
    {
        if (_isBreaking) return;
        _isBreaking = true;

        Vector3 targetScale = transform.localScale * expandMultiplier;
        transform.DOScale(targetScale, breakDuration).SetEase(Ease.OutQuad);

        if (_meshRenderer != null)
        {

            _meshRenderer.material.DOColor(flashColor, breakDuration * 0.5f);

            _meshRenderer.material.DOFade(0, breakDuration).SetEase(Ease.InQuad);
        }

        DOVirtual.DelayedCall(particleSpawnDelay, () =>
        {
            SpawnExplosion(impactPoint);
        });

        Destroy(gameObject, breakDuration);
    }

    private void SpawnExplosion(Vector3 center)
    {
        if (_mainExplosionChunk == null) return;

        int rand = Random.Range(25, 30);
        for (int i = 0; i < rand; i++)
        {
            SpawnChunk(center);
        }
    }

    private void SpawnChunk(Vector3 center)
    {
        Vector3 spawnPos = center + (Vector3.forward * 0.5f) + Random.insideUnitSphere * 0.5f;
        GameObject newObj = Instantiate(_mainExplosionChunk, spawnPos, Random.rotation);

        Rigidbody rb = newObj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddExplosionForce(_explosionForce, center, 3.0f);
        }

        Destroy(newObj, 2.0f);
    }
}