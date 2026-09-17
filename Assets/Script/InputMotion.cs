using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.InputSystem;


    struct dirUnit
    {
        public dirUnit(int newdir, int newwind, bool newstrict)
        {
            direction = newdir;
            window = newwind;
            strict = newstrict;
        }
        public int direction;
        public int window;
        public bool strict;
    }

    class InputMotionClass
    {
        public InputMotionClass(string nameme, List<dirUnit> newInputs,bool Newmirror)
        {
            name = nameme;
            inputList = newInputs;
            inputList.Reverse();
            mirror = Newmirror;
        }

        public InputMotionClass(string namame)
        {
            name = namame;
            inputList = new List<dirUnit>();
        }

        public InputMotionClass Add(int direction,int window, bool strict)
        {
            inputList.Reverse();
            inputList.Add(new dirUnit(direction, window, strict));
            return this;
        }

        public InputMotionClass Mirror(bool NewMirror)
        {
            mirror = NewMirror;
            return this;
        }

        public string name;
        List<dirUnit> inputList;
        bool mirror;

        private bool checkValidInput(int curInput, int bufferpos)
        { //takes in the current buffer (unnecessary if the buffer is stored publicly), current position in the input list as an int
            for (int i = bufferpos; i < bufferpos + inputList[curInput].window; i++)
            {
                if (atacks.dirBuffer[i] == 5) continue; 
                if (checkDir(atacks.dirBuffer[i], inputList[curInput].direction, inputList[curInput].strict))
                {
                    Debug.Log("Check success, iter: " + curInput + " curinput: " + atacks.dirBuffer[i] + " i: " + i + " target: " + inputList[curInput].direction);
                    if (curInput + 1 >= inputList.Count)
                    { //if there's no input at this point in the list, we're done, return true
                        Debug.Log(name);
                        return true;
                    }
                    else return checkValidInput(curInput + 1, i + 1);
                }
            }
            return false;
        }

        public bool checkValidInput()
        {
            return checkValidInput(0, 0);
        }
        bool checkDir(int curDir, int targetDir, bool strict)
        {
            if (mirror==true)
            {
               if(curDir == 7 || curDir == 4 || curDir == 1) curDir += 2;
               else if (curDir == 9 || curDir == 6 || curDir == 3) curDir -= 2;
            }

            if (strict == true)
            {
                if (curDir == targetDir) return true;
                else return false;
            }
            else
            {
                if (targetDir == 6 && (curDir == 6 || curDir == 9 || curDir == 3)) return true;
                else if (targetDir == 4 && (curDir == 4 || curDir == 1 || curDir == 7)) return true;
                else if (targetDir == 2 && (curDir == 2 || curDir == 1 || curDir == 3)) return true;
                else if (targetDir == 8 && (curDir == 8 || curDir == 7 || curDir == 9)) return true;
                else if (targetDir == 3 && (curDir == 3 || curDir == 6 || curDir == 2)) return true;
                else if (targetDir == 1 && (curDir == 1 || curDir == 4 || curDir == 2)) return true;
                else if (targetDir == 9 && (curDir == 9 || curDir == 8 || curDir == 6)) return true;
                else if (targetDir == 7 && (curDir == 7 || curDir == 8 || curDir == 4)) return true;
            }
            return false;
        }
    }
