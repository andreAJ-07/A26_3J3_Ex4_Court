using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] float vitesse;
    [SerializeField] float delaiDestruction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.linearVelocity = transform.forward * vitesse;
        Destroy(this.gameObject, delaiDestruction);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "cible")
        {
            GestionnaireJeu.instance.DetruireCible(collision.gameObject);

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
