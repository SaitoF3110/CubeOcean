using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim = null;
    SpriteRenderer m_sprite = default;
    void Start()
    {
        anim = GetComponent<Animator>();
        m_sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("run", true);
    }
}
