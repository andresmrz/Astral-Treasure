using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMov : MonoBehaviour
{
    public float speed = 3;
    public float rotation = 20;

    private Animator animator;

    private float x, y;

    public GameObject personaje;

    // Start is called before the first frame update
    void Start()
    {
        animator = personaje.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * rotation, 0);
        transform.Translate(0, 0, y * Time.deltaTime * speed);

        animator.SetFloat("Vx", x);
        animator.SetFloat("Vy", y);
    }
}
