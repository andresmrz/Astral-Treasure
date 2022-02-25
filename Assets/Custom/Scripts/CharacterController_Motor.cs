using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterController_Motor : MonoBehaviour {

	public float speed = 3.0f;
	public float sensitivity = 90.0f;
	
	CharacterController character;
	public GameObject cam;
	float moveFB, moveLR;
	float rotX, rotY;
    public string nombre;
	
	float gravity = -9.8f;
	
	public GameObject personaje;
	private Animator p_animator;

	public float fuerzaSalto = 800f;
	private Rigidbody rb;

	public int vida = 50;
	public Slider sliderVida;
		
	void Start(){
		p_animator = personaje.GetComponent<Animator>();
		character = GetComponent<CharacterController>();
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
    {

    }

	
	void Update(){
		if(Input.GetKeyDown(KeyCode.Q)){
            if(p_animator.GetInteger("AnimIndex") != 3){
				p_animator.SetInteger("AnimIndex", 3);
            	p_animator.SetTrigger("Next");
				
			}
        
		}
		if(Input.GetAxis ("Fire3")>0){
			speed = 5.0f;
			//if(!p_animator.GetBool("Run")){
			//	p_animator.SetBool("Run", true);
			//}
		}else{
			speed = 3.0f;

			//p_animator.SetBool("Run", false);
		}
		moveFB = Input.GetAxis ("Horizontal") * speed;
		moveLR = Input.GetAxis ("Vertical") * speed;
	
		rotX = Input.GetAxis ("Mouse X") * sensitivity;
		rotY = Input.GetAxis ("Mouse Y") * sensitivity;

		if(moveFB!=0 || moveLR!=0){
            if(p_animator.GetInteger("AnimIndex") != 1 && !p_animator.GetBool("Run")){
				p_animator.SetInteger("AnimIndex", 1);
            	p_animator.SetTrigger("Next");
				
			}
        }
        else{
            if(p_animator.GetInteger("AnimIndex") != 0 && !p_animator.GetBool("Run")){
				p_animator.SetInteger("AnimIndex", 0);
				p_animator.SetTrigger("Next");
			}
			
        }
		Vector3 movement = new Vector3 (moveFB, gravity, moveLR);
		CameraRotation (cam, rotX, rotY);
		movement = transform.rotation * movement;
		character.Move (movement * Time.deltaTime);

		if(Input.GetButtonDown("Jump"))
		{
			//rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
			//rb.AddForce(Vector3.up, ForceMode.Impulse);
			print("salto");

			Vector3 salto = new Vector3(0, 2, 0);
			character.Move(salto);
		}

		sliderVida.GetComponent<Slider>().value = vida;

		if(vida <= 0)
        {
			SceneManager.LoadScene("GameOver");
		}
	}

	

	void CameraRotation(GameObject cam, float rotX, float rotY){		
		transform.Rotate (0, rotX * Time.deltaTime, 0);
		float rot = rotY * Time.deltaTime;
		if(rot>0){
			if(cam.transform.localRotation.x>-0.4){
				cam.transform.Rotate (-rot, 0, 0);
			}
		}else{
			if(cam.transform.localRotation.x <0.3){
				cam.transform.Rotate (-rot, 0, 0);
			}
		}
	}
}
