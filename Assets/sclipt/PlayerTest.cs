using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerTest : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody _rb;
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
    }
}
