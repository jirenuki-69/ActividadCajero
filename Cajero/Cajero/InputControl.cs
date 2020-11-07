using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroClases
{
    public class InputControl
    {
        DisplayControl displayControl;

        public DisplayControl DisplayControl { get => displayControl; set => displayControl = value; }

        public InputControl()
        {
            DisplayControl = new DisplayControl();
        }

        public void GetPressedButton(string buttonText)
        {
            if (buttonText == "")
            {
                displayControl.DisplayMessage(buttonText);
                return;
            }

            displayControl.ChangeTxtDisplayState(buttonText);
        }
    }
}
