using DG.Tweening;
using System.Linq;
using EDGEE.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsAnimationManager : Singleton<CoinsAnimationManager>
{
    public List<ItemCollectableCoin> PFB_Coin;

    [Header("Animation")]
    public float scaleDuration = 0.5f;
    public float scaleTimeBetweenPieces = 0.1f;
    public Ease scaleEase = Ease.OutBack;

    private void Start()
    {
        PFB_Coin = new List<ItemCollectableCoin>();
        PFB_Coin.Clear();
    }
    public void RegisterCoin(ItemCollectableCoin i)
    {
        if (i != null && !PFB_Coin.Contains(i))
        {
            PFB_Coin.Add(i);
            i.transform.localScale = Vector3.zero;
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            StartAnimations();

        }
    }
    public void StartAnimations()
    {
        StopAllCoroutines();
        StartCoroutine(ScalePiecesByTime());
    }

    IEnumerator ScalePiecesByTime()
    {

       yield return new WaitForEndOfFrame();

       PFB_Coin.RemoveAll(item => item == null);

        foreach (var p in PFB_Coin)
        {
           p.transform.localScale = Vector3.zero;
            if (p != null) p.transform.localScale = Vector3.zero;
        }

        Sort();

        yield return null;

        for (int i = 0; i < PFB_Coin.Count; i++)
        {
            if (PFB_Coin[i] != null)
            {   
                //Assuming originalScale is the desired final scale for the coin
                //Vector3 targetScale = PFB_Coin[i].originalScale; 

                PFB_Coin[i].transform.DOScale(1, scaleDuration).SetEase(scaleEase);
                yield return new WaitForSeconds(scaleTimeBetweenPieces);
            }
        }
    }
    private void Sort()
    {
        PFB_Coin = PFB_Coin
            .Where(p => p != null)
            .OrderBy(p => Vector3.Distance(p.transform.position, PlayerController.Instance.transform.position))
            .ToList();
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }

}
