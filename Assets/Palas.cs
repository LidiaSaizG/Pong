using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palas : MonoBehaviour
{

    [SerializeField] private float velocidad = 7f;
    [SerializeField] private bool Pala1;
    private float yBound = 3.75f;

    void Update()
    {
        float movimiento;

        if (Pala1)
        {
            movimiento = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movimiento = Input.GetAxisRaw("Vertical2");
        }
       Vector2 palaPosition = transform.position;
        palaPosition.y = Mathf.Clamp(palaPosition.y + movimiento * velocidad * Time.deltaTime, -yBound, yBound);
        transform.position = palaPosition;
    }
}
