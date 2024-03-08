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
        talkData.Add(1001, new string[] { "안녕 ? :0", "난 NPC1이야 :1" });
        talkData.Add(1002, new string[] { "안녕:0", "잘부탁해:1" });
        talkData.Add(1003, new string[] { "난 NPC3란다:1" });
        talkData.Add(1004, new string[] { "하이:0", "난 npc4야:1" });

        //Quest Talk
        talkData.Add(10 + 1001, new string[] { "안녕?:0", "반가워:1", "NPC2을도와주자:0"});
        talkData.Add(11 + 1002, new string[] { "내부탁좀들어줘.:0","내가발을찾아줘:   1" });
        talkData.Add(20 + 3001, new string[] { "근처에서 가발을 찾았다." });
        talkData.Add(21 + 1002, new string[] { "엇, 찾아줘서 고마워:2" });

        portraitData.Add(1001, portraitArr[0]);
        portraitData.Add(1002, portraitArr[1]);
        portraitData.Add(1003, portraitArr[2]);
        portraitData.Add(1004, portraitArr[3]);

        // 실전에선 여러가지 표정을 넣을수 있도록 하기위해 NPC 번호를 NCP 1명당 100~1000씩 할당하면 좋을듯함
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
