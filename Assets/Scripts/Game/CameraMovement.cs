using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    public float cameraSpeed;

    private void Update()
    {
        if(_gameManager.startTimer == 0)
            transform.position += new Vector3(0, cameraSpeed * Time.deltaTime, 0);
    }
}
