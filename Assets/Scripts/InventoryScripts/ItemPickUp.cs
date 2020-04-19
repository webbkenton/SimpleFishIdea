
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            PickUp();
        }
    }
    public void PickUp()
    {
        Debug.Log("Picking Up " + item.name);
        bool wasPickedUp = Inventory.instance.add(item);

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
        
    }
}
