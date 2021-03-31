using UnityEngine;

public class Turret : MonoBehaviour {

    public Transform target;

    [Header("General")]

    public float range = 15f;

    [Header("Use Bullets (Default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public ParticleSystem firePointEffect;
    public Light impactLight;


    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;
    //int num = 0;
    float shortestDistance = Mathf.Infinity;
    private GameObject nearestEnemy = null;
    public Transform firePoint;  
    
	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.3f);
	}
	
    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        //float shortestDistance = Mathf.Infinity;
        //GameObject nearestEnemy = null;
        if (nearestEnemy == null)
        {
            for(int i = 0; i < enemies.Length; i++)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemies[i].transform.position);
                if(distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemies[i];
                }
            }
  /*          foreach (GameObject enemy in enemies)
            {
                while (num < enemies.Length)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                    if (distanceToEnemy < shortestDistance)
                    {
                        shortestDistance = distanceToEnemy;
                        nearestEnemy = enemy;
                    }
                    num++;
                }                
                num = 0;
            }*/
        }

        if (nearestEnemy != null && Vector3.Distance(transform.position, nearestEnemy.transform.position) <= range)
        {
            target = nearestEnemy.transform;
        }
  /*      else if (nearestEnemy != null && Vector3.Distance(transform.position, nearestEnemy.transform.position) > range)
        {
            nearestEnemy = null;
            target = null;
            shortestDistance = Mathf.Infinity;
        }*/
        else
        {
            nearestEnemy = null;
            target = null;
            shortestDistance = Mathf.Infinity;
        }
    }

	// Update is called once per frame
	void Update () {
        if (target == null) { 

            if(useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    firePointEffect.Stop();
                    impactLight.enabled = false;
                }
            }
            if (fireCountdown > 0)
                fireCountdown -= Time.deltaTime;
            return;
        }
        //Target Lock on

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
	}

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            firePointEffect.Play();
            impactLight.enabled = true;
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized; // game math theory

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

        firePointEffect.transform.position = firePoint.position;
        firePointEffect.transform.rotation = Quaternion.LookRotation(dir);

        Enemy e = target.GetComponent<Enemy>();
        
        e.TakeDamage(100 / 60); //set Laser damage in this script because damage calc. has different formula from bullet's.
       
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
