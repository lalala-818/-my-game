using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCraftingUI : MonoBehaviour
{
    public GameObject craftingUI;

    void Start()
    {
        // 默认隐藏合成界面
        if (craftingUI != null)
        {
            craftingUI.SetActive(false);
        }
    }
    void Update()
    {
        // 检测按下 E 键
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 切换合成界面的显示状态
            if (craftingUI != null)
            {
                craftingUI.SetActive(!craftingUI.activeSelf);
            }
        }
    }
}
