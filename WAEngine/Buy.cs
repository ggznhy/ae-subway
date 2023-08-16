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
    class Buy
    {
        //GetSet与获取主窗体控件名称变量
        Label lbl_rw;
        public Label Lbl_rw
        {
            get { return lbl_rw; }
            set { lbl_rw = value; }
        }
        Label lbl_yw;
        public Label Lbl_yw
        {
            get { return lbl_yw; }
            set { lbl_yw = value; }
        }
        Label lbl_yz;
        public Label Lbl_yz
        {
            get { return lbl_yz; }
            set { lbl_yz = value; }
        }
        Label lbl_wz;
        public Label Lbl_wz
        {
            get { return lbl_wz; }
            set { lbl_wz = value; }
        }

        ComboBox cbo_type;
        public ComboBox Cbo_type
        {
            get { return cbo_type; }
            set { cbo_type = value; }
        }
        //展示
        public void show()
        {
            //编写数据库连接串
            string connStr = "Data Source=.;Initial Catalog=railway;User ID=sa;Password=20001217";
            //创建SQLConnection的实例
            SqlConnection conn = null;
            try
            {
                //打开数据库连接
                conn = new SqlConnection(connStr);
                conn.Open();
                string[] tt = { "RW25G", "YW25G", "YZ25G" };
                double[] pp = { 0, 0, 0 };
                Label[] ll = { Lbl_rw, Lbl_yw, Lbl_yz };
                for (int i = 0; i < tt.Length; i++)
                {
                    string sql = "SELECT SUM(REMAINING_SEAT) FROM train WHERE CODE = '{0}'";
                    //填充SQL语句
                    sql = string.Format(sql, tt[i]);
                    //创建SqlCommand对象
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        pp[i] += Convert.ToInt32(r[0]);
                        ll[i].Text = pp[i].ToString() + "张";
                    }
                    r.Close();
                }
                if (pp[2] >= 1)
                {
                    Lbl_wz.Text = "无";
                }
                if (pp[2] == 0)
                {
                    Lbl_wz.Text = "有";
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
        //模拟购买
        public void buy()
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
                        tmp += "RW25G";
                        zhongwen += "软卧";
                        break;
                    case 1:
                        tmp += "YW25G";
                        zhongwen += "硬卧";
                        break;
                    case 2:
                        tmp += "YZ25G";
                        zhongwen += "硬座";
                        break;
                    case 3:
                        MessageBox.Show("您购买的是无座票");
                        return;
                    default:
                        MessageBox.Show("您购买的是无座票");
                        return;
                }
                //打开数据库连接
                conn = new SqlConnection(connStr);
                conn.Open();
                Label[] ll = { Lbl_rw, Lbl_yw, Lbl_yz };
                string sql = "UPDATE train SET REMAINING_SEAT = REMAINING_SEAT - 1 WHERE CODE = '{0}'";
                //填充SQL语句
                sql = string.Format(sql, tmp);
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                int enq = cmd.ExecuteNonQuery();
                if (enq != 0)
                {
                    MessageBox.Show("您购买的是" + zhongwen + "票");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("购买失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
            show();
        }
    }
}
