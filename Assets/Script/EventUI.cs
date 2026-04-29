using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EventUI : MonoBehaviour
{
    public List<GameObject> listaInstrucciones;
    public int currentIndex = 0;
    public List<string> mensajesInstrucciones;
    public TextMeshProUGUI textMeshProUGUI;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Actualizar visibilidad de páneles
        UpdateVisibility();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método para actualizar visibilidad de páneles

    private void UpdateVisibility()
    {
        for (int i = 0; i < listaInstrucciones.Count; i++)
        {
            //Solo el panel en el índice actual está activo
            listaInstrucciones[i].SetActive(i == currentIndex);

        }
    }

    //Método para cambiar de escena

    public void ChangeSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    //Metodo para cambiar de escena por nombre

    public void ChangeSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    //Recargar escena actual
    public void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }


    //Método para cambiar entre páneles

    public void CycleObjets(int direction)
    {
        //Incrementa el índice y vuelve al principio
        currentIndex = (currentIndex + direction + listaInstrucciones.Count) % listaInstrucciones.Count;

        //Actualizar la visibilidad
        UpdateVisibility();
    }


    //Método para actualizar el texto mostrado


    private void UpdateText()
    {
        if (mensajesInstrucciones.Count > 0 && textMeshProUGUI !=null)
        {
            textMeshProUGUI.text = mensajesInstrucciones[currentIndex];
        }
    }


    public void CycleText(int direction)
    {
        //Incrementa el índice y vuelve al principio
        currentIndex = (currentIndex + direction + mensajesInstrucciones.Count) % mensajesInstrucciones.Count;

        //Actualizar la visibilidad
        UpdateText();
    }



    //Método para salir de la aplicación

    public void ExitGame()
    {
        Debug.Log("Va a salir");
        Application.Quit();
        Debug.Log("Ya salió");
    }
}
