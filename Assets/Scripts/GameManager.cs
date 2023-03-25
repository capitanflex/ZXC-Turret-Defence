using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Attack Parameters")]
    public GunParameters _gunParameters;
    
    [Header("Def Parameters")]
    public float _maxhp;
    public float _hpRegen;
    public float _absoluteDefense;

    [Header("Money Parameters")] 
    public int CashPerWave;
    public int CoinsPerWave;
    public int CashKill;
    public int CoinsPerKill;
    
    [Header("Coins Upgrades Parameters")] 
    public int _firingRangeCost;
    public int _damageCost;
    public int _reloadCost;
    public int _maxhpCost;
    public int _hpRegenCost;
    public int _absoluteDefenseCost;
    public int _cashPerWaveCost;
    public int _coinsPerWaveCost;
    public int _cashKillCost;
    public int _coinsPerKillCost;
    
    [Header("Money")]
    public int _coinsCount;
    public int _cashCount;
    
    private string savePathParameters;
    private string savePathUpgradesCost;
    private string savePathCoins;
    

    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI cashText;

    private void Awake()
    {
       
        if (!PlayerPrefs.HasKey("firstTime")) {
            PlayerPrefs.SetInt("firstTime", 1);
            SaveParametersToFile();
            SaveCoinsToFile();
            SaveCoinsUpgradesCostToFile();
            print("firstTime");
        }
        
        LoadParametersFromFile();
        LoadCoinsFromFile();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            LoadCoinsUpgradesCostFromFile();
        }
        
    }

    public void ChangeCoinsValue(int value)
    {
        _coinsCount += value;
        coinsText.text = "Coins: " + _coinsCount + "₵";
    }
    
    public void ChangeCashValue(int value)
    {
        _cashCount += value;
        cashText.text = "Cash: " + _cashCount + "$";
    }
    
    public void SaveParametersToFile()
    {
        PlayerPrefs.SetFloat("damage",_gunParameters.damage);
        PlayerPrefs.SetFloat("reload",_gunParameters.reload);
        PlayerPrefs.SetFloat("firingRange",_gunParameters.firingRange);
        PlayerPrefs.SetFloat("maxhp",_maxhp);
        PlayerPrefs.SetFloat("absoluteDefence",_absoluteDefense);
        PlayerPrefs.SetFloat("hpRegen",_hpRegen);
        PlayerPrefs.SetInt("cashPerWave",CashPerWave);
        PlayerPrefs.SetInt("cashPerWave",CoinsPerWave);
        PlayerPrefs.SetInt("cashKill",CashKill);
        PlayerPrefs.SetInt("coinsPerKill",CoinsPerKill);
    }
    
    public void LoadParametersFromFile()
    {
        _gunParameters.damage = PlayerPrefs.GetFloat("damage");
        _gunParameters.reload = PlayerPrefs.GetFloat("reload");
        _gunParameters.firingRange =  PlayerPrefs.GetFloat("firingRange");
        _maxhp =  PlayerPrefs.GetFloat("maxhp");
        _absoluteDefense = PlayerPrefs.GetFloat("absoluteDefence");
        _hpRegen = PlayerPrefs.GetFloat("hpRegen");
        CashPerWave = PlayerPrefs.GetInt("cashPerWave");
        CoinsPerWave = PlayerPrefs.GetInt("cashPerWave");
        CashKill = PlayerPrefs.GetInt("cashKill");
        CoinsPerKill = PlayerPrefs.GetInt("coinsPerKill");
    }
    
    public void SaveCoinsToFile()
    {
        PlayerPrefs.SetInt("coins",_coinsCount);
    }
    
    public void LoadCoinsFromFile()
    {
        _coinsCount = PlayerPrefs.GetInt("coins");
        coinsText.text = "Coins: " + _coinsCount + "₵";
    }
    
    public void SaveCoinsUpgradesCostToFile()
    {
        PlayerPrefs.SetInt("damageCost",_damageCost);
        PlayerPrefs.SetInt("reloadCost",_reloadCost);
        PlayerPrefs.SetInt("firingRangeCost",_firingRangeCost);
        PlayerPrefs.SetInt("absoluteDefenseCost",_absoluteDefenseCost);
        PlayerPrefs.SetInt("hpRegenCost",_hpRegenCost);
        PlayerPrefs.SetInt("maxhpCost",_maxhpCost);
        PlayerPrefs.SetInt("cashPerWaveCost",_cashPerWaveCost);
        PlayerPrefs.SetInt("coinsPerWaveCost",_coinsPerWaveCost);
        PlayerPrefs.SetInt("cashKillCost",_cashKillCost);
        PlayerPrefs.SetInt("coinsPerKillCost",_coinsPerKillCost);
    }
    
    public void LoadCoinsUpgradesCostFromFile()
    {
        _damageCost = PlayerPrefs.GetInt("damageCost");
        _reloadCost = PlayerPrefs.GetInt("reloadCost");
        _firingRangeCost = PlayerPrefs.GetInt("firingRangeCost");
        _absoluteDefenseCost = PlayerPrefs.GetInt("absoluteDefenseCost");
        _maxhpCost = PlayerPrefs.GetInt("maxhpCost");
        _hpRegenCost = PlayerPrefs.GetInt("hpRegenCost");
        _cashPerWaveCost = PlayerPrefs.GetInt("cashPerWaveCost");
        _coinsPerWaveCost = PlayerPrefs.GetInt("coinsPerWaveCost");
        _cashKillCost = PlayerPrefs.GetInt("cashKillCost");
        _coinsPerKillCost = PlayerPrefs.GetInt("coinsPerKillCost");
   
    }
    
    
    
   

    private void OnApplicationQuit()
    {
        SaveCoinsToFile();
        SaveCoinsUpgradesCostToFile();
    }

    public void Quit()
    {
        SaveCoinsToFile();
        SaveCoinsUpgradesCostToFile();
        Application.Quit();
    }

    public void StartBattleButton()
    {
        SaveParametersToFile();
        SaveCoinsToFile();
        SaveCoinsUpgradesCostToFile();
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SaveCoinsToFile();
        SceneManager.LoadScene(0);
    }
        
}
