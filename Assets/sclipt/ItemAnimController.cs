using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimController : MonoBehaviour, IPause
{
    // Start is called before the first frame update
    Animator anim = null;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Pause()
    {
        anim.enabled = false;
    }
    public void Resume()
    {
        anim.enabled = true;
    }
}
