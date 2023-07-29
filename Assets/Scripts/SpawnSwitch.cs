using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSwitch : MonoBehaviour
{
    //　押されるボタンオブジェクト
    [SerializeField]
    private GameObject _button;
    //　消去するオブジェクト
    [SerializeField]
    private GameObject _destroyObject;
    //　球を消す
    [SerializeField]
    private GameObject _destroyBall;
    //　再生するファイル
    [SerializeField]
    private AudioClip _switchSound;
    //　AudioSource
    [SerializeField]
    private AudioSource _audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ボタンが押される音
            _audioSource.clip = _switchSound;
            _audioSource.Play();
            // ボタン部分が押される
            _button.transform.position += new Vector3(0, 0.5f, 0);
            _button.transform.localScale -= new Vector3(0, 0.5f, 0);

            // 球の足場を壊す
            Destroy(_destroyObject);

            _destroyBall = collision.gameObject;
            StartCoroutine(DestroyBall());
        }
    }

    private IEnumerator DestroyBall()
    {
        yield return new WaitForSeconds(1f); // 2秒待つ

        Destroy(_destroyBall);

        yield return null;
    }
}
