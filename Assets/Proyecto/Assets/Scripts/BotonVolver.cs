using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonVolver : MonoBehaviour
{
    public void OnclickVolver()
    {
        MMSceneLoadingManager.LoadScene("Inicio");
    }
}
