using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public Toggle[] _toggle;
    public TowerManager _towerManager;

    public GameObject[] _tower;

    private void Start()
    {
        OffToggle();
    }

    private void LateUpdate()
    {
        changeTower();
    }

    public void changeTower()
    { 
        for(int i = 0; i < _toggle.Length; i++)
        {
            if (_toggle[i].isOn)
            {
                _towerManager.towerToSpawn = _tower[i];
                return;
            } else _towerManager.towerToSpawn = null;
        }
    }

    private void OffToggle()
    {
        for(int i = 0; i < _toggle.Length; i++)
        {
            _toggle[i].isOn = false;
        }
    }

    public void DestoryToggle()
    {
        Debug.Log("destroy");
        for(int i = 0; i < _toggle.Length; i++)
        {
            if (_toggle[i].isOn)
            {
                _toggle[i].isOn = false;
                Destroy(_toggle[i].gameObject);
                _towerManager.towerToSpawn = null;
                return;
            }

        }
    }
}
