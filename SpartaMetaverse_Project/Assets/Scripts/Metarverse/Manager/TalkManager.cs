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
            "문 위쪽에 있는 안내자를 찾아가 보세요, 중요한 얘기를 해줄 거예요!"
            }); // 여러 대화를 위해 배열
        talkData.Add(1001, new string[] {
            "반갑습니다, 플레이어님",
            "위쪽으로 가시면 다양한 미니게임이 준비되어 있답니다.",
            "그럼 즐거운 시간 보내세요."
            });
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
