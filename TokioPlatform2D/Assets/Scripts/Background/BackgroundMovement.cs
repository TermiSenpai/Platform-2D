using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private PlayerMovement player;
    private Rigidbody2D bgRb;

    [SerializeField] private float speed;
    private void Start()
    {
        bgRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        // get player Rb
        Rigidbody2D rb = player.GetPlayerRb();
        // if player is moving
        if (rb.velocity.x > 0f || rb.velocity.x < 0f) // movement right or left for the bg based in player movement
            bgRb.velocity = player.GetIsFacingRight() ? new Vector2(-speed, 0) : new Vector2(speed, 0);
        // If player stop
        else
            bgRb.velocity = Vector2.zero;
    }


}
