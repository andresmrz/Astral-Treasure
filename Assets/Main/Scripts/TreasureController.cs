using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
    private Animator animator;
    public AudioSource source;
    public AudioClip clip_open;
    public AudioClip clip_close;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if (animator.GetInteger("AnimIndex") != 1)
            {
                source.clip = clip_open;
                source.Play();

                animator.SetInteger("AnimIndex", 1);
                animator.SetTrigger("Next");
            }
        }
    }

    private void OnTriggerExit(Collider colicion)
    {
        if (colicion.tag == "Player")
        {
            if (animator.GetInteger("AnimIndex") == 1)
            {
                source.clip = clip_close;
                source.Play();

                animator.SetInteger("AnimIndex", 2);
                animator.SetTrigger("Next");
            }
        }
    }
}
