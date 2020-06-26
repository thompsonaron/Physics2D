using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player2D : Collisions
{
    public float mass = 1f;
    public float speed = 50f;
    public float friction = 0.2f;
    Position2D pos;
    Position2D pos0;
    Velocity2D v;
    Velocity2D v0;

    Transform playerTransform;

    bool canMoveRight = true;
    bool canMoveLeft = true;
    bool isGrounded = false;
    bool isJumping = false;

    

    // Buoyancy
    public TypeOfFluid typeOfFluid;
    public TypeOfMaterial typeOfMaterial;
    float densityOfFluid = 1000f;
    float densityOfMaterial = 1000f;

    private float Fb;
    private float Fg;
    public float volumeOfObject;

    // not needed
    // private MeshGenerator water;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
        // volume = width * height
        volumeOfObject = this.transform.localScale.x * transform.localScale.y;
        mass = volumeOfObject * densityOfMaterial;
        SetFluid();
        SetMaterial();
        // Not needed
        //water = GameObject.FindGameObjectWithTag("Water").GetComponent<MeshGenerator>();
        
        pos = new Position2D();
        pos0 = new Position2D();
        pos.x = transform.position.x;
        pos.y = transform.position.y;
        pos0.x = transform.position.x;
        pos0.y = transform.position.y;

        v = new Velocity2D();
        v0 = new Velocity2D();
        v.velX = 0f;
        v.velY = 0f;
        v0.velX = 0f;
        v0.velY = 0f;

    }

   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && canMoveLeft) { v.velX -= speed * Time.deltaTime; canMoveLeft = true; }
        if (Input.GetKey(KeyCode.RightArrow) && canMoveRight) { v.velX += speed * Time.deltaTime; canMoveRight = true; }

        // Max velocity
        if (v.velX > 10f) { v.velX = 10f; }
        if (v.velX < -10f) { v.velX = -10f; }

        pos.x = pos0.x + v0.velX * Time.deltaTime;
        playerTransform.position = new Vector3(pos0.x, pos0.y, 0f);


        // CHECKING COLLISION WITH THE FLOOR
        if (CheckForCollisionYDown(this.gameObject))
        {
            v.velY = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            v.velY = v0.velY - PhyConstants.gravity * Time.deltaTime;
            pos.y = pos0.y + v0.velY * Time.deltaTime - (PhyConstants.gravity / 2) * (Mathf.Pow(Time.deltaTime, 2));
        }

        // CHECKING COLLISION WITH CEILING
        if (CheckForCollisionYUp(this.gameObject))
        {
            v.velY = v.velY * (-0.5f);
            //v.velY = 0f;
            isJumping = false;
        }


        //CHECKING SIDE COLLISIONS
        if (CheckForCollisionXLeft(this.gameObject))
        {
            v.velX = v.velX * (-0.5f);
            canMoveLeft = false;
            canMoveRight = true;
        }
        if (CheckForCollisionXRight(this.gameObject))
        {
            v.velX = v.velX * (-0.5f);
            canMoveRight = false;
            canMoveLeft = true;
        }
        if (!CheckForCollisionXRight(this.gameObject) && !CheckForCollisionXLeft(this.gameObject))
        {
            canMoveRight = true;
            canMoveLeft = true;
        }

        // JUMPING
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Debug.Log("HOP");
            isJumping = true;
            isGrounded = false;
            v.velY = 10f;

        }

        if (isJumping)
        {
            pos.y = pos0.y + v.velY * Time.deltaTime - PhyConstants.gravity / 2 * Mathf.Pow(Time.deltaTime, 2);
        }

        // GROUND FRICTION
        if (isGrounded)
        {
           // isJumping = false;
            if (v.velX> 0.2)
            {
                v.velX-= friction;
            }
            if (v.velX < -0.2)
            {
                v.velX += friction;
            }
            if (v.velX >= -0.2 && v.velX <= 0.2)
            {
                v.velX = 0;
            }
        }

        //Debug.Log(isGrounded);
        //Debug.Log("Velocity: " + v.velX + " - "+ v.velY);
        Debug.Log(isGrounded);


        // saving val
        pos0 = pos;
        v0 = v;
    }
   
    
    private void SetFluid()
    {
        switch (typeOfFluid)
        {
            case TypeOfFluid.Water:
                densityOfFluid = FluidDensity.water;
                break;
            case TypeOfFluid.Propane:
                densityOfFluid = FluidDensity.propane;
                break;
            case TypeOfFluid.Mercury:
                densityOfFluid = FluidDensity.mercury;
                break;
            default:
                break;
        }
    }

    private void SetMaterial()
    {
        switch (typeOfMaterial)
        {
            case TypeOfMaterial.Wood:
                densityOfMaterial = MaterialDensity.wood;
                break;
            case TypeOfMaterial.Stone:
                densityOfMaterial = MaterialDensity.stone;
                break;
            case TypeOfMaterial.Plastic:
                densityOfMaterial = MaterialDensity.plastic;
                break;
            default:
                break;
        }
    }

}
