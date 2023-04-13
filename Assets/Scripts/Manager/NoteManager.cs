using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    private double _currentTime = 0;

    [SerializeField] private Transform _tfNoteAppear = null;
    [SerializeField] private GameObject _getNote = null;

    private TimingManager _timingManager;

    private void Start()
    {
        _timingManager = GetComponent<TimingManager>();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= 60d / bpm)
        {
            GameObject t_note = Instantiate(_getNote, _tfNoteAppear.position, Quaternion.identity);
            t_note.transform.SetParent(this.transform);
            _timingManager.boxNoteList.Add(t_note);
            _currentTime -= 60d / bpm;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            _timingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

}
