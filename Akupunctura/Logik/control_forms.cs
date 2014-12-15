using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Akupunctura.Logik.Forms.Device;
using Akupunctura.Logik.Files;

namespace Akupunctura.Logik
{
  public class control_forms // Управление дочерними формами
  {
      private commands command = new commands();
      private List<data_check> data_forms = new List<data_check>(); // Список управления данных
      private byte Number;      

      public bool MainForms(Akupunctura mainForm, string Name_form) // Вызов форми и выдача довольствия им же
      {
          Number = numbering(mainForm);  // Поиск позиций
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
                          break;
                      }
                  default: break; // ошибочное название
                      
              }
              return true;
          }
      }
      private byte numbering(Akupunctura mainForm) // Поиск позиций
      {
          byte position = 0;
          byte Max_position = 0;
          for (byte i = 1; i <= data_forms.Count; i++)
              if (data_forms.FindIndex(delegate(data_check bk) { return bk.number_form == i; }) == -1) // Проверка занятости номеров
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
                  data_forms[data_forms.Count - 1].all_db(mainForm.BD); // Все данные получаю доступ к базе данных (data_check содержит control_forms)
              }
          }
          return position;
      }
  }
}
