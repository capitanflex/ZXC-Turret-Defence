using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Upgrades : MonoBehaviour
{
    [Header("Choose Button")]
    [SerializeField] private ButtonsList _button;
    
    private GameManager _gameManager;
    private GatlingGunTestScript _gatlingGunTestScript;
  
    
    [SerializeField] private TextMeshProUGUI textButtonInfo;
    

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gatlingGunTestScript = FindObjectOfType<GatlingGunTestScript>();
        
        if (_button == ButtonsList.Damage)
        {
            textButtonInfo.text = " Damage \n Current: " + _gameManager._gunParameters.damage;
        }
        if (_button == ButtonsList.AttackSpeed)
        {
            textButtonInfo.text = " Reload \n Current: " + _gameManager._gunParameters.reload;
        }
        if (_button == ButtonsList.AttackRange)
        {
            textButtonInfo.text = " Attack range \n Current: " + _gameManager._gunParameters.firingRange;
        }
        if (_button == ButtonsList.MaxHp)
        {
            textButtonInfo.text = " MaxHp \n Current: " + _gameManager._maxhp;
        }
        if (_button == ButtonsList.Regen)
        {
            textButtonInfo.text = " HP regen \n Current: " + _gameManager._hpRegen;
        }
        if (_button == ButtonsList.AbsoluteDefense)
        {
            textButtonInfo.text = " Absolute Defense \n Current: " + _gameManager._absoluteDefense;
        }
    }


    
    
    public void AttackUpgrade()
    {
        _gameManager._gunParameters.damage = (float)Math.Round(_gameManager._gunParameters.damage * 1.25f, 2);
        textButtonInfo.text = " Damage \n Current: " + _gameManager._gunParameters.damage;
    }

    public void SpeedUpgrade()
    {
        _gameManager._gunParameters.reload = (float)Math.Round(_gameManager._gunParameters.reload * 0.9f, 2);
        textButtonInfo.text = " Reload \n Current: " + _gameManager._gunParameters.reload;
    }
    
    public void DistanceUpgrade()
    {
        _gameManager._gunParameters.firingRange = (float)Math.Round(_gameManager._gunParameters.firingRange * 1.05f, 2);
        textButtonInfo.text = " Attack range \n Current: " + _gameManager._gunParameters.firingRange;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            _gatlingGunTestScript.UpdateRange(); 
        }
    }
    
    public void MaxHpUpgrade()
    {
        _gameManager._maxhp = (float)Math.Round(_gameManager._maxhp * 1.1f, 2);
        textButtonInfo.text = " MaxHp \n Current: " + _gameManager._maxhp;
    }
    
    public void RegenUpgrade()
    {
        _gameManager._hpRegen = (float)Math.Round(_gameManager._hpRegen * 1.15f, 2);
        textButtonInfo.text = " HP regen \n Current: " + _gameManager._hpRegen;
    }
    
    public void AbsoluteDefenseUpgrade()
    {
        _gameManager._absoluteDefense = (float)Math.Round(_gameManager._absoluteDefense * 1.15f + 1, 2);
        textButtonInfo.text = " Absolute Defense \n Current: " + _gameManager._absoluteDefense;
    }
    
    
    
    public enum ButtonsList
    {
        Damage = 0,
        AttackSpeed = 1,
        AttackRange = 2,
        MaxHp = 3,
        Regen = 4,
        AbsoluteDefense = 5
        
    }
}
