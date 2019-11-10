using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//se añade el engine para manejar escenas
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Iniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//llama al escenario 1
    }

    public void Cerrar()
    {
        Application.Quit();
    }

    public void Reanudar()
    {
        Time.timeScale = 1;
    }

    public void menu()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);//llama al escenario 0
    }
}