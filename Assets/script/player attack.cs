using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    public float damage = 10f;
    public float range = 2f;
    public LayerMask treeLayer;

    // Start is called before the first frame update
    void Start()
    {
         Debug.Log("Tree Layer Mask Value: " + treeLayer.value);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider2D hittrees = Physics2D.OverlapCircle(transform.position, range, treeLayer);
        if (hittrees != null)
        {
            Debug.Log("Number of trees hit: 1");
            TreeHealth treeHealth = hittrees.GetComponent<TreeHealth>();
            if (treeHealth != null)
            {
                treeHealth.TakeDamage(damage);
            }
        }
        else
        {
            Debug.Log("Number of trees hit: 0");
        }
    }
}

