using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBomb : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject bomb;
    bool _finish = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_finish)
        {
            this.GetComponent<Renderer>().material.color -= new Color(0, 0, 0, this.GetComponent<Renderer>().material.color.a);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerAttack" && !_finish)
        {
            Instantiate(bomb, this.transform);
            _finish = true;
        }
    }
}
