using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text TalkText;
    public GameObject scanObject;
    public GameObject talkPanel;
    public bool isAction;
    
    public void Action(GameObject scanObj)
    {
        if (isAction)
        {
            isAction = false;
            
        }
        else
        {
            isAction =true;
            scanObject = scanObj;
            TalkText.text = scanObject.name;
        }
        talkPanel.SetActive(isAction);//�ǳ��� ���� isAction�� �����ϱ� ����
    }
}
