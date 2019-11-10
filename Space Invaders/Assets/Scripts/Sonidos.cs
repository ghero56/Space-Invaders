using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour
{

    public static Sonidos Instance = null;

    public AudioClip Fire_1;
    public AudioClip Expl_1;

    private AudioSource Efectos_de_sonido;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        AudioSource theSource = GetComponent<AudioSource>();
        Efectos_de_sonido = theSource;

    }

    public void PlayOneShot(AudioClip clip)
    {
        Efectos_de_sonido.PlayOneShot(clip);
    }

}