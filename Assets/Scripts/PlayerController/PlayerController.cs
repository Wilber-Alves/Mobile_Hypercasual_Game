using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EDGEE.Core.Singleton;
using DG.Tweening;
using TMPro;

public class PlayerController : Singleton<PlayerController>
{
    // publics
    public Vector3 startPosition;

    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1.0f;

    public float speed = 5.0f;

    public string tagToCheckObstacle = "Obstacle";
    public string tagToCheckFinishLine = "FinishLine";

    public GameObject endScreen;

    public bool invencibility = false;

    [Header("PowerUp Texts")]
    public TextMeshPro uiTextPowerUp;

    [Header("Coin Setup")]
    public GameObject coinCollector;

    [Header("Animation")]
    public AnimatorManager animatorManager;

    [SerializeField] private BounceHelper _bounceHelper;

    // privates

    private Vector3 _position;
    private bool _canRun;
    private float _currentSpeed;
    private float _baseSpeedToAnimation = 5.0f;


    private void Start()
    {
        startPosition = transform.position;
        ResetSpeed();
    }

    public void Bounce()
    {
        if (_bounceHelper != null)
        {
            _bounceHelper.Bounce();
        }
        else
        {
            Debug.LogWarning("BounceHelper não atribuído no Inspector do PlayerController!");
        }
    }
    void Update()
    {
        if (!_canRun) return;

        Vector3 targetPos = new Vector3(target.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(tagToCheckObstacle))
        {
            if (!invencibility)
            {
                MoveBack();
                EndGame(AnimatorManager.AnimationType.Dead);
            }
            else
            {
                // get vfx handler and call break
                VFXHandler vfx = collision.gameObject.GetComponent<VFXHandler>();
                if (vfx != null)
                {
                    // the point  of impact = player position + 1 meter in front of the player
                    Vector3 impactPos = transform.position + (transform.forward * 2.0f);
                    vfx.OnBreak(impactPos);
                }
                else
                {
                    // Fallback cause the object doesn't have a vfx handler, just destroy it
                    Destroy(collision.gameObject);
                }
            }
        }

        if (collision.transform.tag == tagToCheckFinishLine)
        {
            if (!invencibility) EndGame();
        }

    }

    private void MoveBack()
    {
        transform.DOMoveZ(-1, 0.2f).SetRelative();
    }

    private void EndGame(AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.Idle)
    {
        _canRun = false;
        endScreen.SetActive(true);
        animatorManager.Play(animationType);
        Debug.Log("Game Over!");
    }

    public void StartToRun()
    {
        _canRun = true;
        animatorManager.Play(AnimatorManager.AnimationType.Run, _currentSpeed / _baseSpeedToAnimation);
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

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }

    #endregion
}
