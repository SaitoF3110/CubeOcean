using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ObjectType _type = ObjectType.Block;
    float _fadeSpeed = 0;
    [SerializeField] Texture _defaultAlbedo;
    FactingManager _facM;
    float _thisFactingL;
    float _thisFactingR;
    float _playerFactingL;
    float _playerFactingR;
    public abstract void WhenRotate();

    // Update is called once per frame
    private void Start()
    {
        _facM = GameObject.FindObjectOfType<FactingManager>();
        _facM.FactingTurn += PlayerFacting;

    }
    void Update()
    {
        //Debug.Log(this.GetComponent<Renderer>().material.color.a);
        if (Input.GetKeyDown(KeyCode.R))
        {
            
                      
        }
        //this.GetComponent<Renderer>().material.color = new Color(0,0,0, 1);
        //GetComponent<Renderer>().material.mainTexture = _defaultAlbedo;
    }
    private void FixedUpdate()
    {
        if (this.GetComponent<Renderer>().material.color.a < 1 && this.GetComponent<Renderer>().material.color.a > 0)
        {
            this.GetComponent<Renderer>().material.color += new Color(0, 0, 0, _fadeSpeed);
        }
        else
        {
            if(_fadeSpeed > 0)
            {
                MaterialFix(ChangeType.FadeIn);
            }
            else if(_fadeSpeed < 0)
            {
                MaterialFix(ChangeType.FadeOut);
            }
            _fadeSpeed = 0;
        }
    }
    void PlayerFacting(FactingManager.Facting _fact, bool _turn)
    {
        if (!_turn)
        {
            if (_fact == FactingManager.Facting.MinusZ)
            {
                //_thisFactingL = transform.position.x; 
                //_thisFactingR = transform.position.z; 
            }
            BlockControll();
        }
    }
    void BlockMaterialChange(ChangeType _fade)
    {
        if (_fade == ChangeType.FadeIn)
        {
            if (this.GetComponent<Renderer>().material.color.a <= 1 && this.GetComponent<Renderer>().material.color.a >= 0)
            {
                _fadeSpeed = 0.1f;
                this.GetComponent<Renderer>().material.color += new Color(0, 0, 0, _fadeSpeed);
            }
        }
        else if (_fade == ChangeType.FadeOut)
        {
            if (this.GetComponent<Renderer>().material.color.a >= 0 && this.GetComponent<Renderer>().material.color.a <= 1)
            {
                _fadeSpeed = -0.1f;
                this.GetComponent<Renderer>().material.color += new Color(0, 0, 0, _fadeSpeed);
            }
        }
        else if (_fade == ChangeType.NonFadeIn)
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
            if (_thisFactingL >= _playerFactingL - 1 && _thisFactingL <= _playerFactingL + 1 || _thisFactingR == _playerFactingR && _thisFactingL <= _playerFactingL)
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
    void MaterialFix(ChangeType _fade)
    {
        if (_fade == ChangeType.FadeIn )
        {
            this.GetComponent<Renderer>().material.color -= new Color(0, 0, 0, this.GetComponent<Renderer>().material.color.a);
            this.GetComponent<Renderer>().material.color += new Color(0, 0, 0, 1);
        }
        else if( _fade == ChangeType.FadeOut )
        {
            this.GetComponent<Renderer>().material.color -= new Color(0, 0, 0, this.GetComponent<Renderer>().material.color.a);
        }
    }
    enum ObjectType
    {
        /// <summary>Cube、破壊可能ブロック、アイテムブロック</summary>
        Block,
        /// <summary>壁についてるタイプのオブジェクト</summary>
        Sprite,
    }
    enum ChangeType
    {
        /// <summary>フェードインで出現</summary>
        FadeIn,
        /// <summary>フェードアウトで退場</summary>
        FadeOut,
        /// <summary>切り替えタイプで出現</summary>
        NonFadeIn,
        /// <summary>切り替えタイプで退場</summary>
        NonFadeOut,
    }
}
