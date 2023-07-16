using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSwitch : MonoBehaviour
{
    //　押されるボタンオブジェクト
    [SerializeField]
    private GameObject _button;
    //　アクティブにするエフェクトオブジェクト
    [SerializeField]
    private GameObject _wind;
    //　風の強さ
    private float _windForce = 50f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ボタン部分が押される
            _button.transform.position -= new Vector3(0, 0.5f, 0);
            _button.transform.localScale -= new Vector3(0, 0.5f, 0);
            //　エフェクト発生
            _wind.SetActive(true);

            //　風で球を飛ばす
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 windDirection = new Vector2(1f, 0f);
            Vector2 windForceVector = windDirection * _windForce;

            rb.AddForce(windForceVector, ForceMode2D.Impulse);
        }
    }
}
