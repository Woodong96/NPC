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
        talkData.Add(1001, new string[] { "안녕 ? :0", "난 NPC1이야 :0" });
        talkData.Add(1002, new string[] { "안녕:0", "잘부탁해:0" });
        talkData.Add(1003, new string[] { "난 NPC3란다:0" });
        talkData.Add(1004, new string[] { "하이:0", "난 npc4야:0" });

        portraitData.Add(1001, portraitArr[0]);
        portraitData.Add(1002, portraitArr[1]);
        portraitData.Add(1003, portraitArr[2]);
        portraitData.Add(1004, portraitArr[3]);

        // 실전에선 여러가지 표정을 넣을수 있도록 하기위해 NPC 번호를 NCP 1명당 100~1000씩 할당하면 좋을듯함
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
