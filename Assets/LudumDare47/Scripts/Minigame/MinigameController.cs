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
            private PCUiController pcUI;

            [SerializeField] private List<Module> modules = new List<Module>();

            private void Start() {
                pcUI = GameObject.FindObjectOfType<PCUiController>();
                
                for (int i = 0; i < 9; i++) {
                    Module module = new Module();
                    module.type = (ModuleType)Random.Range(0, Enum.GetNames(typeof(ModuleType)).Length);
                    
                    modules.Add(module);
                }
                
                for (int i = 0; i < modules.Count; i++) {
                    
                    // calculate west neightbour
                    if ((i - 1) >= 0) {
                        modules[i].west = i - 1;
                    }
                    else {
                        modules[i].west = -1;
                    }
                    
                    // calculate east neightbour
                    if ((i + 1) <= modules.Count - 1) {
                        modules[i].east = i + 1;              
                    }
                    else {
                        modules[i].east = -1;
                    }
                    
                    // calculate north  neightbour
                    if ((i - 3) >= 0) {
                        modules[i].north = i - 3;             
                    }
                    else {
                        modules[i].north = -1;                    
                    }
                    
                    // calculate south neightbour
                    if ((i + 3) <= modules.Count) {
                        modules[i].south = i + 3;               
                    }
                    else {
                        modules[i].south = -1;                  
                    }
                }

                pcUI.create_module_spot_button_from_list(modules.ToArray());
            }
            
            private bool solve_puzzel() {
                return false;
            }
            
            public void set_module(int index, ModuleType type) {
                modules[index].type = type;
            }

            public Module get_module(int index) {
                return modules[index];
            }
        }
    }
}

