using System;
using System.IO;
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

    [Header("Save config")] 
    [SerializeField] private string saveFileParameters = "parameters.json";
    [SerializeField] private string saveFileUpgradesCost = "UpgradesCost.json";
    [SerializeField] private string saveFileCoins = "coins.json";

    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI cashText;

    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        savePath = Path.Combine(Application.persistentDataPath, saveFilePatameters);
        savePath = Path.Combine(Application.persistentDataPath, saveFileUpgradesCost);
        savePath = Path.Combine(Application.persistentDataPath, saveFileCoins);
#else
        savePathParameters = Path.Combine(Application.dataPath, saveFileParameters);
        savePathUpgradesCost = Path.Combine(Application.dataPath, saveFileUpgradesCost);
        savePathCoins = Path.Combine(Application.dataPath, saveFileCoins);
#endif
        
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
        GunParametersStruct gameCore = new GunParametersStruct()
        {
            damage = _gunParameters.damage,
            reload = _gunParameters.reload,
            firingRange = _gunParameters.firingRange,
            maxhp = _maxhp,
            absoluteDefence = _absoluteDefense,
            hpRegen = _hpRegen,
            cashPerWave = CashPerWave,
            coinsPerWave = CoinsPerWave,
            cashKill = CashKill,
            coinsPerKill = CoinsPerKill
            
        };

        string json = JsonUtility.ToJson(gameCore, true);

        try
        {
            File.WriteAllText(savePathParameters, json);
        }
        catch (Exception e)
        {
            Debug.Log( "{GameLog} => [GameCore] - (<color=red>Error</color>) - SaveToFile" + e.Message);
        }
    }
    
    public void LoadParametersFromFile()
    {
        if (!File.Exists(savePathParameters))
        {
            Debug.Log("{GameLog} => [GameCore] - LoadFromFile -> File Not Found");
            return;
        }

        try
        {
            string json = File.ReadAllText(savePathParameters);
            GunParametersStruct parametersFromJson = JsonUtility.FromJson<GunParametersStruct>(json);

            _gunParameters.damage = parametersFromJson.damage;
            _gunParameters.reload = parametersFromJson.reload;
            _gunParameters.firingRange = parametersFromJson.firingRange;
            _maxhp = parametersFromJson.maxhp;
            _absoluteDefense = parametersFromJson.absoluteDefence;
            _hpRegen = parametersFromJson.hpRegen;
            CashPerWave = parametersFromJson.cashPerWave;
            CoinsPerWave = parametersFromJson.coinsPerWave;
            CashKill = parametersFromJson.cashKill;
            CoinsPerKill = parametersFromJson.coinsPerKill;
        }
        catch (Exception e)
        {
            Debug.Log( "{GameLog} => [GameCore] - (<color=red>Error</color>) - SaveToFile" + e.Message);
        }
    }
    
    public void SaveCoinsToFile()
    {
        CoinsStruct gameCore = new CoinsStruct()
        {
            coins = _coinsCount
        };

        string json = JsonUtility.ToJson(gameCore, true);

        try
        {
            File.WriteAllText(savePathCoins, json);
        }
        catch (Exception e)
        {
            Debug.Log( "{GameLog} => [GameCore] - (<color=red>Error</color>) - SaveToFile" + e.Message);
        }
    }
    
    public void LoadCoinsFromFile()
    {
        if (!File.Exists(savePathCoins))
        {
            Debug.Log("{GameLog} => [GameCore] - LoadFromFile -> File Not Found");
            return;
        }

        try
        {
            string json = File.ReadAllText(savePathCoins);
            CoinsStruct parametersFromJson = JsonUtility.FromJson<CoinsStruct>(json);

            ChangeCoinsValue(parametersFromJson.coins);
            
            
        }
        catch (Exception e)
        {
            Debug.Log( "{GameLog} => [GameCore] - (<color=red>Error</color>) - SaveToFile" + e.Message);
        }
    }
    
    public void SaveCoinsUpgradesCostToFile()
    {
        CoinsUpgradesCostStruct gameCore = new CoinsUpgradesCostStruct()
        {
            damageCost = _damageCost,
            reloadCost = _reloadCost,
            firingRangeCost = _firingRangeCost,
            maxhpCost = _maxhpCost,
            absoluteDefenseCost = _absoluteDefenseCost,
            hpRegenCost = _hpRegenCost,
            cashPerWaveCost = _cashPerWaveCost,
            coinsPerWaveCost = _coinsPerWaveCost,
            cashKillCost = _cashKillCost,
            coinsPerKillCost = _coinsPerKillCost
            
        };

        string json = JsonUtility.ToJson(gameCore, true);

        try
        {
            File.WriteAllText(savePathUpgradesCost, json);
        }
        catch (Exception e)
        {
            Debug.Log( "{GameLog} => [GameCore] - (<color=red>Error</color>) - SaveToFile" + e.Message);
        }
    }
    
    public void LoadCoinsUpgradesCostFromFile()
    {
        if (!File.Exists(savePathUpgradesCost))
        {
            Debug.Log("{GameLog} => [GameCore] - LoadFromFile -> File Not Found");
            return;
        }

        try
        {
            string json = File.ReadAllText(savePathUpgradesCost);
            CoinsUpgradesCostStruct parametersFromJson = JsonUtility.FromJson<CoinsUpgradesCostStruct>(json);

            _damageCost = parametersFromJson.damageCost;
            _reloadCost = parametersFromJson.reloadCost;
            _firingRangeCost = parametersFromJson.firingRangeCost;
            _maxhpCost = parametersFromJson.maxhpCost;
            _absoluteDefenseCost = parametersFromJson.absoluteDefenseCost;
            _hpRegenCost = parametersFromJson.hpRegenCost;
            _cashPerWaveCost = parametersFromJson.cashPerWaveCost;
            _coinsPerWaveCost = parametersFromJson.coinsPerWaveCost;
            _cashKillCost = parametersFromJson.cashKillCost;
            _coinsPerKillCost = parametersFromJson.coinsPerKillCost;
        }
        catch (Exception e)
        {
            Debug.Log( "{GameLog} => [GameCore] - (<color=red>Error</color>) - SaveToFile" + e.Message);
        }
    }
    
    
    
   

    private void OnApplicationQuit()
    {
        SaveCoinsToFile();
        SaveCoinsUpgradesCostToFile();
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
