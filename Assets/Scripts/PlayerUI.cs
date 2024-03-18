using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _promptText;
    // Start is called before the first frame update
    public static PlayerUI Instance { get; private set; }
    void Start()
    {
        
    }
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void UpdatePromptText(string _promptMessage)
    {
        _promptText.text = _promptMessage;
    }
   
   

}

