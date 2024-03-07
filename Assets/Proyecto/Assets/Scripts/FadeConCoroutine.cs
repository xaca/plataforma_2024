using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class FadeConCoroutine : FadeSinCoroutine
{
    [SerializeField]
    private MMF_Player feedback;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void FadeIn()
    {
        feedback?.PlayFeedbacks();
        StartCoroutine(FadeInCoroutine());
    }

    public override void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        _spriteRenderer = setPlayer();
        
        Color c = _spriteRenderer.color;
        for (float alpha = 0; alpha <= 1; alpha+=.01f)
        {
            //Debug.Log("FadeInCoroutine "+alpha);
            c.a = alpha;
            _spriteRenderer.color = c;
            yield return new WaitForSeconds(0.1f);
            //yield return null;
        }
        
    }

    private IEnumerator FadeOutCoroutine()
    {
        _spriteRenderer = setPlayer();
        
        Color c = _spriteRenderer.color;
        for (float alpha = 1; alpha > 0; alpha-=.01f)
        {
            //Debug.Log("FadeOutCoroutine "+alpha);
            c.a = alpha;
            _spriteRenderer.color = c;
            yield return new WaitForSeconds(0.01f);
            //yield return null;
        }
        
    }
}
