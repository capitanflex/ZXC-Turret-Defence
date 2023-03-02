using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Upgrades : MonoBehaviour
{
    private int SceneId;
    
    [Header("Choose Button")]
    [SerializeField] private ButtonsList _button;
    
    [Header("Cash price")]
    [SerializeField] private int _cashPrice;
    
    
    [SerializeField] private TextMeshProUGUI textButtonInfo;
    [SerializeField] private TextMeshProUGUI textCostUpgrade;
    
    private GameManager _gameManager;
    private PlayerBehaviour _playerBehaviour;
    private GatlingGunTestScript _gatlingGunTestScript;

    private int _sceneId;
  
    
    

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _playerBehaviour = FindObjectOfType<PlayerBehaviour>();
        _gatlingGunTestScript = FindObjectOfType<GatlingGunTestScript>();
        
        
        
        if (_button == ButtonsList.Damage)
        {
            textButtonInfo.text = "Damage \n Current: " + _gameManager._gunParameters.damage;
        }
        if (_button == ButtonsList.AttackSpeed)
        {
            textButtonInfo.text = "Reload \n Current: " + _gameManager._gunParameters.reload;
        }
        if (_button == ButtonsList.AttackRange)
        {
            textButtonInfo.text = "Attack range \n Current: " + _gameManager._gunParameters.firingRange;
        }
        if (_button == ButtonsList.MaxHp)
        {
            textButtonInfo.text = "MaxHp \n Current: " + _gameManager._maxhp;
        }
        if (_button == ButtonsList.Regen)
        {
            textButtonInfo.text = "HP regen \n Current: " + _gameManager._hpRegen;
        }
        if (_button == ButtonsList.AbsoluteDefense)
        {
            textButtonInfo.text = "Absolute Defense \n Current: " + _gameManager._absoluteDefense;
        }
        if (_button == ButtonsList.CoinsPerWave)
        {
            textButtonInfo.text = "Coins Per Wave \n Current: " + _gameManager.CoinsPerWave;
        }
        if (_button == ButtonsList.CoinsPerKill)
        {
            textButtonInfo.text = "Coins Per Kill \n Current: " + _gameManager.CoinsPerKill;
        }
        if (_button == ButtonsList.CashKill)
        {
            textButtonInfo.text = "Cash Per Kill \n Current: " + _gameManager.CashKill;
        }
        if (_button == ButtonsList.CashPerWave)
        {
            textButtonInfo.text = "Cash Per Wave \n Current: " + _gameManager.CashPerWave;
        }

        _sceneId = SceneManager.GetActiveScene().buildIndex;
        
        if (_sceneId == 0)
        {
            if (_button == ButtonsList.Damage)
            {
                textCostUpgrade.text = " Cost: " + _gameManager._damageCost + "₵";
            }
            if (_button == ButtonsList.AttackSpeed)
            {
                textCostUpgrade.text = " Cost: " + _gameManager._reloadCost + "₵";
            }
            if (_button == ButtonsList.AttackRange)
            {
                textCostUpgrade.text = " Cost: " + _gameManager._firingRangeCost + "₵";
            }
            if (_button == ButtonsList.MaxHp)
            {
                textCostUpgrade.text = " Cost: " + _gameManager._maxhpCost + "₵";
            }
            if (_button == ButtonsList.Regen)
            {
                textCostUpgrade.text = " Cost: " + _gameManager._hpRegenCost + "₵";
            }
            if (_button == ButtonsList.AbsoluteDefense)
            {
                textCostUpgrade.text = " Cost: " + _gameManager._absoluteDefenseCost + "₵";
            }
            if (_button == ButtonsList.CoinsPerWave)
            {
                textCostUpgrade.text = " Cost: " + _gameManager._coinsPerWaveCost + "₵";
            }
            if (_button == ButtonsList.CoinsPerKill)
            {
                textCostUpgrade.text = " Cost: " + _gameManager._coinsPerKillCost + "₵";
            }
            if (_button == ButtonsList.CashKill)
            {
                textCostUpgrade.text = " Cost: " + _gameManager._cashKillCost + "₵";
            }
            if (_button == ButtonsList.CashPerWave)
            {
                textCostUpgrade.text = " Cost: " + _gameManager._cashPerWaveCost + "₵";
            }
        }
        else
        {
            textCostUpgrade.text = "Cost: " + _cashPrice + "$";
        }
    }
    
    
    public void AttackUpgrade()
    {
        
        if (_sceneId == 0 && _gameManager._coinsCount >= _gameManager._damageCost)
        {
            _gameManager.ChangeCoinsValue(-_gameManager._damageCost);
            _gameManager._gunParameters.damage = (float)Math.Round(_gameManager._gunParameters.damage * 1.25f, 2);
            _gameManager._damageCost = (int)Math.Round(_gameManager._damageCost*1.45f);
            textCostUpgrade.text = "Cost: " + _gameManager._damageCost + "₵";
        }
        if(_sceneId == 1 && _gameManager._cashCount >= _cashPrice)
        {
            _gameManager.ChangeCashValue(-_cashPrice);
            _gameManager._gunParameters.damage = (float)Math.Round(_gameManager._gunParameters.damage * 1.25f, 2);
            _cashPrice = (int)Math.Round(_cashPrice * 1.3f, 2);
            textCostUpgrade.text = "Cost: " + _cashPrice + "$";
        }
        textButtonInfo.text = "Damage \n Current: " + _gameManager._gunParameters.damage;
    }

    public void SpeedUpgrade()
    {
 
        
        if (_sceneId == 0 && _gameManager._coinsCount >= _gameManager._reloadCost)
        {
            _gameManager.ChangeCoinsValue(-_gameManager._reloadCost);
            _gameManager._gunParameters.reload = (float)Math.Round(_gameManager._gunParameters.reload * 0.9f, 2);
            _gameManager._reloadCost = (int)Math.Round(_gameManager._reloadCost*1.4f);
            textCostUpgrade.text = "Cost: " + _gameManager._reloadCost + "₵";
        }
        if(_sceneId == 1 && _gameManager._cashCount >= _cashPrice)
        {
            _gameManager.ChangeCashValue(-_cashPrice);
            _cashPrice = (int)Math.Round(_cashPrice * 1.3f, 2);
            textCostUpgrade.text = "Cost: " + _cashPrice + "$";
            _gameManager._gunParameters.reload = (float)Math.Round(_gameManager._gunParameters.reload * 0.9f, 2);

        }
        textButtonInfo.text = "Reload \n Current: " + _gameManager._gunParameters.reload;
    }
    
    public void DistanceUpgrade()
    {
        
        
        if (_sceneId == 0 && _gameManager._coinsCount >= _gameManager._firingRangeCost)
        {
            _gameManager.ChangeCoinsValue(-_gameManager._firingRangeCost);
            _gameManager._firingRangeCost = (int)Math.Round(_gameManager._firingRangeCost*1.25f);
            textCostUpgrade.text = "Cost: " + _gameManager._firingRangeCost + "₵";
            _gameManager._gunParameters.firingRange = (float)Math.Round(_gameManager._gunParameters.firingRange * 1.05f, 2);
        }
        if(_sceneId == 1 && _gameManager._cashCount >= _cashPrice)
        {
            _gameManager.ChangeCashValue(-_cashPrice);
            _cashPrice = (int)Math.Round(_cashPrice * 1.3f, 2);
            textCostUpgrade.text = "Cost: " + _cashPrice + "$";
            _gatlingGunTestScript.UpdateRange();
            _gameManager._gunParameters.firingRange = (float)Math.Round(_gameManager._gunParameters.firingRange * 1.05f, 2);
            
        }
        textButtonInfo.text = "Attack range \n Current: " + _gameManager._gunParameters.firingRange;
    }
    
    public void MaxHpUpgrade()
    {
        
        

        if (_sceneId == 0 && _gameManager._coinsCount >= _gameManager._maxhpCost)
        {
            _gameManager.ChangeCoinsValue(-_gameManager._maxhpCost);
            _gameManager._maxhpCost = (int)Math.Round(_gameManager._maxhpCost*1.35f);
            textCostUpgrade.text = "Cost: " + _gameManager._maxhpCost + "₵";
            _gameManager._maxhp = (float)Math.Round(_gameManager._maxhp * 1.1f);
        }
        if(_sceneId == 1 && _gameManager._cashCount >= _cashPrice)
        {
            _gameManager.ChangeCashValue(-_cashPrice);
            _cashPrice = (int)Math.Round(_cashPrice * 1.3f, 2);
            textCostUpgrade.text = "Cost: " + _cashPrice + "$";
            _playerBehaviour.UpdateParameters();
            _gameManager._maxhp = (float)Math.Round(_gameManager._maxhp * 1.1f);

        }
        textButtonInfo.text = "MaxHp \n Current: " + _gameManager._maxhp;
    }
    
    public void RegenUpgrade()
    {
        
        
        
        if (_sceneId == 0 && _gameManager._coinsCount >= _gameManager._hpRegenCost)
        {
            _gameManager.ChangeCoinsValue(-_gameManager._hpRegenCost);
            _gameManager._hpRegenCost = (int)Math.Round(_gameManager._hpRegenCost*1.3f);
            textCostUpgrade.text = "Cost: " + _gameManager._hpRegenCost + "₵";
            _gameManager._hpRegen = (float)Math.Round(_gameManager._hpRegen * 1.15f, 1);
        }
        if(_sceneId == 1 && _gameManager._cashCount >= _cashPrice)
        {
            _gameManager.ChangeCashValue(-_cashPrice);
            _cashPrice = (int)Math.Round(_cashPrice * 1.3f, 2);
            textCostUpgrade.text = "Cost: " + _cashPrice + "$";
            _playerBehaviour.UpdateParameters();
            _gameManager._hpRegen = (float)Math.Round(_gameManager._hpRegen * 1.15f, 1);
        }
        textButtonInfo.text = "HP regen \n Current: " + _gameManager._hpRegen;
    }
    
    public void AbsoluteDefenseUpgrade()
    {
       
        
        
        if (_sceneId == 0 && _gameManager._coinsCount >= _gameManager._absoluteDefenseCost)
        {
            _gameManager.ChangeCoinsValue(-_gameManager._absoluteDefenseCost);
            _gameManager._absoluteDefenseCost = (int)Math.Round(_gameManager._absoluteDefenseCost*1.3f);
            textCostUpgrade.text = "Cost: " + _gameManager._absoluteDefenseCost + "₵";
            _gameManager._absoluteDefense = (float)Math.Round(_gameManager._absoluteDefense * 1.15f + 1, 1);
        }
        if(_sceneId == 1 && _gameManager._cashCount >= _cashPrice)
        {
            _gameManager.ChangeCashValue(-_cashPrice);
            _cashPrice = (int)Math.Round(_cashPrice * 1.3f, 2);
            textCostUpgrade.text = "Cost: " + _cashPrice + "$";
            _playerBehaviour.UpdateParameters();
            _gameManager._absoluteDefense = (float)Math.Round(_gameManager._absoluteDefense * 1.15f + 1, 1);

        }
        textButtonInfo.text = "Absolute Defense \n Current: " + _gameManager._absoluteDefense;
    }
    
    public void CoinsPerWaveUpgrade()
    {
        
        
        if (_sceneId == 0 && _gameManager._coinsCount >= _gameManager._coinsPerWaveCost)
        {
            _gameManager.ChangeCoinsValue(-_gameManager._coinsPerWaveCost);
            _gameManager._coinsPerWaveCost = (int)Math.Round(_gameManager._coinsPerWaveCost*1.4f);
            textCostUpgrade.text = "Cost: " + _gameManager._coinsPerWaveCost + "₵";
            _gameManager.CoinsPerWave = (int)Math.Round(_gameManager.CoinsPerWave * 1.1f + 4);
        }
        if(_sceneId == 1 && _gameManager._cashCount >= _cashPrice)
        {
            _gameManager.ChangeCashValue(-_cashPrice);
            _cashPrice = (int)Math.Round(_cashPrice * 1.3f, 2);
            textCostUpgrade.text = "Cost: " + _cashPrice + "$";
            _gameManager.CoinsPerWave = (int)Math.Round(_gameManager.CoinsPerWave * 1.1f + 4);

        }
        textButtonInfo.text = "Coins Per Wave \n Current: " + _gameManager.CoinsPerWave;
    }
    
    public void CoinsPerKillUpgrade()
    {
        
        
        if (_sceneId == 0 && _gameManager._coinsCount >= _gameManager._coinsPerKillCost)
        {
            _gameManager.ChangeCoinsValue(-_gameManager._coinsPerKillCost);
            _gameManager._coinsPerKillCost = (int)Math.Round(_gameManager._coinsPerKillCost*1.5f);
            textCostUpgrade.text = "Cost: " + _gameManager._coinsPerKillCost + "₵";
            _gameManager.CoinsPerKill = (int)Math.Round(_gameManager.CoinsPerKill * 1.05f + 1);
        }
        if(_sceneId == 1 && _gameManager._cashCount >= _cashPrice)
        {
            _gameManager.ChangeCashValue(-_cashPrice);
            _cashPrice = (int)Math.Round(_cashPrice * 1.3f, 2);
            textCostUpgrade.text = "Cost: " + _cashPrice + "$";
            _gameManager.CoinsPerKill = (int)Math.Round(_gameManager.CoinsPerKill * 1.05f + 1);

        }
        textButtonInfo.text = "Coins Per Kill \n Current: " + _gameManager.CoinsPerKill;
    }
    
    public void CashPerWaveUpgrade()
    {
        
        if (_sceneId == 0 && _gameManager._coinsCount >= _gameManager._cashPerWaveCost)
        {
            _gameManager.ChangeCoinsValue(-_gameManager._cashPerWaveCost);
            _gameManager.CashPerWave = (int)Math.Round(_gameManager.CashPerWave * 1.1f + 20);
            _gameManager._cashPerWaveCost = (int)Math.Round(_gameManager._cashPerWaveCost*1.25f);
            textCostUpgrade.text = "Cost: " + _gameManager._cashPerWaveCost + "₵";
        }
        if(_sceneId == 1 && _gameManager._cashCount >= _cashPrice)
        {
            _gameManager.CashPerWave = (int)Math.Round(_gameManager.CashPerWave * 1.1f + 20);
            _gameManager.ChangeCashValue(-_cashPrice);
            _cashPrice = (int)Math.Round(_cashPrice * 1.3f, 2);
            textCostUpgrade.text = "Cost: " + _cashPrice + "$";
        }
        textButtonInfo.text = "Cash Per Wave \n Current: " + _gameManager.CashPerWave;
    }
    
    public void CashKillUpgrade()
    {
        
        
        if (_sceneId == 0 && _gameManager._coinsCount >= _gameManager._cashKillCost)
        {
            _gameManager.ChangeCoinsValue(-_gameManager._cashKillCost);
            _gameManager._cashKillCost = (int)Math.Round(_gameManager._cashKillCost*1.2f);
            textCostUpgrade.text = "Cost: " + _gameManager._cashKillCost + "₵";
            _gameManager.CashKill = (int)Math.Round(_gameManager.CashKill * 1.1f + 1);
        }
        if(_sceneId == 1 && _gameManager._cashCount >= _cashPrice)
        {
            _gameManager.ChangeCashValue(-_cashPrice);
            _cashPrice = (int)Math.Round(_cashPrice * 1.3f, 2);
            textCostUpgrade.text = "Cost: " + _cashPrice + "$";
            _gameManager.CashKill = (int)Math.Round(_gameManager.CashKill * 1.1f + 1);

        }
        textButtonInfo.text = "Cash Per Kill \n Current: " + _gameManager.CashKill;
    }
    
    
    
    public enum ButtonsList
    {
        Damage = 0,
        AttackSpeed = 1,
        AttackRange = 2,
        MaxHp = 3,
        Regen = 4,
        AbsoluteDefense = 5,
        CoinsPerWave = 6,
        CoinsPerKill = 7,
        CashPerWave = 8,
        CashKill = 9
        
    }
}
