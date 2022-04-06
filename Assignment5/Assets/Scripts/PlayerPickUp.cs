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
                    case ItemData.ItemType.Apple:
                        _playerResources.AdjustHitPoints(hitObject.Quantity);
                        break;
                    case ItemData.ItemType.Bananna:
                        _playerResources.AdjustMana(hitObject.Quantity);
                        break;
                    case ItemData.ItemType.Kiwi:
                        _playerResources.AdjustDamageMultiplier(hitObject.Quantity);
                        break;
                    case ItemData.ItemType.Melon:
                        _playerResources.AdjustHitPoints(hitObject.Quantity);
                        break;
                    case ItemData.ItemType.Orange:
                        _playerResources.AdjustHitPoints(hitObject.Quantity);
                        break;
                    case ItemData.ItemType.Pineapple:
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
