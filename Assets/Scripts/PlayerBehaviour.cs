using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float _hp;
    [SerializeField] private float _hpRegen;
    [SerializeField] private float _absoluteDefence;

    [SerializeField] private TextMeshProUGUI hpGUI;

    public void GetDamage(float damage)
    {
        if (_absoluteDefence - damage < 0)
        {
            _hp -= _absoluteDefence - damage;
        }
        
        print(_hp);
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HpRegeneration()
    {
        _hp += _hpRegen * Time.deltaTime;
    }

}
