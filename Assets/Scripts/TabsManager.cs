using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum Tab
{
    Games,
    LeaderBoard,
    Statistics
}

public class TabsManager : MonoBehaviour
{
    [SerializeField] GameObject games, leaderboard, statistics;
    [SerializeField] Image gamesTabButtonBg, leaderboardTabButtonBg, statisticsTabButtonBg;
    private GameObject currentTab;
    private Image currentTabButtonBg;

    private void Start()
    {
        currentTab = games;
        currentTabButtonBg = gamesTabButtonBg;
        gamesTabButtonBg.color = Color.red;
    }

    public void SwitchToGames()
    {
        SwitchTo(Tab.Games);
    }

    public void SwitchToLeaderBoards()
    {
        SwitchTo(Tab.LeaderBoard);
    }

    public void SwitchToStatistics()
    {
        SwitchTo(Tab.Statistics);
    }

    public void SwitchTo(Tab tab)
    {
        currentTab.SetActive(false);
        currentTabButtonBg.DOColor(Color.black, 0.5f);

        switch(tab)
        {
            case Tab.Games:
                currentTab = games;
                currentTabButtonBg = gamesTabButtonBg;
                break;
            case Tab.LeaderBoard:
                currentTab = leaderboard;
                currentTabButtonBg = leaderboardTabButtonBg;
                break;
            case Tab.Statistics:
                currentTab = statistics;
                currentTabButtonBg = statisticsTabButtonBg;
                break;
        }
        currentTab.SetActive(true);
        currentTabButtonBg.DOColor(Color.red, 0.5f);
    }
}
