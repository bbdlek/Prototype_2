using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Inventory : MonoBehaviour
{
    public TowerManager _towerManager;
    public List<Toggle> _toggle;
    public List<GameObject> _tower;

    [SerializeField] GameObject _toggleGrid;
    [SerializeField] GameObject _togglePrefab;


    private void Start()
    {
        OffToggle();
    }

    private void OffToggle()
    {
        for (int i = 0; i < _toggle.Count; i++)
        {
            _toggle[i].isOn = false;
        }
    }

    public GameObject GetSelectedTower()
    {
        return _tower[GetActiveToggleIndex()];
    }

    private int GetActiveToggleIndex()
    {
        for (int i = 0; i < _toggle.Count; i++)
        {
            if (_toggle[i].isOn)
                return i;
        }
        return -1;
    }

    public void AddItem(GameObject tower)
    {
        GameObject toggle = Instantiate(_togglePrefab);
        toggle.transform.SetParent(_toggleGrid.transform);
        _toggle.Add(toggle.GetComponent<Toggle>());
        _tower.Add(tower);
    }

    public void DeleteSelectedItem()
    {
        int selectedIndex = GetActiveToggleIndex();
        DestoryToggle(selectedIndex);
        DeleteSelectedTower(selectedIndex);
    }

    public void DestoryToggle(int selectedIndex)
    {
        Debug.Log(_toggle.Count);
        Debug.Log("destroy");
        if (selectedIndex != -1)
        {
            _toggle[selectedIndex].isOn = false;
            Destroy(_toggle[selectedIndex].gameObject);
            _toggle.RemoveAt(selectedIndex);
            _towerManager.towerToSpawn = null;
            return;
        }
    }

    public void DeleteSelectedTower(int selectedIndex)
    {
        _tower.RemoveAt(selectedIndex);
    }

    public void SetToggleInteractable(bool interactable)
    {
        for (int i = 0; i < _toggle.Count; i++)
        {
            _toggle[i].interactable = interactable;
        }
    }
}
