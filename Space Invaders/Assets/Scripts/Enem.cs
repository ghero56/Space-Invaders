using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enem : MonoBehaviour {

    public float velocidad = 2;

    public float rangoDeDisp = 1F;

    private float siguienteDis;

    public Rigidbody2D rigidBody;

    public Sprite ImagenInicial;

    public Sprite ImagenMovimiento;

    private SpriteRenderer renderizador;

    public float TiempoAnDeCambiarImagen = 0.7F;

    public GameObject Disparo_ene;

    public float TiempoMinimoDeDisparo = 1F;

    public float TiempoMaximoDeDisparo = 5.0F;

    public float TiempoBaseDeDisparo = 3F;

    public Sprite ExplosionNave1;

    public Sprite ExplosionNave2;

    void Start(){

        rigidBody = GetComponent<Rigidbody2D>();
        if(Disparo.cambio_de_nivel < 32 && Disparo.cambio_de_nivel > 24)
        {
            velocidad *= 2;
        }

        if (Disparo.cambio_de_nivel == 24 && Disparo.cambio_de_nivel > 16)
        {
            velocidad *= 2;
        }

        if (Disparo.cambio_de_nivel == 16 || Disparo.cambio_de_nivel > 8)
        {
            velocidad *= 2;
        }

        if (Disparo.cambio_de_nivel < 8 && Disparo.cambio_de_nivel > 1)
        {
            velocidad *= 2;
        }

        rigidBody.velocity = new Vector2(1, 0) * velocidad;

        renderizador = GetComponent<SpriteRenderer>();

        StartCoroutine(CambiarImagen());

        TiempoBaseDeDisparo += Random.Range(TiempoMinimoDeDisparo, TiempoMaximoDeDisparo);

    }

    void Cambiar(int direccion) //funcion para voltear la direccion
    {//recibe el entero llamado direccion
        Vector2 nuevaVelocidad = rigidBody.velocity;
        nuevaVelocidad.x = velocidad * direccion;//enrique segoviano
        rigidBody.velocity = nuevaVelocidad;
    }

    void Bajar()//funcion para moverse abajo
    {
        Vector2 posicion = transform.position;
        posicion.y -= 3;
        transform.position = posicion;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //soundManager.Instance.PlayOneShot(SoundManager.Instance.Explosion);
            col.gameObject.GetComponent<SpriteRenderer>().sprite = ExplosionNave1;
            Destroy(gameObject);
            Destroy(col.gameObject, 0.7F);
            col.gameObject.GetComponent<SpriteRenderer>().sprite = ExplosionNave2;
            Destroy(col.gameObject, 0.5F);
        }

        if (col.gameObject.name == "Muro_izq") {
            Cambiar(1);//se llama a la funcion cambiar y se le manda el entero 1
            Bajar();
        }

        if (col.gameObject.name == "Muro_der")
        {      
            Cambiar(-1);
            Bajar();
        }

        if (col.gameObject.tag == "balas")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.name == "Muro_inf")
        {
            Cambiar(-1);
            Bajar();
        }
    }

    public IEnumerator CambiarImagen()//funcion para cambiar la imagen
    {
        while (true)
        {
            if(renderizador.sprite == ImagenInicial)
                renderizador.sprite = ImagenMovimiento;
            else
                renderizador.sprite = ImagenInicial;
            yield return new WaitForSeconds(TiempoAnDeCambiarImagen);
        }
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
            siguienteDis = Time.time + rangoDeDisp;
        else if(Input.GetButtonDown("Jump"))
            siguienteDis = Time.time + rangoDeDisp;
    }

    void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad > TiempoBaseDeDisparo) 
        {
           
            TiempoBaseDeDisparo += Random.Range(TiempoMinimoDeDisparo, TiempoMaximoDeDisparo);

            Instantiate(Disparo_ene , transform.position, Quaternion.identity);
        }
    }
}
