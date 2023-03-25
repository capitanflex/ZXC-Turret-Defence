using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    private float _hp;
    
    public float _maxhp;
    public float _hpRegen;
    public float _absoluteDefense;

    [SerializeField] private TextMeshProUGUI hpGUI;
    [SerializeField]private GameObject loseMenu;
    private GameManager _gameManager;
    private EnemySpawner _enemySpawner;
   

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _enemySpawner = FindObjectOfType<EnemySpawner>();
        
        UpdateParameters();
        _hp = _maxhp;
    }

    public void UpdateParameters()
    {
        _maxhp = _gameManager._maxhp;
        _hpRegen = _gameManager._hpRegen;
        _absoluteDefense = _gameManager._absoluteDefense;
    }
    private void Update()
    {
        hpGUI.text = "HP: " + (float)Math.Round(_hp);
        HpRegeneration();
    }

    public void GetDamage(float damage)
    {
        if (_absoluteDefense - damage < 0)
        {
            _hp -= Mathf.Abs(_absoluteDefense - damage);
        }
        
        if (_hp <= 0)
        {
            _hp = 0;
            _enemySpawner.canMove = false;
            DieAnim();
        }
    }

    public void HpRegeneration()
    {
        if (_hp<_maxhp)
        {
            _hp += _hpRegen * Time.deltaTime;
        }
        
    }

    public void DieAnim()
    {
        loseMenu.SetActive(true);
        loseMenu.GetComponent<Animation>().Play();
        GameObject.Find("Main Interface").SetActive(false);
    }

    

}
