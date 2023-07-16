using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSpawnSwitch : MonoBehaviour
{
    //　押されるボタンオブジェクト
    [SerializeField]
    private GameObject _button;
    //　消去するオブジェクト
    [SerializeField]
    private GameObject _destroyObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ボタン部分が押される
            _button.transform.position += new Vector3(0.5f, 0, 0);
            _button.transform.localScale -= new Vector3(0, 0.5f, 0);

            // でかい球の足場を壊す
            Destroy(_destroyObject);
        }
    }
}
