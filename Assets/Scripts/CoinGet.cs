using UnityEngine;

public class CoinGet : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            anim.SetTrigger("CoinGet");
        }
    }
}
