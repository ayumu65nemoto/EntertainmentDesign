using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //　再生するファイル
    [SerializeField]
    private  AudioClip _collisionSound;
    //　AudioSource
    [SerializeField]
    private AudioSource _audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // 地面に接触した場合に音を再生する
            _audioSource.clip = _collisionSound;
            _audioSource.Play();
        }
    }
}
