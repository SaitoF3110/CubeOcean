using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRecipeController : MonoBehaviour,IPause
{
    [SerializeField] GameObject _recipeFrame;
    [SerializeField] List<RecipeDataManager> _recipeData = new List<RecipeDataManager>();//���J�����V�s�̃��X�g
    public List<RecipeDataManager> _playerRecipeData = new List<RecipeDataManager>();//�v���C���[�������Ă��郌�V�s�̃��X�g
    GameObject _player;
    PlayerItem _pl;
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _pl = _player.GetComponent<PlayerItem>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Pause()
    {
        for (int i = 0; _recipeData.Count > i; i++)//�S�Ă̖��J�����V�s������
        {
            List<bool> _itemBools = new List<bool>();//���V�s���ƂɃA�C�e���̗L�����i�[
            for (int j = 0; j < _recipeData[i]._requiredItems.Length; j++)//���V�s���̕K�v�A�C�e�������邩�ǂ���
            {               
                foreach (KeyValuePair<ItemDataManager, int> item in _pl._itemDictionary)//�A�C�e�����X�g���S����
                {
                    if (item.Key == _recipeData[i]._requiredItems[j])//�A�C�e������������bools�ɒǉ�
                    {
                        _itemBools.Add(true);
                        break;
                    }
                }
            }
            if( _itemBools.Count == _recipeData[i]._requiredItems.Length)//������v���Ă����烌�V�s�J��
            {
                _playerRecipeData.Add(_recipeData[i]);
                _recipeData.Remove(_recipeData[i]);
                break;
            }
        }
        //���V�sUI�`��
        for (int i = 0; _playerRecipeData.Count > i; i++)
        {
            GameObject _frame = Instantiate(_recipeFrame, this.transform.position, transform.rotation, this.gameObject.transform) as GameObject;
            _frame.transform.localPosition = new Vector3(169, i * -110, 0);
            UIRecipe _ui = _frame.GetComponent<UIRecipe>();
            _ui._recipeData = _playerRecipeData[i];
        }
    }
    public void Resume()
    {
        
    }
}
