using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    //�@���P�b�g
    [SerializeField]
    private GameObject _rocket;
    //�@�ł��グ�̋���
    private int _launchForce = 1;
    //�@�A�N�e�B�u�ɂ���G�t�F�N�g
    [SerializeField]
    private GameObject _effect;
    //�@���P�b�g�̉�
    [SerializeField]
    private AudioClip _reflectSound;
    //�@AudioSource
    [SerializeField]
    private AudioSource _audioSource;
    //�@���P�b�g�ɗ͂������邩�ۂ�
    private bool _isLauch = false;

    private void Update()
    {
        if (_isLauch == true)
        {
            LaunchRocket();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //�@�����i�[�i�����j
            Destroy(collision.gameObject);

            _isLauch = true;
        }
    }

    private void LaunchRocket()
    {
        Rigidbody2D rb = _rocket.GetComponent<Rigidbody2D>();
        Vector2 launchDirection = new Vector2(0f, 1f);
        Vector2 launchForceVector = launchDirection * _launchForce;
        rb.AddForce(launchForceVector, ForceMode2D.Impulse);
        _effect.SetActive(true);
    }
}
