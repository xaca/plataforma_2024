using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class FadeSinCoroutine : MonoBehaviour
{
    
    private GameObject _fadeObject;
    protected SpriteRenderer _spriteRenderer;
    [Header("Fade")]
    [MMInspectorButton("FadeIn")]
    public bool FadeInButton;
    [MMInspectorButton("FadeOut")]
    public bool FadeOutButton;

    void Start()
    {
        
    }
    public SpriteRenderer setPlayer()
    {
        GameObject model,sr;
        _fadeObject = LevelManager.Instance.Players[0].gameObject;
         model = _fadeObject.transform.Find("Model").gameObject;
        
        if (model == null)
        {
            Debug.LogError("Model not found");
        }
        else{
            sr = model.transform.Find("SpriteRenderer").gameObject;
            if(sr == null)
            {
                Debug.LogError("SpriteRenderer not found");
            }
            else{
                SpriteRenderer renderer = sr.GetComponent<SpriteRenderer>();
                return renderer;
            }
        }
        
        return null;
    }
    public virtual void FadeIn()
    {
        _spriteRenderer = setPlayer();
        
        Color c = _spriteRenderer.color;
        for (float alpha = 0; alpha <= 1; alpha+=.01f)
        {
            c.a = alpha;
            _spriteRenderer.color = c;
        }
    }
    public virtual void FadeOut()
    {
        _spriteRenderer = setPlayer();
        Color c = _spriteRenderer.color;
        for (float alpha = 1; alpha > 0; alpha-=.01f)
        {
            c.a = alpha;
            _spriteRenderer.color = c;
        }
        
    }

}
