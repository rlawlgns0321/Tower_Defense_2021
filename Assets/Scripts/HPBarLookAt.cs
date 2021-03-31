using UnityEngine;

public class HPBarLookAt : MonoBehaviour {

    RectTransform rect;
    Vector3 lookatPos;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
       // lookatPos = new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);
    }

    void Update () {
        lookatPos = new Vector3(this.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        rect.LookAt(lookatPos);
	}
}
