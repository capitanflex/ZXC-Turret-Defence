using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("AttackParameters")]
    public GunParameters _gunParameters;
    
    [Header("DefParameters")]
    public float _maxhp;
    public float _hpRegen;
    public float _absoluteDefense;
    
    [Header("Monye")]
    public int _coinsCount;
    public int _cashCount;

    [Header("Save config")] 
    [SerializeField] private string savePathParameters;
    [SerializeField] private string savePathCoins;
    [SerializeField] private string saveFilePatameters = "parameters.json";
    [SerializeField] private string saveFileCoins = "coins.json";
    
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI cashText;

    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        savePath = Path.Combine(Application.persistentDataPath, saveFilePatameters);
        savePath = Path.Combine(Application.persistentDataPath, saveFileCoins);
#else
        savePathParameters = Path.Combine(Application.dataPath, saveFilePatameters);
        savePathCoins = Path.Combine(Application.dataPath, saveFileCoins);
        
#endif
        LoadParametersFromFile();
        LoadCoinsFromFile();
    }

    public void ChangeCoinsValue(int value)
    {
        _coinsCount += value;
        coinsText.text = "Coins: " + _coinsCount;
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
            _hpRegen = parametersFromJson.maxhp;
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

    private void OnApplicationQuit()
    {
        SaveCoinsToFile();
        
    }

    public void StartBattle()
    {
        SaveParametersToFile();
        SaveCoinsToFile();
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SaveCoinsToFile();
        SceneManager.LoadScene(0);
    }
        
}
