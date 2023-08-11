using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class BreakableBlock : BlockController
{
    // Start is called before the first frame update
    [SerializeField] GameObject _se;
    public override void WhenRotate()
    {

    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerAttack")
        {
            
            Instantiate(_se);
            Destroy(this.gameObject);
        }
    }
}
