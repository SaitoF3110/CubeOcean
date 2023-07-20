using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ObjectType _type = ObjectType.Block;
    Vector3 _position;
    [SerializeField] float _fadeSpeed = 0;
    [SerializeField] Texture _defaultAlbedo;
    public abstract void WhenRotate();

    // Update is called once per frame
    private void Start()
    {

    }
    void Update()
    {
        Debug.Log(this.GetComponent<Renderer>().material.color.a);
        if (Input.GetKeyDown(KeyCode.R))
        {
            BlockControll();
            
        }
        //this.GetComponent<Renderer>().material.color = new Color(0,0,0, 1);
        GetComponent<Renderer>().material.mainTexture = _defaultAlbedo;
    }
    private void FixedUpdate()
    {
        if (this.GetComponent<Renderer>().material.color.a < 1 && this.GetComponent<Renderer>().material.color.a > 0)
        {
            this.GetComponent<Renderer>().material.color += new Color(0, 0, 0, _fadeSpeed);
        }
        else
        {
            _fadeSpeed = 0;
        }
    }
    void BlockMaterialChange(ChangeType _fade)
    {
        if( _fade == ChangeType.FadeIn )
        {
            if (this.GetComponent<Renderer>().material.color.a < 1 && this.GetComponent<Renderer>().material.color.a > 0)
            {
                _fadeSpeed = 0.1f;
                this.GetComponent<Renderer>().material.color += new Color(0, 0, 0, _fadeSpeed);
            }
        }
        else if( _fade == ChangeType.FadeOut )
        {
            if (this.GetComponent<Renderer>().material.color.a > 0 && this.GetComponent<Renderer>().material.color.a < 1)
            {
                _fadeSpeed = -0.1f;
                this.GetComponent<Renderer>().material.color += new Color(0, 0, 0, _fadeSpeed);
            }
        }
        else if( _fade == ChangeType.NonFadeIn )
        {
            if (this.GetComponent<Renderer>().material.color.a < 1)
            {
                this.GetComponent<Renderer>().material.color += new Color(0, 0, 0, 1);
            }
        }
        else
        {
            if (this.GetComponent<Renderer>().material.color.a > 0)
            {
                this.GetComponent<Renderer>().material.color += new Color(0, 0, 0, -1);
            }
        }
    }
    void BlockControll()
    {
        if (_type == ObjectType.Block)
        {
            if (this.transform.position.x == GameController._intPlayer.x && this.transform.position.x <= GameController._intPlayer.x || this.transform.position.z == GameController._intPlayer.z && this.transform.position.x <= GameController._intPlayer.x)
            {
                BlockMaterialChange(ChangeType.NonFadeIn);
            }
            else if (this.transform.position.x > GameController._intPlayer.x)
            {
                BlockMaterialChange(ChangeType.FadeOut);
            }
            else
            {
                //this.GetComponent<Renderer>().material = _material[1];
                //GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0.5f);
                //this.GetComponent<Renderer>().material.color += new Color(0, 0, 0, 0.5f);
                BlockMaterialChange(ChangeType.NonFadeOut);

            }

        }
        else if (_type == ObjectType.Sprite)
        {

        }
    }
    enum ObjectType
    {
        /// <summary>Cube�A�j��\�u���b�N�A�A�C�e���u���b�N</summary>
        Block,
        /// <summary>�ǂɂ��Ă�^�C�v�̃I�u�W�F�N�g</summary>
        Sprite,
    }
    enum ChangeType
    {
        /// <summary>�t�F�[�h�C���ŏo��</summary>
        FadeIn,
        /// <summary>�t�F�[�h�A�E�g�őޏ�</summary>
        FadeOut,
        /// <summary>�؂�ւ��^�C�v�ŏo��</summary>
        NonFadeIn,
        /// <summary>�؂�ւ��^�C�v�őޏ�</summary>
        NonFadeOut,
    }
}
