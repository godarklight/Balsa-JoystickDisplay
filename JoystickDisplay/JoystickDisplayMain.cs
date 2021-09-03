using System;
using Tutorials;
using UI;
using UI.MMX.Data;
using UnityEngine;
using DarkLog;

namespace JoystickDisplay
{
    public class JoystickDisplayMain : MonoBehaviour
    {
        private ModLog log;
        private FloatingMMXPanel floatingPanel;
        private ContentData content;
        private int frameCountdown = 50;
        private int updateCountdown = 5;

        public void Start()
        {   
            log = new ModLog("JoystickDisplay");
            DontDestroyOnLoad(this);
        }

        public void Update()
        {
            if (View.Instance != null && frameCountdown > 0)
            {
                frameCountdown--;
                if (frameCountdown == 0)
                {
                    log.Log("Showing joystick window");
                    BuildUI();
                    floatingPanel = FloatingMMXPanel.Create().SetContents("Joystick Display", content);
                }
            }
            if (floatingPanel != null && updateCountdown > 0)
            {
                updateCountdown--;
                if (updateCountdown == 0)
                {
                    updateCountdown = 5;
                    RebuildUI();
                }
            }

        }

        private void BuildUI()
        {
            if (content == null)
            {
                content = new ContentData();
            }
            content.Clear();
            content.Add(new VerticalLayout());
            content.Add(new HorizontalLayout());
            content.AddMany(new Label("Roll"), new ProgressBar(InputSettings.Axis_Roll.GetAxis, UpdateMoment.Update, 1, -1, false, "", "0.0"));
            content.Add(new EndLayout());
            content.Add(new HorizontalLayout());
            content.AddMany(new Label("Pitch"), new ProgressBar(InputSettings.Axis_Pitch.GetAxis, UpdateMoment.Update, 1, -1, false, "", "0.0"));
            content.Add(new EndLayout());
            content.Add(new HorizontalLayout());
            content.AddMany(new Label("Yaw"), new ProgressBar(InputSettings.Axis_Yaw.GetAxis, UpdateMoment.Update, 1, -1, false, "", "0.0"));
            content.Add(new EndLayout());
            content.Add(new HorizontalLayout());
            content.AddMany(new Label("Throttle"), new ProgressBar(InputSettings.Axis_Throttle.GetAxis, UpdateMoment.Update, 1, -1, false, "", "0.0"));
            content.Add(new EndLayout());
            content.Add(new EndLayout());
            content.OnNeedRebuild = RebuildUI;
        }

        private void RebuildUI()
        {
            floatingPanel.ClearContents();
            BuildUI();
            floatingPanel.SetContents("Joystick Display", content);
        }
    }
}
