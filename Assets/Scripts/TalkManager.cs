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
        talkData.Add(1001, new string[] { "�ȳ� ? :0", "�� NPC1�̾� :1" });
        talkData.Add(1002, new string[] { "�ȳ�:0", "�ߺ�Ź��:1" });
        talkData.Add(1003, new string[] { "�� NPC3����:1" });
        talkData.Add(1004, new string[] { "����:0", "�� npc4��:1" });

        //Quest Talk
        talkData.Add(10 + 1001, new string[] { "�ȳ�?:0", "�ݰ���:1", "NPC2����������:0"});
        talkData.Add(11 + 1002, new string[] { "����Ź�������.:0","��������ã����:   1" });
        talkData.Add(20 + 3001, new string[] { "��ó���� ������ ã�Ҵ�." });
        talkData.Add(21 + 1002, new string[] { "��, ã���༭ ����:2" });

        portraitData.Add(1001, portraitArr[0]);
        portraitData.Add(1002, portraitArr[1]);
        portraitData.Add(1003, portraitArr[2]);
        portraitData.Add(1004, portraitArr[3]);

        // �������� �������� ǥ���� ������ �ֵ��� �ϱ����� NPC ��ȣ�� NCP 1��� 100~1000�� �Ҵ��ϸ� ��������
    }
    public string GetTalk(int _id, int _talkIndex)
    {
        if (_talkIndex == talkData[_id].Length)
            return null;
        else
            return talkData[_id][_talkIndex];
    }
    public Sprite GetPortrait(int _id, int portraitIndex)
    {
        //return portraitData[id + portraitIndex];
        return portraitData[_id];
    }
}
