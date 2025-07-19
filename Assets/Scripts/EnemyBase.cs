using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("移動速度")]
    [SerializeField] float _moveSpeed = 3f;
    Rigidbody2D _rb = default;
    public Vector2 _lineForPlayer = Vector2.right; // Rayの方向
    [Header("反応する相手(player)")]
    public LayerMask _layerMask;//PlayerのLayer

    /// <summary>
    /// 敵のそれぞれの性能を実装する
    /// </summary>
    public abstract void Ability();

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        EnemyAct();
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        Vector2 velocity = _rb.velocity;   // この変数 velocity に速度を計算して、最後に Rigidbody2D.velocity に戻す

        if (h == 0)
        {
            velocity.x = h - _moveSpeed;
        }

        _rb.velocity = velocity;
    }
    /// <summary>
    /// playerを見つけた時に実行
    /// </summary>
    void EnemyAct()
    {
        Vector2 start = this.transform.position;
        RaycastHit2D hit = Physics2D.Linecast(start,start - _lineForPlayer * 10, _layerMask);
        Debug.DrawLine(transform.position,start - _lineForPlayer * 10, Color.red);  // 検出するセンサー の可視化

        if (hit.collider != null)
        {
                Ability();
        }
    }
}
