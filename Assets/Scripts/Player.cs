using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Definiowane w paneli inspekcyjnym")]
    public float speed = 3;
    public float speedRun = 6;
    public GameObject crosshair;

    private float speedMultiplay = 0;
    private Vector2 move = Vector2.zero;
    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        speedMultiplay = speed;
    }
    // Update is called once per frame
    void Update()
    {
        move.y = Input.GetAxisRaw("Horizontal");
        move.x = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedMultiplay = speedRun;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speedMultiplay = speed;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Rotation();
    }

    private void Move()
    {
        move = move.normalized * speedMultiplay;
        rigid.velocity = move;
    }

    void Rotation()
    {
        Vector3 delta = crosshair.transform.position - transform.position;
        Vector3 targetRotation = (Vector2)delta;
        transform.right = Vector3.Lerp(transform.right, targetRotation, Time.deltaTime * 10f);
    }
}
