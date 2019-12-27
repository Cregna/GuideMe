using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElement : MonoBehaviour
{
    public ObjectDialog dialog;
    public void triggerDialog() {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }
}
