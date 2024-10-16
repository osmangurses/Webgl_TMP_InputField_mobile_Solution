using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VK_Manager : MonoBehaviour
{
    public VKKeyboardState keyboardState;
    public TMP_InputField selectedInputField=null;
    [SerializeField] GameObject keyboard_panel;
    [SerializeField] Button[] vk_tabs;
    [SerializeField] string vk_upper_chars;
    [SerializeField] string vk_lower_chars;
    [SerializeField] string vk_num_chars;
    [SerializeField] string vk_shift_num_chars;
    private void Awake()
    {
        keyboardState = VKKeyboardState.lower_chars;
        for (int i = 0; i < vk_tabs.Length; i++)
        {
            vk_tabs[i].GetComponentInChildren<TextMeshProUGUI>().text = vk_lower_chars[i].ToString();
        }
    }
    public void SetLower()
    {
        for (int i = 0; i < vk_tabs.Length; i++)
        {
            vk_tabs[i].GetComponentInChildren<TextMeshProUGUI>().text = vk_lower_chars[i].ToString();
        }
    }
    public void SetUpper()
    {
        for (int i = 0; i < vk_tabs.Length; i++)
        {
            vk_tabs[i].GetComponentInChildren<TextMeshProUGUI>().text = vk_upper_chars[i].ToString();
        }
    }
    public void SetNum()
    {
        for (int i = 0; i < vk_tabs.Length; i++)
        {
            vk_tabs[i].GetComponentInChildren<TextMeshProUGUI>().text = vk_num_chars[i].ToString();
        }
    }
    public void SetShiftNum()
    {
        for (int i = 0; i < vk_tabs.Length; i++)
        {
            vk_tabs[i].GetComponentInChildren<TextMeshProUGUI>().text = vk_shift_num_chars[i].ToString();
        }
    }
    public void CloseOpenKeyboard(bool isClose)
    {
        if (isClose)
        {
            keyboard_panel.SetActive(false);
        }
        else { keyboard_panel.SetActive(true); } 
    }
    void Update()
    {
        if (Input.touchCount > 0 && selectedInputField == null)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                PointerEventData pointerData = new PointerEventData(EventSystem.current);
                pointerData.position = touch.position;

                // Raycast for UI elements
                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerData, results);

                foreach (RaycastResult result in results)
                {
                    TMP_InputField inputField = result.gameObject.GetComponent<TMP_InputField>();

                    if (inputField != null)
                    {
                        selectedInputField = inputField;
                        Debug.Log("Selected InputField: " + selectedInputField.gameObject.name);
                        EventSystem.current.SetSelectedGameObject(selectedInputField.gameObject, null);
                        CloseOpenKeyboard(false);
                        break;
                    }
                }
            }
        }

    }
}

public enum VKKeyboardState
{
    lower_chars,
    upper_chars,
    num,
    shift_num
}
public enum VKSpeacialTab 
{
    classic,
    shift,
    backspace,
    num_char,
    enter
}