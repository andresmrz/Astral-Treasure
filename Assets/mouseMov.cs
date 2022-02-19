using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMov : MonoBehaviour
{
    float mousePosX;
    float mousePosY;

    [SerializeField] float movementQuantity;

    // Start is called before the first frame update
    void Start()
    {
        movementQuantity = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosX = Input.mousePosition.x;
        mousePosY = Input.mousePosition.y;

        this.GetComponent<RectTransform>().position = new Vector2(((mousePosX / Screen.width) * movementQuantity + (Screen.width / 2)), ((mousePosY / Screen.height) * movementQuantity + (Screen.height / 2)));
    }
}
