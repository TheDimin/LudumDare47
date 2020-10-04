using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace LD47
{
    namespace Minigame
    {
        public class PCUiController : MonoBehaviour
        {
            public List<Button> moduleSpotButtons;
            public Button[] moduleButtons;

            private Button selectedModuleButton;

            private Button runRobotButton;
            private Button discardRobotButton;

            private Button ludumDareButton;
            private TMPro.TMP_Text timeText;

            [SerializeField] private GameObject moduleSlotPrefab;
            // temp
            [SerializeField]private Sprite[] sprites;
            
            private void Awake() {
                runRobotButton = GameObject.Find("RunRobotButton").GetComponent<Button>();
                runRobotButton.onClick.AddListener(()=>{ });
                
                discardRobotButton = GameObject.Find("DiscardRobotButton").GetComponent<Button>();
                discardRobotButton.onClick.AddListener(()=>{ /* signal mini game manager that the robot is broken and needs to be discarded*/ });

                ludumDareButton = GameObject.Find("LudumDareButton").GetComponent<Button>();
                ludumDareButton.onClick.AddListener(()=>{ Application.OpenURL("https://ldjam.com/"); /* little easter egg :) */ });

                timeText = GameObject.Find("OSTimeText").GetComponent<TMPro.TMP_Text>();
                
            }

            public void create_module_spot_button_from_list(Module[] modules) {

            }

            private void LateUpdate() {
                timeText.text = DateTime.Now.ToString("h:mm:ss tt");
            }
        }
    }
}

