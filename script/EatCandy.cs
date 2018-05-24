using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCandy : MonoBehaviour {

    GameObject candy;
	// Use this for initialization
	private void Start () {
        //candy 오브젝트를 불러와서 코드에서 정장해 놓는다 => 나중에 candy에 접근할 것이다.
        candy = GameObject.Find("candy");
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "candy")
        {
            //start에서 찾아놨던 candy 오브젝트를 끈다.
            candy.SetActive(false);
        }
    }
	
	// Update is called once per frame
	//void Update () {
		
	//}

    //is Trigger : 다른 오브젝트랑 부딫혔을 때 스크립트가 실행된다
}
