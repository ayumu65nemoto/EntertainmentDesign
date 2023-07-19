using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    //�@�ł��グ�̋���
    private float _launchForce = 200f;
    //�@�ł��グ���̉�
    [SerializeField]
    private AudioClip _launchSound;
    //�@AudioSource
    [SerializeField]
    private AudioSource _audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //�@�΂˂ŋ����΂�
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            Vector2 launchDirection = new Vector2(0f, 1f);
            Vector2 launchForceVector = launchDirection * _launchForce;
            //�@�΂˂̉�
            _audioSource.clip = _launchSound;
            _audioSource.Play();

            rb.AddForce(launchForceVector, ForceMode2D.Impulse);
        }
    }
}
