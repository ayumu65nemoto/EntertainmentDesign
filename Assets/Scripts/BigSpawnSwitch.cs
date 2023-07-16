using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSpawnSwitch : MonoBehaviour
{
    //�@�������{�^���I�u�W�F�N�g
    [SerializeField]
    private GameObject _button;
    //�@��������I�u�W�F�N�g
    [SerializeField]
    private GameObject _destroyObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �{�^���������������
            _button.transform.position += new Vector3(0.5f, 0, 0);
            _button.transform.localScale -= new Vector3(0, 0.5f, 0);

            // �ł������̑������
            Destroy(_destroyObject);
        }
    }
}
