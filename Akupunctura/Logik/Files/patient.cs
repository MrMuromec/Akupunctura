﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Akupunctura.Logik.Files
{
  [Serializable]
  public class patient
  {
      private DateTime id_patient;// Дата создания записи
      private DateTime data_patient; // Дата рождения 
      private List<string> FIO = new List<string>();

      public void clean() // Чистка
      {
          FIO.Clear();
          // А вот с датой хз
      }
      public List<string> read_fio() // Чтение
      {
          return FIO;
      }
      public DateTime read_id() // Чтение
      {
          return id_patient;
      }
      public DateTime read_data() // Чтение
      {
          return data_patient;
      }
      public bool save(string fio, DateTime T, DateTime t_data) // Запись
      {
          List<string> str = new List<string>(fio.Split(' '));
          if (str.Count != 0) FIO = str;
          else return false;
          id_patient = T;
          data_patient = t_data;
          return true;
      }
  }
}
