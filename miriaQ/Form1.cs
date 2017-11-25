using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace miriaQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void importBT_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string strFileName = ofd.FileName;
                FileStream fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
                StreamReader read = new StreamReader(fs, Encoding.Default);
                string strReadline;
                int i = 0;
                this.dataGridView1.Rows.Clear();
                while ((strReadline = read.ReadLine()) != null)
                {
                    string[] strs = strReadline.Split('|');
                    if (strs.Length >= 2)
                    {
                        i = this.dataGridView1.Rows.Add();
                        this.dataGridView1.Rows[i].Cells[0].Value = strs[0];
                        this.dataGridView1.Rows[i].Cells[1].Value = strs[1];
                        if (Http.CheckPwdAndLogin(strs[0], strs[1]))
                        {
                            string req = Http.HttpGet("http://www.ulearning.cn/umooc/learner/userInfo.do?operation=studentChangeInfo", strs[0]);
                            var doc = new HtmlAgilityPack.HtmlDocument();
                            doc.LoadHtml(req);
                            var node = doc.DocumentNode.SelectNodes("//*/span[@id='cellPhone']").First();
                            if (node == null)
                            {
                                this.dataGridView1.Rows[i].Cells[3].Value = "";
                            }
                            else
                            {
                                this.dataGridView1.Rows[i].Cells[3].Value = node.InnerText;
                            }

                            node = doc.DocumentNode.SelectNodes("//*/input[@name='name']").First();
                            if (node == null)
                            {
                                this.dataGridView1.Rows[i].Cells[2].Value = "";
                            }
                            else
                            {
                                var attrs = node.Attributes;
                                foreach (var attr in attrs)
                                {
                                    if (attr.Name == "value")
                                    {
                                        this.dataGridView1.Rows[i].Cells[2].Value = attr.Value;
                                    }
                                }
                            }

                            node = doc.DocumentNode.SelectNodes("//*/div[@style='margin-left:20px;']").Last();
                            if (node == null)
                            {
                                this.dataGridView1.Rows[i].Cells[4].Value = "";
                            }
                            else
                            {
                                this.dataGridView1.Rows[i].Cells[4].Value = node.InnerText.Trim('\r').Trim('\n').Trim('\t').Trim('\n').Trim('\r');
                            }
                        }
                        else
                        {
                            this.dataGridView1.Rows[i].Cells[2].Value = "用户名密码错误";
                        }
                    }
                }

                fs.Close();
                read.Close();
            }
        }

        private void queryBT_Click(object sender, EventArgs e)
        {
            string course = "";

            if (this.selectCB.Text == null || this.selectCB.Text == "")
            {
                this.warningLB.Visible = true;
                return;
            }
            else
            {
                course = this.selectCB.Text;
            }
            this.warningLB.Visible = false;

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                string postdata = "operation=catalog&lang=zh&catalogID=0&year=0";
                string req = Http.HttpPost("http://www.ulearning.cn/umooc/learner/study.do?operation=catalog&lang=zh", postdata, row.Cells[0].Value.ToString());
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(req);

                var nodes = doc.DocumentNode.SelectNodes("//*/div[@class='course-detail left']");
                bool flag = true;
                foreach (var node in nodes)
                {
                    if (node.InnerText.Contains(course))
                    {
                        var x2 = node.SelectSingleNode("./div/div/span[@class='progress-pre left']").InnerText;
                        this.dataGridView1.Rows[row.Index].Cells[5].Value = x2;
                        var x4 = node.SelectSingleNode("./div[@class='info-block']").InnerText.Trim('\r').Trim('\n').Trim('\t');
                        if (x4.Contains("已过期"))
                        {
                            this.dataGridView1.Rows[row.Index].Cells[6].Value = "已过期";
                        }
                        else
                        {
                            this.dataGridView1.Rows[row.Index].Cells[6].Value = x4;
                        }
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    this.dataGridView1.Rows[row.Index].Cells[5].Value = "无课程";
                    this.dataGridView1.Rows[row.Index].Cells[6].Value = "";
                }
            }
            return;
        }

        private void exportBT_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "保存文件";
            saveFile.Filter = "Excel 文件(*.xlsx)|*.xlsx|All files(*.*)|*.*";
            saveFile.RestoreDirectory = true;
            saveFile.FilterIndex = 1;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string Savepath = saveFile.FileName;
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                object Nothing = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Add(Nothing);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = workBook.Sheets[1];
                worksheet.Name = "sheet1";
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                   foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            worksheet.Cells[row.Index + 1, cell.ColumnIndex + 1] = "'"+cell.Value.ToString();
                        }
                    }
                }
                worksheet.SaveAs(Savepath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
                workBook.Close(false, Type.Missing, Type.Missing);
                app.Quit();
            }
        }
    }
}
