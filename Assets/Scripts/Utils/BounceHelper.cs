using DG.Tweening;
using UnityEngine;

public class BounceHelper : MonoBehaviour
{

    [Header("Animation")]
    public float scaleDuration = 0.25f;
    public float scaleBounce = 1.2f;
    public Ease scaleEase = Ease.Linear;

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            Bounce();
        }
    }

    public void Bounce()
    {
        transform.DOKill(true);
        transform.DOScale(scaleBounce, scaleDuration).SetEase(scaleEase).SetLoops(2, LoopType.Yoyo).OnComplete(() => transform.localScale = Vector3.one);

    }

}
