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

    // 대화 데이터를 수동으로 등록
    void GenerateData()
    {
        talkData.Add(1000, new string[] {
            "스파르타 메타버스에 온걸 환영합니다.",
            "WASD, 화살표 키로 플레이어의 이동을 조작할 수 있고 SpaceBar를 누르면 점프를 할 수 있습니다.",
            "위로 올라가면 보이는 문 앞에 가서 F키를 누르면 상호작용을 하실 수 있습니다.",
            "그럼 즐거운 시간 보내세요."
            }); // 여러 대화를 위해 배열
        talkData.Add(1001, new string[] { "안녕?", "난 게임NPC!" });
        talkData.Add(1002, new string[] { "미구현입니다" });
        talkData.Add(1003, new string[] { "미구현입니다" });
    }

    // 특정 ID와 인덱스에 해당하는 대사 문자열 반환
    public string GetTalk(int id, int talkIndex)
    {
        // 대화 데이터가 더 없으면 null 반환
        if (talkIndex == talkData[id].Length)
        {
            return null;

        }
        // 대화 데이터가 남으면 해당 인덱스 데이터 반환
        else
        {
            return talkData[id][talkIndex];
        }
    }

}
