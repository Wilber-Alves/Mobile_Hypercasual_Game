using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemCollectableBase : MonoBehaviour
{
    [HideInInspector] public Vector3 originalScale;

    public string compareTag = "Player";

    [Header("Particles")]
    public ParticleSystem pSystem;

    [Header("Sounds")]
    public AudioSource audioSource;

    public float timeToHide = 0.5f;

    public GameObject graphicItem;

    private void Awake()
    {
        originalScale = transform.localScale;
        //if (pSystem != null) pSystem.transform.SetParent(null);
    }

    private void Start()
    {
        CoinsAnimationManager.Instance.RegisterCoin(this);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        var col = GetComponent<Collider>();
        if (col != null) col.enabled = false;

        PlayerController.Instance.Bounce();

        if (graphicItem != null) graphicItem.SetActive(false);
        if (GetComponent<Collider>() != null) GetComponent<Collider>().enabled = false;

        if (pSystem != null)
        {
            pSystem.transform.SetParent(null);
            pSystem.Play();
        }

        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.spatialBlend = 0f;
            audioSource.Play();
        }

        OnCollect();
    }

    protected virtual void OnCollect()
    {

        Destroy(gameObject, timeToHide);
    }
}
