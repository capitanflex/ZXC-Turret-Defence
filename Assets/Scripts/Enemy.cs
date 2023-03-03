using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _damage;
    private EnemySpawner _enemySpawner;
    private GameManager _gameManager;
    private Animation _animation;
    private float _currentHp;

    
    
    private GameObject player;
    private PlayerBehaviour _playerBehaviour;

    private float time;

    private void Start()
    {

        _animation = GetComponent<Animation>();
        _enemySpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
        _gameManager = FindObjectOfType<GameManager>();
        _playerBehaviour = FindObjectOfType<PlayerBehaviour>();
        player = _playerBehaviour.gameObject;

    }

    public void SetStats(float hp, float damage)
    {
        _currentHp = hp;
        _damage = damage;
        print(_currentHp);
    }

    private void Update()
    {
        if (_enemySpawner.canMove)
        {
           Move(); 
        }
        
    }

    private void Move()
    {

        if (DistanceToPlayer() > _attackRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime); 
        }
        else
        {
            _animation.Play();
        }
    }

    private float DistanceToPlayer()
    {
        return Vector3.Distance(player.transform.position, transform.position);
    }

    public void Attack()
    {
           _playerBehaviour.GetDamage(_damage);
       
        
       
        
    }

    public void GetDamage(float damage)
    {
        _currentHp -= damage;
        if (_currentHp <= 0)
        {
            if (Random.Range(1,5) == 1)//с шансом 20% падают монеты
            {
                _gameManager.ChangeCoinsValue(_gameManager.CoinsPerKill);
            }
            _gameManager.ChangeCashValue(_gameManager.CashKill);
            _enemySpawner._enemiesCount -= 1;
            Destroy(gameObject);
        }
    }
    
    
    
}
