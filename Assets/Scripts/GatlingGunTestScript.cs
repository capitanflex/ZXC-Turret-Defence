using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;

public class GatlingGunTestScript : MonoBehaviour
{
    public GunParameters _gunParameters;

    [SerializeField] private Transform baseRotation;
    [SerializeField] private Transform gunBody;
    [SerializeField] private Transform barrel;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private ParticleSystem muzzelFlash;

    
    private float baseRotationSpeed = 5f;
    private float _timer;
    
    private GameManager _gameManager;
    private Animator rotateAnim;
    private SphereCollider _sphereCollider;
    private Queue<GameObject> Enemy;
    private GameObject _currentTarget;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gunParameters = _gameManager._gunParameters;
    }

    private void Start()
        {
            Enemy = new Queue<GameObject>();
            rotateAnim = barrel.GetComponent<Animator>();
            _sphereCollider = GetComponent<SphereCollider>();
            UpdateRange();
            
        }
    
    private void Update()
    {
        Debug.DrawRay(firePoint.position, firePoint.forward * 100f, Color.red);
        AimAndFire();
    }

    

    private void SearchTarget()
    {
        _currentTarget = Enemy.Dequeue();
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
           Enemy.Enqueue(other.gameObject);
        }

    }

    private void AimAndFire()
    {
        if (_currentTarget != null)
        {
            GunRotation(_currentTarget);
            if (_timer <= 0 && IsAimed())
            {
                Shoot();
                rotateAnim.SetTrigger("Rotate");
                muzzelFlash.Play();
                _timer = _gunParameters.reload;
            }
            else
                _timer -= Time.deltaTime;
        }
        else
        {
            if (Enemy.Count != 0)
            {
                SearchTarget();
            }
            
        }
    }

    private void GunRotation(GameObject target)
    {
        var targetPostition = target.transform.position; 
        gunBody.transform.LookAt(new Vector3(targetPostition.x, transform.position.y, targetPostition.z));
        
        
        Vector3 baselookDirection = targetPostition - baseRotation.position;
        baselookDirection.Normalize();
        baseRotation.rotation = Quaternion.Slerp(baseRotation.rotation, Quaternion.LookRotation(baselookDirection), baseRotationSpeed * Time.deltaTime);
    }


    public void UpdateRange()
    {
        _sphereCollider.radius = _gunParameters.firingRange;
    }
   

    
    private void Shoot()
    { 
       var _bullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
       _bullet.GetComponent<Bullet>().damage = _gunParameters.damage;
    }

    
    private bool IsAimed()
    {
        Ray ray = new Ray(firePoint.position, firePoint.forward);
        

        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.collider.tag == "Enemy")
        {
            return true;
        } 
        return false;
        
    }
    
    
}