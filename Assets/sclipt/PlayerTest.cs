using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerTest : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float _jumpPawer = 3;
    [SerializeField] float _moveSpeed = 1;
    AudioSource _audioRot;
    Rigidbody _rb;
    int turn = 3;
    float _run = 1;
    float r = 0;
    /// <summary>
    /// ÉvÉåÉCÉÑÅ[Ç™å¸Ç´ÇïœÇ¶ÇÈ
    /// </summary>
    bool _rotMode = false;
    public float _rotLimit = 1;
    void Start()
    {
        _audioRot = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !_rotMode)
        {
            _rb.velocity = new Vector3(_rb.velocity.x,0,_rb.velocity.z);
            _rb.AddForce(new Vector3(0,_jumpPawer * 100,0));
        }
        if (Input.GetKeyDown(KeyCode.S) && !_rotMode)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
            _rb.AddForce(new Vector3(0, -_jumpPawer * 50, 0));
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(!_rotMode)
            {
                _audioRot.Play();
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _rb.velocity = new Vector3(0, 0, 0);
            Physics.gravity = new Vector3(0, 0, 0);
        }
        else
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
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
        Vector3 velocity = transform.localPosition;
        if (Input.GetKey(KeyCode.D) && !_rotMode)
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y,0);
            _rb.AddForce(transform.right * _moveSpeed * _run);
        }
        else if (Input.GetKey(KeyCode.A) && !_rotMode)
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
            _rb.AddForce(transform.right * -_moveSpeed * _run);
        }
        else
        {
            //velocity.x += 0;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            Physics.gravity = new Vector3(0, -1, 0);
        }
            
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            Physics.gravity = new Vector3(0, -1, 0);
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
        }
    }
}
