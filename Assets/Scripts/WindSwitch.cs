using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSwitch : MonoBehaviour
{
    //�@�������{�^���I�u�W�F�N�g
    [SerializeField]
    private GameObject _button;
    //�@�A�N�e�B�u�ɂ���G�t�F�N�g�I�u�W�F�N�g
    [SerializeField]
    private GameObject _wind;
    //�@���̋���
    private float _windForce = 50f;
    //�@�X�C�b�`�̉�
    [SerializeField]
    private AudioClip _switchSound;
    //�@���̉�
    [SerializeField]
    private AudioClip _windSound;
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
            // �{�^���������������
            _button.transform.position -= new Vector3(0, 0.5f, 0);
            _button.transform.localScale -= new Vector3(0, 0.5f, 0);
            //�@�G�t�F�N�g����
            _wind.SetActive(true);

            //�@���ŋ����΂�
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 windDirection = new Vector2(1f, 0f);
            Vector2 windForceVector = windDirection * _windForce;
            //�@���̉�
            _audioSource.clip = _windSound;
            _audioSource.Play();

            rb.AddForce(windForceVector, ForceMode2D.Impulse);
        }
    }
}
