using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    private bool isFacingRight = false;
    private bool isFacingUp = true;
    private bool isFacingDown;
    public GameObject weapon;
    public GameObject Torche;
    public bool isHolding;

    public GameObject ColliderUp;
    public GameObject ColliderDown;
    public GameObject ColliderRight;
    public GameObject ColliderLeft;
    public bool isHittingFire;
    private bool isColliderUp;
    private bool isColliderDown;
    private bool isColliderRight;
    private bool isColliderLeft;
    public bool asHit;
    float elapsed;
    float index;
    private SpriteRenderer spriteRenderer;
    private Vector2 direction;
    public Sprite Down;
    public Sprite Up;
    public Sprite Right;
    public Sprite DiagoBas;
    public Sprite DiagoUp;

    public Sprite DownT;
    public Sprite UpT;
    public Sprite RightT;
    public Sprite DiagoBasT;
    public Sprite DiagoUpT;

    public Sprite DownM;
    public Sprite UpM;
    public Sprite RightM;
    public Sprite DiagoBasM;
    public Sprite DiagoUpM;

    public Sprite DownP;
    public Sprite UpP;
    public Sprite RightP;
    public Sprite DiagoBasP;
    public Sprite DiagoUpP;

    public Sprite DownE;
    public Sprite UpE;
    public Sprite RightE;
    public Sprite DiagoBasE;
    public Sprite DiagoUpE;


    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Up;
        rb = GetComponent<Rigidbody2D>();
        ColliderUp.SetActive(false);
        ColliderDown.SetActive(false);
        ColliderRight.SetActive(false);
        ColliderLeft.SetActive(false);
        
    }
	

	void Update () {

        Orientation();
        Movement();
        
        //Debug.Log("Up" + isFacingUp);
        //Debug.Log("Down" + isFacingDown);
	}

    private void Movement()
    {
        
            
        
        if (Input.GetKey(KeyCode.Z))
        {
            isColliderUp = true;
            isColliderDown = false;
            isColliderRight = false;
            isColliderLeft = false;
            direction = Vector2.up;
            rb.AddForce(Vector2.up * speed);
            if (isFacingUp)
            {
                FlipVertically();
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            isColliderUp = false;
            isColliderDown = true;
            isColliderRight = false;
            isColliderLeft = false;
            direction = Vector2.down;
            rb.AddForce(Vector2.up * -speed);
            if (isFacingDown)
            {
                FlipVertically();
            }
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            isColliderUp = false;
            isColliderDown = false;
            isColliderRight = true;
            isColliderLeft = false;
            direction = Vector2.right;
            rb.AddForce(Vector2.right * speed);
            if (isFacingRight)
            {
                Flip();
                spriteRenderer.flipX = true;
            }
            
        }
        if (Input.GetKey(KeyCode.Q))
        {
            isColliderUp = false;
            isColliderDown = false;
            isColliderRight = false;
            isColliderLeft = true;
            direction = Vector2.left;
            rb.AddForce(Vector2.right * -speed);
            if (!isFacingRight)
            {
                Flip();
                spriteRenderer.flipX = true;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Drop();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Light();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (weapon != null)
            {
                Hit();
            }
            
        }
        if (asHit)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= .4f)
            {
                ColliderUp.SetActive(false);
                ColliderDown.SetActive(false);
                ColliderRight.SetActive(false);
                ColliderLeft.SetActive(false);
                

                if (elapsed >= .5f)
                {
                    elapsed = 0;
                    asHit = false;
                }
            }
        }
    }

    private void Flip()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
        //spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    private void FlipVertically()
    {
        spriteRenderer.flipY = !spriteRenderer.flipY;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        isFacingDown = !isFacingDown;
        isFacingUp = !isFacingUp;
        transform.Rotate(180, 0, 0);
    }

    private void Drop()
    {
        //Instantiate(weapon, transform.position, Quaternion.identity);
        weapon.GetComponent<Items>().sp.enabled = true;
        weapon.GetComponent<Items>().Drop(direction);
        weapon = null;
        isHolding = false;
    }

    private void Hit()
    {
        
        if (!asHit)
        {
            
            if (isColliderUp)
            {
                ColliderUp.SetActive(true);
                asHit = true;
            }
            if (isColliderDown)
            {
                ColliderDown.SetActive(true);
                asHit = true;
            }
            if (isColliderRight)
            {
                ColliderRight.SetActive(true);
                asHit = true;
            }
            if (isColliderLeft)
            {
                ColliderLeft.SetActive(true);
                asHit = true;
            }
        }
        
    }

    public void Light()
    {
        Debug.Log("en faite son nom c'est" + weapon.name);
        if (weapon.name == "Baton" || weapon.gameObject.CompareTag("Baton") )
        {
            Debug.Log("Ok");
            weapon.GetComponent<Torche>().isLight = true;
            Debug.Log("lol");
        }
    }
    
    private void Orientation()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (weapon != null)
            {
                if (weapon.name == "Baton" || weapon.CompareTag("Baton"))
                {
                    spriteRenderer.sprite = UpT;
                }
                else if (weapon.name == "Marteau" || weapon.CompareTag("Marteau"))
                {
                    spriteRenderer.sprite = UpM;
                }
                else if (weapon.name == "Pelle" || weapon.CompareTag("Pelle"))
                {
                    spriteRenderer.sprite = UpP;
                }
                else if (weapon.name == "EPE" || weapon.CompareTag("EPE"))
                {
                    spriteRenderer.sprite = UpE;
                }
                else spriteRenderer.sprite = Up;
            }
            else spriteRenderer.sprite = Up;

        }

        if (Input.GetKey(KeyCode.S))
        {
            if (weapon != null)
            {
                if (weapon.name == "Baton" || weapon.CompareTag("Baton"))
                {
                    spriteRenderer.sprite = DownT;
                }
                else if (weapon.name == "Marteau" || weapon.CompareTag("Marteau"))
                {
                    spriteRenderer.sprite = DownM;
                }
                else if (weapon.name == "Pelle" || weapon.CompareTag("Pelle"))
                {
                    spriteRenderer.sprite = DownP;
                }
                else if (weapon.name == "EPE" || weapon.CompareTag("EPE"))
                {
                    spriteRenderer.sprite = DownE;
                }
                else spriteRenderer.sprite = Down;
            }
            else spriteRenderer.sprite = Down;

        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Q))
        {
            if (weapon != null)
            {
                if (weapon.name == "Baton" || weapon.CompareTag("Baton"))
                {
                    spriteRenderer.sprite = RightT;
                }
                else if (weapon.name == "Marteau" || weapon.CompareTag("Marteau"))
                {
                    spriteRenderer.sprite = RightM;
                }
                else if (weapon.name == "Pelle" || weapon.CompareTag("Pelle"))
                {
                    spriteRenderer.sprite = RightP;
                }
                else if (weapon.name == "EPE" || weapon.CompareTag("EPE"))
                {
                    spriteRenderer.sprite = RightE;
                }
                else spriteRenderer.sprite = Right;
            }
            else spriteRenderer.sprite = Right;

        }

        if ((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Q)))
        {
            if (weapon != null)
            {
                if (weapon.name == "Baton" || weapon.CompareTag("Baton"))
                {
                    spriteRenderer.sprite = DiagoBasT;
                }
                else if (weapon.name == "Marteau" || weapon.CompareTag("Marteau"))
                {
                    spriteRenderer.sprite = DiagoBasM;
                }
                else if (weapon.name == "Pelle" || weapon.CompareTag("Pelle"))
                {
                    spriteRenderer.sprite = DiagoBasP;
                }
                else if (weapon.name == "EPE" || weapon.CompareTag("EPE"))
                {
                    spriteRenderer.sprite = DiagoBasE;
                }
                else spriteRenderer.sprite = DiagoBas;
            }
            else spriteRenderer.sprite = DiagoBas;

        }

        if ((Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.Q)))
        {
            if (weapon != null)
            {
                if (weapon.name == "Baton" || weapon.CompareTag("Baton"))
                {
                    spriteRenderer.sprite = DiagoUpT;
                }
                else if (weapon.name == "Marteau" || weapon.CompareTag("Marteau"))
                {
                    spriteRenderer.sprite = DiagoUpM;
                }
                else if (weapon.name == "Pelle" || weapon.CompareTag("Pelle"))
                {
                    spriteRenderer.sprite = DiagoUpP;
                }
                else if (weapon.name == "EPE" || weapon.CompareTag("EPE"))
                {
                    spriteRenderer.sprite = DiagoUpE;
                }
                else spriteRenderer.sprite = DiagoUp;
            }
            else spriteRenderer.sprite = DiagoUp;

        }
    }
    
}
