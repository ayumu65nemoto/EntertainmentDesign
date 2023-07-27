using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    //　ロケット
    [SerializeField]
    private GameObject _rocket;
    //　打ち上げの強さ
    private int _launchForce = 1;
    //　アクティブにするエフェクト
    [SerializeField]
    private GameObject _effect;
    //　ロケットの音
    [SerializeField]
    private AudioClip _reflectSound;
    //　AudioSource
    [SerializeField]
    private AudioSource _audioSource;
    //　ロケットに力を加えるか否か
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
            //　球を格納（消去）
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
