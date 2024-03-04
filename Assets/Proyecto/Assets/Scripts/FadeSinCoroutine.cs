using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class FadeSinCoroutine : MonoBehaviour
{
    private GameObject model,sr;
    private GameObject _fadeObject;
    private SpriteRenderer _spriteRenderer;
    [Header("Fade")]
    [MMInspectorButton("FadeIn")]
    public bool FadeInButton;
    [MMInspectorButton("FadeOut")]
    public bool FadeOutButton;

    void Start()
    {
        
    }
    void setPlayer()
    {
        _fadeObject = LevelManager.Instance.Players[0].gameObject;
         model = _fadeObject.transform.Find("Model").gameObject;
        
        if (model == null)
        {
            Debug.LogError("Model not found");
            return;
        }
        else{
            sr = model.transform.Find("SpriteRenderer").gameObject;
        }
    }
    public virtual void FadeIn()
    {
        setPlayer();
        if(sr == null)
        {
            Debug.LogError("SpriteRenderer not found");
            return;
        }
        SpriteRenderer renderer = sr.GetComponent<SpriteRenderer>();
        Color c = renderer.color;
        for (int alpha = 0; alpha <= 255; alpha++)
        {
            c.a = alpha;
            renderer.color = c;
        }
    }
    public virtual void FadeOut()
    {
        Debug.Log("Fade");
        setPlayer();
        
        if(sr == null)
        {
            Debug.LogError("SpriteRenderer not found");
            return;
        }

        SpriteRenderer renderer = sr.GetComponent<SpriteRenderer>();
        Color c = renderer.color;
        for (int alpha = 255; alpha >= 0; alpha--)
        {
            c.a = alpha;
            renderer.color = c;
        }
        
    }

}
