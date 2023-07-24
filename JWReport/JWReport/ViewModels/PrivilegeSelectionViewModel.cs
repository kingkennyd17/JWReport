using JWReport.PageModels.Base;
using JWReport.ViewModels.Buttons;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWReport.ViewModels
{
    public class PrivilegeSelectionViewModel : ExtendedBindableObject
    {
        public ButtonModel PrivilegeSelection { get; set; }

        public PrivilegeSelectionViewModel(ButtonModel privilegeSelection) 
        {
            PrivilegeSelection = new ButtonModel(privilegeSelection.Text, privilegeSelection.Command, privilegeSelection.Parameter);
        }

    }
}
