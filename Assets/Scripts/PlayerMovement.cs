using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class PlayerMovement : MonoBehaviour
{
    public event Action PlayerMoved;
    [SerializeField] GameObject movePoint;
    [SerializeField] float moveSpeed;
    [SerializeField] LayerMask walls;
    [SerializeField] Tilemap ground;
    [SerializeField] Tilemap obstacles;

    Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoint.transform.position, moveSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, movePoint.transform.position) <= 0.01f)
        {
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) ==1)
            {
                if(CanMove(movePoint.transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f)))
                    movePoint.transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) ==1)
            {

                if(CanMove(movePoint.transform.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f)))
                    movePoint.transform.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }

        }
        
    }

    private bool CanMove(Vector3 point)
    {

        if(!Physics2D.OverlapCircle(point, 0.4f, walls))
        {
            PlayerMoved?.Invoke();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetPosition()
    {
        transform.position = originalPosition;
        movePoint.transform.position = originalPosition;
    }
}
