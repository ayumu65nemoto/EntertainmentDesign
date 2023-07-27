using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectBall : MonoBehaviour
{
    //�@���˕Ԃ���
    [SerializeField]
    private int _reflectCount = 0;
    //�@�j�󂷂�I�u�W�F�N�g
    [SerializeField]
    private GameObject _destroyReflect;
    //�@���˕Ԃ���
    [SerializeField]
    private AudioClip _reflectSound;
    //�@AudioSource
    [SerializeField]
    private AudioSource _audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //�@���𒵂˕Ԃ�
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = -rb.velocity;
            _reflectCount--;
            _audioSource.clip = _reflectSound;
            _audioSource.Play();

            //�@���񐔒��˕Ԃ�����j��
            if (_reflectCount == 0)
            {
                Destroy(_destroyReflect);
            }
        }
    }
}
