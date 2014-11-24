using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Akupunctura.Logik.Commands_for_files;

namespace Akupunctura.Logik
{
  public class control_database // Управление базой
  {
    public control_of_doctors Doc = new control_of_doctors(); // Инициализация управления записями врачей (сами записи в нутри)
    public control_of_measurement Measu = new control_of_measurement(); // Инициализация управления записями измерений (сами записи в нутри)
    public control_of_patients Patient = new control_of_patients(); // Инициализация управления записями пациентов (сами записи в нутри)

  }
}
