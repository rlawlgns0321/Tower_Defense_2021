using UnityEngine;

public class ItemMotion : MonoBehaviour {

    int i = 0;
    private Rigidbody rgd;
    public GameObject ItemGetEffect;
    float rand_x;
    float rand_z;

    private void OnMouseDown()
    {
        Debug.Log("You got item!");
        GameObject Effect = (GameObject)Instantiate(ItemGetEffect, transform.position, Quaternion.identity);
        Destroy(Effect, 4f);
        Destroy(this.gameObject); //Destroy dropped item on click.
    }

    private void Start()
    {
        rand_x = Random.Range(-5, 5);
        rand_z = Random.Range(-5, 5); //set bouncing position randomly.
        rgd = GetComponent<Rigidbody>();
        rgd.AddForce(new Vector3(rand_x, 10.0f, rand_z), ForceMode.Impulse); // make bouncing effect once.
    }
    void Update () {
        if (i >= 720)
            i = 0;
        this.transform.rotation = Quaternion.AngleAxis(i * 1/2, Vector3.up); // make rotating effect.
        i++;
	}
}
