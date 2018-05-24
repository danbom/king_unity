using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    //public은 unity창에서 볼 수 있다 
    //실행시키면서 변경시키고 싶은 값이 있으면 public을 붙여준다
   public float movespeed = 15f;
    float jumppower = 8f;
    Rigidbody2D rigid;
    Vector3 movement;
    bool isJumping = false;

    // Use this for initialization
    void Start () {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        //오브젝트에있는 rigidbody를 불러와서 아까 선언 한 rigid 변수에 저장한다.
	}

    void FixedUpdate() { // 여기선! update대신 사용한다
        //일정 주기로 반복되서 호출이 된다. 
        //space눌렀을 때만 jump가 되야하니까 일정주기로 isJumping을 계속 false로 초기화한다.
        isJumping = false;
        if (Input.GetButtonDown("Jump"))  
            //Input은 사용자로부터 입력을 받을 때
            //"Jump"를 다른 키로 바꾸면 유니티에서 일단 여기서 Jump는 space var
            isJumping = true;
        LR_Move();
        Jump();
    }

    void LR_Move() {
        //이동할 좌표 선언 및 (0,0,0)으로 초기화
        Vector3 H_move = Vector3.zero;

        //방향키 좌우(Hrozontal)입력이 들어올 경우
        if (Input.GetAxisRaw("Horizontal") > 0)  //우측 이동
        {
            H_move = Vector3.right;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)  //좌측 이동
        {
            H_move = Vector3.left;
        }

        //오브젝트 position 변경
        transform.position += H_move * movespeed * Time.deltaTime;
    }

    void Jump()
    {
        if (!isJumping) return; //false일때 return

        //오브젝트의 rigidbody 속도를 0으로 초기화
        rigid.velocity = Vector2.zero;

        //jump해서 이동할 위치 선언
        Vector2 jumpVelocitiy = new Vector2(0, jumppower);

        //오브젝트 리지드바디에 점프만큼의 힘 더해주기 포물선으로 하기위해서!?
        rigid.AddForce(jumpVelocitiy, ForceMode2D.Impulse);

        isJumping = false;
    }


	// Update is called once per frame
	void Update () {
		
	}
}
