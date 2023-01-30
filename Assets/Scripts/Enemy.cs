using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _damage;
    [SerializeField] private float _hp;
    private EnemySpawner _enemySpawner;
    private GameManager _gameManager;
    private float _currentHp;
    
    private GameObject player;
    private PlayerBehaviour _playerBehaviour;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _enemySpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _currentHp = _hp + (_enemySpawner.waveID*2);
        _damage += (_enemySpawner.waveID * 3);
        print(_currentHp);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {

        if (DistanceToPlayer() > _attackRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime); 
        }
        else
        {
            // Attack();
        }
    }

    private float DistanceToPlayer()
    {
        return Vector3.Distance(player.transform.position, transform.position);
    }

    private void Attack()
    {
        _playerBehaviour.GetDamage(_damage);
    }

    public void GetDamage(float damage)
    {
        _currentHp -= damage;
        if (_currentHp <= 0)
        {
            if (Random.Range(1,5) == 1)//с шансом 20% падает денежка
            {
                _gameManager.ChangeCoinsValue(_enemySpawner.waveID * 2 + 1);
            }
            _gameManager.ChangeCashValue(_enemySpawner.waveID*4);
            _enemySpawner._enemiesCount -= 1;
            Destroy(gameObject);
        }
    }
    
}
