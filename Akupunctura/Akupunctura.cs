using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Akupunctura.Logik;
///////////////////////////////////////////////////////////
using System.Windows;
using System.Threading;
using System.IO.Ports;
using System.IO;
using System.Runtime.InteropServices;
///////////////////////////////////////////////////////////
using Akupunctura.Logik.Forms.Device;
using Akupunctura.Logik.Forms.Рosition_folders;
using Akupunctura.Logik.Forms.Authorization;
using Akupunctura.Logik.Forms.patient_list;
using Akupunctura.Logik.Files;

namespace Akupunctura
{
  public partial class Akupunctura : Form
  {
    public control_forms BD = new control_forms(); //  набор данных для форм и функции для работы с ними (возможно прощай) + data_check (прощай)

    private string address = Environment.CurrentDirectory + @"\БД"; // По началу там где лежит exe (Адрес папки)

    private List<DateTime> ID_DOC = new List<DateTime>(); // id Докторов
    private int i_id_doc = -1;
    private List<DateTime> ID_PAT = new List<DateTime>(); // id Пациентов
    private int i_id_pat = -1;

    public Akupunctura()
    {  
      InitializeComponent();
    }

    private void МенюРаботыПрибораToolStripMenuItem_Click(object sender, EventArgs e)
    {
        form_Device01();
    }
    /********************************************************************************************/


    /********************************************************************************************/
    public List<DateTime> add_rows(string str) // Создание не совпадающего списка id 
    {
      DateTime id;
      List<DateTime> many_id = new List<DateTime>();
      for (int i = Directory.GetFiles(str, "*.txt").Length; i != 0; i--)
      {
        if (DateTime.TryParse(Path.GetFileNameWithoutExtension(Directory.GetFiles(str, "*.txt")[i - 1]).Replace(';', ':'), out id))
          many_id.Add(id.ToUniversalTime());
      }
      return many_id;
    }
    /********************************************************************************************/
    public void form_Device01() // Запуск работы с прибором
    {
      doctor local_doctor = new doctor();

      if (( -1 < i_id_doc ) && ( i_id_doc < ID_DOC.Count ))
        local_doctor.read_disk(out local_doctor, ID_DOC[i_id_doc], address);
      /*
       * 2 аргумента
       * входные данные - то с чем дают (могут и не дать)
       * выходные - то что с чем работают (то что есть)
       * проверка выдаёт праду когда данные корекны
       * а если ложь то нужно запросить данные
       */
      if (check_Position() && check_Doctor(local_doctor) && check_Patient()) ;
            //Number = numbering(Parent);
            /*
            Device01 device01 = new Device01(Parent, data_forms[Number - 1]);
            device01.MdiParent = Parent;
            device01.Show();
            * */
    }
    public void form_Position() // Запуск выбора бызы
    {
      Position position = new Position(this);
      position.MdiParent = this;
      position.Show();
    }
    public void fofm_Doctor(doctor local_doctor) // Запуск окна выбора врача
    {
      Authorization authorization = new Authorization(local_doctor, this);
      authorization.MdiParent = this;
      authorization.Show();
    }
    public void fofm_Patient() // Запуск окна выбора пациента
    {
      /*
      //Number = numbering(Parent);
      Patient_list patient_list = new Patient_list(Parent, data_forms[Number - 1]);
      patient_list.MdiParent = Parent;
      patient_list.Show();
       */
    }
    /***************************************************************************************
    public void get_Parent(Akupunctura mainForm) // Получение родителя
    {
      //this.Parent = mainForm;
    }
    /****************************************************************************************/
    private bool check_Position() // Проверка наличия базы
    {
      if (!Directory.GetDirectories(address.Replace(@"\БД", "")).Contains(address))
      {
        form_Position();
        return false;
      }
      else
      {
        ID_DOC.Clear();
        ID_DOC = add_rows(address + new doctor().get_folder(address));
        return true;
      }
    }
    private bool check_Doctor(doctor local_doctor) // Проверка наличия врача
    {
      if (local_doctor.read_fio().Count() == 0)
      {
        fofm_Doctor( local_doctor);
        return false;
      }
      return true;
    }
    private bool check_Patient() // Проверка наличия пациента
    {
      /*
      if (local_patient.read_fio().Count == 0)
      {
        fofm_Patient();
        return false;
      }
       * */
      return true;
    }
    /********************************************************************************************/
    public void Addres(string address) // Получение адреса
    {
      this.address = address;
    }
    public string get_Addres() // Отдача адреса
    {
      return address;
    }
    /********************************************************************************************/
  }
}
