using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Akupunctura.Logik.Commands_for_files.Files; // Подключение образцов записей

namespace Akupunctura.Logik.Commands_for_files
{
  public class control_of_doctors
  {
    public List<doctor> doc = new List<doctor>(); // Инициализация записей врачей
    public List<rights_doctor> rig = new List<rights_doctor>(); // Инициализация записей прав врачей

  }
}
