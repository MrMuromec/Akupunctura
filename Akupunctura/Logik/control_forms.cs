using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Akupunctura.Logik.Forms.Device;

namespace Akupunctura.Logik
{
  public class control_forms // Управление дочерними формами
  {
      private List<data_check> data_forms = new List<data_check>();
      private list_data lists = new list_data();
      private byte Number;

      public bool MainForms(Akupunctura mainForm, string Name_form) // Вызов форми и выдача довольствия им же
      {
          for (byte i = 1; i < data_forms.Count; i++)
              if (data_forms.FindLastIndex(delegate(data_check bk) { return bk.number_form == i; }) == -1)
                  lists.del_issue(i); // Проверка и удаление освободившихся адресов (нахождение свободных data_check)
          if (0 != (Number = lists.new_issue())) // Получение не нулевых свободных номеров (1..255) и нуля при переполнении
          {
            for (; data_forms.Count < Number; data_forms.Add(new data_check())) ; // В случае отсутсвия записи создание новой
            data_forms[Number - 1].number_form = Number; // запись текущего номера
            switch (Name_form)
            {
                case "Device01":
                {
                    Device01 device01 = new Device01(mainForm, data_forms[Number-1]);
                    device01.MdiParent = mainForm;
                    device01.Show();
                }
            break;
            }
            return true;
          }
          else
          {
            return false;
          }
      }
  }
}
