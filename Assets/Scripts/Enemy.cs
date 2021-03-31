using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    // Use this for initialization
    public float speed = 10f;

    public float max_health;
    private float health;

    public int value = 50;

    public GameObject deathEffect;
    public GameObject ItemBox;

    private Transform target;
    private int wavepointIndex = 0;

    public Image healthbar;

    void Start()
    {
        max_health = StageLevelModifier.modified_enemyHealth;
        speed = StageLevelModifier.modified_enemySpeed;
        target = WayPoints.points[0];
        health = max_health;
    }

    public void TakeDamage(float amount)
    {
        if(health > 0)
            health -= amount;

        healthbar.fillAmount = health / max_health;
/*
        if(health <= 0)
        {
            Die();
        }*/
    }

    void Die()
    {
        Debug.Log("Died! health " + health);
        int item_drop_percentage = Random.Range(0, 99);
        GameObject dropped;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
   /*     if (item_drop_percentage == 1) //item drop rate = 1%
            dropped = (GameObject)Instantiate(ItemBox, transform.position, Quaternion.identity); //drop item.*/
        Destroy(effect, 5f);
        
        Destroy(gameObject);
        PlayerStats.Money += value;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
        if (health <= 0)
            Die();
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= WayPoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = WayPoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        //Debug.Log(PlayerStats.Lives);
        Destroy(gameObject);
    }
}
