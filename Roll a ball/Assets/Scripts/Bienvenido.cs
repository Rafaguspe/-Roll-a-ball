using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Bienvenido : MonoBehaviour
{
    public Button BtnMenos,BtnMas,BtnEmpezar;
    public TextMeshProUGUI Velocidad;
    public int vel=1;



    // Start is called before the first frame update
    void Start()
    {
        
        BtnMenos.onClick.AddListener(()=>Bajar());
        BtnMas.onClick.AddListener(()=>Subir());
        BtnEmpezar.onClick.AddListener(()=>Empezar());


    }

  
    void Bajar()
    {
        if (vel>1)
        {
            vel=vel-1;
            Velocidad.text= vel.ToString();
            Debug.Log(Velocidad);
        }

    GuardaValor(vel);
        
    }


    void Subir()
    {

        if (vel>=1 && vel<10)
        {
            vel=vel+1;
            Velocidad.text= vel.ToString();
            Debug.Log(Velocidad);
        }
        GuardaValor(vel);
        
    }


    void GuardaValor(int vel)
    {
       PlayerPrefs.SetInt("Velo", vel);

    }



void Empezar()
    {
        SceneManager.LoadScene("Juego");
    }


}
