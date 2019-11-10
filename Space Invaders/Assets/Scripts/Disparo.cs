using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;//se agrego la libreria de interfaz de usuario

public class Disparo : MonoBehaviour{

    public int vidas = 100;

    public float velocidad = 20; //flotante para la velocidad de la bala

    static int puntajeNum = 0;

    static int cambio_de_nivel = 32;
    public Text puntajeTxt;

    public AudioSource explosion;

    private Rigidbody2D CuerpoCalloso; //se le otorga el atributo de cuerpo rigido

    public Sprite muerte4; //se llaman a los sprites de la muerte de un alien
    public Sprite muerte4_2;
    public Sprite muerte4_3;
    public Sprite muerte3;
    public Sprite muerte3_2;
    public Sprite muerte2;
    public Sprite muerte2_2;
    public Sprite muerte1;
    public Sprite muerte1_2;
    

    void Start () {

        CuerpoCalloso = GetComponent<Rigidbody2D>(); //se le da el atributo a la variable

        CuerpoCalloso.velocity = Vector2.up * velocidad; //se le da el escalar de velocidad al vector 
    }
   
    void OnCollisionEnter2D(Collision2D col){

        if (col.gameObject.tag == "Muros")//si le pega a un muro
        {
            Destroy(gameObject);//se destruye la bala
        }

        print(cambio_de_nivel);

        if (col.gameObject.tag == "enemigos")//si le pega a un enemigo morado
        {
            
            if (cambio_de_nivel == 0)
            {
                SceneManager.LoadScene("Boss");
            }

            //explosion.Play();
            puntajeNum += 40;
            IncreaseTextUIScore(puntajeNum); //se llama a la funcion para aumentar la puntuacion

            Destroy(col.gameObject, 0.02f); //se destruye el alien
            
            col.gameObject.GetComponent<SpriteRenderer>().sprite = muerte4; //se llama al sprite de explosion
            col.gameObject.GetComponent<SpriteRenderer>().sprite = muerte4_2;
            col.gameObject.GetComponent<SpriteRenderer>().sprite = muerte4_3;

            Destroy(gameObject);//se destruye la bala

            cambio_de_nivel--;

        }

        if (col.gameObject.tag == "enemigo_1")//si le pega a un enemigo naranja
        {
            //explosion.Play();
            
            if (cambio_de_nivel == 0)
            {
                SceneManager.LoadScene("Boss");
            }

            puntajeNum += 10;
            IncreaseTextUIScore(puntajeNum); //se llama a la funcion para aumentar la puntuacion

            Destroy(col.gameObject, 0.02f); //se destruye el alien
            
            col.gameObject.GetComponent<SpriteRenderer>().sprite = muerte1; //se llama al sprite de explosion
            col.gameObject.GetComponent<SpriteRenderer>().sprite = muerte1_2;

            Destroy(gameObject);//se destruye la bala

            cambio_de_nivel--;
        }

        if (col.gameObject.tag == "enemigo_2")//si le pega a un enemigo rosa
        {
            //explosion.Play();
            
            if (cambio_de_nivel == 0)
            {
                SceneManager.LoadScene("Boss");
            }
            puntajeNum += 20;
            IncreaseTextUIScore(puntajeNum); //se llama a la funcion para aumentar la puntuacion

            Destroy(col.gameObject, 0.02f); //se destruye el alien
            
            col.gameObject.GetComponent<SpriteRenderer>().sprite = muerte2; //se llama al sprite de explosion
            col.gameObject.GetComponent<SpriteRenderer>().sprite = muerte2_2;

            Destroy(gameObject);//se destruye la bala

            cambio_de_nivel--;
        }

        if (col.gameObject.tag == "boss")
        {
            //explosion.Play();
            puntajeNum += 100;
            IncreaseTextUIScore(puntajeNum);

            Destroy(gameObject);
            vidas--;
            
        }

        if (vidas == 0)
        {
            col.gameObject.GetComponent<SpriteRenderer>().sprite = muerte2;
            col.gameObject.GetComponent<SpriteRenderer>().sprite = muerte2_2;

            Destroy(gameObject);
        }

        if (col.gameObject.tag == "enemigo_3")//si le pega a un enemigo azul
        {
            //explosion.Play();
            
            if (cambio_de_nivel == 0)
            {
                SceneManager.LoadScene("Boss");
            }
            puntajeNum += 30;
            IncreaseTextUIScore(puntajeNum); //se llama a la funcion para aumentar la puntuacion

            Destroy(col.gameObject, 0.2f); //se destruye el alien
            
            col.gameObject.GetComponent<SpriteRenderer>().sprite = muerte3; //se llama al sprite de explosion
            col.gameObject.GetComponent<SpriteRenderer>().sprite = muerte3_2;
            /*
             * Animation anim; variables de tipo animation
             * 
             * col.gameObject.GetComponent<Animator>().SetTrigger("muerte"); se activa la animacion muerte
             */

            Destroy(gameObject);//se destruye la bala

            cambio_de_nivel--;
        }
    }

    void IncreaseTextUIScore(int puntajeNum)//funcion para aumentar el puntaje
    {
        puntajeTxt.text = puntajeNum.ToString(); //manda el resultado a la pantalla
    }

    void OnBecomeInvisible()//una vez invisible (fuera de camara)
    {
        Destroy(gameObject); //se destruye la bala
    }

    private void Awake()
    {
        puntajeTxt = GameObject.FindGameObjectWithTag("puntaje").GetComponent<Text>();
    }
}