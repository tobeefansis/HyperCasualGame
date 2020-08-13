using UnityEngine;
using System.Collections;
[RequireComponent(typeof(BoxCollider2D))]
public class GroundCheck : MonoBehaviour
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] [Range(0, 2)] float groudCheckDistance;
    public bool IsGround => IsGrounded();
    BoxCollider2D _boxCollider2;

    private void Awake()
    {
        _boxCollider2 = transform.GetComponent<BoxCollider2D>();
    }

    private void LateUpdate()
    {
    }
    private bool IsGrounded()
    {
        //return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;

        float extraHeightText = 0.2f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider2.bounds.center, _boxCollider2.bounds.size, 0f, Vector2.down, extraHeightText, groundMask);

        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(_boxCollider2.bounds.center + new Vector3(_boxCollider2.bounds.extents.x, 0), Vector2.down * (_boxCollider2.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(_boxCollider2.bounds.center - new Vector3(_boxCollider2.bounds.extents.x, 0), Vector2.down * (_boxCollider2.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(_boxCollider2.bounds.center - new Vector3(_boxCollider2.bounds.extents.x, _boxCollider2.bounds.extents.y + extraHeightText), Vector2.right * (_boxCollider2.bounds.extents.x * 2f), rayColor);

        return raycastHit.collider != null;
    }
}
