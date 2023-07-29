using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    //　表示するテキスト
    [TextArea(1, 10)]
    public string _text;
    //　テキストエリア
    [SerializeField]
    private TextMeshProUGUI _tmp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _tmp.text = _text;
        }
    }
}
