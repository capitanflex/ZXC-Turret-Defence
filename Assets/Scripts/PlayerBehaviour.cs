using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float _hp;
    
    public float _maxhp;
    public float _hpRegen;
    public float _absoluteDefense;

    [SerializeField] private TextMeshProUGUI hpGUI;
    
    private GameManager _gameManager;

    private void Start()
    {
        _maxhp = _gameManager._maxhp;
        _hpRegen = _gameManager._hpRegen;
        _absoluteDefense = _gameManager._absoluteDefense;
        _hp = _maxhp;
    }

    private void Update()
    {
        hpGUI.text = "HP: " + _hp;
        HpRegeneration();
    }

    public void GetDamage(float damage)
    {
        if (_absoluteDefense - damage < 0)
        {
            _hp -= _absoluteDefense - damage;
        }
        
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HpRegeneration()
    {
        if (_hp<_maxhp)
        {
            _hp += _hpRegen * Time.deltaTime;
        }
        
    }

}
