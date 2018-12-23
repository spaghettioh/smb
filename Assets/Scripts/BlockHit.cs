using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BlockHit : MonoBehaviour
{
    public bool isQuestionBlock;
    public GameObject label;
    public UnityEvent hit;

    //Animator anim;

	// Use this for initialization
	void Start ()
    {
        //anim = gameObject.GetComponent<Animator>();
        Destroy(label);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            hit.Invoke();
        }
    }

    public void DestoryThis(GameObject g)
    {
        StartCoroutine(DestroyNow(g));
    }

    IEnumerator DestroyNow(GameObject g)
    {
        yield return new WaitForSeconds(1f);
        Destroy(g);
    }
}
