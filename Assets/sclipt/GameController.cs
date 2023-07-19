using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector3 _player;
    public static Vector3 _intPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //_player‚ÌŠe”’l‚ğintŒ^‚É•ÏŠ·‚µ_intPlayer‚É‘ã“ü
        _intPlayer.x = (int)_player.x;
        _intPlayer.y = (int)_player.y;
        _intPlayer.z = (int)_player.z;
    }
}
