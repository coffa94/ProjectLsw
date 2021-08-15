using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float maxDistanceRaycast = 1f;
    [SerializeField] private Canvas canvasDialoge;

    private PlayerMovement _playerMovement;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Action")) {
            //Debug.Log("Action");
            RaycastHit2D raycastHit2D;

            Vector2 origin = new Vector2(transform.position.x, transform.position.y);
            raycastHit2D = Physics2D.Raycast(origin, transform.up, maxDistanceRaycast);

            if (raycastHit2D.collider != null) {
                if (raycastHit2D.collider.gameObject.name.Equals("ShopKeeper")) {
                    raycastHit2D.collider.gameObject.GetComponent<ShopKeeperController>().StartDialogue();
                    this.enabled = false;
                    _playerMovement.enabled = false;

                    //set animator's parameter speedMovement to zero to stop walking animation
                    _animator.SetFloat("speedMovement", 0f);

                    //stop player's movement resetting the rigidbody2D's velocity
                    _rigidbody2D.velocity = Vector2.zero;
}
            } else {
                Debug.Log("Nothing to do");
            }

        }
    }
}
