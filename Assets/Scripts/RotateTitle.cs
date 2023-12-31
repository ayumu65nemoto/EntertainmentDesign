using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTitle : MonoBehaviour
{
    //　回転速度
    private float _rotationSpeed = 200f;
    //　回転回数
    private int _maxRotationCount = 2000;
    //　現在の回転回数
    private int _rotationCount = 0;
    //　回転中か判定
    private bool isRotation = false;
    //　回転の時の音
    [SerializeField]
    private AudioClip _rotationSound;
    //　AudioSource
    [SerializeField]
    private AudioSource _audioSource;
    //　CameraController
    [SerializeField]
    private CameraController _cameraController;

    private void Update()
    {
        if (isRotation == true)
        {
            transform.Rotate(Vector3.right, _rotationSpeed * Time.deltaTime);

            if (_rotationCount >= _maxRotationCount)
            {
                transform.rotation = Quaternion.identity;
                isRotation = false;
            }
            else
            {
                _rotationCount++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = Quaternion.identity;
            isRotation = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isRotation = true;
            _rotationCount = 0;
            _cameraController.SetTarget();
        }
    }
}
