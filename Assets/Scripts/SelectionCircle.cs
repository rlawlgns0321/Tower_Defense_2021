using UnityEngine;

public class SelectionCircle : MonoBehaviour {

    public int vertexCount = 41;
    public float lineWidth = 0.2f;
    public float radius;
    
    public LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        SetupCircle();
    }

    public void SetupCircle() 
    {
        lineRenderer.widthMultiplier = lineWidth;
        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;

        Vector3 oldPos = Vector3.zero;

        lineRenderer.positionCount = vertexCount + 1;
        for(int i = 0; i < vertexCount + 1; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Sin(theta), 1f, radius * Mathf.Cos(theta));
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }
}
