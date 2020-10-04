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
                moduleButtons = GameObject.Find("PCBContent").GetComponentsInChildren<Button>();
                
                runRobotButton = GameObject.Find("RunRobotButton").GetComponent<Button>();
                runRobotButton.onClick.AddListener(()=>{ Debug.Log(FindObjectOfType<MinigameController>().solve_puzzel() );});
                
                discardRobotButton = GameObject.Find("DiscardRobotButton").GetComponent<Button>();
                discardRobotButton.onClick.AddListener(()=>{ /* signal mini game manager that the robot is broken and needs to be discarded*/ });

                ludumDareButton = GameObject.Find("LudumDareButton").GetComponent<Button>();
                ludumDareButton.onClick.AddListener(()=>{ Application.OpenURL("https://ldjam.com/"); /* little easter egg :) */ });

                timeText = GameObject.Find("OSTimeText").GetComponent<TMPro.TMP_Text>();
                
                for (int i = 0; i < moduleButtons.Length; i++) {
                    int x = i;
                    moduleButtons[i].onClick.AddListener(() =>
                    {
                        selectedModuleButton = moduleButtons[x];
                    });
                }
            }

            public void create_module_spot_button_from_list(Module[] modules) {
                for (int i = 0; i < modules.Length; i++) {
                    var a = Instantiate(moduleSlotPrefab, GameObject.Find("_SLOTGRID").transform);
                    moduleSpotButtons.Add(a.GetComponent<Button>());
                    moduleSpotButtons[i].GetComponentInChildren<Button>().image.sprite = sprites[(int)modules[i].type];
                    
                    int x = i;
                    moduleSpotButtons[i].onClick.AddListener(() =>
                    {
                        if (selectedModuleButton != null) {
                            selectedModuleButton.transform.position = moduleSpotButtons[x].transform.position;
                            selectedModuleButton.transform.SetParent(moduleSpotButtons[x].transform);
                            selectedModuleButton = null;
                        }
                    });
                }
            }

            private void LateUpdate() {
                timeText.text = DateTime.Now.ToString("h:mm:ss tt");
            }
        }
    }
}

