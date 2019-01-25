using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine.UI;

public class EndlessRunnerBackground : MonoBehaviour
{
    public ChaserEngine engine;
    public Image image;

    private float _width;
    private RectTransform _rect;
    
    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _width = _rect.rect.width;
        
    }

    private void LateUpdate()
    {
        if (_rect.position.x < -_width)
        {
            _rect.position = Vector2.right * _width * -2;
        } 
    }
}