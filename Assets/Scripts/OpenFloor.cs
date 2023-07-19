using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFloor : MonoBehaviour
{
    //�@��]������I�u�W�F�N�g
    [SerializeField]
    private GameObject _rotateObject;
    //�@��]�̒��S
    [SerializeField]
    private GameObject _targetObject;
    //�@��]�̎�
    [SerializeField]
    private Vector3 _rotateAxis = Vector3.left;
    //�@��]�̑��x
    private float _rotateSpeed = 500f;
    //�@�Đ�����t�@�C��
    [SerializeField]
    private AudioClip _openSound;
    //�@AudioSource
    [SerializeField]
    private AudioSource _audioSource;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb.mass > 2)
            {
                //�@�����J����
                _audioSource.clip = _openSound;
                _audioSource.Play();

                _rotateObject.transform.RotateAround(_targetObject.transform.position, _rotateAxis, _rotateSpeed * Time.deltaTime);
            }
        }
    }
}
