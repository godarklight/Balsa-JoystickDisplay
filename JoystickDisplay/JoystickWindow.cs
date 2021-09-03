using System;
using Tutorials;
using UI.MMX.Data;
using UnityEngine;
using DarkLog;

namespace JoystickDisplay
{
    class DebugTutorialWindow : TutorialFSM
    {
        private TutorialPage page1;
		private ModLog log;
        private bool enableUpdate = true;

        public DebugTutorialWindow(ModLog log)
        {
			this.log = log;
			Page1();
		}

        private void Page1()
        {
            page1 = new TutorialPage("Debug Data")
            {
                GetPageContent = delegate(ContentData content)
                {
                    content.Add(new Label($"Joystick roll: {InputSettings.Axis_Roll.GetAxis()}"));
                    content.Add(new Label($"Joystick roll raw: {InputSettings.Axis_Roll.GetAxisRaw()}"));
                    content.Add(new Button("Close")
                    {
                        OnClicked = delegate
                        {
                            enableUpdate = false;
                            EndTutorial();
                        }
                    });
                }
            };
            AddPage(page1);
            SetInitialPage(page1);
        }

        public void UpdatePage()
        {
            if (enableUpdate)
            {
                page1._content.NeedRebuild();
            }
        }
    }
}
