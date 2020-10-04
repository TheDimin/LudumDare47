using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace LD47
{
    namespace Minigame
    {
        public class MinigameController : MonoBehaviour
        {
            private Transform[] rings = new Transform[4];
            private Transform[] ringConnectors = new Transform[4];
            private Transform[] envRings = new Transform[5];

            private int index = 0;

            private float rotationSpeed = 175.0f;

            private bool gameIsActive = true;

            private int score = 0;
            
            private void Start() {
                rings[0] = GameObject.Find("Ring1").transform;
                rings[1] = GameObject.Find("Ring2").transform;
                rings[1].gameObject.SetActive(false);
                
                
                rings[2] = GameObject.Find("Ring3").transform;
                rings[2].gameObject.SetActive(false);
                
                rings[3] = GameObject.Find("Ring4").transform;
                rings[3].gameObject.SetActive(false);
                
                ringConnectors[0] = GameObject.Find("Ring1Connector").transform;
                ringConnectors[0].Rotate(0,0,Random.Range(0,360));
                
                ringConnectors[1] = GameObject.Find("Ring2Connector").transform;
                ringConnectors[1].Rotate(0,0,Random.Range(0,360));
                
                ringConnectors[2] = GameObject.Find("Ring3Connector").transform;
                ringConnectors[2].Rotate(0,0,Random.Range(0,360));
                
                ringConnectors[3] = GameObject.Find("Ring4Connector").transform;
                ringConnectors[3].Rotate(0,0,Random.Range(0,360));
            }

            private void Update() {
                if (gameIsActive) {
                    rings[index].transform.Rotate(0,0,rotationSpeed * Time.deltaTime);

                    if (Input.GetKeyDown(KeyCode.Space)) {
                        
                            if (rings[index].GetComponent<RectTransform>().localEulerAngles.z > ringConnectors[index].GetComponent<RectTransform>().localEulerAngles.z - 10 &&
                                rings[index].GetComponent<RectTransform>().localEulerAngles.z < ringConnectors[index].GetComponent<RectTransform>().localEulerAngles.z + 10) { // fix for treshhold
                                
                                Debug.Log("Yess!" + score);
                                ringConnectors[index].GetComponentInChildren<Image>().color = Color.yellow;
                                score++;
                            }
                            else {
                                Debug.Log("Noo!" + score);
                            }
                            
                            if (index + 1 > 3) {
                                gameIsActive = false;
                            }
                            else {
                                index++;
                                rings[index].gameObject.SetActive(true);
                                rotationSpeed *= 1.1f;
                            }
                    }
                }
            }

            public int get_game_score() {
                return score;
            }
        }
    }
}

