using UnityEngine;
using UnityEngine.Events;

public class CoinGet : MonoBehaviour {

    Animator anim;

    public UnityEvent collect;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collect.Invoke();
        }
    }
}
