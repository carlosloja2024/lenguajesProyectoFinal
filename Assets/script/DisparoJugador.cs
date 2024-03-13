using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour

{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;
    // Start is called before the first frame update
    
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }
    private void Disparar()
    {
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);

    }
}
