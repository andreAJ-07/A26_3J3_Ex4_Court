using UnityEngine;

public class DeplacementCible : MonoBehaviour
{
    [SerializeField] Vector3 pointA;
    [SerializeField] Vector3 pointB;
    [SerializeField] float vitesse = 1;
    [SerializeField] float ecart = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointA = transform.position - transform.right * ecart;
        pointB = transform.position + transform.right * ecart;
    }

    // Update is called once per frame
    void Update()
    {
        float t = (Mathf.Sin(Time.time * vitesse) + 1f) / 2f;
        transform.position = Vector3.Lerp(pointA, pointB, t);
    }
}
