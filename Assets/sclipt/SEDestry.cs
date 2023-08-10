using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEDestry : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float _livingTime = 5;
    float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > _livingTime) 
        {
            Destroy(this.gameObject);
        }
    }
}
