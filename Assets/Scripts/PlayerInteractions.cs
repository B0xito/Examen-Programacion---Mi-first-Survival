using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] Rigidbody playerRB;

    [Range(1f, 10f)]
    [SerializeField] float playerSpeed;

    [Range(1f, 10f)]
    [SerializeField] float playerJumpBoost;
    [SerializeField] bool isGrounded;

    [Header("Mining Variables")]
    [Range(1f, 10f)]
    [SerializeField] float rayDistance;
    [SerializeField] LayerMask minableMask;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
        Mining();
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        transform.Translate(h, 0, v);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            playerRB.AddForce(Vector3.up * playerJumpBoost, ForceMode.Impulse);
        }
    }

    void Mining()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, minableMask))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mining");
                Destroy(hit.transform.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
