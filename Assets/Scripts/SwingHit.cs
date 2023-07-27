using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingHit : MonoBehaviour
{
    //　球を飛ばす強さ
    private float _hitForce = 100f;
    //　再生するファイル
    [SerializeField]
    private AudioClip _hitSound;
    //　AudioSource
    [SerializeField]
    private AudioSource _audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //　ボタンが押される音
            _audioSource.clip = _hitSound;
            _audioSource.Play();
            
            //　球を飛ばす
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 hitDirection = new Vector2(1f, 0f);
            Vector2 hitForceVector = hitDirection * _hitForce;
            
            rb.AddForce(hitForceVector, ForceMode2D.Impulse);
        }
    }
}
