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
            private Button ludumDareButton;
            private TMPro.TMP_Text timeText;

            private void Awake() {
                ludumDareButton = GameObject.Find("LudumDareButton").GetComponent<Button>();
                ludumDareButton.onClick.AddListener(()=>{ Application.OpenURL("https://ldjam.com/"); /* little easter egg :) */ });

                timeText = GameObject.Find("OSTimeText").GetComponent<TMPro.TMP_Text>();
            }

            private void LateUpdate() {
                timeText.text = DateTime.Now.ToString("h:mm:ss tt");
            }
        }
    }
}

