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
            _time += Time.deltaTime;
            if(_time > _intervalSec)
            {
                _time = 0;
                m_ObjectCollider.isTrigger = false;
                //this.GetComponent<Renderer>().material.color += new Color(0, 0, 0, 1);
                _active = true;
                
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(_active)
        {
            if (other.gameObject.tag == "PlayerAttack")
            {
                m_ObjectCollider.isTrigger = true;
                Instantiate(_se);
                _active = false;
            }
        }

    }
}
