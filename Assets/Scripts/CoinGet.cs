using UnityEngine;

public class CoinGet : MonoBehaviour {

    public IntVariable Score;

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            anim.SetTrigger("CoinGet");
        }
    }
}
