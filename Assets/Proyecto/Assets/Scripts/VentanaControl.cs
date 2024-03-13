using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class VentanaControl : MonoBehaviour
{
    private Vector3 _posicionInicial;

   ///<summary>
 /// Positions of all four side of the screen. It is calculated using the screen camera .
 ///</summary>
 private Vector3
     leftScreenPosition,
     rightScreenPosition,
     topScreenPosition,
     bottomScreenPosition;


 /// <summary>
 /// offset positions of all side of the screen calculated with panel size in mind.
 /// </summary>
 private Vector3
     leftOffSetScreenPosition,
     rightOffSetScreenPosition,
     topOffSetScreenPosition,
     bottomOffSetScreenPosition;
    private Camera _mainCamera; //Main camera of the scene.
    private RectTransform posicion;
    [SerializeField]
    private GameObject panel;

    //Set the all position of all the screen side positions.
    private void UpdateAllSideScreenPositions()
    {
        if (_mainCamera == null)
            _mainCamera = GameObject.Find("UICamera").GetComponent<Camera>();
            
        //Vector3 screenDimen = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f)) * 2;
        Vector3 screenDimen = _mainCamera.WorldToScreenPoint(new Vector3(Screen.width, Screen.height, 0f)) * 2;
        
        if (screenDimen.x < screenDimen.y)
        {
            screenDimen = new Vector3(screenDimen.y, screenDimen.x, screenDimen.z);
        }

        topScreenPosition = new Vector3(0, screenDimen.y / 2, 0);
        bottomScreenPosition = new Vector3(0, -screenDimen.y / 2, 0);
        leftScreenPosition = new Vector3(-screenDimen.x / 2, 0, 0);
        rightScreenPosition = new Vector3(screenDimen.x / 2, 0, 0);
    }

    private void SetOffScreenPositionForPanel()
    {
        //_mainCamera.WorldToScreenPoint(transform.position);
        RectTransform myRect = transform.GetComponent<RectTransform>();
        float sizeToAdd = myRect.rect.width / 100;
        leftOffSetScreenPosition = leftScreenPosition - new Vector3(sizeToAdd, 0, 0);
        rightOffSetScreenPosition = rightScreenPosition + new Vector3(sizeToAdd, 0, 0);
        sizeToAdd = myRect.rect.height / 100;
        topOffSetScreenPosition = topScreenPosition + new Vector3(0, sizeToAdd, 0);
        bottomOffSetScreenPosition = bottomScreenPosition - new Vector3(0, sizeToAdd, 0);
        
    }

    void Awake()
    {
        //UpdateAllSideScreenPositions();
        posicion = panel.transform.GetComponent<RectTransform>();
        //RectTransform myRect = posicion;
        //myRect.anchoredPosition.Set(.5f, -1.5f);
        /*myRect.pivot = new Vector2(.5f,-1.5f);
        Debug.Log(myRect.position+" "+myRect.pivot);
        Vector2 inicio = Vector2.one*myRect.position;

        //myRect.anchoredPosition.Set(.5f,0);
        myRect.pivot = new Vector2(.5f,0);
        Debug.Log(myRect.position+" "+myRect.pivot);
        Vector2 next = Vector2.one*myRect.position;*/

        
        /*Debug.Log(Vector2.up);
        Debug.Log(_mainCamera.WorldToScreenPoint(Vector2.up*temp.y)+" "+Vector2.up*temp.y);
        Debug.Log(myRect.rect.height);*/
        //SetOffScreenPositionForPanel();
        //Vector2 pos_x = Vector2.right*myRect.rect.width;
        //Debug.Log(myRect.rect.width+" "+myRect.rect.height);
        //Debug.Log(Screen.width*2+" "+Screen.height*2);

        //float x = ((Screen.width*2)-myRect.rect.width)/2;
        //float y = ((Screen.height*2)-myRect.rect.height)/2;
        //float x = Screen.width*2;
        //float y = Screen.height*2-myRect.rect.height;
        //Debug.Log(_mainCamera.WorldToScreenPoint(Vector2.right*Screen.width)+" "+myRect.rect.width);
        //Vector2 inicio = _mainCamera.ScreenToWorldPoint(new Vector2(500,0));
        //Vector2 fin = _mainCamera.ScreenToWorldPoint(Vector2.right*900);
        //Vector2 fin = _mainCamera.ScreenToWorldPoint(new Vector2(500,-800));
       // myRect.rect.Set(500,0,myRect.rect.width,myRect.rect.height);
        //myRect.ForceUpdateRectTransforms();
        //myRect.anchoredPosition = new Vector2(500,-800);
        
        Vector2 inicio = new Vector2(274,100);
        //myRect.rect.Set(500,-800,myRect.rect.width,myRect.rect.height);
        Vector2 fin = new Vector2(274,-800);

        posicion.anchoredPosition = inicio;
        //Debug.Log(myRect.position);
        StartCoroutine(AnimarVentana(inicio,fin));
        GameManager.Instance.Pause(PauseMethods.NoPauseMenu);
    }
    public void MoveFromTop()
    {
        Vector3 posToGive = Vector3.zero;
        Vector3 initPos = Vector3.zero;
        initPos =  topOffSetScreenPosition; 
        transform.position = initPos;
        posToGive =  topScreenPosition;
        MMTween.MoveTransform(this, this.transform, initPos, posToGive, null, 0, .5f, MMTween.MMTweenCurve.EaseInSinusoidal);
    }
    // Start is called before the first frame update

    public void CerrarVentana()
    {
        Vector2 inicio = new Vector2(274, 100);
        //myRect.rect.Set(500,-800,myRect.rect.width,myRect.rect.height);
        Vector2 fin = new Vector2(274, -800);
        StartCoroutine(AnimarVentana(fin, inicio));
        GameManager.Instance.Pause(PauseMethods.NoPauseMenu);
    }

    IEnumerator AnimarVentana(Vector2 inicio,Vector2 fin){
        //Debug.Log("AnimarVentana");
        //RectTransform temp = new RectTransform();
        for(float i=0;i<1;i+=.01f){ //Time.deltaTime
            posicion.anchoredPosition = Vector2.Lerp(inicio,fin,i);
            yield return null;
        }
        //yield return new WaitForSeconds(1);
        //Debug.Log("AnimarVentana 2");
        //MMTween.MoveTransform(this, posicion.anchoredPosition, inicio, fin, null, 0, .5f, MMTween.MMTweenCurve.EaseInSinusoidal);
        //MMTween.MoveRectTransform(this, posicion, inicio, fin, null, 0, .5f, MMTween.MMTweenCurve.EaseInSinusoidal);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
