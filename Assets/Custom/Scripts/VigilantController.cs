using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VigilantController : MonoBehaviour
{
    public GameObject OpenPanel;
    public GameObject Letra;
    public GameObject Player;
    private Animator animator;

    private bool _isInsideTrigger = false;

    //public string OpenText = "Press E to open";
    //public string CloseText = "press E to close";
    private bool _isOpen = false;
    private bool mensaje = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (IsOpenPanelActive && _isInsideTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isOpen = !_isOpen;

            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if (mensaje)
            {
                _isInsideTrigger = true;
                OpenPanel.SetActive(true);

                float distance = Vector3.Distance(Player.transform.position, transform.position);

                if (distance >= 2)
                {
                    if (animator.GetInteger("AnimIndex") != 1)
                    {
                        animator.SetInteger("AnimIndex", 1);
                        animator.SetTrigger("Next");
                    }
                }

                mensaje = false;
            }
            else
            {
                float distance = Vector3.Distance(Player.transform.position, transform.position);

                if (distance <= 2)
                {
                    _isInsideTrigger = true;
                    OpenPanel.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider colicion)
    {
        if (colicion.tag == "Player")
        {
            _isInsideTrigger = false;
            OpenPanel.SetActive(false);
            if (animator.GetInteger("AnimIndex") != 0)
            {
                animator.SetInteger("AnimIndex", 0);
                animator.SetTrigger("Next");
            }
        }
    }
    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }
    /*
        private void SetPanelText(string text){
            Text panelText = Letra.GetComponent <Text>();
            if(panelText.text = null){
                panelText.text = text;
            }
        } */
}
