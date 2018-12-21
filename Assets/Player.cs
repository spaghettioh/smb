using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    public FloatVariable size;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        size.SetValue(0);
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Size", size.Value);
	}
}
