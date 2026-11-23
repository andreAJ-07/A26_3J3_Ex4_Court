using UnityEngine;

public class ClicJoueur : MonoBehaviour
{
    Renderer renderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    public void AuClic()
    {
        Debug.Log("Clic");
        renderer.material.color = Random.ColorHSV();
    }
}
