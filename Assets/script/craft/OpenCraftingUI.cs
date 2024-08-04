using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCraftingUI : MonoBehaviour
{
    public GameObject craftingUI;

    void Start()
    {
        // Ĭ�����غϳɽ���
        if (craftingUI != null)
        {
            craftingUI.SetActive(false);
        }
    }
    void Update()
    {
        // ��ⰴ�� E ��
        if (Input.GetKeyDown(KeyCode.E))
        {
            // �л��ϳɽ������ʾ״̬
            if (craftingUI != null)
            {
                craftingUI.SetActive(!craftingUI.activeSelf);
            }
        }
    }
}
