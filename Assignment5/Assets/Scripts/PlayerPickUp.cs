using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    // Other Player Scripts
    private PlayerController _playerController;
    private PlayerResources _playerResources;
    void Start()
    {
        // Other Player Scripts
        _playerController = GetComponent<PlayerController>();
        _playerResources = GetComponent<PlayerResources>();
    }
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            ItemData hitObject = collision.gameObject.
            GetComponent<Consumable>().Item;
            if (hitObject != null)
            {
                print("Hit: " + hitObject.ObjectName);
                switch (hitObject.Type)
                {
                    case ItemData.ItemType.Coin:
                    
                        break;
                    case ItemData.ItemType.Health:
                        _playerResources.AdjustHitPoints(hitObject.Quantity);
                        break;
                    case ItemData.ItemType.Strawberry:
                        _playerResources.AdjustHitPoints(hitObject.Quantity);
                        break;
                }
                collision.gameObject.SetActive(false);
            }
        }
    }
}
