using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Renderer _backgroundRenderer;

    public float backgroundSpeed;
    private void Update()
    {
        if(_gameManager.startTimer == 0)
            _backgroundRenderer.material.mainTextureOffset += new Vector2(0f, backgroundSpeed * Time.deltaTime);
    }
}
