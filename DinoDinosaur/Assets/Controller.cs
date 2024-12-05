using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    private Animator animator;
    private bool jumping;
    private int maxJump;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        jumping=false;
        maxJump=5;
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetInteger("life")>0){
            if(Input.GetAxis("Horizontal") > 0.0){
                animator.SetInteger("move", animator.GetInteger("move")+1); //altera o valor de move no animator
                transform.localScale=new Vector3(1f,1f,1f);  //tranform é um componente que define position, rotation e scale do GameObject(define que a sprite olhe pra direita (x,y,z))
                transform.Translate(0.1f,0.0f,0.0f);//move o personagem para a direita
            }else if(Input.GetAxis("Horizontal") < 0.0){
                animator.SetInteger("move", animator.GetInteger("move")+1);
                transform.localScale=new Vector3(-1f,1f,1f);  
                transform.Translate(-0.1f,0.0f,0.0f);

            }else animator.SetInteger("move",0);
            

            if(Input.GetKey("w") && !jumping){
                animator.SetBool("jump",true);
                jumping=true;
            }
            if(jumping){
                if(transform.position.y<maxJump){
                    transform.Translate(0.0f,0.3f,0.0f);//se não chegar na altura max continua o pulo
                }else{
                    jumping=false;
                    animator.SetBool("jump", false);
                    
                }
            }else if(transform.position.y>0) transform.Translate(0.0f,-0.3f,0.0f); //simulação da graviade

            if(Input.GetKey("t")){
                animator.SetInteger("life",0);
            }

            // //apertar a tecla
            // if(Input.GetKey(KeyCode.E)){
            //     animator.SetBool("jump", true);
            // }

            // if(Input.GetKeyUp(KeyCode.E)){
            //     animator.SetBool("jump", false);

            // }
        }
        else animator.SetInteger("life",-1);
    }
}
