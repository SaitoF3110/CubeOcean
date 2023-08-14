using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ObjectType _type = ObjectType.Block;
    
    float _fadeSpeed = 0;
    [SerializeField] Texture _defaultAlbedo;
    FactingManager _facMBlock;
    float _thisFacting;
    float _playerFacting;
    int _factNumber;
    bool _facMAdd;
    public abstract void WhenRotate();

    // Update is called once per frame
    private void Start()
    {
        _facMBlock = GameObject.FindObjectOfType<FactingManager>();
        _facMBlock.FactingTurn += PlayerFactingBlock;

    }
    void Update()
    {
        //Debug.Log(this.GetComponent<Renderer>().material.color.a);
        if (Input.GetKeyDown(KeyCode.R))
        {
            
                      
        }
        //this.GetComponent<Renderer>().material.color = new Color(0,0,0, 1);
        //GetComponent<Renderer>().material.mainTexture = _defaultAlbedo;
        GameObject obj = GameObject.FindWithTag("Player");
        PlayerController playerscript = obj.GetComponent<PlayerController>();
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
    void PlayerFactingBlock(FactingManager.Facting _fact, bool _turn)
    {
        GameObject _playerObj = GameObject.FindWithTag("Player");
        float _fixdTrans;
        //�v���C���[�̈ʒu�C��
        if (_fact == FactingManager.Facting.PlusZ || _fact == FactingManager.Facting.MinusZ)
        {
            float _fixValue;
            if (this.transform.position.x >= 0) { _fixValue = 0.45f; } else { _fixValue = -0.45f; }
            _fixdTrans = _playerObj.transform.position.x + _fixValue;
        }
        else
        {
            float _fixValue;
            if (this.transform.position.z >= 0) { _fixValue = 0.45f; } else { _fixValue = -0.45f; }
            _fixdTrans = _playerObj.transform.position.z + _fixValue;
        }
        
        if (_fact == FactingManager.Facting.MinusZ || _fact == FactingManager.Facting.PlusZ)
        {
            _thisFacting = (int)this.transform.position.x;
            _playerFacting = (int)_fixdTrans;
        }
        else if(_fact == FactingManager.Facting.PlusX || _fact == FactingManager.Facting.MinusX)
        {
            _thisFacting = (int)this.transform.position.z;
            _playerFacting = (int)_fixdTrans;  
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
            if (_thisFacting == _playerFacting || _thisFacting == _playerFacting + _factNumber)
            {
                BlockMaterialChange(ChangeType.FadeIn);//��]��ɕ\������u���b�N�̓t�F�[�h�C��
                
            }
            else if(_thisFacting == _playerFacting - _factNumber)//��O�̃u���b�N�͔�������
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
            if (this.GetComponent<Renderer>().material.color.a < 0.3)
            {
                this.GetComponent<Renderer>().material.color += new Color(0, 0, 0, 0.3f);
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
