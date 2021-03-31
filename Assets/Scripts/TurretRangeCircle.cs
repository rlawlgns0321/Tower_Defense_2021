using UnityEngine;

public class TurretRangeCircle : MonoBehaviour {

    public static int vertexCount = 41;
    public static float lineWidth = 0.2f;
    public float radius;
    public static GameObject existing_Circle;
    public static LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        //SetupCircle(radius);
    }

    public static void Draw_Range_Circle(GameObject circle, Node Nod, float rad)
    {
        SetupCircle(circle, rad);
        existing_Circle = (GameObject)Instantiate(circle, Nod.transform.position, Nod.transform.rotation);
    }

    public static void Delete_Range_Circle()
    {
        if (existing_Circle)
            Destroy(existing_Circle);
    }

    public static void SetupCircle(GameObject circle, float radius)
    {
        LineRenderer lineRenderer = circle.GetComponent<LineRenderer>();
        lineRenderer.widthMultiplier = lineWidth;
        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;

        Vector3 oldPos = Vector3.zero;

        lineRenderer.positionCount = vertexCount + 1;
        for (int i = 0; i < vertexCount + 1; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Sin(theta), 1f, radius * Mathf.Cos(theta));
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }

}
