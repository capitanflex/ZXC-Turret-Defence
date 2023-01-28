using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private GatlingGunTestScript _gatlingGunTestScript;
    
    [SerializeField] private TextMeshProUGUI textButtonInfo;
    [SerializeField] private ButtonsList _button;

    private void Awake()
    {
        _gatlingGunTestScript = FindObjectOfType<GatlingGunTestScript>();
        if (_button == ButtonsList.Damage)
        {
            textButtonInfo.text = " Damage \n Current: " + _gatlingGunTestScript._gunParameters.damage;
        }
        if (_button == ButtonsList.AttackSpeed)
        {
            textButtonInfo.text = " Reload \n Current: " + _gatlingGunTestScript._gunParameters.reload;
        }
        if (_button == ButtonsList.AttackRange)
        {
            textButtonInfo.text = " Attack range \n Current: " + _gatlingGunTestScript._gunParameters.firingRange;
        }
    }


    
    
    public void AttackUpgrade()
    {
        _gatlingGunTestScript._gunParameters.damage = (float)Math.Round(_gatlingGunTestScript._gunParameters.damage * 1.25f, 2);
        textButtonInfo.text = " Damage \n Current: " + _gatlingGunTestScript._gunParameters.damage;
    }

    public void SpeedUpgrade()
    {
        _gatlingGunTestScript._gunParameters.reload = (float)Math.Round(_gatlingGunTestScript._gunParameters.reload * 0.9f, 2);
        textButtonInfo.text = " Reload \n Current: " + _gatlingGunTestScript._gunParameters.reload;
    }
    
    public void DistanceUpgrade()
    {
        _gatlingGunTestScript._gunParameters.firingRange = (float)Math.Round(_gatlingGunTestScript._gunParameters.firingRange * 1.05f, 2);
        textButtonInfo.text = " Attack range \n Current: " + _gatlingGunTestScript._gunParameters.firingRange;
        _gatlingGunTestScript.UpdateRange();
    }
    public enum ButtonsList
    {
        Damage = 0,
        AttackSpeed = 1,
        AttackRange = 2,
        
    }
}
