using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Agregamos
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class JugadorController : MonoBehaviour {

//Declarlo la variable de tipo RigidBody que luego asociaremos a nuestro Jugador

private Rigidbody rb;

//Inicializo el contador de coleccionables recogidos
private int contador;

//Inicializo variables para los textos
public TextMeshProUGUI textoContador;

//Declaro la variable pública velocidad para poder modificarla desde la Inspector window
int velocidad;

public AudioSource quienEmite;
public AudioClip elSonido;

public GameObject Gane;
public Button btnrepetir;
// Use this for initialization

void Start () {
textoContador.text = "Contador: 0";
 velocidad=  PlayerPrefs.GetInt("Velo"); 
//Capturo esa variable al iniciar el juego
quienEmite= GetComponent<AudioSource>();
rb = GetComponent<Rigidbody>();
//Inicio el contador a 0
contador = 0;
//Actualizo el texto del contador por pimera vez
setTextoContador();
//Inicio el texto de ganar a vacío
btnrepetir.onClick.AddListener(()=>repetir());
}

// Para que se sincronice con los frames de física del motor

void FixedUpdate () {
//Estas variables nos capturan el movimiento en horizontal y vertical de nuestro teclado
float movimientoH = Input.GetAxis("Horizontal");
float movimientoV = Input.GetAxis("Vertical");

//Un vector 3 es un trío de posiciones en el espacio XYZ, en este caso el que corresponde al movimiento
Vector3 movimiento = new Vector3(movimientoH, 0.0f,
movimientoV);

//Asigno ese movimiento o desplazamiento a mi RigidBody, multiplicado por la velocidad que quiera darle
if (contador < 12){
rb.AddForce(movimiento * velocidad);
}
}

//Se ejecuta al entrar a un objeto con la opción isTrigger seleccionada
IEnumerator OnTriggerEnter(Collider other)
{
if (other.gameObject.CompareTag ("Coleccionable"))
{
//Desactivo el objeto
quienEmite.Play();
 yield return new WaitForSeconds(0.1f); 
other.gameObject.SetActive (false);
//Incremento el contador en uno (también se peude hacer como contador++)

contador = contador + 1;
//Actualizo elt exto del contador
StartCoroutine(setTextoContador());
}

}
//Actualizo el texto del contador (O muestro el de ganar si las ha cogido todas)

IEnumerator setTextoContador(){
textoContador.text = "Contador: " + contador.ToString();
if (contador >= 12){
//textoGanar.text = "¡Ganaste!";
rb.AddForce(new Vector3(0,0,0));
Gane.SetActive(true);
 yield return new WaitForSeconds(5f);
 repetir();
}
}


void repetir ()
{
    
    SceneManager.LoadScene("Bienvenido");
}



}
