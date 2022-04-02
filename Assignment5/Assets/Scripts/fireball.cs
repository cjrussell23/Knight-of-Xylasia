using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public void Shoot(float direction)
    {
        Vector3 scale = transform.localScale;
        Vector3 newScale = new Vector3(scale.x * direction, scale.y, scale.z);
        transform.localScale = newScale;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(.1f * direction, 0));
        Invoke(nameof(DestroyFireBall), 2f);
    }
    private void DestroyFireBall()
    {
        Destroy(gameObject);
    }
}
