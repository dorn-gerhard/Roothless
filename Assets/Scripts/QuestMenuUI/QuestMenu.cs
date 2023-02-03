using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;




public class QuestMenu : MonoBehaviour
{

    private bool _canAcusePerson = true;
    private bool _isAcusing = false;
    public delegate void OnAcusePerson();
    public event OnAcusePerson onAcusePerson;
    public event OnAcusePerson onStopAcusing;
    [SerializeField]
    private Button acuseButton;
    [SerializeField]
    private string _acuseText;
    [SerializeField]
    private string _stopAcuseText;

    void Start()
    {
        
        onAcusePerson += SwitchAcusationButton;
        onStopAcusing += SwitchAcusationButton;

    }

    public void AcuseButtonPress()
    {
        if (_isAcusing)
        {
            onStopAcusing?.Invoke();
            _isAcusing = false;
        } else
        {
            onAcusePerson?.Invoke();
            _isAcusing = true;
        }
    }
    private void SwitchAcusationButton()
    {
        string textUpdate = _isAcusing ?  _acuseText : _stopAcuseText;
        acuseButton.GetComponentInChildren<TextMeshProUGUI>().text = textUpdate;
    }

}
