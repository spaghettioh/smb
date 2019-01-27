using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BlockHit : MonoBehaviour
{
    public FloatVariable playerSize;
    public bool isQuestionBlock;
    public GameObject label;
    public UnityEvent activate;
    public UnityEvent bump;

    bool activated = false;

    // Use this for initialization
    void Start()
    {
        // Remove the editor label
        Destroy(label);
    }

    private void FixedUpdate()
    {
        // TODO: Add some logic in here to help with destorying bricks
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, -1));

        // Record the hit
        if (hit.distance < .5f && hit.collider.name == "Player")
        {
            if (!activated && (playerSize.Value > 0 || isQuestionBlock))
            {
                activate.Invoke();
                activated = true;
            }
            else
            {
                bump.Invoke();
            }

        }
    }

    public void DestoryThisNow()
    {
        Destroy(gameObject);
    }

    public void DestoryThisDelayed()
    {
        StartCoroutine(DestroyInSeconds(.6f));
    }

    IEnumerator DestroyInSeconds(float t)
    {
        yield return new WaitForSeconds(t);
        Destroy(gameObject);
    }
}
