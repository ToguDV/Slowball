using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeForeClickManager : MonoBehaviour
{
    public GameObject[] contenidos;
    bool once;

    private void OnEnable()
    {
        ThrowController.OnFirstClick += OcultarTodo;
    }

    private void OnDisable()
    {
        ThrowController.OnFirstClick -= OcultarTodo;
    }
    void Start()
    {
        once = true;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OcultarTodo()
    {
        if (once)
        {
            foreach (GameObject contenido in contenidos)
            {
                contenido.SetActive(false);
            }
            once = false;
        }
    }
}
