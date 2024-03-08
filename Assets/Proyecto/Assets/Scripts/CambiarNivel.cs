using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarNivel : MonoBehaviour
{
    [SerializeField]
    private string siguiente;

    public void OnCambiarDeNivel()
    {
        MMSceneLoadingManager.LoadScene(siguiente);
        //Debug.Log("Cambiar de nivel");
    }
}
