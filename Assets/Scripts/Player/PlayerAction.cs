using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    public float Speed;


    Rigidbody2D rigid;
    float h;
    float v;

    public GameManager gameManager;
    Vector3 dirVec;
    bool isHorizonMove;
    GameObject scanObject;
    public GameObject TalkBtn;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //간단한 이동식
        h = gameManager.isAction ? 0 : Input.GetAxisRaw("Horizontal");  //액션상태에 따라 움직이지 못하게
        v = gameManager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        bool hDown = gameManager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = gameManager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = gameManager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = gameManager.isAction ? false : Input.GetButtonUp("Vertical");

        if (hDown || vUp)
            isHorizonMove = true;
        else if (vDown || hUp)
            isHorizonMove = false;
     


        //보는 방향 설정
        if (vDown && v == 1)
            dirVec = Vector3.up;
        //else if (vDown && v == -1)
        //    dirVec = Vector3.down;
        else if (hDown && h == -1)
            dirVec = Vector3.left;
         else if (hDown && h == 1)
            dirVec = Vector3.right;

        //scanObject
        if (Input.GetButtonDown("Jump") && scanObject != null)
            gameManager.Action(scanObject);





    }

    void FixedUpdate()
    {
        //수평이동
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;

       
    }

    /// Istrigger가 켜져있는 콜라이더가 겹치는 곳의 npc 정보를 가져옴
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other != null)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Object"))
            {
                scanObject = other.gameObject;
                TalkBtn.SetActive(true);
            }
        }
        else
        {
            scanObject = null;
            TalkBtn = null;
        }
            
    }


    /// 아래 부분이 없으면 NPC와 떨어지더라도 가장 최근 접촉한 NPC와 계속 대화함
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != null)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Object"))
            {
                scanObject = null;
                TalkBtn.SetActive(false);
            }
        }
        else
        {
            TalkBtn = null;
            scanObject = null;
        }
            
    }


}


////보는 방향+ 거리확인
//Debug.DrawRay(rigid.position, dirVec * 1.7f, new Color(0, 1, 0));

////대화걸기
//RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 1.7f, LayerMask.GetMask("Object"));

//if (rayHit.collider != null)
//{
//    scanObject = rayHit.collider.gameObject;
//}
//else
//    scanObject = null;