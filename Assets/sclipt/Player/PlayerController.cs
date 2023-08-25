using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour, IPause
{
    // Start is called before the first frame update
    [SerializeField] float _jumpPawer = 3;
    [SerializeField] float _moveSpeed = 1;
    [SerializeField] GameObject _transform;
    [SerializeField] GameObject _attack;
    [SerializeField] GameObject _attackSword;
    AudioSource _audioRot;
    [SerializeField] AudioClip _jumpSE;
    FactingManager _facM;
    Rigidbody _rb;
    Vector3 _grav = new Vector3(0,-9.8f,0);
    bool _water = false;
    int turn = 3;
    float _run = 1;
    float r = 0;
    /// <summary>
    /// ÉvÉåÉCÉÑÅ[Ç™å¸Ç´ÇïœÇ¶ÇÈ
    /// </summary>
    bool _rotMode = false;
    public float _rotLimit = 1;
    public float _speedY;
    public bool _rotation = false;
    bool _pause;
    Vector3 _velocity;
    /// <summary>
    /// âÒÇ¡ÇΩå„ÇÃå¸Ç´ 0:1:2:3 = 0:-90:Å}180:90
    /// </summary>
    public int _afterFacting = 0;
    void Start()
    {
        _audioRot = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody>();
        _facM = GetComponent<FactingManager>();
        _facM.FactingTurn += AllowFacting;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_pause)
        {
            Instantiate(_attack,this.transform.position,this.transform.rotation);
            Instantiate(_attackSword, this.transform.position, this.transform.rotation,this.transform);
        }
        
        _speedY = _rb.velocity.y;
        GameController._player = this.transform.position;
        if (Input.GetKeyDown(KeyCode.W) && !_rotMode && !Input.GetKey(KeyCode.LeftShift) && !_pause)
        {
            _audioRot.PlayOneShot(_jumpSE);
            _rb.velocity = new Vector3(_rb.velocity.x,0,_rb.velocity.z);
            _rb.AddForce(new Vector3(0,_jumpPawer * 100,0));
        }
        if (Input.GetKeyDown(KeyCode.S) && !_rotMode && !Input.GetKey(KeyCode.LeftShift) && !_pause)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
            _rb.AddForce(new Vector3(0, -_jumpPawer * 50, 0));
        }
        if (Input.GetKeyDown(KeyCode.R) && !_pause)
        {
            if(!_rotMode)
            {
                _audioRot.Play();
                _rotation = true;
                //this.transform.position = new Vector3((int)this.transform.position.x,this.transform.position.y, (int)this.transform.position.z);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                turn = 3;
            }
            else
            {
                turn = -3;
            }
            _rotMode = true;
            r += turn;
        }
        if (Input.GetKey(KeyCode.LeftShift) && !_pause)
        {
            _rb.velocity = new Vector3(0, 0, 0);
            _grav = Physics.gravity;
            Physics.gravity = new Vector3(0, 0, 0);
        }
        else
        {
            if (_water)
            {
                Physics.gravity = new Vector3(0,-1,0);
            }
            else
            {
                Physics.gravity = new Vector3(0, -9.8f, 0);
            }
            
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _run = 2;
        }
        else
        {
            _run = 1;
        }

    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 velocity = transform.localPosition;
        if(h > 0 && !_pause)
        {
            _rb.AddForce(transform.right * _moveSpeed * _run);
        }
        else if(h < 0 && !_pause)
        {
            _rb.AddForce(transform.right * -_moveSpeed * _run);
        }
        if (_rotMode)
        {
            if (r % 90 != 0)
            {
                r += turn;
            }
            else
            {
                _rotMode = false;
            }
            transform.rotation = Quaternion.Euler(0, r, 0);
        }
    }
    void AllowFacting(FactingManager.Facting _fact,bool _turn)
    {
        
        if (_fact == FactingManager.Facting.PlusZ || _fact == FactingManager.Facting.MinusZ)
        {
            float _fixValue;
            if(this.transform.position.x >= 0) { _fixValue = 0.45f; } else { _fixValue = -0.45f; }
            float _fixdTrans = this.transform.position.x + _fixValue;
            this.transform.position = new Vector3((int)_fixdTrans, this.transform.position.y, this.transform.position.z);
            _rb.constraints = RigidbodyConstraints.FreezeRotation
            | RigidbodyConstraints.FreezePositionX;
        }
        else
        {
            float _fixValue;
            if (this.transform.position.z >= 0) { _fixValue = 0.45f; } else { _fixValue = -0.45f; }
            float _fixdTrans = this.transform.position.z + _fixValue;
            _rb.constraints = RigidbodyConstraints.FreezeRotation  
           | RigidbodyConstraints.FreezePositionZ;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, (int)_fixdTrans);
                
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            _water = true;
        }
            
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            _water = true;
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            _water = false;
        }
    }
    public void Pause()
    {
        _pause = true;
        _velocity = _rb.velocity;
        _rb.Sleep();
    }
    public void Resume()
    {
        _pause = false;
        _rb.WakeUp();
        _rb.velocity = _velocity;
    }
}
