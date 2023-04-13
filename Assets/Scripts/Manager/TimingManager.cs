using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();

    [SerializeField] private Transform _center = null;
    [SerializeField] private RectTransform[] _timingRect = null;
    private Vector2[] _timingBoxes = null;

    private void Start()
    {
        _timingBoxes = new Vector2[_timingRect.Length];

        for (int i = 0; i < _timingRect.Length; i++)
        {
            _timingBoxes[i].Set(_center.localPosition.x - _timingRect[i].rect.width / 2,
                _center.localPosition.x + _timingRect[i].rect.width / 2);
        }
    }

    public void CheckTiming()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosX = boxNoteList[i].transform.localPosition.x;

            for (int x = 0; x < _timingBoxes.Length; x++)
            {
                if (_timingBoxes[x].x <= t_notePosX && t_notePosX <= _timingBoxes[x].y)
                {
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);
                    Debug.Log("hit" + x);
                    return;
                }
            }
        }

        Debug.Log("miss");
    }
}
