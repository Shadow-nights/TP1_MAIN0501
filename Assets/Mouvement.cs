using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    float baseSpeed = 0.01f;
    float speed;
    Rigidbody rb;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(){
        isGrounded = true;
    }

    // Update is called once per frame
    void Update(){
        //Permet de faire bouger le personnage(Player), en arrière
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(Vector3.forward * speed);
        }
        //Permet de faire bouger le personnage(Player), en avant
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(Vector3.back * speed);
        }
        //Permet de faire bouger le personnage(Player), à gauche
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(Vector3.up, -2);
        }
        //Permet de faire bouger le personnage(Player), à droite
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(Vector3.up, 2);
        }
        //Permet de faire courir le personnage(Player),
        //Le personnage passe en mode courir ce qui change la vitesse de bass du personnage
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = baseSpeed*2;
        }else{
            speed = baseSpeed;
        }
        //Permet de faire sauter le personnage(Player), seulement quand il est au sol
        //La fonction permet au personnage d'effectuer soit un saut simple, soit un double saut
        if((Input.GetKeyDown(KeyCode.Space)) && (isGrounded)){
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
