using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] {
            "스파르타 메타버스에 온걸 환영합니다.",
            "WASD, 화살표 키로 플레이어의 이동을 조작할 수 있고 SpaceBar를 누르면 점프를 할 수 있습니다.",
            "위로 올라가면 보이는 문 앞에 가서 F키를 누르면 상호작용을 하실 수 있습니다.",
            "그럼 즐거운 시간 보내세요."
            }); // 여러 대화를 위해 배열
        talkData.Add(1001, new string[] { "안녕?", "난 게임NPC!" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;

        }
        else
        {
            return talkData[id][talkIndex];
        }
    }

}
