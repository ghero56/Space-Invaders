using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jugador : MonoBehaviour{

    public int Valor_actual;

    public float rangoDeDisp = 1F;

    private float siguienteDis = 0;

    public GameObject MenuPausa;

    public AudioSource disparo;
    private float t = 0.5F;

    public int vidasNum = 3;
    public Text vidasTxt;

    

    //variable llamada velocidad
    public float velocidad = 30;
    //objeto de balas
    public GameObject Ballas_GTA;

    void Start()
    {
        disparo = GetComponent<AudioSource>();
    }

    void FixedUpdate(){
        float horizontal = Input.GetAxisRaw("Horizontal"); //variable llamada horizontal que obtiene los valores de las teclas

        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal, 0) * velocidad;

        Valor_actual = Disparo.cambio_de_nivel;

        if (Disparo.cambio_de_nivel <= 0)
        {
            SceneManager.LoadScene("Boss");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "enemigos")
        {
            SceneManager.LoadScene("Menu");
        }

        if (col.gameObject.tag == "enemigo_3")
        {
            SceneManager.LoadScene("Menu");
        }

        if (col.gameObject.tag == "enemigo_2")
        {
            SceneManager.LoadScene("Menu");
        }

        if (col.gameObject.tag == "enemigo_1")
        {
            SceneManager.LoadScene("Menu");
        }

        if (col.gameObject.tag == "BalasEnm")
        {
            Destroy(col.gameObject, t);
            IncreaseTextUIScore();
            if (vidasNum == 0)
            {
                Disparo.puntajeNum = 0;
                Destroy(gameObject);
                SceneManager.LoadScene("Menu");
                
            }
        }
    }

    void IncreaseTextUIScore()
    {
        vidasTxt = GameObject.FindGameObjectWithTag("vidas").GetComponent<Text>();

        vidasNum--;

        vidasTxt.text = vidasNum.ToString(); //manda el resultado a la pantalla
    }

    private void Awake()
    {

        vidasTxt = GameObject.FindGameObjectWithTag("vidas").GetComponent<Text>();

    }

    void Update() {
        if (Input.GetButtonDown("Jump") && Time.time > siguienteDis) {
            siguienteDis = Time.time + rangoDeDisp;
            Instantiate(Ballas_GTA, transform.position, Quaternion.identity);
            disparo.Play();
        }
        if (Input.GetButtonDown("Fire2") && Time.time > siguienteDis)
        {
            siguienteDis = Time.time + rangoDeDisp;
            Instantiate(Ballas_GTA, transform.position, Quaternion.identity);
            disparo.Play();
        }

        if (Input.GetButtonDown("pausa"))
        {
            Pausa();
        }
    }

    void OnEnable()
    {
        Disparo.cambio_de_nivel = 32;
    }

    public void Pausa()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            MenuPausa.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            MenuPausa.SetActive(true);
        }
    }
}
