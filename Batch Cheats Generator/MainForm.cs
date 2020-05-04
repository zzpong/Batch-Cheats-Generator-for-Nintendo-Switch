using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Batch_Cheats_Generator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // 初始化变量，在程序新加载文件后并不重新初始化，与加载文件后的初始化不同。

            comboBoxMemoryType.SelectedIndex = 0;
            comboBoxCodeFormat.SelectedIndex = 0;

            BytesMain.SelectedIndex = 0;
            Bytes1.SelectedIndex = 0;
            Bytes2.SelectedIndex = 0;
            Bytes3.SelectedIndex = 0;
            Bytes4.SelectedIndex = 0;
            Bytes5.SelectedIndex = 0;

            Description.Text = "Type Cheats Description Here";
            Description.ForeColor = Color.LightGray;
            Description.Enter += new EventHandler(Description_Enter);  //失去焦点后发生事件
            Description.Leave += new EventHandler(Description_Leave);   //获取焦点前发生事件
            //Description.MouseClick += new MouseEventHandler(Description_MouseClick);  // 鼠标点击事件

            BaseAddress.Text = "{MAIN+0274EFDB}+{Next:1F}";
            BaseAddress.ForeColor = Color.LightGray;
            BaseAddress.Enter += new EventHandler(BaseAddress_Enter);  //失去焦点后发生事件
            BaseAddress.Leave += new EventHandler(BaseAddress_Leave);  //获取焦点前发生事件

            comboBoxMemoryType.SelectedIndexChanged += new EventHandler(comboBoxMemoryType_SelectedIndexChanged);
            comboBoxCodeFormat.SelectedIndexChanged += new EventHandler(comboBoxCodeFormat_SelectedIndexChanged);

            checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
            checkBox2.CheckedChanged += new EventHandler(checkBox2_CheckedChanged);
            checkBox3.CheckedChanged += new EventHandler(checkBox3_CheckedChanged);
            checkBox4.CheckedChanged += new EventHandler(checkBox4_CheckedChanged);
            checkBox5.CheckedChanged += new EventHandler(checkBox5_CheckedChanged);

            OffsetAdd1.Text = "Base Offset:0D";
            OffsetAdd1.ForeColor = Color.LightGray;
            OffsetAdd1.Enter += new EventHandler(OffsetAdd1_Enter);  //失去焦点后发生事件
            OffsetAdd1.Leave += new EventHandler(OffsetAdd1_Leave);  //获取焦点前发生事件

            Value1.Text = "3D";
            Value1.ForeColor = Color.LightGray;
            Value1.Enter += new EventHandler(Value1_Enter);  //失去焦点后发生事件
            Value1.Leave += new EventHandler(Value1_Leave);  //获取焦点前发生事件

            Export.Enabled = false;
        }

        public static bool bomFlag = false;
        public static bool DescriptionHasText = false;
        public static bool BaseAddressHasText = false;
        public static bool HEAP = false;
        public static bool Pointer = false;

        public static bool hasFile = false;

        public static bool correctFormat = true;

        public static bool checker1 = false;
        public static bool checker2 = false;
        public static bool checker3 = false;
        public static bool checker4 = false;
        public static bool checker5 = false;

        public static bool OffsetAdd1HasText = false;
        public static bool Value1HasText = false;

        public static ArrayList outputList = new ArrayList();

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Data Base File (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Filter = "Data Base File (*.csv)|*.csv|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataFileBox.Text = openFileDialog.FileName;
                ProcessFile();
                //ActiveControl = Description;
                //Description.Focus();
            }
        }

        private void ProcessFile()
        {
            // Code needs refactoring 在这儿初始化变量
            outputList.Clear();
            OutputBox.Text = "";
            Export.Enabled = false;
            hasFile = false;
            correctFormat = true;

            try
            {
                if (CheckFile())
                {
                    hasFile = true;
                    //CheatsGenerator();
                    //LoadNSP();
                }
                else
                {
                    DataFileBox.Text = null;
                    if (bomFlag == true) MessageBox.Show("File is empty or unsupported.");
                    else MessageBox.Show("Please save CSV as UTF-8 format.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString() + "\nFile is empty or unsupported.");
            }

        }

        //public bool CheckFile()
        //{
        //    FileInfo dataFile = new FileInfo(DataFileBox.Text);
        //    if (dataFile.Length == 0 || !DataFileBox.Text.Contains(".txt"))
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        public bool CheckFile()
        {
            FileStream fileStream = File.OpenRead(DataFileBox.Text);
            byte[] array = new byte[5];
            fileStream.Read(array, 0, 5);
            CSV.CSV_Headers[0] = new CSV.CSV_Header(array);
            if (CSV.CSV_Headers[0].Type == "EFBBBF" && !(CSV.CSV_Headers[0].EndMark == "0D0A"))
            {
                bomFlag = true;
                return true;
            }
            // else if (CSV.CSV_Headers[0].Type.Contains("0D0A")) return false;
            // else if (CSV.CSV_Headers[0].Type.Substring(0, 4) == "0D0A")  return false;

            return false;
        }

        //textbox获得焦点
        private void Description_Enter(object sender, EventArgs e)
        //private void Description_MouseDown(object sender, EventArgs e)
        {
            if (DescriptionHasText == false) Description.Text = "";
            Description.ForeColor = Color.Black;
        }

        //textbox失去焦点
        private void Description_Leave(object sender, EventArgs e)
        {
            if (Description.Text == "")
            {
                Description.Text = "Type Cheats Description Here";
                Description.ForeColor = Color.LightGray;
                DescriptionHasText = false;
            }
            else
                DescriptionHasText = true;
        }

        //textbox获得焦点
        private void BaseAddress_Enter(object sender, EventArgs e)
        {
            //if (BaseAddressHasText == false) BaseAddress.Text = "";
            BaseAddress.ForeColor = Color.Black;
        }

        //textbox失去焦点
        private void BaseAddress_Leave(object sender, EventArgs e)
        {
            if (BaseAddress.Text == "")
            {
                if (HEAP == false && Pointer == false)
                {
                    BaseAddress.Text = "{MAIN+0274EFDB}+{Next:1F}";
                    BaseAddress.ForeColor = Color.LightGray;
                    BaseAddressHasText = false;
                }
                else if (HEAP == false && Pointer == true)
                {
                    BaseAddress.Text = "{[[MAIN+0274EFDB]+3D]+3B}+{Next:1F}";
                    BaseAddress.ForeColor = Color.LightGray;
                    BaseAddressHasText = false;
                }
                else if (HEAP == true && Pointer == false)
                {
                    BaseAddress.Text = "{HEAP+0274EFDB}+{Next:1F}";
                    BaseAddress.ForeColor = Color.LightGray;
                    BaseAddressHasText = false;
                }
                else if (HEAP == true && Pointer == true)
                {
                    BaseAddress.Text = "Wrong Code Format Selection";
                    BaseAddress.ForeColor = Color.LightGray;
                    BaseAddressHasText = false;
                }
            }
            else
                BaseAddressHasText = true;
        }

        //textbox获得焦点
        private void OffsetAdd1_Enter(object sender, EventArgs e)
        {
            //if (OffsetAdd1HasText == false) OffsetAdd1.Text = "";
            OffsetAdd1.ForeColor = Color.Black;
        }

        //textbox失去焦点
        private void OffsetAdd1_Leave(object sender, EventArgs e)
        {
            if (OffsetAdd1.Text == "")
            {
                OffsetAdd1.Text = "Base Offset:0D";
                OffsetAdd1.ForeColor = Color.LightGray;
                OffsetAdd1HasText = false;
            }
            else
                OffsetAdd1HasText = true;
        }

        //textbox获得焦点
        private void Value1_Enter(object sender, EventArgs e)
        {
            //if (Value1HasText == false) Value1.Text = "";
            Value1.ForeColor = Color.Black;
        }

        //textbox失去焦点
        private void Value1_Leave(object sender, EventArgs e)
        {
            if (Value1.Text == "")
            {
                Value1.Text = "3D";
                Value1.ForeColor = Color.LightGray;
                Value1HasText = false;
            }
            else
                Value1HasText = true;
        }

        private void comboBoxMemoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            HEAP = !HEAP;  // 该函数并不是切换不同内容才会触发，而是只要切换就会触发，比如HEAP切HEAP。

            if (comboBoxMemoryType.SelectedItem.ToString() == "MAIN") HEAP = false;
            else HEAP = true;

            if (HEAP == false && Pointer == false)
            {
                BaseAddress.Text = "{MAIN+0274EFDB}+{Next:1F}";
                BaseAddress.ForeColor = Color.LightGray;
                BaseAddressHasText = false;
                BaseAddress.Enabled = true;
            }
            else if (HEAP == false && Pointer == true)
            {
                BaseAddress.Text = "{[[MAIN+0274EFDB]+3D]+3B}+{Next:1F}";
                BaseAddress.ForeColor = Color.LightGray;
                BaseAddressHasText = false;
                BaseAddress.Enabled = true;
            }
            else if (HEAP == true && Pointer == false)
            {
                BaseAddress.Text = "{HEAP+0274EFDB}+{Next:1F}";
                BaseAddress.ForeColor = Color.LightGray;
                BaseAddressHasText = false;
                BaseAddress.Enabled = true;
            }
            else if (HEAP == true && Pointer == true)
            {
                BaseAddress.Text = "Wrong Code Format Selection";
                BaseAddress.ForeColor = Color.LightGray;
                BaseAddressHasText = false;
                BaseAddress.Enabled = false;
            }

        }

        private void comboBoxCodeFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pointer = !Pointer;  // 该函数并不是切换不同内容才会触发，而是只要切换就会触发，比如HEAP切HEAP。

            if (comboBoxCodeFormat.SelectedItem.ToString() == "Static") Pointer = false;
            else Pointer = true;

            if (HEAP == false && Pointer == false)
            {
                BaseAddress.Text = "{MAIN+0274EFDB}+{Next:1F}";
                BaseAddress.ForeColor = Color.LightGray;
                BaseAddressHasText = false;
                BaseAddress.Enabled = true;
            }
            else if (HEAP == false && Pointer == true)
            {
                BaseAddress.Text = "{[[MAIN+0274EFDB]+3D]+3B}+{Next:1F}";
                BaseAddress.ForeColor = Color.LightGray;
                BaseAddressHasText = false;
                BaseAddress.Enabled = true;
            }
            else if (HEAP == true && Pointer == false)
            {
                BaseAddress.Text = "{HEAP+0274EFDB}+{Next:1F}";
                BaseAddress.ForeColor = Color.LightGray;
                BaseAddressHasText = false;
                BaseAddress.Enabled = true;
            }
            else if (HEAP == true && Pointer == true)
            {
                BaseAddress.Text = "Wrong Code Format Selection";
                BaseAddress.ForeColor = Color.LightGray;
                BaseAddressHasText = false;
                BaseAddress.Enabled = false;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checker1 = !checker1;
            if (checker1 == true)
            {
                OffsetAdd1.Enabled = true;
                Value1.Enabled = true;
                Bytes1.Enabled = true;
            }
            else
            {
                OffsetAdd1.Enabled = false;
                Value1.Enabled = false;
                Bytes1.Enabled = false;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checker2 = !checker2;
            if (checker2 == true)
            {
                OffsetAdd2.Enabled = true;
                Value2.Enabled = true;
                Bytes2.Enabled = true;
            }
            else
            {
                OffsetAdd2.Enabled = false;
                Value2.Enabled = false;
                Bytes2.Enabled = false;
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checker3 = !checker3;
            if (checker3 == true)
            {
                OffsetAdd3.Enabled = true;
                Value3.Enabled = true;
                Bytes3.Enabled = true;
            }
            else
            {
                OffsetAdd3.Enabled = false;
                Value3.Enabled = false;
                Bytes3.Enabled = false;
            }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checker4 = !checker4;
            if (checker4 == true)
            {
                OffsetAdd4.Enabled = true;
                Value4.Enabled = true;
                Bytes4.Enabled = true;
            }
            else
            {
                OffsetAdd4.Enabled = false;
                Value4.Enabled = false;
                Bytes4.Enabled = false;
            }
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            checker5 = !checker5;
            if (checker5 == true)
            {
                OffsetAdd5.Enabled = true;
                Value5.Enabled = true;
                Bytes5.Enabled = true;
            }
            else
            {
                OffsetAdd5.Enabled = false;
                Value5.Enabled = false;
                Bytes5.Enabled = false;
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            //btn.BringToFront();  // 将控件放置所有控件最顶层  
            //btn.SendToBack();  // 将控件放置所有控件最底层
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Generate_Click(object sender, EventArgs e)
        {
            OutputBox.Text = "";

            // 把主函数塞这儿就不用考虑大量的参数传递，因此没有放在ProcessFile()。在准备充足前禁用Generate按钮。
            if (BaseAddressHasText == true && hasFile == true)
            {
                FileStream fs = new FileStream(DataFileBox.Text, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, Encoding.UTF8);
                string strLine = "";

                string[] id = new string[50000];
                string[] title = new string[50000];
                string[] pointcache = new string[500];

                string cheats = "";

                int baseAddress = 0;
                int nextItemAddress = 0;
                int endAddress = 0;
                string[] offset = new string[50];

                int count = 0;

                int[] offsetAddress = new int[5];
                string[] value = new string[5];

                while ((strLine = sr.ReadLine()) != null)
                {
                    if (strLine.Contains(','))
                    {
                        id[count] = strLine.Split(',')[0];
                        title[count] = strLine.Split(',')[1];
                        count++;
                    }
                    else
                    {
                        id[count] = strLine;
                        count++;
                    }
                }

                sr.Close();
                fs.Close();

                try
                {
                    if (HEAP == false && Pointer == false)
                    {
                        baseAddress = Convert.ToInt32(BaseAddress.Text.Split('+', '}')[1], 16);
                        nextItemAddress = Convert.ToInt32(BaseAddress.Text.Split(':', '}')[2], 16);
                    }
                    else if (HEAP == false && Pointer == true)
                    {
                        pointcache = BaseAddress.Text.Split('+', '}', ']');

                        for (int i = 0; i < pointcache.Length; i++)
                        {
                            if (pointcache[2 * i + 5].Contains("{Next:1F"))
                            {
                                endAddress = Convert.ToInt32(pointcache[2 * i + 3], 16);
                                break;
                            }
                            offset[i] = pointcache[2 * i + 3];
                        }

                        baseAddress = Convert.ToInt32(pointcache[1], 16);
                        nextItemAddress = Convert.ToInt32(BaseAddress.Text.Split(':', '}')[2], 16);

                    }
                    else if (HEAP == true && Pointer == false)
                    {
                        baseAddress = Convert.ToInt32(BaseAddress.Text.Split('+', '}')[1], 16);
                        nextItemAddress = Convert.ToInt32(BaseAddress.Text.Split(':', '}')[2], 16);
                    }
                    correctFormat = true;
                }
                catch
                {
                    MessageBox.Show("Wrong Base Address Format.");
                    correctFormat = false;
                }

                try
                {
                    if ((checkBox1.Checked == true) && (OffsetAdd1HasText == true) && (Value1HasText == true))
                    {
                        offsetAddress[0] = Convert.ToInt32(OffsetAdd1.Text.Split(':')[1], 16);
                        value[0] = Value1.Text.PadLeft(8, '0');
                    }
                    if ((checkBox2.Checked == true) && (OffsetAdd2.Text != "") && (Value2.Text != ""))
                    {
                        offsetAddress[1] = Convert.ToInt32(OffsetAdd2.Text.Split(':')[1], 16);
                        value[1] = Value2.Text.PadLeft(8, '0');
                    }
                    if ((checkBox3.Checked == true) && (OffsetAdd3.Text != "") && (Value3.Text != ""))
                    {
                        offsetAddress[2] = Convert.ToInt32(OffsetAdd3.Text.Split(':')[1], 16);
                        value[2] = Value3.Text.PadLeft(8, '0');
                    }
                    if ((checkBox4.Checked == true) && (OffsetAdd4.Text != "") && (Value4.Text != ""))
                    {
                        offsetAddress[3] = Convert.ToInt32(OffsetAdd4.Text.Split(':')[1], 16);
                        value[3] = Value4.Text.PadLeft(8, '0');
                    }
                    if ((checkBox5.Checked == true) && (OffsetAdd5.Text != "") && (Value5.Text != ""))
                    {
                        offsetAddress[4] = Convert.ToInt32(OffsetAdd5.Text.Split(':')[1], 16);
                        value[4] = Value5.Text.PadLeft(8, '0');
                    }
                }
                catch
                {
                    MessageBox.Show("Wrong Offset Address or Value Format.");
                    correctFormat = false;
                }

                if (correctFormat == true)
                {
                    OutputBox.Text = "";
                    outputList.Clear();
                    bool isFirstTime = true;

                    if (checkBox6.Checked == true)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            // Description
                            // if (DescriptionHasText == true && title.Any(x => string.IsNullOrEmpty(x)))
                            if (DescriptionHasText == true && title[0] != null)
                            {
                                outputList.Add("[" + Description.Text + " " + title[i] + "]");
                            }
                            else if (DescriptionHasText == false && title[0] != null)
                            {
                                outputList.Add("[" + title[i] + "]");
                            }
                            else if (DescriptionHasText == true && title[0] == null)
                            {
                                outputList.Add("[" + Description.Text + " " + Convert.ToString(i + 1, 10) + "]");
                            }
                            else
                            {
                                outputList.Add("[" + "No Description" + " " + Convert.ToString(i + 1, 10) + "]");
                            }

                            // Header Address
                            if (HEAP == false && Pointer == false)
                            {
                                cheats = "0" + BytesMain.SelectedItem.ToString() + "000000" + " " + Convert.ToString((baseAddress + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + id[i].ToUpper().PadLeft(8, '0') + Environment.NewLine;

                                if ((checkBox1.Checked == true) && (OffsetAdd1HasText == true) && (Value1HasText == true))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "000000" + " " + Convert.ToString((baseAddress + offsetAddress[0] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[0] + Environment.NewLine;
                                }
                                if ((checkBox2.Checked == true) && (OffsetAdd2.Text != "") && (Value2.Text != ""))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "000000" + " " + Convert.ToString((baseAddress + offsetAddress[1] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[1] + Environment.NewLine;
                                }
                                if ((checkBox3.Checked == true) && (OffsetAdd3.Text != "") && (Value3.Text != ""))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "000000" + " " + Convert.ToString((baseAddress + offsetAddress[2] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[2] + Environment.NewLine;
                                }
                                if ((checkBox4.Checked == true) && (OffsetAdd4.Text != "") && (Value4.Text != ""))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "000000" + " " + Convert.ToString((baseAddress + offsetAddress[3] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[3] + Environment.NewLine;
                                }
                                if ((checkBox5.Checked == true) && (OffsetAdd5.Text != "") && (Value5.Text != ""))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "000000" + " " + Convert.ToString((baseAddress + offsetAddress[4] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[4] + Environment.NewLine;
                                }

                            }
                            else if (HEAP == false && Pointer == true)
                            {
                                int k = 0;
                                cheats = "58000000" + " " + Convert.ToString((baseAddress), 16).ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                while (offset[k] != null)
                                {
                                    cheats = cheats + "58001000" + " " + offset[k].ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                    k++;
                                }
                                cheats = cheats + "78000000" + " " + Convert.ToString((endAddress + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                cheats = cheats + "6" + BytesMain.SelectedItem.ToString() + "000000" + " " + "00000000" + " " + id[i].ToUpper().PadLeft(8, '0') + Environment.NewLine;

                                if ((checkBox1.Checked == true) && (OffsetAdd1HasText == true) && (Value1HasText == true))
                                {
                                    cheats = cheats + "78000000" + " " + Convert.ToString((endAddress + offsetAddress[0] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                    cheats = cheats + "6" + BytesMain.SelectedItem.ToString() + "000000" + " " + "00000000" + " " + value[0] + Environment.NewLine;
                                }
                                if ((checkBox2.Checked == true) && (OffsetAdd2.Text != "") && (Value2.Text != ""))
                                {
                                    cheats = cheats + "78000000" + " " + Convert.ToString((endAddress + offsetAddress[1] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                    cheats = cheats + "6" + BytesMain.SelectedItem.ToString() + "000000" + " " + "00000000" + " " + value[1] + Environment.NewLine;
                                }
                                if ((checkBox3.Checked == true) && (OffsetAdd3.Text != "") && (Value3.Text != ""))
                                {
                                    cheats = cheats + "78000000" + " " + Convert.ToString((endAddress + offsetAddress[2] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                    cheats = cheats + "6" + BytesMain.SelectedItem.ToString() + "000000" + " " + "00000000" + " " + value[2] + Environment.NewLine;
                                }
                                if ((checkBox4.Checked == true) && (OffsetAdd4.Text != "") && (Value4.Text != ""))
                                {
                                    cheats = cheats + "78000000" + " " + Convert.ToString((endAddress + offsetAddress[3] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                    cheats = cheats + "6" + BytesMain.SelectedItem.ToString() + "000000" + " " + "00000000" + " " + value[3] + Environment.NewLine;
                                }
                                if ((checkBox5.Checked == true) && (OffsetAdd5.Text != "") && (Value5.Text != ""))
                                {
                                    cheats = cheats + "78000000" + " " + Convert.ToString((endAddress + offsetAddress[4] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                    cheats = cheats + "6" + BytesMain.SelectedItem.ToString() + "000000" + " " + "00000000" + " " + value[4] + Environment.NewLine;
                                }

                            }
                            else if (HEAP == true && Pointer == false)
                            {
                                cheats = "0" + BytesMain.SelectedItem.ToString() + "100000" + " " + Convert.ToString((baseAddress + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + id[i].ToUpper().PadLeft(8, '0') + Environment.NewLine;

                                if ((checkBox1.Checked == true) && (OffsetAdd1HasText == true) && (Value1HasText == true))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "100000" + " " + Convert.ToString((baseAddress + offsetAddress[0] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[0] + Environment.NewLine;
                                }
                                if ((checkBox2.Checked == true) && (OffsetAdd2.Text != "") && (Value2.Text != ""))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "100000" + " " + Convert.ToString((baseAddress + offsetAddress[1] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[1] + Environment.NewLine;
                                }
                                if ((checkBox3.Checked == true) && (OffsetAdd3.Text != "") && (Value3.Text != ""))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "100000" + " " + Convert.ToString((baseAddress + offsetAddress[2] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[2] + Environment.NewLine;
                                }
                                if ((checkBox4.Checked == true) && (OffsetAdd4.Text != "") && (Value4.Text != ""))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "100000" + " " + Convert.ToString((baseAddress + offsetAddress[3] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[3] + Environment.NewLine;
                                }
                                if ((checkBox5.Checked == true) && (OffsetAdd5.Text != "") && (Value5.Text != ""))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "100000" + " " + Convert.ToString((baseAddress + offsetAddress[4] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[4] + Environment.NewLine;
                                }

                            }

                            outputList.Add(cheats);
                            cheats = "";
                        }
                    }
                    else
                    {
                        if (DescriptionHasText == true)
                        {
                            outputList.Add("[" + Description.Text + "]");
                        }
                        else
                        {
                            outputList.Add("[" + "No Description" + "]");
                        }

                        for (int i = 0; i < count; i++)
                        {
                            // Header Address
                            if (HEAP == false && Pointer == false)
                            {
                                cheats = cheats + "0" + BytesMain.SelectedItem.ToString() + "000000" + " " + Convert.ToString((baseAddress + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + id[i].ToUpper().PadLeft(8, '0') + Environment.NewLine;

                                if ((checkBox1.Checked == true) && (OffsetAdd1HasText == true) && (Value1HasText == true))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "000000" + " " + Convert.ToString((baseAddress + offsetAddress[0] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[0] + Environment.NewLine;
                                }
                                if ((checkBox2.Checked == true) && (OffsetAdd2.Text != "") && (Value2.Text != ""))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "000000" + " " + Convert.ToString((baseAddress + offsetAddress[1] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[1] + Environment.NewLine;
                                }
                                if ((checkBox3.Checked == true) && (OffsetAdd3.Text != "") && (Value3.Text != ""))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "000000" + " " + Convert.ToString((baseAddress + offsetAddress[2] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[2] + Environment.NewLine;
                                }
                                if ((checkBox4.Checked == true) && (OffsetAdd4.Text != "") && (Value4.Text != ""))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "000000" + " " + Convert.ToString((baseAddress + offsetAddress[3] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[3] + Environment.NewLine;
                                }
                                if ((checkBox5.Checked == true) && (OffsetAdd5.Text != "") && (Value5.Text != ""))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "000000" + " " + Convert.ToString((baseAddress + offsetAddress[4] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[4] + Environment.NewLine;
                                }

                            }
                            else if (HEAP == false && Pointer == true)
                            {
                                if (isFirstTime == true)
                                {
                                    int k = 0;
                                    cheats = "58000000" + " " + Convert.ToString((baseAddress), 16).ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                    while (offset[k] != null)
                                    {
                                        cheats = cheats + "58001000" + " " + offset[k].ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                        k++;
                                    }
                                    cheats = cheats + "78000000" + " " + Convert.ToString((endAddress + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                    cheats = cheats + "64000000" + " " + "00000000" + " " + id[i].ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                    isFirstTime = false;
                                }
                                else
                                {
                                    cheats = cheats + "78000000" + " " + Convert.ToString((endAddress + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                    cheats = cheats + "6" + BytesMain.SelectedItem.ToString() + "000000" + " " + "00000000" + " " + id[i].ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                }

                                if ((checkBox1.Checked == true) && (OffsetAdd1HasText == true) && (Value1HasText == true))
                                {
                                    cheats = cheats + "78000000" + " " + Convert.ToString((endAddress + offsetAddress[0] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                    cheats = cheats + "6" + BytesMain.SelectedItem.ToString() + "000000" + " " + "00000000" + " " + value[0] + Environment.NewLine;
                                }
                                if ((checkBox2.Checked == true) && (OffsetAdd2.Text != "") && (Value2.Text != ""))
                                {
                                    cheats = cheats + "78000000" + " " + Convert.ToString((endAddress + offsetAddress[1] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                    cheats = cheats + "6" + BytesMain.SelectedItem.ToString() + "000000" + " " + "00000000" + " " + value[1] + Environment.NewLine;
                                }
                                if ((checkBox3.Checked == true) && (OffsetAdd3.Text != "") && (Value3.Text != ""))
                                {
                                    cheats = cheats + "78000000" + " " + Convert.ToString((endAddress + offsetAddress[2] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                    cheats = cheats + "6" + BytesMain.SelectedItem.ToString() + "000000" + " " + "00000000" + " " + value[2] + Environment.NewLine;
                                }
                                if ((checkBox4.Checked == true) && (OffsetAdd4.Text != "") && (Value4.Text != ""))
                                {
                                    cheats = cheats + "78000000" + " " + Convert.ToString((endAddress + offsetAddress[3] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                    cheats = cheats + "6" + BytesMain.SelectedItem.ToString() + "000000" + " " + "00000000" + " " + value[3] + Environment.NewLine;
                                }
                                if ((checkBox5.Checked == true) && (OffsetAdd5.Text != "") && (Value5.Text != ""))
                                {
                                    cheats = cheats + "78000000" + " " + Convert.ToString((endAddress + offsetAddress[4] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + Environment.NewLine;
                                    cheats = cheats + "6" + BytesMain.SelectedItem.ToString() + "000000" + " " + "00000000" + " " + value[4] + Environment.NewLine;
                                }

                            }
                            else if (HEAP == true && Pointer == false)
                            {
                                cheats = cheats + "0" + BytesMain.SelectedItem.ToString() + "100000" + " " + Convert.ToString((baseAddress + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + id[i].ToUpper().PadLeft(8, '0') + Environment.NewLine;

                                if ((checkBox1.Checked == true) && (OffsetAdd1HasText == true) && (Value1HasText == true))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "100000" + " " + Convert.ToString((baseAddress + offsetAddress[0] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[0] + Environment.NewLine;
                                }
                                if ((checkBox2.Checked == true) && (OffsetAdd2.Text != "") && (Value2.Text != ""))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "100000" + " " + Convert.ToString((baseAddress + offsetAddress[1] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[1] + Environment.NewLine;
                                }
                                if ((checkBox3.Checked == true) && (OffsetAdd3.Text != "") && (Value3.Text != ""))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "100000" + " " + Convert.ToString((baseAddress + offsetAddress[2] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[2] + Environment.NewLine;
                                }
                                if ((checkBox4.Checked == true) && (OffsetAdd4.Text != "") && (Value4.Text != ""))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "100000" + " " + Convert.ToString((baseAddress + offsetAddress[3] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[3] + Environment.NewLine;
                                }
                                if ((checkBox5.Checked == true) && (OffsetAdd5.Text != "") && (Value5.Text != ""))
                                {
                                    cheats = cheats + "0" + Bytes1.SelectedItem.ToString() + "100000" + " " + Convert.ToString((baseAddress + offsetAddress[4] + nextItemAddress * i), 16).ToUpper().PadLeft(8, '0') + " " + value[4] + Environment.NewLine;
                                }

                            }
                        }

                        outputList.Add(cheats);
                        cheats = "";
                    }

                    foreach (string j in outputList)  // 循环实现textBox2的赋值
                    {
                        OutputBox.Text += j.ToString() + Environment.NewLine;
                    }

                    Export.Enabled = true;

                }
            }
            else if (hasFile == false)
            {
                OutputBox.Text = "";
                OutputBox.Text = "Plaese Provide Data File First.";
            }
            else
            {
                OutputBox.Text = "";
                OutputBox.Text = "Plaese Provide Base Address Value First.";
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            string localFilePath = "";
            saveFileDialog.Filter = "Cheats (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                localFilePath = saveFileDialog.FileName.ToString();

                string[] arrString = (string[])outputList.ToArray(typeof(string));
                File.WriteAllLines(localFilePath, arrString);

                // string[] lines = { "First line", "Second line", "Third line"};
                // File.WriteAllLines(localFilePath, lines);

                // System.IO.FileStream fs = (FileStream)saveFileDialog.OpenFile();
                // fs.Write(Encoding.ASCII.GetBytes("Hello222"), 0, "Hello222".Length);
                // fs.Close();
            }
        }

        private void FreeForAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://github.com/zzpong/Batch-Cheats-Generator-for-Nintendo-Switch");   
        }
    }
}
