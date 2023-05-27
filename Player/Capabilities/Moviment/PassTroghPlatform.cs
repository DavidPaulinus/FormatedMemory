using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassTroghPlatform : MonoBehaviour
{
    [SerializeField] private float disableTimer;
    [SerializeField] private BoxCollider2D playerCollision;

    private GameObject currentPassablePlatform;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentPassablePlatform != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PassableGround"))
        {
            currentPassablePlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PassableGround"))
        {
            currentPassablePlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        var _platformCollider = currentPassablePlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollision, _platformCollider, true);
        yield return new WaitForSeconds(disableTimer);
        Physics2D.IgnoreCollision(playerCollision, _platformCollider, false);
    }
}
