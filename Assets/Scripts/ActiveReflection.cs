using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveReflection : MonoBehaviour
{
    //�@�A�N�e�B�u�ɂ���I�u�W�F�N�g
    [SerializeField]
    private GameObject _reflectWall;
    //�@�j�󂷂�X�C�b�`
    [SerializeField]
    private GameObject _destroySwitch;
    //�@�X�C�b�`�̉�
    [SerializeField]
    private AudioClip _switchSound;
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
            //�@�{�^����������鉹
            _audioSource.clip = _switchSound;
            _audioSource.Play();

            //�@���˔��A�N�e�B�u��
            _reflectWall.SetActive(true);

            //�@���𒵂˕Ԃ�
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = -rb.velocity;
            _audioSource.clip = _reflectSound;
            _audioSource.Play();

            //�@���̃I�u�W�F�N�g��j��
            Destroy(_destroySwitch);
        }
    }
}
