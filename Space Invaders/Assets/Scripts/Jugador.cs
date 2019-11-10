using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jugador : MonoBehaviour{

    public float rangoDeDisp = 1F;

    private float siguienteDis;

    public AudioSource explosion, disparo;
    private float t = 0.5F;

    public int vidasNum = 3;
    public Text vidasTxt;

    //variable llamada velocidad
    public float velocidad = 30;
    //objeto de balas
    public GameObject Ballas_GTA;

    void FixedUpdate(){
        float horizontal = Input.GetAxisRaw("Horizontal"); //variable llamada horizontal que obtiene los valores de las teclas

        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal, 0) * velocidad;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "BalasEnm")
        {
            Destroy(col.gameObject, t);
            IncreaseTextUIScore();
            if (vidasNum == 0)
            {
                explosion.Play();
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
        if (Input.GetButtonDown("Jump")) {
            Instantiate(Ballas_GTA, transform.position, Quaternion.identity);
            disparo.Play();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(Ballas_GTA, transform.position, Quaternion.identity);
            disparo.Play();
        }
        if (Input.GetButtonDown("pausa"))
        {
            if (Time.timeScale == 0)
                Time.timeScale = 1;
            else
                Time.timeScale = 0;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            siguienteDis = Time.time + rangoDeDisp;
        }
        else if (Input.GetButtonDown("Jump"))
        {
            siguienteDis = Time.time + rangoDeDisp;
        }
    }
}
