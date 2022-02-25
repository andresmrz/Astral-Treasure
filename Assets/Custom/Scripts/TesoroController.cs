using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TesoroController : MonoBehaviour
{
    private Animator animator;
    public AudioSource source;
    public AudioClip clip_open;
    public AudioClip clip_close;

    private bool iniciar = false;
    private float secondsCounter = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (iniciar)
       {
            secondsCounter += Time.deltaTime;

            if(secondsCounter >= 2)
            {
                SceneManager.LoadScene("Mensaje");
            }
       }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            if(animator.GetInteger("AnimIndex") != 1)
            {
                source.clip = clip_open;
                source.Play();

                animator.SetInteger("AnimIndex", 1);
                animator.SetTrigger("Next");

                iniciar = true;
			}
        }
    }

    private void OnTriggerExit(Collider colicion)
    {
        if(colicion.tag == "Player")
        {
            if(animator.GetInteger("AnimIndex") == 1)
            {
                source.clip = clip_close;
                source.Play();

                animator.SetInteger("AnimIndex", 2);
                animator.SetTrigger("Next");
            }
        }
    }
}
