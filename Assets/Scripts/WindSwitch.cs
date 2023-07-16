using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSwitch : MonoBehaviour
{
    //�@�������{�^���I�u�W�F�N�g
    [SerializeField]
    private GameObject _button;
    //�@�A�N�e�B�u�ɂ���G�t�F�N�g�I�u�W�F�N�g
    [SerializeField]
    private GameObject _wind;
    //�@���̋���
    private float _windForce = 50f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �{�^���������������
            _button.transform.position -= new Vector3(0, 0.5f, 0);
            _button.transform.localScale -= new Vector3(0, 0.5f, 0);
            //�@�G�t�F�N�g����
            _wind.SetActive(true);

            //�@���ŋ����΂�
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 windDirection = new Vector2(1f, 0f);
            Vector2 windForceVector = windDirection * _windForce;

            rb.AddForce(windForceVector, ForceMode2D.Impulse);
        }
    }
}
