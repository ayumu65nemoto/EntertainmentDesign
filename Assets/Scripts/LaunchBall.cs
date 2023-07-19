using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    //　打ち上げの強さ
    private float _launchForce = 200f;
    //　打ち上げ時の音
    [SerializeField]
    private AudioClip _launchSound;
    //　AudioSource
    [SerializeField]
    private AudioSource _audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //　ばねで球を飛ばす
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            Vector2 launchDirection = new Vector2(0f, 1f);
            Vector2 launchForceVector = launchDirection * _launchForce;
            //　ばねの音
            _audioSource.clip = _launchSound;
            _audioSource.Play();

            rb.AddForce(launchForceVector, ForceMode2D.Impulse);
        }
    }
}
