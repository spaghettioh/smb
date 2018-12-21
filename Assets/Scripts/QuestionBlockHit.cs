using UnityEngine;
using UnityEngine.Events;

public class QuestionBlockHit : MonoBehaviour
{
    public UnityEvent hit;

    Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = gameObject.GetComponent<Animator>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            hit.Invoke();
        }
    }
}
