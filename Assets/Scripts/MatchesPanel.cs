using UnityEngine;

public class MatchesPanel : MonoBehaviour
{
    [SerializeField] private MatchDataUIItem m_ItemPrefab;
    [SerializeField] private Transform m_ItemsParent;

    private void OnEnable()
    {
        var dataList = DataManager.GetMatchDataList();
        var matches = dataList.matches;

        for (int i = 0; i < matches.Count; i++)
        {
            var newItem = Instantiate(m_ItemPrefab, m_ItemsParent);
            var data = matches[i];
            newItem.SetItem(data.Player1.Name, data.Player1.Score, data.Player2.Name, data.Player2.Score);
        }
    }
}
