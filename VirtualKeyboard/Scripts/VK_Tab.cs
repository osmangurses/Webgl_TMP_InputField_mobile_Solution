using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VK_Tab : MonoBehaviour
{
    [SerializeField] VKSpeacialTab special;
    [SerializeField] VK_Manager manager;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Clicked);
    }
    void Clicked()
    {
        if (special==VKSpeacialTab.shift)
        {
            if (manager.keyboardState == VKKeyboardState.lower_chars)
            {
                manager.SetUpper();
                manager.keyboardState = VKKeyboardState.upper_chars;
            }
            else if (manager.keyboardState == VKKeyboardState.upper_chars)
            {
                manager.SetLower();
                manager.keyboardState = VKKeyboardState.lower_chars;
            }
            else if (manager.keyboardState == VKKeyboardState.num)
            {
                manager.SetShiftNum();
                manager.keyboardState = VKKeyboardState.shift_num;
            }
            else if (manager.keyboardState == VKKeyboardState.shift_num)
            {
                manager.SetNum();
                manager.keyboardState = VKKeyboardState.num;
            }
        }
        else if (special == VKSpeacialTab.num_char)
        {
            if (manager.keyboardState == VKKeyboardState.lower_chars || manager.keyboardState == VKKeyboardState.upper_chars)
            {
                manager.SetNum();
                manager.keyboardState = VKKeyboardState.num;
            }
            else
            {
                manager.SetLower();
                manager.keyboardState = VKKeyboardState.lower_chars;
            }

        }
        else if (special == VKSpeacialTab.backspace)
        {
            if (manager.selectedInputField != null && manager.selectedInputField.text.Length > 0)
            {
                manager.selectedInputField.text = manager.selectedInputField.text.Substring(0, manager.selectedInputField.text.Length - 1);
            }

        }
        else if (special==VKSpeacialTab.enter)
        {
            if (manager.selectedInputField != null)
            {
                manager.selectedInputField.onEndEdit.Invoke(manager.selectedInputField.text);
                manager.CloseOpenKeyboard(true);
                manager.selectedInputField = null;
            }

        }
        else if (special == VKSpeacialTab.classic)
        {
            if (manager.selectedInputField != null)
            {
                manager.selectedInputField.text += GetComponentInChildren<TextMeshProUGUI>().text;
                EventSystem.current.SetSelectedGameObject(manager.selectedInputField.gameObject, null);
            }
        }

    }
}
