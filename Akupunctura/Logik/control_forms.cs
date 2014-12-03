using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Akupunctura.Logik.Forms.Device;

namespace Akupunctura.Logik
{
  public class control_forms // Управление дочерними формами
  {
      private List<data_check> data_forms;
      private list_data lists = new list_data();
      private UInt16 Number;

      public void MainForms(Akupunctura mainForm, string Name_form)
      {
          Number = lists.new_issue();
          switch (Name_form)
          {
              case "Device01":
                  {
                      Device01 device01 = new Device01(mainForm, data_forms[Number]);
                      device01.MdiParent = mainForm;
                      device01.Show();
                  }
                  break;
          }
      }
  }
}
