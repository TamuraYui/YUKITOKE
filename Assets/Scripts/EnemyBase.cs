using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("�ړ����x")]
    [SerializeField] float _moveSpeed = 3f;
    Rigidbody2D _rb = default;
    public Vector2 _lineForPlayer = Vector2.right; // Ray�̕���
    [Header("�������鑊��(player)")]
    public LayerMask _layerMask;//Player��Layer

    /// <summary>
    /// �G�̂��ꂼ��̐��\����������
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
        Vector2 velocity = _rb.velocity;   // ���̕ϐ� velocity �ɑ��x���v�Z���āA�Ō�� Rigidbody2D.velocity �ɖ߂�

        if (h == 0)
        {
            velocity.x = h - _moveSpeed;
        }

        _rb.velocity = velocity;
    }
    /// <summary>
    /// player�����������Ɏ��s
    /// </summary>
    void EnemyAct()
    {
        Vector2 start = this.transform.position;
        RaycastHit2D hit = Physics2D.Linecast(start,start - _lineForPlayer * 10, _layerMask);
        Debug.DrawLine(transform.position,start - _lineForPlayer * 10, Color.red);  // ���o����Z���T�[ �̉���

        if (hit.collider != null)
        {
                Ability();
        }
    }
}
