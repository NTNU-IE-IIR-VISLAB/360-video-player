using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[Serializable]
public class KeyCodeMap
{
    public string name;
    public string key;
}


public class HelpDisplay : MonoBehaviour
{

    [SerializeField]
    bool isWorldSpace = false;

    [SerializeField]
    private KeyCodeMap[] utilityKeyCodes = {
        new KeyCodeMap{name="Open help", key="F1"},
        new KeyCodeMap{name="Toggle sphere", key="F2"},
        new KeyCodeMap{name="- Inc sphere radius", key="Numpad 9"},
        new KeyCodeMap{name="- Dec sphere radius", key="Numpad 7"},
        new KeyCodeMap{name="- Inc sphere resolution", key="Numpad 6"},
        new KeyCodeMap{name="- Dec sphere resolution", key="Numpad 4"},
        new KeyCodeMap{name="Toggle FPS counter", key="F3"},
        };

    [SerializeField]
    private KeyCodeMap[] gameKeyCodes;

    [SerializeField]
    private GameObject gameKeyCodeGroup;

    [SerializeField]
    private GameObject utilityKeyCodeGroup;

    [SerializeField]
    private TMP_Text textPrefab;

    private void Start()
    {
        CreateUtilityKeycodeText();
        CreateGameKeycodeText();
    }

    private void CreateUtilityKeycodeText()
    {
        foreach (var keyCode in this.utilityKeyCodes)
        {
            var textelement = Instantiate(textPrefab);
            textelement.SetText($"{keyCode.name}: {keyCode.key}");
            textelement.transform.SetParent(utilityKeyCodeGroup.transform);
            if (isWorldSpace)
            {
                WorldSpaceReset(textelement);
            }
        }
    }

    private void CreateGameKeycodeText()
    {
        foreach (var keyCode in this.gameKeyCodes)
        {
            var textelement = Instantiate(textPrefab);
            textelement.SetText($"{keyCode.name}: {keyCode.key}");
            textelement.transform.SetParent(gameKeyCodeGroup.transform);
            if (isWorldSpace)
            {
                WorldSpaceReset(textelement);
            }
        }
    }

    private void WorldSpaceReset(TMP_Text element)
    {
        element.gameObject.layer = 0;
        var p = element.transform.position;
        var lp = element.transform.localPosition;
        p.z = 0f;
        lp.z = 0f;
        element.transform.position = p;
        element.transform.localPosition = lp;
    }

}
