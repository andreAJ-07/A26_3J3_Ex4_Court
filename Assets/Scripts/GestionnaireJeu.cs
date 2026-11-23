using System.Collections;
using System.Collections.Generic;
using System.Linq; //tolist
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum EtatJeu
{
    JEU,
    FIN
}

public class GestionnaireJeu : MonoBehaviour
{
    public static GestionnaireJeu instance;

    public EtatJeu etatJeu;
    [SerializeField] TMP_Text texteCibles;
    [SerializeField] TMP_Text texteFin;

    [SerializeField] Color[] listeCouleurs;
    [SerializeField] List<int> listeEntiers;
    [SerializeField] List<GameObject> listeCibles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        yield return null;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        //for the arrays[], the lenght is with Lenght
        Color couleurAleatoire = listeCouleurs[Random.Range(0, listeCouleurs.Length)];

        int entierAleatoire = listeEntiers[Random.Range(0, listeEntiers.Count)];

        listeEntiers.Add(5);
        //listeEntiers.Remove(5);

       

    }
    public void Update()
    {
        listeCibles = GameObject.FindGameObjectsWithTag("cible").ToList();
        for (int i=0; i < listeCibles.Count; i++)
        {
            GameObject cible = listeCibles[i];
            cible.SetActive(true);
        }

        //TODO: Mettre a jour la quantité d'elements dans le UI
        texteCibles.text = $"cibles:{listeCibles.Count}";

    }

    public void DetruireCible(GameObject cible)
    {
        if (listeCibles.Contains(cible))
        {
            listeCibles.Remove(cible);
        }

        //TODO: Mettre a jour la quantité d'elements danss le UI
        texteCibles.text = $"cibles:{listeCibles.Count}";


        //si il n'y a plus de cibles, demarrer nla coroutine de fin de jeu
        if (listeCibles.Count <= 0)
        {
            StartCoroutine(FinJeu());

        }

    }

    IEnumerator FinJeu()
    {
        etatJeu = EtatJeu.FIN;
        texteFin.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("Ex4");
        // Reste de la logique pour terminer le jeu
        // Ex: Afficher un panneau, changer de scène, cinématique, etc. 
    }
}
