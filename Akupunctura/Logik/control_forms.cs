﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Akupunctura.Logik.Forms.Device;
using Akupunctura.Logik.Forms.Рosition_folders;
using Akupunctura.Logik.Forms.Authorization;
using Akupunctura.Logik.Forms.patient_list;
using Akupunctura.Logik.Files;
using System.IO;

namespace Akupunctura.Logik
{
  public class control_forms // Управление дочерними формами
  {
     
      private List<data_check> data_forms = new List<data_check>(); // Список управления данных
      private byte Number;
      public doctor local_doctor = new doctor(); // Авторизованный доктор 
      public patient local_patient = new patient(); // Текущий пациент (нужен для измерений)
      public commands command = new commands(); // Команды
      public string address = Environment.CurrentDirectory + @"\БД"; // По началу там где лежит exe (Адрес папки с бд + @"\БД")
      
      public bool MainForms(Akupunctura mainForm, string Name_form) // Вызов форми и выдача довольствия им же
      {
          if (!Directory.GetDirectories(address.Replace(@"\БД", "")).Contains(address))
              Name_form = "Position"; // Если папка отсуттсвует, то принудительно запрашивается её положение
          else 
              if (local_doctor.read_fio().Count() == 0)
              Name_form = "Authorization"; // Если врач ещё не авторзовался, то принудительно запрашивается авторизация
          switch (Name_form)
          {
               case "Position":
               {
                   Position position = new Position(mainForm, mainForm.BD);
                   position.MdiParent = mainForm;
                   position.Show();
                   break;
               }
               case "Authorization":
               {
                   Authorization authorization = new Authorization(mainForm, mainForm.BD);
                   authorization.MdiParent = mainForm;
                   authorization.Show();
                   break;
               }
               default:
               {
                   if (local_patient.read_fio().Count == 0)
                       Name_form = "Patient_list";
                   switch (Name_form)
                   {
                       case "Device01":
                           {
                               if ((Number = numbering(mainForm)) == 0) return false;  // Поиск позиций
                               Device01 device01 = new Device01(mainForm, data_forms[Number - 1]);
                               device01.MdiParent = mainForm;
                               device01.Show();
                               break;
                           }
                       case "Patient_list":
                           {
                               if ((Number = numbering(mainForm)) == 0) return false;  // Поиск позиций
                               Patient_list patient_list = new Patient_list(mainForm, data_forms[Number - 1]);
                               patient_list.MdiParent = mainForm;
                               patient_list.Show();
                               break;
                           }
                       default:
                           {
                               break;
                           }
                   }
                   break;
               }
                                   
          }              
          return true;
      }
      private byte numbering(Akupunctura mainForm) // Поиск позиций
      {
          byte position = 0;
          byte Max_position = 0;
          for (byte i = 1; i <= data_forms.Count; i++)
              if (data_forms[i-1].Free) // Проверка занятости номеров
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
              if (Max_position == byte.MaxValue) // 1..255 , а если равно 255 то 0 в качестве ошибки
                  return 0;
              else
              {
                  position = (byte)(Max_position + 1);
                  data_forms.Add(new data_check());
                  data_forms[data_forms.Count - 1].all_db(mainForm.BD); // Все данные получаю доступ к базе данных (data_check содержит control_forms)
              }
          }
          data_forms[position - 1].local_doctor.clean(); // Очистка
          data_forms[position - 1].local_mesument.clean(); // Очистка
          data_forms[position - 1].local_patient.clean(); // Очистка
          data_forms[position - 1].Free = false; // Занимаем данные под форму
          data_forms[position - 1].local_doctor.save(local_doctor.read_fio(),local_doctor.read_id()); // Запись авторизовавшегося доктора по умолчанию
          return position;
      }
  }
}
