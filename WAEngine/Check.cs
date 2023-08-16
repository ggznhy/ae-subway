using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesOleDB;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.GlobeCore;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.SystemUI;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace WAEngine
{
    class Check
    {
        ComboBox cbo_type;
        public ComboBox Cbo_type
        {
            get { return cbo_type; }
            set { cbo_type = value; }
        }
        TextBox txt_from;
        public TextBox Txt_from
        {
            get { return txt_from; }
            set { txt_from = value; }
        }
        TextBox txt_to;
        public TextBox Txt_to
        {
            get { return txt_to; }
            set { txt_to = value; }
        }

        public void fare()
        {
            //编写数据库连接串
            string connStr = "Data Source=.;Initial Catalog=railway;User ID=sa;Password=20001217";
            //创建SQLConnection的实例
            SqlConnection conn = null;
            try
            {
                int i = cbo_type.SelectedIndex;
                string tmp = "";
                string zhongwen = "";
                switch (i)
                {
                    case 0:
                        tmp += "SoftSleeper";
                        zhongwen += "软卧";
                        break;
                    case 1:
                        tmp += "HardSleeper";
                        zhongwen += "硬卧";
                        break;
                    case 2:
                        tmp += "HardSeat";
                        zhongwen += "硬座";
                        break;
                    case 3:
                        tmp += "NoSeat";
                        zhongwen += "无座";
                        break;
                    default:
                        tmp += "NoSeat";
                        zhongwen += "无座";
                        break;
                }

                conn = new SqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                string sql = "Select * from fare where RANGE = '{0}'" + "or" + " RANGE = '{1}'";
                //填充SQL语句
                sql = string.Format(sql, txt_from.Text, txt_to.Text);
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                //执行SQL语句
                SqlDataReader r = cmd.ExecuteReader();

                double a = 0;
                double b = 0;
                //判断SQL语句是否执行成功
                int Time = 0;
                while (r.Read())
                {
                    if (Time == 0)
                    {
                        a += Convert.ToDouble(r[tmp]);
                    }
                    if (Time == 1)
                    {
                        b += Convert.ToDouble(r[tmp]);
                    }
                    Time++;
                }
                if (Time == 2)
                {
                    MessageBox.Show("您购买的是从[" + txt_from.Text + "]到[" + txt_to.Text + "]的" + zhongwen + "车票\n"
                        + "费用为：" + (a - b).ToString() + "元");
                }
                else
                {
                    MessageBox.Show("输入有误！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }
    }
}
