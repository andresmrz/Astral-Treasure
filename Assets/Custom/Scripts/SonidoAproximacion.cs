using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoAproximacion : MonoBehaviour
{
    private Animator animator;
    public AudioSource source;
    public AudioClip clip;
    public bool reproducir_todo;

    void Start()
    {
        source.clip = clip;
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            source.Play();
        }
    }

    private void OnTriggerExit(Collider colicion)
    {
        if (colicion.tag == "Player")
        {
            if(!reproducir_todo)
            {
                source.Stop();
            }
        }
    }
}
