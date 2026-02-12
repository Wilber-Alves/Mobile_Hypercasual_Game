using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EDGEE.Core.Singleton;
using DG.Tweening;
using TMPro;

public class PlayerController : Singleton<PlayerController>
{
    // publics
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1.0f;

    public float speed = 1.0f;

    public string tagToCheckObstacle = "Obstacle";
    public string tagToCheckFinishLine = "FinishLine";

    public GameObject endScreen;

    public bool invencibility = false;

    [Header("PowerUp Texts")]
    public TextMeshPro uiTextPowerUp;

    [Header("Coin Setup")]
    public GameObject coinCollector;

    // privates
    private Vector3 _position;
    private bool _canRun;
    private float _currentSpeed;
    private Vector3 _startPosition;


    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();

    }
    void Update()
    {
        if (!_canRun) return;

        _position = transform.position;
        _position.y = transform.position.y;
        _position.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _position, lerpSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == tagToCheckObstacle)
        {
            if (!invencibility) EndGame();
        }

        if (collision.transform.tag == tagToCheckFinishLine)
        {
            if (!invencibility) EndGame();
        }

    }

    private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
        Debug.Log("Game Over!");

    }

    public void StartToRun()
    {
        _canRun = true;

    }
    #region POWER UP
    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }
    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void SetInvencibility(bool b)
    {
        invencibility = b;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    { 
        
        /*var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;*/

        transform.DOMoveY(_startPosition.y + amount,
        animationDuration).SetEase(ease);//.OnComplete(ResetHeight);a
        Invoke(nameof(ResetHeight), duration);


    }

    public void ResetHeight()
    {
        transform.DOMoveY(_startPosition.y, 0.1f);
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }

    #endregion
}
