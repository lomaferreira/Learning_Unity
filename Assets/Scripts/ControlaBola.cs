using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlaBola  : MonoBehaviour
// Update() → Chamado a cada frame.
// FixedUpdate() → Chamado em intervalos fixos de tempo (ideal para física).
// LateUpdate() → Chamado após Update() (ideal para seguir objetos, câmeras, etc.).


{
    private Rigidbody rb;
    public float power;
    private bool play=false;
    public int derrubados;
    public TMP_Text placar;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        derrubados=0;
        placar.text = "";
    
    }

    void FixedUpdate() 
    {   if(Input.GetKey("a") && transform.position.x < 2.0f && !play){
            transform.Translate(0.1f,0.0f,0.0f);
        }
        if(Input.GetKey("d") && transform.position.x > -2.0f && !play){
            transform.Translate(-0.1f, 0.0f,0.0f);
        }
        if (Input.GetKey("w") && !play)
        {
            rb.AddForce(new Vector3(0.0f,0.0f, -Mathf.Abs(power)));//retorna o valor absoluto
            play=true;
        }

        if(play){
            placar.text="Derrubou: " + derrubados.ToString() +" pinos.";
        }

       
    }
     void OnTriggerEnter(Collider other) //detecção sem colisão (como checkpoints, áreas de dano, sensores invisíveis)
    {
        if (other.gameObject.CompareTag("Pino")) // Verifica se o objeto é um pino
        {
            derrubados++;
            placar.text = "Derrubou: " + derrubados + " pinos";
            Destroy(other.gameObject); // Remove o pino da cena
        }
    }

    
}
