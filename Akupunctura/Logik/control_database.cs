using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Akupunctura.Logik.Files;
using Akupunctura.Logik.Forms.Device;

namespace Akupunctura.Logik
{
  public class control_database // Управление базой
  {
      private patient local_patient = new patient();
      private doctor local_doctor = new doctor();
      private measurement local_measument = new measurement();
      public void MainForms(Akupunctura mainForm, string Name_form)
      {
          switch (Name_form)
          {
              case "Device01":
                  {
                      Device_01 device01 = new Device_01(mainForm);
                      device01.MdiParent = mainForm;
                      device01.Show();
                  }
                  break;
          }
      }
  }
}
