using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poursuite : MonoBehaviour
{
    // Position actuelle de l'objet
    public Vector3 C; 

    // Vitesse de poursuite
    public float v = 5f; 

    // Cible à poursuivre (ex: le joueur)
    public GameObject Cible;

    // Start est appelé avant la première image
    void Start()
    {
        // Initialiser la position de départ
        C = this.transform.position;
    }

    void Update()
    {
        if (Cible != null)
        {
            Vector3 direction = Cible.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
            float distanceThisFrame = v * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Cible.transform.position, distanceThisFrame);
        }
    }
}
