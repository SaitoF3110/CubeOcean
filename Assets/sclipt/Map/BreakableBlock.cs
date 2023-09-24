using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class BreakableBlock : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _se;
    bool _active = true;
    [SerializeField] float _intervalSec = 1;
    float _time;
    Collider m_ObjectCollider;
    private void Start()
    {
        m_ObjectCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if(!_active)
        {
            this.GetComponent<Renderer>().material.color -= new Color(0, 0, 0, this.GetComponent<Renderer>().material.color.a);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(_active)
        {
            if (other.gameObject.tag == "Explosion")
            {
                m_ObjectCollider.isTrigger = true;
                Instantiate(_se);
                _active = false;
            }
        }

    }
}
