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
    // public control_forms BD = new control_forms(); //  набор данных для форм и функции для работы с ними (возможно прощай) + data_check (прощай)

    private string address = Environment.CurrentDirectory + @"\БД"; // По началу там где лежит exe (Адрес папки)

    private List<DateTime> ID_DOC = new List<DateTime>(); // id Докторов (все)
    private List<DateTime> ID_PAT = new List<DateTime>(); // id Пациентов (все)
    private DateTime id_doc = DateTime.MinValue; // id доктора
    private DateTime id_pat = DateTime.MinValue; // id пациента

    public Akupunctura()
    {  
      InitializeComponent();
    }

    private void МенюРаботыПрибораToolStripMenuItem_Click(object sender, EventArgs e)
    {
        form_Device01();
    }
      /************************************************************************************** 
       * 
       * Дальше только работа с дочерними формами и базой
       * 
       **************************************************************************************/
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
        measurement local_mesement;
        if (check_Position() && check_Doctor(id_doc) && check_Patient(id_pat))
        {
            /*
            Device01 device01 = new Device01(,this);
            device01.MdiParent = this;
            device01.Show();  
             */
        }
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
    public void fofm_Doctor(doctor local_doctor ) // Запуск окна выбора врача
    {
      Authorization authorization = new Authorization(local_doctor, this);
      authorization.MdiParent = this;
      authorization.Show();
    }
    public void fofm_Patient(patient local_patient) // Запуск окна выбора пациента
    {
        Patient_list patient_list = new Patient_list(local_patient, this);
        patient_list.MdiParent = this;
        patient_list.Show();
    }
    /********************************************************************************************/
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
        ID_PAT.Clear();
        ID_PAT = add_rows(address + new patient().get_folder(address));
        return true;
      }
    }
    private bool check_Doctor(DateTime id) // Проверка наличия врача
    {
        doctor local_doctor = new doctor();
        if (ID_DOC.Contains(id))
            return true;
        else
            {
            fofm_Doctor( local_doctor );
            return false;
            }
    }
    private bool check_Patient(DateTime id) // Проверка наличия пациента
    {
        patient local_patient = new patient();
        if (ID_PAT.Contains(id))
            return true;
        else
        {
            fofm_Patient( local_patient );
            return false;
        }
    }
    /********************************************************************************************/
    public void id_d(DateTime id) // Выбранный докто
    {
        id_doc = id;
    }
    public void id_p(DateTime id) // Выбранный пациент
    {
        id_pat = id;
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
