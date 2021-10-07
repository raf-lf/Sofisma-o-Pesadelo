using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject deathEffect;

    public void Death()
    {
        GameObject deathEffectObj = Instantiate<GameObject>(deathEffect);
        deathEffectObj.transform.position = new Vector2(transform.position.x, transform.position.y);
        Destroy(this.gameObject);
    }

}
