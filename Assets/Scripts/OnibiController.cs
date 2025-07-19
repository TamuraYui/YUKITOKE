using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnibiController : EnemyBase
{
    CircleCollider2D _circol;
    public override void Ability()
    {
        _circol = GetComponent<CircleCollider2D>();
        Debug.Log("playerî≠å©ÅIOni");

        if (_circol != null)
        {
            for (int i = 0; i < 1.05; i++)
            {
                _circol.radius += 0.001f;
            }

            //Destroy(gameObject);
        }
    }
}
