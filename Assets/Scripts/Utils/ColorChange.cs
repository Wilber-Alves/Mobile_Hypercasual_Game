using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class ColorChange : MonoBehaviour
{

    public MeshRenderer meshRenderer;
    public float duration = 1.0f;
    public Color startColor = Color.white;

    private Color _correctColor;


    private void OnValidate()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _correctColor = meshRenderer.materials[0].GetColor("_BaseColor");
        LerpColor();
    }

    private void LerpColor()
    {
        meshRenderer.materials[0].SetColor("_BaseColor", startColor);
        meshRenderer.materials[0].DOColor(_correctColor, duration).SetDelay(0.5f);
    }

}



    