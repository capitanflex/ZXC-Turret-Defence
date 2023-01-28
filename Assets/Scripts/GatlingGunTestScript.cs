using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GatlingGunTestScript : MonoBehaviour
{
    public GunParameters _gunParameters;
    
    private float _timer;
    [SerializeField] private Transform baseRotation;
    [SerializeField] private Transform gunBody;
    [SerializeField] private Transform barrel;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private ParticleSystem muzzelFlash;
    private Animator rotateAnim;
    private SphereCollider SphereCollider;
    
    private Queue<GameObject> Enemy;
    private GameObject _currentTarget;
    
    
    private void Start()
        {
            Enemy = new Queue<GameObject>();
            rotateAnim = barrel.GetComponent<Animator>();
            SphereCollider = GetComponent<SphereCollider>();
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
            SearchTarget();
        }
    }

    private void GunRotation(GameObject target)
    {
        var targetPostition = target.transform.position; 
        gunBody.transform.LookAt(new Vector3(targetPostition.x, transform.position.y, targetPostition.z));
        
        
        Vector3 baselookDirection = targetPostition - baseRotation.position;
        baselookDirection.Normalize();
        baseRotation.rotation = Quaternion.Slerp(baseRotation.rotation, Quaternion.LookRotation(baselookDirection), _gunParameters.baseRotatinonSpeed * Time.deltaTime);
        //
        // Vector3 gunLookDirection = targetPostition - barrel.position;
        // gunLookDirection.Normalize();
        // Quaternion barellRotation = Quaternion.Slerp(gunBody.rotation, Quaternion.LookRotation(gunLookDirection), _gunParameters.baseRotatinonSpeed * Time.deltaTime );
        // gunBody.rotation = new Quaternion(0, barrel.transform.rotation.y, 0, barellRotation.w);
       
        
        
        
    }


    public void UpdateRange()
    {
        GetComponent<SphereCollider>().radius = _gunParameters.firingRange;
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