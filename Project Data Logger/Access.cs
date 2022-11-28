using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Project_Data_Logger
{
    internal class Access
    {
        public bool AccessIdicator { get; set; }

        public Color AccessColor { get; set; }

        public Access(bool accessIdicator, TextBox textBox)
        {
            AccessIdicator = accessIdicator;

            AccessColor = GetAccessColor(accessIdicator);

            textBox.BackColor = AccessColor;
        }

        public Color GetAccessColor(bool accessBool)
        {
            Color accessColor = Color.White;

            if (accessBool == true)
            {
                accessColor = Color.Green;
            }
            else if (accessBool == false)
            {
                accessColor = Color.Red;
            }
            return accessColor;
        }
    }
}
