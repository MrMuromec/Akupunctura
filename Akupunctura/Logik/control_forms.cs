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
          Number = numbering();
          if (Number == 0) return false;
          else
          {
              data_forms[Number - 1].number_form = Number; // запись текущего номера
              switch (Name_form)
              {
                  case "Device01":
                      {
                          Device01 device01 = new Device01(mainForm, data_forms[Number - 1]);
                          device01.MdiParent = mainForm;
                          device01.Show();
                      }
                      break;
              }
              return true;
          }
      }
      private byte numbering() // Поиск позиций
      {
          byte position = 0;
          byte Max_position = 0;
          for (byte i = 1; i <= data_forms.Count; i++)
              if (data_forms.FindLastIndex(delegate(data_check bk) { return bk.number_form == i; }) == -1) // Проверка занятости номеров
              {
                  position = i; // Записываем свободный
                  break;
              }
              else
              {
                  if (i > Max_position) Max_position = i; // Ищем максимальный номер
              }
          if (position == 0)
          {
              if (Max_position == byte.MaxValue) // 1..255 , а если больше то 0 в качестве ошибки
                  return 0;
              else
              {
                  position = (byte)(Max_position + 1);
                  data_forms.Add(new data_check());
              }
          }
          return position;
      }
  }
}
