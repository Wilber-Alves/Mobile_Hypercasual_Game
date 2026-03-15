using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimatorSetup> animatorSetup;

    public enum AnimationType
    { 
        Idle,
        Run,
        Dead 
    }

    public void Play(AnimationType type, float currentSpeedFactor = 1.0f)
    {
        foreach (var animation in animatorSetup)
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                animator.speed = animation.speed * currentSpeedFactor;
                break;
            }
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Play(AnimationType.Run);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Play(AnimationType.Dead);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Play(AnimationType.Idle);
        }
    }

    [System.Serializable]
    public class AnimatorSetup
    {
        public AnimatorManager.AnimationType type;
        public string trigger;
        public float speed = 1f;

    }
}
