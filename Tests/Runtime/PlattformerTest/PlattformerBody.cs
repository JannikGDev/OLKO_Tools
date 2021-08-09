using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(BoxCollider2D))]
public class PlattformerBody : MonoBehaviour
{
    BoxCollider2D Hitbox;

    Vector2 Velocity;
    float gravity = 10f;

    private void Start()
    {
        Hitbox = this.GetComponent<BoxCollider2D>();
        Velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if (!groundContact.HasValue)
            Velocity += Time.deltaTime * Vector2.down * gravity;
        else
            Velocity = Vector2.zero;
        
        this.transform.position += Velocity.V3() * Time.deltaTime;
    }

    private void LateUpdate()
    {
        GroundCollisionRay();
    }


    private void GroundCollisionRay()
    {
        var direction = Vector2.down;
        var standTolerance = 0.1f;
        var raw_distance = Hitbox.size.y / 2f;
        var distance = raw_distance * (1 + standTolerance);
        var targetFraction = raw_distance / distance;
        var hit = Physics2D.Raycast(transform.position, direction, Hitbox.size.y/2f, LayerMask.GetMask("Ground"));
        if(hit.collider != null)
        {
            if (hit.fraction == 0)
                return;

            if (Mathf.Abs(hit.fraction - targetFraction) < 0.01f)
                return;

            groundContact = hit.point;
            this.transform.position += -direction.V3() * (targetFraction - hit.fraction);
        }
        else
        {
            groundContact = null;
        }
    }

    Vector2? groundContact;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        if (groundContact.HasValue)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, groundContact.Value);
        }
    }
}
