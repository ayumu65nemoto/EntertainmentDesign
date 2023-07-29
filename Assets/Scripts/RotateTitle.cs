using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTitle : MonoBehaviour
{
    //�@��]���x
    private float _rotationSpeed = 200f;
    //�@��]��
    private int _maxRotationCount = 2000;
    //�@���݂̉�]��
    private int _rotationCount = 0;
    //�@��]��������
    private bool isRotation = false;
    //�@��]�̎��̉�
    [SerializeField]
    private AudioClip _rotationSound;
    //�@AudioSource
    [SerializeField]
    private AudioSource _audioSource;
    //�@CameraController
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
