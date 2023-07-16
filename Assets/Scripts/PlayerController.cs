using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�@�Đ�����t�@�C��
    [SerializeField]
    private  AudioClip _collisionSound;
    //�@AudioSource
    [SerializeField]
    private AudioSource _audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // �n�ʂɐڐG�����ꍇ�ɉ����Đ�����
            _audioSource.clip = _collisionSound;
            _audioSource.Play();
        }
    }
}
