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
    int _factNumber;
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
        GameObject _playerObj = GameObject.FindWithTag("Player");
        if (_fact == FactingManager.Facting.MinusZ || _fact == FactingManager.Facting.PlusZ)
        {
            _thisFactingL = (int)this.transform.position.x; 
            _playerFactingL = (int)_playerObj.transform.position.x;
        }
        else if(_fact == FactingManager.Facting.PlusX || _fact == FactingManager.Facting.MinusX)
        {
            _thisFactingL = (int)this.transform.position.z;
            _playerFactingL = (int)_playerObj.transform.position.z;  
        }
        if(!_turn)
        {
            if(_fact == FactingManager.Facting.PlusX || _fact == FactingManager.Facting.MinusZ)
                _factNumber = -1;
            else if(_fact == FactingManager.Facting.PlusZ || _fact == FactingManager.Facting.MinusX)
                _factNumber = 1;
        }
        else
        {
            if (_fact == FactingManager.Facting.PlusX || _fact == FactingManager.Facting.MinusZ)
                _factNumber = 1;
            else if (_fact == FactingManager.Facting.PlusZ || _fact == FactingManager.Facting.MinusX)
                _factNumber = -1;
        }
            BlockControll();
    }
    void BlockControll()
    {
        if(this.GetComponent<Renderer>().material.color.a >= 0.7 && this.GetComponent<Renderer>().material.color.a <= 0.9)
        {
            MaterialFix(ChangeType.FadeIn);
        }
        if (_type == ObjectType.Block)
        {
            if (_thisFactingL == _playerFactingL || _thisFactingL == _playerFactingL + _factNumber)
            {
                BlockMaterialChange(ChangeType.FadeIn);//��]��ɕ\������u���b�N�̓t�F�[�h�C��
            }
            else if(_thisFactingL == _playerFactingL - _factNumber)//��O�̃u���b�N�͔�������
            {
                MaterialFix(ChangeType.FadeOut);
                BlockMaterialChange(ChangeType.TranslucentIn);
            }
            else
            {
                //this.GetComponent<Renderer>().material = _material[1];
                //GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0.5f);
                //this.GetComponent<Renderer>().material.color += new Color(0, 0, 0, 0.5f);
                BlockMaterialChange(ChangeType.FadeOut);

            }

        }
        else if (_type == ObjectType.Sprite)
        {

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
        else if (_fade == ChangeType.TranslucentIn)
        {
            if (this.GetComponent<Renderer>().material.color.a < 0.8)
            {
                this.GetComponent<Renderer>().material.color += new Color(0, 0, 0, 0.8f);
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
        /// <summary>�������u���b�N�̏o��</summary>
        TranslucentIn,
        /// <summary>�������u���b�N�̑ޏ�</summary>
        TranslucentOut,
    }
}
