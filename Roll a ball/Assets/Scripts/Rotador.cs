using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour
{
   //public AudioSource Sonido;

    // Start is called before the first frame update
    void Start()
    {
      //  Sonido= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rota el elemento una cantidad diferente en cada dirección y en cada intervalo de tiempo
        transform.Rotate(new Vector3(0,60,0) * Time.deltaTime);


    }

  

}
