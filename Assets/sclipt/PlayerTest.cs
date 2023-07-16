using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerTest : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody _rb;
    float r = 0;
    /// <summary>
    /// ÉvÉåÉCÉÑÅ[Ç™å¸Ç´ÇïœÇ¶ÇÈ
    /// </summary>
    bool _rotMode = false;
    public float _rotLimit = 1;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //transform.position += 5 * transform.up * Time.deltaTime;
            _rb.AddForce(new Vector3(0,300,0));
        }
        Vector3 velocity = transform.localPosition;
        if (Input.GetKey(KeyCode.D))
        {
            //velocity.x += 0.1f;
            this.transform.Translate(0.1f, 0, 0, Space.Self);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //velocity.x += -0.1f;
            this.transform.Translate(-0.1f, 0, 0, Space.Self);
        }
        else
        {
            //velocity.x += 0;
        }
        //this.transform.localPosition = velocity;
        if (Input.GetKeyDown(KeyCode.R))
        {
            _rotMode = true;
            r -= 3;
        }



    }
    void FixedUpdate()
    {
        if (_rotMode)
        {
            
            if(r % 90 != 0)
            {
                r -= 3;
            }
            else
            {
                _rotMode = false;
            }
            transform.rotation = Quaternion.Euler(0, r, 0);
        }
    }
}
