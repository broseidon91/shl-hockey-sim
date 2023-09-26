using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttributeEditorMenu : MonoBehaviour
{
    public GameObject AttributePrefab;
    public GameObject AttributeGroupPrefab;
    public GameObject AttributeGroupTitlePrefab;

    public Transform Content;

    public void Awake()
    {
        foreach (var group in DataManager.Instance.Model.Attributes)
        {
            var title = Instantiate(AttributeGroupTitlePrefab);
            title.GetComponent<TMP_Text>().text = group.GroupTitle;
            title.name = group.GroupTitle;
            title.transform.SetParent(Content);

            var groupPrefab = Instantiate(AttributeGroupPrefab);
            groupPrefab.transform.SetParent(Content);

            foreach (var attribute in group.Attributes)
            {
                var attributePrefab = Instantiate(AttributePrefab).GetComponent<AttributeEditor>();
                attributePrefab.transform.SetParent(groupPrefab.transform);
                attributePrefab.Init(attribute);

            }
        }
    }
}
