using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPause : MonoBehaviour, IPause
{
    Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void Pause()
    {
        _anim.enabled = false;
    }
    public void Resume()
    {
        _anim.enabled = true;
    }
}
