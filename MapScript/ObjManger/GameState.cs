using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public List<NpcState> npcStates = new List<NpcState>(); // 모든 NPC의 상태 정보

    // NPC의 상태를 가져옴
    public NpcState GetNPCState(string npcName)
    {
        return npcStates.Find(npcState => npcState.npcName == npcName);
    }

    // NPC의 상태를 저장함
    public void SetNPCState(NpcState npcState)
    {
        int index = npcStates.FindIndex(state => state.npcName == npcState.npcName);
        if (index != -1)
        {
            npcStates[index] = npcState;
        }
        else
        {
            npcStates.Add(npcState);
        }
    }
}
