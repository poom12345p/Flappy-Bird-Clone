using System;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Canvas Canvas=>_canvas;
    [SerializeField] protected Canvas _canvas;
    [SerializeField] protected GraphicRaycaster _raycaster;
    [SerializeField]protected CanvasGroup _canvasGroup;
    private Tween _tween;
    
    

    private void Awake()
    {
        gameObject.SetActive(false);
        _canvasGroup.alpha = 0f;
    }

    public void Show()
    {
        if(gameObject.activeInHierarchy)return;
        gameObject.SetActive(true);
        _raycaster.enabled = true;
        _canvasGroup.alpha = 0f;
        _tween.Stop();
        _tween = Tween.Alpha(_canvasGroup, 1f,1f);
       
    }

    public void Hide()
    {
        if(!gameObject.activeInHierarchy)return;
        _raycaster.enabled = false;
        _canvasGroup.alpha = 1f;
        _tween.Stop();
        _tween = Tween.Alpha(_canvasGroup, 0f,1f);
        _tween.OnComplete(()=>gameObject.SetActive(false));
    }
}
