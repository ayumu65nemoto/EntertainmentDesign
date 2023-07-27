using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveReflection : MonoBehaviour
{
    //　アクティブにするオブジェクト
    [SerializeField]
    private GameObject _reflectWall;
    //　破壊するスイッチ
    [SerializeField]
    private GameObject _destroySwitch;
    //　スイッチの音
    [SerializeField]
    private AudioClip _switchSound;
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
            //　ボタンが押される音
            _audioSource.clip = _switchSound;
            _audioSource.Play();

            //　反射板をアクティブに
            _reflectWall.SetActive(true);

            //　球を跳ね返す
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = -rb.velocity;
            _audioSource.clip = _reflectSound;
            _audioSource.Play();

            //　このオブジェクトを破壊
            Destroy(_destroySwitch);
        }
    }
}
