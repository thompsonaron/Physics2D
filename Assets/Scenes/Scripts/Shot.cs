using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : Collisions
{
    Player2D playerController;
    Position p, p0;
    Velocity v0, v;
    public float Wf;
    public float bulletForce = 20f;

    [Range(0, 180)]
    public float projectileShootAngle;

    float bulletShootAngle;
    bool isGrounded = false;

    private float degToRad = Mathf.PI / 180;
    public float friction = 0.1f;

    private void Awake()
    {
        collidedObjects = GameObject.FindGameObjectsWithTag("Obstacle");
        waters = GameObject.FindGameObjectsWithTag("Water");
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2D>();
    }

    private void Start()
    {
        SetPositinVeelocity();

        // bullet force
        v0.velX = bulletForce + playerController.v.velX;
        v0.velY = bulletForce + playerController.v.velY;

        // angle shot
        bulletShootAngle = projectileShootAngle * degToRad;
        v.velX = v0.velX * Mathf.Cos(bulletShootAngle);
        v.velY = v0.velY * Mathf.Sin(bulletShootAngle);
    }

    private void SetPositinVeelocity()
    {
        p0 = new Position();
        p0.x = transform.position.x;
        p0.y = transform.position.y;
        p = p0;
        v0 = new Velocity();
        v0.velX = 0f;
        v0.velY = 0f;
        v = v0;
    }

    private void Update()
    {
        FloorCol();
        Friction();
        AirCollision();
        #region Water
        //if (CheckCollisionWithWaterUp(this.gameObject) && wasInWater)
        //{
        //    v.velY = v.velY * 0.6f;
        //    if (v.velY < 0.5f)
        //    {
        //        v.velY = 0;
        //    }
        //    wasInWater = false;
        //}
        #endregion
        transform.position = new Vector2(p.x, p.y);

        p0 = p;
        v0.velX = v.velX;
        v0.velY = v.velY;
    }

    private void AirCollision()
    {
        if (CheckForCollisionXLeft(this.gameObject))
        {
            p.x = p0.x + 0.1f;
            v.velX = -v.velX * 0.5f;
        }
        if (CheckForCollisionXRight(this.gameObject))
        {
            p.x = p0.x - 0.1f;
            v.velX = -v.velX * 0.5f;
        }
        if (!CheckForCollisionXLeft(this.gameObject) && !CheckForCollisionXRight(this.gameObject))
        {
            p.x = p0.x + v0.velX * Time.deltaTime;
        }

        if (CheckForCollisionYUp(this.gameObject))
        {
            p.y = p0.y - 0.1f;
            v.velY = 0;
        }

        if (CheckCollisionWithWaterDown(this.gameObject))
        {
            wasInWater = true;
            v.velY += 0.2f;

        }
    }

    private void Friction()
    {
        if (isGrounded)
        {
            if (v.velX > friction) { v.velX -= friction; }
            if (v.velX < -friction) { v.velX += friction; }
            if (v.velX >= -friction && v.velX <= friction) { v.velX = 0; }
        }
    }

    private void FloorCol()
    {
        if (CheckForCollisionYDown(this.gameObject))
        {
            v.velY = 0;
            isGrounded = true;
        }
        else
        {
            v.velY = v0.velY - PhyConstants.gravity * Wf * Time.deltaTime;
            p.y = p0.y + v.velY * Time.deltaTime;
        }
    }
}
