using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : Collisions
{
    private const float gravity = 9.81f;
  //  private MeshGenerator bulletMesh;
   // private float mass;
    Player2D playerController;
    Position bulletPosition, bulletPosition0;
    //float bx, by, bx0, by0;
    Velocity bulletVelocity0, bulletVelocity;
    public float mass;


    [Range(0, 180)]
    public float projectileShootAngle;

    float bulletShootAngle;
    bool isGrounded = false;

    private void Awake()
    {
       // bulletMesh = GetComponent<MeshGenerator>();
       // mass = GetComponent<MeshGenerator>().mass;
        collidedObjects = GameObject.FindGameObjectsWithTag("Obstacle");
        waters = GameObject.FindGameObjectsWithTag("Water");
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2D>();
    }

    private void Start()
    {
        bulletPosition0 = new Position();
        bulletPosition0.x = transform.position.x;
        bulletPosition0.y = transform.position.y;
        bulletPosition = bulletPosition0;
        bulletVelocity0 = new Velocity();
        bulletVelocity0.velX = 0f;
        bulletVelocity0.velY = 0f;
        bulletVelocity = bulletVelocity0;

        // DEFINING THE FORCE FOR SHOOTING THE BULLET + CURRENT PLAYER VELOCITY
        bulletVelocity0.velX = 15f + playerController.v.velX;
        bulletVelocity0.velY = 15f + playerController.v.velY;

        // ANGLE ON WHICH THE BULLET IS SHOOTED
        bulletShootAngle = projectileShootAngle * Mathf.PI / 180;

        bulletVelocity.velX = bulletVelocity0.velX * Mathf.Cos(bulletShootAngle);
        bulletVelocity.velY = bulletVelocity0.velY * Mathf.Sin(bulletShootAngle);
    }

    private void Update()
    {



        // CHECKING COLLISION WITH THE FLOOR
        if (CheckForCollisionYDown(this.gameObject))
        {
            bulletVelocity.velY = 0;
            isGrounded = true;
        }
        else
        {
            bulletVelocity.velY = bulletVelocity0.velY - gravity * mass * Time.deltaTime;
            bulletPosition.y = bulletPosition0.y + bulletVelocity.velY * Time.deltaTime;
        }


        // FRICTION
        if (isGrounded)
        {
            if (bulletVelocity.velX > 0.2)
            {
                bulletVelocity.velX -= 0.2f;
            }
            if (bulletVelocity.velX < -0.2)
            {
                bulletVelocity.velX += 0.2f;
            }
            if (bulletVelocity.velX >= -0.2 && bulletVelocity.velX <= 0.2)
            {
                bulletVelocity.velX = 0;
            }
        }

        //CHECKING SIDE COLLISIONS
        if (CheckForCollisionXLeft(this.gameObject))
        {
            bulletPosition.x = bulletPosition0.x + 0.1f;
            bulletVelocity.velX = -bulletVelocity.velX * 0.5f;
        }
        if (CheckForCollisionXRight(this.gameObject))
        {
            bulletPosition.x = bulletPosition0.x - 0.1f;
            bulletVelocity.velX = -bulletVelocity.velX * 0.5f;
        }
        if (!CheckForCollisionXLeft(this.gameObject) && !CheckForCollisionXRight(this.gameObject))
        {
            bulletPosition.x = bulletPosition0.x + bulletVelocity0.velX * Time.deltaTime;
        }

        if (CheckForCollisionYUp(this.gameObject))
        {
            bulletPosition.y = bulletPosition0.y - 0.1f;
            bulletVelocity.velY = 0;
        }

        if (CheckCollisionWithWaterDown(this.gameObject))
        {
            wasInWater = true;
            bulletVelocity.velY += 0.2f;

        }

        if (CheckCollisionWithWaterUp(this.gameObject) && wasInWater)
        {
            bulletVelocity.velY = bulletVelocity.velY * 0.6f;
            if (bulletVelocity.velY < 0.5f)
            {
                bulletVelocity.velY = 0;
            }
            wasInWater = false;
        }


        transform.position = new Vector2(bulletPosition.x, bulletPosition.y);

        bulletPosition0 = bulletPosition;
        bulletVelocity0.velX = bulletVelocity.velX;
        bulletVelocity0.velY = bulletVelocity.velY;

    }
}
