using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Akupunctura.Logik.Files
{
  public class measurement
  {
      private List<Int32> Currents = new List<Int32>();
      private List<Int32> Voltages = new List<Int32>();
      private string  id_doctor;
      private string id_patient;

      public void put_dimension(Int32 Current, Int32 Voltage)
      {
          Currents.Add(Current);
          Voltages.Add(Voltage);
      }
      public List<Int32> open_dimension (string str)
      {          
          switch (str)
          {
              case "currents":
                  {
                      return Currents;
                  }
              case "voltages":
                  {
                      return Voltages;
                  }
              default:
                  {
                      return new List<Int32>();
                  }
          }
      }
      public void save_mesurement_id(string id_d,string id_p)
      {
          id_doctor = id_d;
          id_patient = id_p;
      }
  }
}
