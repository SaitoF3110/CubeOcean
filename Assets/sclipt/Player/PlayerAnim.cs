using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour, IPause
{
    // Start is called before the first frame update
    Animator anim = null;
    SpriteRenderer m_sprite = default;
    Rigidbody rb = null;
    AudioSource _audio;
    [SerializeField] AudioClip _landingSE;
    [SerializeField] AudioClip _AttackSE;
    bool _pause = false;
    bool _landing = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        m_sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("NomalAttack", false);
        if (Input.GetMouseButtonDown(0) && !_pause)
        {
            anim.SetBool("NomalAttack", true);
            _audio.PlayOneShot(_AttackSE);
        }
        float h = Input.GetAxis("Horizontal");
        if(h != 0f && !_pause)
        {
            m_sprite.flipX = (h < 0);
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }
        if (Input.GetKeyDown(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            //this.GetComponent<Animator>().enabled = false;  アニメーション停止のメモ
            anim.SetBool("jumpKey", true);
            anim.SetFloat("SpeedY", 0);
        }
        //アニメーション
        GameObject obj = transform.parent.gameObject;
        PlayerController player = obj.GetComponent<PlayerController>();
        anim.SetFloat("SpeedY", player._speedY);
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            anim.SetBool("ground", false);
        }
            _landing = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            anim.SetBool("ground", true);
            _landing = true;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            anim.SetBool("ground", true);
            anim.SetBool("jumpKey", false);
            
            
        }
        if(!_landing)
        {
            _audio.PlayOneShot(_landingSE);
        }



    }
    public void Pause()
    {
        _pause = true;
        anim.enabled = false;
    }
    public void Resume()
    {
        _pause = false;
        anim.enabled = true;
    }
}
