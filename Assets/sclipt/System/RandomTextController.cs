using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RandomTextController : MonoBehaviour, IPause
{
    [SerializeField] string[] _strings;
    [SerializeField] Sprite[] _sprites;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause()
    {
        if(_strings.Length > 0)
        {
            int _random = Random.Range(0, _strings.Length);
            Text _text = this.GetComponent<Text>();
            _text.text = _strings[_random];
        }
        if(_sprites.Length > 0)
        {
            int _random = Random.Range(0, _sprites.Length);
            Image _image = this.GetComponent<Image>();
            _image.sprite = _sprites[_random];
        }
    }
    public void Resume()
    {

    }
}
