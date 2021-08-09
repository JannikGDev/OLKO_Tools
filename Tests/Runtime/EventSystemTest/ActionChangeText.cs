using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ActionChangeText : MonoBehaviour
{
    [SerializeField]
    [TextArea]
    private string TextToChangeTo;

    public void ChangeText()
    {
        this.GetComponent<Text>().text = TextToChangeTo;
    }
}
