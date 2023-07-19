using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFloor : MonoBehaviour
{
    //　回転させるオブジェクト
    [SerializeField]
    private GameObject _rotateObject;
    //　回転の中心
    [SerializeField]
    private GameObject _targetObject;
    //　回転の軸
    [SerializeField]
    private Vector3 _rotateAxis = Vector3.left;
    //　回転の速度
    private float _rotateSpeed = 500f;
    //　再生するファイル
    [SerializeField]
    private AudioClip _openSound;
    //　AudioSource
    [SerializeField]
    private AudioSource _audioSource;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb.mass > 2)
            {
                //　扉が開く音
                _audioSource.clip = _openSound;
                _audioSource.Play();

                _rotateObject.transform.RotateAround(_targetObject.transform.position, _rotateAxis, _rotateSpeed * Time.deltaTime);
            }
        }
    }
}
