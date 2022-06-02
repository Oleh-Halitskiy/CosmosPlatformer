using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private Inventory shopInventory;
    [SerializeField] private GameObject shopPanel;
    private BoxCollider2D boxCollider;
    private Inventory playerInventory;
    private bool ShopOpened = false;
    void Start()
    {
       boxCollider = GetComponent<BoxCollider2D>(); 
    }
    void Update()
    {
        if (ShopOpened)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                //buy item 1
                Debug.Log("One is pressed");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                //buy item 2
                Debug.Log("Two is pressed");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                //buy item 3
                Debug.Log("Three is pressed");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                //buy item 4
                Debug.Log("Four is pressed");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            ShopOpened = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            ShopOpened = false;
        }
    }
}
