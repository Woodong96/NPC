using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1001, new string[] { "�ȳ� ? :0", "�� NPC1�̾� :0" });
        talkData.Add(1002, new string[] { "�ȳ�:0", "�ߺ�Ź��:0" });
        talkData.Add(1003, new string[] { "�� NPC3����:0" });
        talkData.Add(1004, new string[] { "����:0", "�� npc4��:0" });

        portraitData.Add(1001, portraitArr[0]);
        portraitData.Add(1002, portraitArr[1]);
        portraitData.Add(1003, portraitArr[2]);
        portraitData.Add(1004, portraitArr[3]);

        // �������� �������� ǥ���� ������ �ֵ��� �ϱ����� NPC ��ȣ�� NCP 1��� 100~1000�� �Ҵ��ϸ� ��������
    }
    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        //return portraitData[id + portraitIndex];
        return portraitData[id];
    }
}
