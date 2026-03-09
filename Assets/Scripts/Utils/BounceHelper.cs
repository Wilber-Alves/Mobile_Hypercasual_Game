using DG.Tweening;
using UnityEngine;

public class BounceHelper : MonoBehaviour
{

    [Header("Animation")]
    public float scaleDuration = 0.05f;
    public float scaleBounce = 1.2f;
    public Ease ease = Ease.OutBack;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Bounce();
        }
    }


    public void Bounce()
    {
        transform.DOKill();
        transform.localScale = Vector3.one;

        transform.DOScale(scaleBounce, scaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo).OnComplete(() => transform.localScale = Vector3.one);

    }

}
