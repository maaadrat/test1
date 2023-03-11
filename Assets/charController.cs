using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    public Sprite corpseObject;
    Rigidbody2D rb;
    Transform tr;
    GameObject cam;
    public GameObject particles;
    public float mouseX = 0f;
    public float mouseY = 0f;
    public float vertical;
    public float horizontal;
    public int force = 2;
    public int classChoose;
    public bool eCondition = false;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        cam = GameObject.Find("Main Camera");
    }

    void Update() {
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y");
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        rb.AddForce(tr.right * horizontal * force, ForceMode2D.Impulse);
        rb.AddForce(tr.up * vertical * force, ForceMode2D.Impulse);

        if(Input.GetKeyDown("e")) {
            eCondition = true;
        }

        // cam.transform.position = (tr.position.x + mouseX, tr.position.y + mouseY,0);
    }

    void OnCollisionEnter2D(Collision2D hit) {
        if(hit.gameObject.tag == "corpse" & eCondition == true) {
            hit.gameObject.GetComponent<SpriteRenderer>().sprite = corpseObject; 
            particles.SetActive(true);
        }
    }

}
