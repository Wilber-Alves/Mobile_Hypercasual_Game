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

    public void Play(AnimationType type)
    {
        foreach (var animation in animatorSetup)
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
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

    }
}
