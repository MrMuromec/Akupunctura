using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Akupunctura.Logik;

using System.Windows;
using System.Threading;
using System.IO.Ports;
using System.IO;
using System.Runtime.InteropServices;

namespace Akupunctura
{
  public partial class Akupunctura : Form
  {
    // http://rsdn.ru/article/dotnet/CSThreading2.xml

    private string address = Environment.CurrentDirectory + @"\БД"; // По началу там где лежит exe (Адрес папки)
    private List<DateTime> ID_DOC = new List<DateTime>(); // id Докторов
    public control_forms BD = new control_forms(); //  набор данных для форм и функции для работы с ними (возможно прощай)

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
      /*
       * 2 аргумента
       * входные данные - то с чем дают (могут и не дать)
       * выходные - то что с чем работают (то что есть)
       * проверка выдаёт праду когда данные корекны
       * а если ложь то нужно запросить данные
       */
      while (!check_Position() && !check_Doctor() && !check_Patient()) ;
     /*
      if (check_Position() && check_Doctor() && check_Patient())
      {
        //Number = numbering(Parent);
        Device01 device01 = new Device01(Parent, data_forms[Number - 1]);
        device01.MdiParent = Parent;
        device01.Show();
      }
    */
    }
    public void form_Position() // Запуск выбора бызы
    {
      /*
      Position position = new Position(Parent.BD);
      position.MdiParent = Parent;
      position.Show();
       * */
    }
    public void fofm_Doctor() // Запуск окна выбора врача
    {
      /*
      //Number = numbering(Parent);
      Authorization authorization = new Authorization(data_forms[Number - 1]);
      authorization.MdiParent = Parent;
      authorization.Show();
       * */
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
    /****************************************************************************************/
    public void get_Parent(Akupunctura mainForm) // Получение родителя
    {
      this.Parent = mainForm;
    }
    /****************************************************************************************/
    private bool check_Position() // Проверка наличия базы
    {
      if (!Directory.GetDirectories(address.Replace(@"\БД", "")).Contains(address))
      {
        form_Position();
        return false;
      }
      return true;
    }
    private bool check_Doctor() // Проверка наличия врача
    {
      /*
      if (local_doctor.read_fio().Count() == 0)
      {
        fofm_Doctor();
        return false;
      }
       * */
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
