using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;


public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float finalScale = 1.1f; // The scale to which the button will grow
    public float scaleDuration = 0.2f; // Duration of the scaling animation

    private Vector3 _defaultScale;

    private Tween _currentTween;

    private void Awake()
    {
      _defaultScale = transform.localScale; // Store the original scale of the button
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
      //transform.localScale = _defaultScale * finalScale; // Scale up the button to the final scale
      _currentTween = transform.DOScale(_defaultScale * finalScale, scaleDuration).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo); // Animate the scale up with a bounce effect
        Debug.Log("Pointer entered the button area, scaling up.");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _currentTween?.Kill(); // Stop any ongoing tween to prevent conflicts
        transform.localScale = _defaultScale; // Reset the button scale to normal
      Debug.Log("Pointer exited the button area, scaling down.");
    }

}
