using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerTest : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource _audioRot;
    Rigidbody _rb;
    int turn = 3;
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
        if (Input.GetKeyDown(KeyCode.Space) && !_rotMode)
        {
            //transform.position += 5 * transform.up * Time.deltaTime;
            _rb.AddForce(new Vector3(0,300,0));
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



    }
    void FixedUpdate()
    {
        Vector3 velocity = transform.localPosition;
        if (Input.GetKey(KeyCode.D) && !_rotMode)
        {
            //velocity.x += 0.1f;
            this.transform.Translate(0.1f, 0, 0, Space.Self);
        }
        else if (Input.GetKey(KeyCode.A) && !_rotMode)
        {
            //velocity.x += -0.1f;
            this.transform.Translate(-0.1f, 0, 0, Space.Self);
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
}
