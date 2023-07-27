using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectBall : MonoBehaviour
{
    //　跳ね返す回数
    [SerializeField]
    private int _reflectCount = 0;
    //　破壊するオブジェクト
    [SerializeField]
    private GameObject _destroyReflect;
    //　跳ね返す音
    [SerializeField]
    private AudioClip _reflectSound;
    //　AudioSource
    [SerializeField]
    private AudioSource _audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //　球を跳ね返す
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = -rb.velocity;
            _reflectCount--;
            _audioSource.clip = _reflectSound;
            _audioSource.Play();

            //　一定回数跳ね返したら破壊
            if (_reflectCount == 0)
            {
                Destroy(_destroyReflect);
            }
        }
    }
}
