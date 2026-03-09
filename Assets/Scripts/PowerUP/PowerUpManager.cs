using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PowerUpManager : MonoBehaviour
{
    private PlayerController _player;

    // Referências para cancelar cronômetros anteriores
    private Coroutine _speedCoroutine;
    private Coroutine _invincibilityCoroutine;
    private Coroutine _coinCollectorCoroutine;
    private Tween _heightTween;

    private void Awake()
    {
        _player = GetComponent<PlayerController>();
    }

    public void StartSpeed(float amount, float duration)
    {
        if (_speedCoroutine != null) StopCoroutine(_speedCoroutine);

        _player.PowerUpSpeedUp(amount);
        _player.SetPowerUpText("Speed Up!");

        _speedCoroutine = StartCoroutine(Timer(() => {
            _player.ResetSpeed();
            _player.SetPowerUpText("");
        }, duration));
    }

    public void StartInvincibility(float duration)
    {
        if (_invincibilityCoroutine != null) StopCoroutine(_invincibilityCoroutine);

        _player.SetInvencibility(true);
        _player.SetPowerUpText("Invincibility!");

        _invincibilityCoroutine = StartCoroutine(Timer(() => {
            _player.SetInvencibility(false);
            _player.SetPowerUpText("");
        }, duration));
    }

    public void StartHeight(float amount, float duration, float animDuration, Ease ease)
    {
        _heightTween?.Kill();
        CancelInvoke(nameof(ResetHeightInternal));
        _heightTween = transform.DOMoveY(_player.startPosition.y + amount, animDuration).SetEase(ease);
        Invoke(nameof(ResetHeightInternal), duration);
    }
    private void ResetHeightInternal()
    {
        _heightTween?.Kill();
        _heightTween = transform.DOMoveY(_player.startPosition.y, 0.3f)
              .SetEase(Ease.OutQuad)
              .OnComplete(() => 
              {
                 transform.position = new Vector3(transform.position.x, _player.startPosition.y, transform.position.z);
              });
    }

    public void StartCoinCollector(float size, float duration)
    {
        if (_coinCollectorCoroutine != null) StopCoroutine(_coinCollectorCoroutine);

        _player.ChangeCoinCollectorSize(size);
        _player.SetPowerUpText("Magnet!");

        _coinCollectorCoroutine = StartCoroutine(Timer(() => {
            _player.ChangeCoinCollectorSize(1);
            _player.SetPowerUpText("");
        }, duration));
    }

    private IEnumerator Timer(System.Action onEnd, float time)
    {
        yield return new WaitForSeconds(time);
        onEnd?.Invoke();
    }
}