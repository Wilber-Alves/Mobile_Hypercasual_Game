using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ItemCollectableBase : MonoBehaviour
{

    public string compareTag = "Player";

    [Header("Particles")]
    public ParticleSystem particleSystem;

    [Header("Sounds")]
    public AudioSource audioSource;

    public float timeToHide = 0.5f;
    public GameObject graphicItem; 


    private void Awake()
    {
        if (particleSystem != null) particleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
            OnCollect();
        }
    }

    protected virtual void Collect()
    {
        if (GetComponent<SpriteRenderer>() != null) GetComponent<SpriteRenderer>().enabled = false;
        if (GetComponent<Collider>() != null) GetComponent<Collider>().enabled = false;

        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);

        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (particleSystem != null) particleSystem.Play();

        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.spatialBlend = 0f;
            audioSource.Play();

            Destroy(gameObject, 0.5f);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
